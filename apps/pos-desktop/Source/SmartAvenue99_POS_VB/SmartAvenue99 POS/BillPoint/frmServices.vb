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
Imports CrystalDecisions.[Shared]
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005D2 RID: 1490
	<DesignerGenerated()>
	Public Partial Class frmServices
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060122F1 RID: 74481 RVA: 0x00A75404 File Offset: 0x00A73604
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmServices_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmServices_KeyDown
			Me.ntid = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x170070F0 RID: 28912
		' (get) Token: 0x060122F4 RID: 74484 RVA: 0x0007CBC1 File Offset: 0x0007ADC1
		' (set) Token: 0x060122F5 RID: 74485 RVA: 0x0007CBCB File Offset: 0x0007ADCB
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170070F1 RID: 28913
		' (get) Token: 0x060122F6 RID: 74486 RVA: 0x0007CBD4 File Offset: 0x0007ADD4
		' (set) Token: 0x060122F7 RID: 74487 RVA: 0x0007CBDE File Offset: 0x0007ADDE
		Friend Overridable Property Label3 As Label

		' Token: 0x170070F2 RID: 28914
		' (get) Token: 0x060122F8 RID: 74488 RVA: 0x0007CBE7 File Offset: 0x0007ADE7
		' (set) Token: 0x060122F9 RID: 74489 RVA: 0x00A77CB0 File Offset: 0x00A75EB0
		Private _txtCustomerID As TextBox
		Friend Overridable Property txtCustomerID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtCustomerID = value
				textBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x170070F3 RID: 28915
		' (get) Token: 0x060122FA RID: 74490 RVA: 0x0007CBF1 File Offset: 0x0007ADF1
		' (set) Token: 0x060122FB RID: 74491 RVA: 0x0007CBFB File Offset: 0x0007ADFB
		Friend Overridable Property Panel3 As Panel

		' Token: 0x170070F4 RID: 28916
		' (get) Token: 0x060122FC RID: 74492 RVA: 0x0007CC04 File Offset: 0x0007AE04
		' (set) Token: 0x060122FD RID: 74493 RVA: 0x0007CC0E File Offset: 0x0007AE0E
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170070F5 RID: 28917
		' (get) Token: 0x060122FE RID: 74494 RVA: 0x0007CC17 File Offset: 0x0007AE17
		' (set) Token: 0x060122FF RID: 74495 RVA: 0x0007CC21 File Offset: 0x0007AE21
		Friend Overridable Property Label1 As Label

		' Token: 0x170070F6 RID: 28918
		' (get) Token: 0x06012300 RID: 74496 RVA: 0x0007CC2A File Offset: 0x0007AE2A
		' (set) Token: 0x06012301 RID: 74497 RVA: 0x0007CC34 File Offset: 0x0007AE34
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x170070F7 RID: 28919
		' (get) Token: 0x06012302 RID: 74498 RVA: 0x0007CC3D File Offset: 0x0007AE3D
		' (set) Token: 0x06012303 RID: 74499 RVA: 0x0007CC47 File Offset: 0x0007AE47
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x170070F8 RID: 28920
		' (get) Token: 0x06012304 RID: 74500 RVA: 0x0007CC50 File Offset: 0x0007AE50
		' (set) Token: 0x06012305 RID: 74501 RVA: 0x00A77CF4 File Offset: 0x00A75EF4
		Private _dtpServiceCreationDate As DateTimePicker
		Friend Overridable Property dtpServiceCreationDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpServiceCreationDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpServiceCreationDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpServiceCreationDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpServiceCreationDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpServiceCreationDate = value
				dateTimePicker = Me._dtpServiceCreationDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170070F9 RID: 28921
		' (get) Token: 0x06012306 RID: 74502 RVA: 0x0007CC5A File Offset: 0x0007AE5A
		' (set) Token: 0x06012307 RID: 74503 RVA: 0x0007CC64 File Offset: 0x0007AE64
		Friend Overridable Property txtServiceCode As TextBox

		' Token: 0x170070FA RID: 28922
		' (get) Token: 0x06012308 RID: 74504 RVA: 0x0007CC6D File Offset: 0x0007AE6D
		' (set) Token: 0x06012309 RID: 74505 RVA: 0x0007CC77 File Offset: 0x0007AE77
		Friend Overridable Property Label4 As Label

		' Token: 0x170070FB RID: 28923
		' (get) Token: 0x0601230A RID: 74506 RVA: 0x0007CC80 File Offset: 0x0007AE80
		' (set) Token: 0x0601230B RID: 74507 RVA: 0x0007CC8A File Offset: 0x0007AE8A
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170070FC RID: 28924
		' (get) Token: 0x0601230C RID: 74508 RVA: 0x0007CC93 File Offset: 0x0007AE93
		' (set) Token: 0x0601230D RID: 74509 RVA: 0x00A77D54 File Offset: 0x00A75F54
		Private _btnSelect As Button
		Friend Overridable Property btnSelect As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelect
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelect_Click
				Dim button As Button = Me._btnSelect
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSelect = value
				button = Me._btnSelect
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170070FD RID: 28925
		' (get) Token: 0x0601230E RID: 74510 RVA: 0x0007CC9D File Offset: 0x0007AE9D
		' (set) Token: 0x0601230F RID: 74511 RVA: 0x0007CCA7 File Offset: 0x0007AEA7
		Friend Overridable Property lblUserType As Label

		' Token: 0x170070FE RID: 28926
		' (get) Token: 0x06012310 RID: 74512 RVA: 0x0007CCB0 File Offset: 0x0007AEB0
		' (set) Token: 0x06012311 RID: 74513 RVA: 0x0007CCBA File Offset: 0x0007AEBA
		Friend Overridable Property lblUser As Label

		' Token: 0x170070FF RID: 28927
		' (get) Token: 0x06012312 RID: 74514 RVA: 0x0007CCC3 File Offset: 0x0007AEC3
		' (set) Token: 0x06012313 RID: 74515 RVA: 0x0007CCCD File Offset: 0x0007AECD
		Friend Overridable Property txtCID As TextBox

		' Token: 0x17007100 RID: 28928
		' (get) Token: 0x06012314 RID: 74516 RVA: 0x0007CCD6 File Offset: 0x0007AED6
		' (set) Token: 0x06012315 RID: 74517 RVA: 0x00A77D98 File Offset: 0x00A75F98
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

		' Token: 0x17007101 RID: 28929
		' (get) Token: 0x06012316 RID: 74518 RVA: 0x0007CCE0 File Offset: 0x0007AEE0
		' (set) Token: 0x06012317 RID: 74519 RVA: 0x0007CCEA File Offset: 0x0007AEEA
		Friend Overridable Property ToolTip1 As ToolTip

		' Token: 0x17007102 RID: 28930
		' (get) Token: 0x06012318 RID: 74520 RVA: 0x0007CCF3 File Offset: 0x0007AEF3
		' (set) Token: 0x06012319 RID: 74521 RVA: 0x0007CCFD File Offset: 0x0007AEFD
		Friend Overridable Property Label2 As Label

		' Token: 0x17007103 RID: 28931
		' (get) Token: 0x0601231A RID: 74522 RVA: 0x0007CD06 File Offset: 0x0007AF06
		' (set) Token: 0x0601231B RID: 74523 RVA: 0x0007CD10 File Offset: 0x0007AF10
		Friend Overridable Property txtID As TextBox

		' Token: 0x17007104 RID: 28932
		' (get) Token: 0x0601231C RID: 74524 RVA: 0x0007CD19 File Offset: 0x0007AF19
		' (set) Token: 0x0601231D RID: 74525 RVA: 0x00A77DDC File Offset: 0x00A75FDC
		Private _txtItemsDescription As TextBox
		Friend Overridable Property txtItemsDescription As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtItemsDescription
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtItemsDescription_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtItemsDescription
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtItemsDescription = value
				textBox = Me._txtItemsDescription
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007105 RID: 28933
		' (get) Token: 0x0601231E RID: 74526 RVA: 0x0007CD23 File Offset: 0x0007AF23
		' (set) Token: 0x0601231F RID: 74527 RVA: 0x0007CD2D File Offset: 0x0007AF2D
		Friend Overridable Property Label8 As Label

		' Token: 0x17007106 RID: 28934
		' (get) Token: 0x06012320 RID: 74528 RVA: 0x0007CD36 File Offset: 0x0007AF36
		' (set) Token: 0x06012321 RID: 74529 RVA: 0x0007CD40 File Offset: 0x0007AF40
		Friend Overridable Property Label13 As Label

		' Token: 0x17007107 RID: 28935
		' (get) Token: 0x06012322 RID: 74530 RVA: 0x0007CD49 File Offset: 0x0007AF49
		' (set) Token: 0x06012323 RID: 74531 RVA: 0x0007CD53 File Offset: 0x0007AF53
		Friend Overridable Property Label12 As Label

		' Token: 0x17007108 RID: 28936
		' (get) Token: 0x06012324 RID: 74532 RVA: 0x0007CD5C File Offset: 0x0007AF5C
		' (set) Token: 0x06012325 RID: 74533 RVA: 0x0007CD66 File Offset: 0x0007AF66
		Friend Overridable Property Label11 As Label

		' Token: 0x17007109 RID: 28937
		' (get) Token: 0x06012326 RID: 74534 RVA: 0x0007CD6F File Offset: 0x0007AF6F
		' (set) Token: 0x06012327 RID: 74535 RVA: 0x0007CD79 File Offset: 0x0007AF79
		Friend Overridable Property Label10 As Label

		' Token: 0x1700710A RID: 28938
		' (get) Token: 0x06012328 RID: 74536 RVA: 0x0007CD82 File Offset: 0x0007AF82
		' (set) Token: 0x06012329 RID: 74537 RVA: 0x0007CD8C File Offset: 0x0007AF8C
		Friend Overridable Property Label9 As Label

		' Token: 0x1700710B RID: 28939
		' (get) Token: 0x0601232A RID: 74538 RVA: 0x0007CD95 File Offset: 0x0007AF95
		' (set) Token: 0x0601232B RID: 74539 RVA: 0x0007CD9F File Offset: 0x0007AF9F
		Friend Overridable Property Label7 As Label

		' Token: 0x1700710C RID: 28940
		' (get) Token: 0x0601232C RID: 74540 RVA: 0x0007CDA8 File Offset: 0x0007AFA8
		' (set) Token: 0x0601232D RID: 74541 RVA: 0x0007CDB2 File Offset: 0x0007AFB2
		Friend Overridable Property Label6 As Label

		' Token: 0x1700710D RID: 28941
		' (get) Token: 0x0601232E RID: 74542 RVA: 0x0007CDBB File Offset: 0x0007AFBB
		' (set) Token: 0x0601232F RID: 74543 RVA: 0x00A77E3C File Offset: 0x00A7603C
		Private _txtRemarks As TextBox
		Friend Overridable Property txtRemarks As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtRemarks
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtRemarks_KeyDown
				Dim textBox As TextBox = Me._txtRemarks
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtRemarks = value
				textBox = Me._txtRemarks
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700710E RID: 28942
		' (get) Token: 0x06012330 RID: 74544 RVA: 0x0007CDC5 File Offset: 0x0007AFC5
		' (set) Token: 0x06012331 RID: 74545 RVA: 0x00A77E80 File Offset: 0x00A76080
		Private _txtProblemDescription As TextBox
		Friend Overridable Property txtProblemDescription As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtProblemDescription
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtProblemDescription_KeyDown
				Dim textBox As TextBox = Me._txtProblemDescription
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._txtProblemDescription = value
				textBox = Me._txtProblemDescription
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700710F RID: 28943
		' (get) Token: 0x06012332 RID: 74546 RVA: 0x0007CDCF File Offset: 0x0007AFCF
		' (set) Token: 0x06012333 RID: 74547 RVA: 0x00A77EC4 File Offset: 0x00A760C4
		Private _dtpEstimatedRepairDate As DateTimePicker
		Friend Overridable Property dtpEstimatedRepairDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpEstimatedRepairDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.dtpEstimatedRepairDate_LostFocus
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpEstimatedRepairDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpEstimatedRepairDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.LostFocus, eventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpEstimatedRepairDate = value
				dateTimePicker = Me._dtpEstimatedRepairDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.LostFocus, eventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007110 RID: 28944
		' (get) Token: 0x06012334 RID: 74548 RVA: 0x0007CDD9 File Offset: 0x0007AFD9
		' (set) Token: 0x06012335 RID: 74549 RVA: 0x00A77F24 File Offset: 0x00A76124
		Private _cmbStatus As ComboBox
		Friend Overridable Property cmbStatus As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbStatus
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbStatus_KeyDown
				Dim comboBox As ComboBox = Me._cmbStatus
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbStatus = value
				comboBox = Me._cmbStatus
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007111 RID: 28945
		' (get) Token: 0x06012336 RID: 74550 RVA: 0x0007CDE3 File Offset: 0x0007AFE3
		' (set) Token: 0x06012337 RID: 74551 RVA: 0x00A77F68 File Offset: 0x00A76168
		Private _txtUpfront As TextBox
		Friend Overridable Property txtUpfront As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtUpfront
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtChargesQuote_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtUpfront_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtUpfront
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtUpfront = value
				textBox = Me._txtUpfront
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007112 RID: 28946
		' (get) Token: 0x06012338 RID: 74552 RVA: 0x0007CDED File Offset: 0x0007AFED
		' (set) Token: 0x06012339 RID: 74553 RVA: 0x00A77FE4 File Offset: 0x00A761E4
		Private _txtChargesQuote As TextBox
		Friend Overridable Property txtChargesQuote As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtChargesQuote
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.txtChargesQuote_KeyPress_1
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.txtChargesQuote_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtChargesQuote
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtChargesQuote = value
				textBox = Me._txtChargesQuote
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007113 RID: 28947
		' (get) Token: 0x0601233A RID: 74554 RVA: 0x0007CDF7 File Offset: 0x0007AFF7
		' (set) Token: 0x0601233B RID: 74555 RVA: 0x00A78060 File Offset: 0x00A76260
		Private _cmbServiceType As ComboBox
		Friend Overridable Property cmbServiceType As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbServiceType
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbServiceType_Format
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbServiceType_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._cmbServiceType
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Format, listControlConvertEventHandler
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._cmbServiceType = value
				comboBox = Me._cmbServiceType
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Format, listControlConvertEventHandler
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17007114 RID: 28948
		' (get) Token: 0x0601233C RID: 74556 RVA: 0x0007CE01 File Offset: 0x0007B001
		' (set) Token: 0x0601233D RID: 74557 RVA: 0x0007CE0B File Offset: 0x0007B00B
		Friend Overridable Property txtContactNo As TextBox

		' Token: 0x17007115 RID: 28949
		' (get) Token: 0x0601233E RID: 74558 RVA: 0x0007CE14 File Offset: 0x0007B014
		' (set) Token: 0x0601233F RID: 74559 RVA: 0x00A780DC File Offset: 0x00A762DC
		Private _TextBox10 As TextBox
		Friend Overridable Property TextBox10 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox10
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox10_TextChanged
				Dim textBox As TextBox = Me._TextBox10
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox10 = value
				textBox = Me._TextBox10
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17007116 RID: 28950
		' (get) Token: 0x06012340 RID: 74560 RVA: 0x0007CE1E File Offset: 0x0007B01E
		' (set) Token: 0x06012341 RID: 74561 RVA: 0x0007CE28 File Offset: 0x0007B028
		Friend Overridable Property TextBox9 As TextBox

		' Token: 0x17007117 RID: 28951
		' (get) Token: 0x06012342 RID: 74562 RVA: 0x0007CE31 File Offset: 0x0007B031
		' (set) Token: 0x06012343 RID: 74563 RVA: 0x0007CE3B File Offset: 0x0007B03B
		Friend Overridable Property Label14 As Label

		' Token: 0x17007118 RID: 28952
		' (get) Token: 0x06012344 RID: 74564 RVA: 0x0007CE44 File Offset: 0x0007B044
		' (set) Token: 0x06012345 RID: 74565 RVA: 0x0007CE4E File Offset: 0x0007B04E
		Friend Overridable Property txtcompname As TextBox

		' Token: 0x17007119 RID: 28953
		' (get) Token: 0x06012346 RID: 74566 RVA: 0x0007CE57 File Offset: 0x0007B057
		' (set) Token: 0x06012347 RID: 74567 RVA: 0x0007CE61 File Offset: 0x0007B061
		Friend Overridable Property DTP2 As DateTimePicker

		' Token: 0x1700711A RID: 28954
		' (get) Token: 0x06012348 RID: 74568 RVA: 0x0007CE6A File Offset: 0x0007B06A
		' (set) Token: 0x06012349 RID: 74569 RVA: 0x0007CE74 File Offset: 0x0007B074
		Friend Overridable Property DTP1 As DateTimePicker

		' Token: 0x1700711B RID: 28955
		' (get) Token: 0x0601234A RID: 74570 RVA: 0x0007CE7D File Offset: 0x0007B07D
		' (set) Token: 0x0601234B RID: 74571 RVA: 0x00A78120 File Offset: 0x00A76320
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

		' Token: 0x1700711C RID: 28956
		' (get) Token: 0x0601234C RID: 74572 RVA: 0x0007CE87 File Offset: 0x0007B087
		' (set) Token: 0x0601234D RID: 74573 RVA: 0x0007CE91 File Offset: 0x0007B091
		Friend Overridable Property F2 As TextBox

		' Token: 0x1700711D RID: 28957
		' (get) Token: 0x0601234E RID: 74574 RVA: 0x0007CE9A File Offset: 0x0007B09A
		' (set) Token: 0x0601234F RID: 74575 RVA: 0x0007CEA4 File Offset: 0x0007B0A4
		Friend Overridable Property F1 As TextBox

		' Token: 0x1700711E RID: 28958
		' (get) Token: 0x06012350 RID: 74576 RVA: 0x0007CEAD File Offset: 0x0007B0AD
		' (set) Token: 0x06012351 RID: 74577 RVA: 0x0007CEB7 File Offset: 0x0007B0B7
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x1700711F RID: 28959
		' (get) Token: 0x06012352 RID: 74578 RVA: 0x0007CEC0 File Offset: 0x0007B0C0
		' (set) Token: 0x06012353 RID: 74579 RVA: 0x0007CECA File Offset: 0x0007B0CA
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17007120 RID: 28960
		' (get) Token: 0x06012354 RID: 74580 RVA: 0x0007CED3 File Offset: 0x0007B0D3
		' (set) Token: 0x06012355 RID: 74581 RVA: 0x00A78164 File Offset: 0x00A76364
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

		' Token: 0x17007121 RID: 28961
		' (get) Token: 0x06012356 RID: 74582 RVA: 0x0007CEDD File Offset: 0x0007B0DD
		' (set) Token: 0x06012357 RID: 74583 RVA: 0x00A781A8 File Offset: 0x00A763A8
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

		' Token: 0x17007122 RID: 28962
		' (get) Token: 0x06012358 RID: 74584 RVA: 0x0007CEE7 File Offset: 0x0007B0E7
		' (set) Token: 0x06012359 RID: 74585 RVA: 0x00A781EC File Offset: 0x00A763EC
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

		' Token: 0x17007123 RID: 28963
		' (get) Token: 0x0601235A RID: 74586 RVA: 0x0007CEF1 File Offset: 0x0007B0F1
		' (set) Token: 0x0601235B RID: 74587 RVA: 0x00A78230 File Offset: 0x00A76430
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

		' Token: 0x17007124 RID: 28964
		' (get) Token: 0x0601235C RID: 74588 RVA: 0x0007CEFB File Offset: 0x0007B0FB
		' (set) Token: 0x0601235D RID: 74589 RVA: 0x0007CF05 File Offset: 0x0007B105
		Friend Overridable Property btnNew As GelButton

		' Token: 0x17007125 RID: 28965
		' (get) Token: 0x0601235E RID: 74590 RVA: 0x0007CF0E File Offset: 0x0007B10E
		' (set) Token: 0x0601235F RID: 74591 RVA: 0x00A78274 File Offset: 0x00A76474
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
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

		' Token: 0x06012360 RID: 74592 RVA: 0x00A782B8 File Offset: 0x00A764B8
		Public Sub Reset()
			Me.txtChargesQuote.Text = ""
			Me.txtCID.Text = ""
			Me.txtCustomerID.Text = ""
			Me.txtCustomerName.Text = ""
			Me.txtItemsDescription.Text = ""
			Me.txtProblemDescription.Text = ""
			Me.txtRemarks.Text = ""
			Me.txtUpfront.Text = ""
			Me.cmbServiceType.Text = ""
			Me.cmbStatus.SelectedIndex = 1
			Me.txtContactNo.Text = ""
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.dtpEstimatedRepairDate.Text = Conversions.ToString(DateAndTime.Today)
			Me.btnPrint.Enabled = False
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.btnSave.Enabled = True
			Me.auto()
			Me.dtpServiceCreationDate.Focus()
		End Sub

		' Token: 0x06012361 RID: 74593 RVA: 0x00A783E8 File Offset: 0x00A765E8
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 S_ID FROM Service ORDER BY S_ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("S_ID"))
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

		' Token: 0x06012362 RID: 74594 RVA: 0x00A78554 File Offset: 0x00A76754
		Private Function GenerateIDSr() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select TOP 1 ID FROM SrService ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x06012363 RID: 74595 RVA: 0x00A786C0 File Offset: 0x00A768C0
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
				Me.ntid = Me.GenerateIDSr()
				Me.txtServiceCode.Text = String.Concat(New String() { "SC-", Me.GenerateIDSr(), "-", Me.F1.Text, "/", Me.F2.Text })
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012364 RID: 74596 RVA: 0x00A78778 File Offset: 0x00A76978
		Private Sub btnSelect_Click(sender As Object, e As EventArgs)
			Me.txtRemarks.Focus()
			MyProject.Forms.frmCustomerRecord.lblSet.Text = "Services"
			MyProject.Forms.frmCustomerRecord.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmCustomerRecord.btnAddCustomer.Visible = True
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
			MyProject.Forms.frmCustomerRecord.Dispose()
		End Sub

		' Token: 0x06012365 RID: 74597 RVA: 0x00A78814 File Offset: 0x00A76A14
		Public Sub Print()
			MyProject.Forms.frmReport.TextBox2.Text = Me.txtContactNo.Text.TrimEnd(New Char(-1) {})
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptServiceReceipt As rptServiceReceipt = New rptServiceReceipt()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT Service.S_ID, Service.ServiceCode, Service.ServiceType, Service.ServiceCreationDate, Service.ItemDescription, Service.ProblemDescription, Service.ChargesQuote,Service.AdvanceDeposit, Service.EstimatedRepairDate, Service.Remarks, Service.Status, Customer.ID, Customer.Name, Customer.Address, Customer.City,Customer.State, Customer.ZipCode, Customer.ContactNo, Customer.EmailID, Customer.Remarks AS Expr2 FROM Service INNER JOIN Customer ON Service.CustomerID = Customer.ID where Service.ServiceCode=@d1"
				sqlCommand.Parameters.AddWithValue("@d1", Me.txtServiceCode.Text)
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "Service")
				sqlDataAdapter.Fill(dataSet, "Customer")
				sqlDataAdapter2.Fill(dataSet, "Company")
				rptServiceReceipt.SetDataSource(dataSet)
				rptServiceReceipt.SetParameterValue("p1", Me.txtCustomerID.Text)
				rptServiceReceipt.SetParameterValue("p2", DateAndTime.Today)
				rptServiceReceipt.SetParameterValue("0", Me.TextBox9.Text.Trim())
				Dim parameterFields As ParameterFields = New ParameterFields()
				Dim parameterField As ParameterField = New ParameterField()
				Dim parameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
				parameterField.ParameterFieldName = "0"
				parameterDiscreteValue.Value = Me.TextBox9.Text.Trim()
				parameterField.CurrentValues.Add(parameterDiscreteValue)
				parameterFields.Add(parameterField)
				MyProject.Forms.frmReport.CrystalReportViewer1.ParameterFieldInfo = parameterFields
				MyProject.Forms.frmReport.CrystalReportViewer1.Refresh()
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptServiceReceipt
				MyProject.Forms.frmReport.ShowDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012366 RID: 74598 RVA: 0x00A78A68 File Offset: 0x00A76C68
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT S_ID FROM Service INNER JOIN InvoiceInfo1 ON Service.S_ID = InvoiceInfo1.ServiceID where S_ID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Unable to delete..Already in use in Billing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con.Close()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text2 As String = "delete from Service where S_ID=@d1"
					ModCommonClasses.cmd = New SqlCommand(text2)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
					Dim flag3 As Boolean = num > 0
					If flag3 Then
						ModFunc.LedgerDelete(Me.txtServiceCode.Text, "Service Upfront")
						ModFunc.LedgerDelete(Me.txtServiceCode.Text, "Receipt")
						ModFunc.CustomerLedgerDelete(Me.txtServiceCode.Text)
						ModFunc.SrServiceDelete(Me.txtServiceCode.Text)
						Dim text3 As String = "deleted the record having service code '" + Me.txtServiceCode.Text + "'"
						ModFunc.LogFunc(Me.lblUser.Text, text3)
						MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
						Me.fillServiceType()
					Else
						MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Reset()
					End If
					Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
					If flag4 Then
						ModCommonClasses.con.Close()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012367 RID: 74599 RVA: 0x0007CF18 File Offset: 0x0007B118
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06012368 RID: 74600 RVA: 0x00A78CD8 File Offset: 0x00A76ED8
		Private Sub txtChargesQuote_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtUpfront.Text
					Dim selectionStart As Integer = Me.txtUpfront.SelectionStart
					Dim selectionLength As Integer = Me.txtUpfront.SelectionLength
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

		' Token: 0x06012369 RID: 74601 RVA: 0x00A78DD0 File Offset: 0x00A76FD0
		Public Sub fillServiceType()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(ServiceType) FROM Service", ModCommonClasses.con)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbServiceType.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbServiceType.Items.Add(dataRow(0).ToString())
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0601236A RID: 74602 RVA: 0x00A78F04 File Offset: 0x00A77104
		Private Sub txtChargesQuote_KeyPress_1(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.txtChargesQuote.Text
					Dim selectionStart As Integer = Me.txtChargesQuote.SelectionStart
					Dim selectionLength As Integer = Me.txtChargesQuote.SelectionLength
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

		' Token: 0x0601236B RID: 74603 RVA: 0x00A78FFC File Offset: 0x00A771FC
		Private Sub GetCompanyname()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName),RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtcompname.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.DTP1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.DTP2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.F1.Text = ModCommonClasses.rdr.GetValue(1).ToString().Substring(7, 4)
					Me.F2.Text = ModCommonClasses.rdr.GetValue(2).ToString().Substring(9, 2)
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

		' Token: 0x0601236C RID: 74604 RVA: 0x0007CF34 File Offset: 0x0007B134
		Private Sub frmServices_Load(sender As Object, e As EventArgs)
			Me.GetCompanyname()
			Me.InvoiceHead()
			Me.LastBillDate()
			Me.auto()
			Me.fillServiceType()
			Me.Convert_Language()
		End Sub

		' Token: 0x0601236D RID: 74605 RVA: 0x00A79168 File Offset: 0x00A77368
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

		' Token: 0x0601236E RID: 74606 RVA: 0x00A79408 File Offset: 0x00A77608
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

		' Token: 0x0601236F RID: 74607 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06012370 RID: 74608 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbServiceType_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x06012371 RID: 74609 RVA: 0x00A794C4 File Offset: 0x00A776C4
		Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con.Close()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(Sign) from Registration where UserID=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.TextBox10.Text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox9.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012372 RID: 74610 RVA: 0x00A795B8 File Offset: 0x00A777B8
		Private Sub dtpServiceCreationDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpServiceCreationDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpServiceCreationDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpServiceCreationDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpServiceCreationDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			End If
		End Sub

		' Token: 0x06012373 RID: 74611 RVA: 0x00A79658 File Offset: 0x00A77858
		Private Sub dtpEstimatedRepairDate_LostFocus(sender As Object, e As EventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.dtpEstimatedRepairDate.Value, Me.DTP1.Value) < 0
			If flag Then
				Me.dtpEstimatedRepairDate.Value = DateAndTime.Today
				MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				MyBase.Close()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.dtpEstimatedRepairDate.Value, Me.DTP2.Value) > 0
				If flag2 Then
					Me.dtpEstimatedRepairDate.Value = DateAndTime.Today
					MessageBox.Show("Your selected date is not between current financial year", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06012374 RID: 74612 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpServiceCreationDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012375 RID: 74613 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbServiceType_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012376 RID: 74614 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtChargesQuote_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012377 RID: 74615 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtItemsDescription_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012378 RID: 74616 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtProblemDescription_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06012379 RID: 74617 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtUpfront_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601237A RID: 74618 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub dtpEstimatedRepairDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601237B RID: 74619 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbStatus_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601237C RID: 74620 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub txtRemarks_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0601237D RID: 74621 RVA: 0x00A79704 File Offset: 0x00A77904
		Private Sub Button35_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmReminder.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmReminder.ShowDialog()
			MyProject.Forms.frmReminder.Dispose()
		End Sub

		' Token: 0x0601237E RID: 74622 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmServices_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0601237F RID: 74623 RVA: 0x00A79754 File Offset: 0x00A77954
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

		' Token: 0x06012380 RID: 74624 RVA: 0x00A7984C File Offset: 0x00A77A4C
		Public Sub LastBillDate()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT Top 1 ServiceCreationDate from Service order by S_ID DESC"
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
					Me.dtpServiceCreationDate.Value = Me.prevdate
				Else
					Me.dtpServiceCreationDate.Value = DateAndTime.Today
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06012381 RID: 74625 RVA: 0x00A7998C File Offset: 0x00A77B8C
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtUpfront.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtUpfront, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtUpfront, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtItemsDescription.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtItemsDescription, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtItemsDescription, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.txtCustomerID.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.txtCustomerID, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtCustomerID, String.Empty)
			End If
			Dim flag4 As Boolean = String.IsNullOrEmpty(Me.txtChargesQuote.Text.Trim())
			If flag4 Then
				Me.ErrorProvider1.SetError(Me.txtChargesQuote, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtChargesQuote, String.Empty)
			End If
			Dim flag5 As Boolean = String.IsNullOrEmpty(Me.cmbServiceType.Text.Trim())
			If flag5 Then
				Me.ErrorProvider1.SetError(Me.cmbServiceType, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.cmbServiceType, String.Empty)
			End If
		End Sub

		' Token: 0x06012382 RID: 74626 RVA: 0x0007CF61 File Offset: 0x0007B161
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x06012383 RID: 74627 RVA: 0x00A79B18 File Offset: 0x00A77D18
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmServicesRecord.lblSet.Text = "Services"
			MyProject.Forms.frmServicesRecord.Reset()
			MyProject.Forms.frmServicesRecord.ShowDialog()
			MyProject.Forms.frmServicesRecord.Dispose()
		End Sub

		' Token: 0x06012384 RID: 74628 RVA: 0x00A79B70 File Offset: 0x00A77D70
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

		' Token: 0x06012385 RID: 74629 RVA: 0x00A79BD8 File Offset: 0x00A77DD8
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtItemsDescription.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter items description", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtItemsDescription.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtChargesQuote.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please enter charges quote", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtChargesQuote.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtUpfront.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please enter upfront", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtUpfront.Focus()
					Else
						Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
						If flag4 Then
							MessageBox.Show("Please retrieve customer details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "Update Service set ServiceCode=@d2, CustomerID=@d3, ServiceType=@d4, ServiceCreationDate=@d5, ItemDescription=@d6, ProblemDescription=@d7, ChargesQuote=@d8, AdvanceDeposit=@d9, EstimatedRepairDate=@d10, Remarks=@d11, Status=@d12 where S_ID=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtServiceCode.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtCID.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbServiceType.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dtpServiceCreationDate.Value.[Date])
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtItemsDescription.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtProblemDescription.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtChargesQuote.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtUpfront.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.dtpEstimatedRepairDate.Value.[Date])
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtRemarks.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.cmbStatus.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.ExecuteReader()
								ModCommonClasses.con.Close()
								ModFunc.LedgerDelete(Me.txtServiceCode.Text, "Service Upfront")
								ModFunc.LedgerDelete(Me.txtServiceCode.Text, "Receipt")
								ModFunc.CustomerLedgerDelete(Me.txtServiceCode.Text)
								ModFunc.LedgerSave(Me.dtpServiceCreationDate.Value.[Date], Me.txtCustomerName.Text, Me.txtServiceCode.Text, "Service Upfront", New Decimal(Conversion.Val(Me.txtUpfront.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text)
								ModFunc.CustomerLedgerSave(Me.dtpServiceCreationDate.Value.[Date], Me.txtCustomerName.Text, Me.txtServiceCode.Text, "Service Upfront", New Decimal(Conversion.Val(Me.txtUpfront.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
								ModFunc.LedgerSave(Me.dtpServiceCreationDate.Value.[Date], "Cash Account", Me.txtServiceCode.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtUpfront.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text)
								ModFunc.CustomerLedgerSave(Me.dtpServiceCreationDate.Value.[Date], "Cash Account", Me.txtServiceCode.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtUpfront.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
								Dim text2 As String = "updated the service having service code '" + Me.txtServiceCode.Text + "'"
								ModFunc.LogFunc(Me.lblUser.Text, text2)
								Me.btnUpdate.Enabled = False
								Me.fillServiceType()
								MessageBox.Show("Successfully Updated", "Service", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x06012386 RID: 74630 RVA: 0x00A7A1C4 File Offset: 0x00A783C4
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblCPhone.Text, "Trial", False) <> 0
			If Not flag Then
				Dim value As DateTime = Me.dtpServiceCreationDate.Value
				Dim dateTime As DateTime = New DateTime(value.Year, value.Month, 1)
				Dim dateTime2 As DateTime = dateTime.AddMonths(1).AddDays(-1.0)
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select count(*) from Service where ServiceCreationDate between @d1 and @d2 having count(*) >= 5"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "ServiceCreationDate").Value = dateTime
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "ServiceCreationDate").Value = dateTime2
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
			Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.txtItemsDescription.Text)) = 0
			If flag4 Then
				MessageBox.Show("Please enter items description", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtItemsDescription.Focus()
			Else
				Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.txtChargesQuote.Text)) = 0
				If flag5 Then
					MessageBox.Show("Please enter charges quote", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtChargesQuote.Focus()
				Else
					Dim flag6 As Boolean = Strings.Len(Strings.Trim(Me.txtUpfront.Text)) = 0
					If flag6 Then
						MessageBox.Show("Please enter upfront", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtUpfront.Focus()
					Else
						Dim flag7 As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
						If flag7 Then
							MessageBox.Show("Please retrieve customer details", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "select * from Company"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag8 As Boolean = Not ModCommonClasses.rdr.Read()
								If flag8 Then
									MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag9 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "insert into Service(S_ID, ServiceCode, CustomerID, ServiceType, ServiceCreationDate, ItemDescription, ProblemDescription, ChargesQuote, AdvanceDeposit, EstimatedRepairDate, Remarks, Status) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtServiceCode.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(Me.txtCID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.cmbServiceType.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.dtpServiceCreationDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.txtItemsDescription.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.txtProblemDescription.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.txtChargesQuote.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Conversion.Val(Me.txtUpfront.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.dtpEstimatedRepairDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Me.txtRemarks.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.cmbStatus.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									ModFunc.LedgerSave(Me.dtpServiceCreationDate.Value.[Date], Me.txtCustomerName.Text, Me.txtServiceCode.Text, "Service Upfront", New Decimal(Conversion.Val(Me.txtUpfront.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text)
									ModFunc.CustomerLedgerSave(Me.dtpServiceCreationDate.Value.[Date], Me.txtCustomerName.Text, Me.txtServiceCode.Text, "Service Upfront", New Decimal(Conversion.Val(Me.txtUpfront.Text)), 0D, Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
									ModFunc.LedgerSave(Me.dtpServiceCreationDate.Value.[Date], "Cash Account", Me.txtServiceCode.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtUpfront.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text)
									ModFunc.CustomerLedgerSave(Me.dtpServiceCreationDate.Value.[Date], "Cash Account", Me.txtServiceCode.Text, "Receipt", 0D, New Decimal(Conversion.Val(Me.txtUpfront.Text)), Me.txtCustomerID.Text, Me.txtCustomerName.Text.TrimEnd(New Char(-1) {}) + "-" + Me.txtCustomerID.Text.TrimEnd(New Char(-1) {}), Me.txtRemarks.Text)
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text4 As String = "insert into SrService(ID, InvNo) Values (@d1,@d2)"
									ModCommonClasses.cmd = New SqlCommand(text4)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.ntid))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtServiceCode.Text)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.ExecuteReader()
									ModCommonClasses.con.Close()
									Dim text5 As String = "added the new service having service code '" + Me.txtServiceCode.Text + "'"
									ModFunc.LogFunc(Me.lblUser.Text, text5)
									Try
										Dim flag10 As Boolean = ModFunc.CheckForInternetConnection()
										If flag10 Then
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text6 As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes' and AutoSMS='Yes'"
											ModCommonClasses.cmd = New SqlCommand(text6)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
											Dim flag11 As Boolean = ModCommonClasses.rdr.Read()
											If flag11 Then
												Me.st2 = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
												Dim text7 As String = String.Concat(New String() { "Dear Sir/Madam, ", Me.txtCustomerName.Text, " , service has been created successfully having service code ", Me.txtServiceCode.Text, ", Best wishes from ", Me.txtcompname.Text.Trim(), "." })
												ModFunc.SMSFunc(Me.txtContactNo.Text, text7, Me.st2)
												ModFunc.SMS(text7)
												MessageBox.Show("Successfully SMS Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
												Dim flag12 As Boolean = ModCommonClasses.rdr IsNot Nothing
												If flag12 Then
													ModCommonClasses.rdr.Close()
												End If
											End If
										Else
											MessageBox.Show("SMS is not sent", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										End If
									Catch ex As Exception
										MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
									ModCommonClasses.con.Close()
									Me.btnSave.Enabled = False
									Me.fillServiceType()
									Dim flag13 As Boolean = MessageBox.Show("Successfully Saved" & vbCrLf & "Do you Want to Print Service Receipt ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
									If flag13 Then
										Me.Print()
									Else
										Me.Reset()
									End If
								End If
							Catch ex2 As Exception
								MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x04006D78 RID: 28024
		Private st2 As String

		' Token: 0x04006D79 RID: 28025
		Private ntid As String

		' Token: 0x04006D7A RID: 28026
		Private InvDateSts As String

		' Token: 0x04006D7B RID: 28027
		Private prevdate As DateTime
	End Class
End Namespace
