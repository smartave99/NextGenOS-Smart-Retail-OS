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
Imports CrystalDecisions.CrystalReports.Engine
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200033E RID: 830
	<DesignerGenerated()>
	Public Partial Class frmEmployeePayment
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C175 RID: 49525 RVA: 0x0005675F File Offset: 0x0005495F
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAdvanceEntry_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEmployeePayment_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004CE3 RID: 19683
		' (get) Token: 0x0600C178 RID: 49528 RVA: 0x00056791 File Offset: 0x00054991
		' (set) Token: 0x0600C179 RID: 49529 RVA: 0x0005679B File Offset: 0x0005499B
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004CE4 RID: 19684
		' (get) Token: 0x0600C17A RID: 49530 RVA: 0x000567A4 File Offset: 0x000549A4
		' (set) Token: 0x0600C17B RID: 49531 RVA: 0x000567AE File Offset: 0x000549AE
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004CE5 RID: 19685
		' (get) Token: 0x0600C17C RID: 49532 RVA: 0x000567B7 File Offset: 0x000549B7
		' (set) Token: 0x0600C17D RID: 49533 RVA: 0x000567C1 File Offset: 0x000549C1
		Friend Overridable Property Label1 As Label

		' Token: 0x17004CE6 RID: 19686
		' (get) Token: 0x0600C17E RID: 49534 RVA: 0x000567CA File Offset: 0x000549CA
		' (set) Token: 0x0600C17F RID: 49535 RVA: 0x000567D4 File Offset: 0x000549D4
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17004CE7 RID: 19687
		' (get) Token: 0x0600C180 RID: 49536 RVA: 0x000567DD File Offset: 0x000549DD
		' (set) Token: 0x0600C181 RID: 49537 RVA: 0x000567E7 File Offset: 0x000549E7
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17004CE8 RID: 19688
		' (get) Token: 0x0600C182 RID: 49538 RVA: 0x000567F0 File Offset: 0x000549F0
		' (set) Token: 0x0600C183 RID: 49539 RVA: 0x007B2F24 File Offset: 0x007B1124
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

		' Token: 0x17004CE9 RID: 19689
		' (get) Token: 0x0600C184 RID: 49540 RVA: 0x000567FA File Offset: 0x000549FA
		' (set) Token: 0x0600C185 RID: 49541 RVA: 0x00056804 File Offset: 0x00054A04
		Friend Overridable Property txtID As TextBox

		' Token: 0x17004CEA RID: 19690
		' (get) Token: 0x0600C186 RID: 49542 RVA: 0x0005680D File Offset: 0x00054A0D
		' (set) Token: 0x0600C187 RID: 49543 RVA: 0x00056817 File Offset: 0x00054A17
		Friend Overridable Property lblUser As Label

		' Token: 0x17004CEB RID: 19691
		' (get) Token: 0x0600C188 RID: 49544 RVA: 0x00056820 File Offset: 0x00054A20
		' (set) Token: 0x0600C189 RID: 49545 RVA: 0x007B2F68 File Offset: 0x007B1168
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

		' Token: 0x17004CEC RID: 19692
		' (get) Token: 0x0600C18A RID: 49546 RVA: 0x0005682A File Offset: 0x00054A2A
		' (set) Token: 0x0600C18B RID: 49547 RVA: 0x00056834 File Offset: 0x00054A34
		Friend Overridable Property txtEmpID As TextBox

		' Token: 0x17004CED RID: 19693
		' (get) Token: 0x0600C18C RID: 49548 RVA: 0x0005683D File Offset: 0x00054A3D
		' (set) Token: 0x0600C18D RID: 49549 RVA: 0x00056847 File Offset: 0x00054A47
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004CEE RID: 19694
		' (get) Token: 0x0600C18E RID: 49550 RVA: 0x00056850 File Offset: 0x00054A50
		' (set) Token: 0x0600C18F RID: 49551 RVA: 0x007B2FC8 File Offset: 0x007B11C8
		Private _txtEmployee As TextBox
		Friend Overridable Property txtEmployee As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmployee
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtEmployee_TextChanged
				Dim textBox As TextBox = Me._txtEmployee
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtEmployee = value
				textBox = Me._txtEmployee
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CEF RID: 19695
		' (get) Token: 0x0600C190 RID: 49552 RVA: 0x0005685A File Offset: 0x00054A5A
		' (set) Token: 0x0600C191 RID: 49553 RVA: 0x00056864 File Offset: 0x00054A64
		Friend Overridable Property groupBox3 As GroupBox

		' Token: 0x17004CF0 RID: 19696
		' (get) Token: 0x0600C192 RID: 49554 RVA: 0x0005686D File Offset: 0x00054A6D
		' (set) Token: 0x0600C193 RID: 49555 RVA: 0x007B300C File Offset: 0x007B120C
		Private _DateTo As DateTimePicker
		Friend Overridable Property DateTo As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._DateTo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.DateTo_Validating
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DateTo_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._DateTo
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.Validating, cancelEventHandler
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._DateTo = value
				dateTimePicker = Me._DateTo
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.Validating, cancelEventHandler
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CF1 RID: 19697
		' (get) Token: 0x0600C194 RID: 49556 RVA: 0x00056877 File Offset: 0x00054A77
		' (set) Token: 0x0600C195 RID: 49557 RVA: 0x007B306C File Offset: 0x007B126C
		Private _DateFrom As DateTimePicker
		Friend Overridable Property DateFrom As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._DateFrom
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.DateFrom_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._DateFrom
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._DateFrom = value
				dateTimePicker = Me._DateFrom
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CF2 RID: 19698
		' (get) Token: 0x0600C196 RID: 49558 RVA: 0x00056881 File Offset: 0x00054A81
		' (set) Token: 0x0600C197 RID: 49559 RVA: 0x0005688B File Offset: 0x00054A8B
		Friend Overridable Property Label11 As Label

		' Token: 0x17004CF3 RID: 19699
		' (get) Token: 0x0600C198 RID: 49560 RVA: 0x00056894 File Offset: 0x00054A94
		' (set) Token: 0x0600C199 RID: 49561 RVA: 0x0005689E File Offset: 0x00054A9E
		Friend Overridable Property Label12 As Label

		' Token: 0x17004CF4 RID: 19700
		' (get) Token: 0x0600C19A RID: 49562 RVA: 0x000568A7 File Offset: 0x00054AA7
		' (set) Token: 0x0600C19B RID: 49563 RVA: 0x000568B1 File Offset: 0x00054AB1
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004CF5 RID: 19701
		' (get) Token: 0x0600C19C RID: 49564 RVA: 0x000568BA File Offset: 0x00054ABA
		' (set) Token: 0x0600C19D RID: 49565 RVA: 0x000568C4 File Offset: 0x00054AC4
		Friend Overridable Property PaymentID As TextBox

		' Token: 0x17004CF6 RID: 19702
		' (get) Token: 0x0600C19E RID: 49566 RVA: 0x000568CD File Offset: 0x00054ACD
		' (set) Token: 0x0600C19F RID: 49567 RVA: 0x000568D7 File Offset: 0x00054AD7
		Friend Overridable Property Label19 As Label

		' Token: 0x17004CF7 RID: 19703
		' (get) Token: 0x0600C1A0 RID: 49568 RVA: 0x000568E0 File Offset: 0x00054AE0
		' (set) Token: 0x0600C1A1 RID: 49569 RVA: 0x000568EA File Offset: 0x00054AEA
		Friend Overridable Property PresentDays As TextBox

		' Token: 0x17004CF8 RID: 19704
		' (get) Token: 0x0600C1A2 RID: 49570 RVA: 0x000568F3 File Offset: 0x00054AF3
		' (set) Token: 0x0600C1A3 RID: 49571 RVA: 0x000568FD File Offset: 0x00054AFD
		Friend Overridable Property Label18 As Label

		' Token: 0x17004CF9 RID: 19705
		' (get) Token: 0x0600C1A4 RID: 49572 RVA: 0x00056906 File Offset: 0x00054B06
		' (set) Token: 0x0600C1A5 RID: 49573 RVA: 0x00056910 File Offset: 0x00054B10
		Friend Overridable Property Department As TextBox

		' Token: 0x17004CFA RID: 19706
		' (get) Token: 0x0600C1A6 RID: 49574 RVA: 0x00056919 File Offset: 0x00054B19
		' (set) Token: 0x0600C1A7 RID: 49575 RVA: 0x00056923 File Offset: 0x00054B23
		Friend Overridable Property Designation As TextBox

		' Token: 0x17004CFB RID: 19707
		' (get) Token: 0x0600C1A8 RID: 49576 RVA: 0x0005692C File Offset: 0x00054B2C
		' (set) Token: 0x0600C1A9 RID: 49577 RVA: 0x00056936 File Offset: 0x00054B36
		Friend Overridable Property Label17 As Label

		' Token: 0x17004CFC RID: 19708
		' (get) Token: 0x0600C1AA RID: 49578 RVA: 0x0005693F File Offset: 0x00054B3F
		' (set) Token: 0x0600C1AB RID: 49579 RVA: 0x00056949 File Offset: 0x00054B49
		Friend Overridable Property Label16 As Label

		' Token: 0x17004CFD RID: 19709
		' (get) Token: 0x0600C1AC RID: 49580 RVA: 0x00056952 File Offset: 0x00054B52
		' (set) Token: 0x0600C1AD RID: 49581 RVA: 0x007B30B0 File Offset: 0x007B12B0
		Private _PaymentModeDetails As TextBox
		Public Overridable Property PaymentModeDetails As TextBox
			<CompilerGenerated()>
			Get
				Return Me._PaymentModeDetails
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.PaymentModeDetails_KeyDown
				Dim textBox As TextBox = Me._PaymentModeDetails
				If textBox IsNot Nothing Then
					RemoveHandler textBox.KeyDown, keyEventHandler
				End If
				Me._PaymentModeDetails = value
				textBox = Me._PaymentModeDetails
				If textBox IsNot Nothing Then
					AddHandler textBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004CFE RID: 19710
		' (get) Token: 0x0600C1AE RID: 49582 RVA: 0x0005695C File Offset: 0x00054B5C
		' (set) Token: 0x0600C1AF RID: 49583 RVA: 0x00056966 File Offset: 0x00054B66
		Friend Overridable Property Label15 As Label

		' Token: 0x17004CFF RID: 19711
		' (get) Token: 0x0600C1B0 RID: 49584 RVA: 0x0005696F File Offset: 0x00054B6F
		' (set) Token: 0x0600C1B1 RID: 49585 RVA: 0x00056979 File Offset: 0x00054B79
		Friend Overridable Property Overtime As TextBox

		' Token: 0x17004D00 RID: 19712
		' (get) Token: 0x0600C1B2 RID: 49586 RVA: 0x00056982 File Offset: 0x00054B82
		' (set) Token: 0x0600C1B3 RID: 49587 RVA: 0x0005698C File Offset: 0x00054B8C
		Friend Overridable Property Advance As TextBox

		' Token: 0x17004D01 RID: 19713
		' (get) Token: 0x0600C1B4 RID: 49588 RVA: 0x00056995 File Offset: 0x00054B95
		' (set) Token: 0x0600C1B5 RID: 49589 RVA: 0x0005699F File Offset: 0x00054B9F
		Friend Overridable Property Label14 As Label

		' Token: 0x17004D02 RID: 19714
		' (get) Token: 0x0600C1B6 RID: 49590 RVA: 0x000569A8 File Offset: 0x00054BA8
		' (set) Token: 0x0600C1B7 RID: 49591 RVA: 0x000569B2 File Offset: 0x00054BB2
		Friend Overridable Property OvertimeAmount As TextBox

		' Token: 0x17004D03 RID: 19715
		' (get) Token: 0x0600C1B8 RID: 49592 RVA: 0x000569BB File Offset: 0x00054BBB
		' (set) Token: 0x0600C1B9 RID: 49593 RVA: 0x000569C5 File Offset: 0x00054BC5
		Friend Overridable Property Label13 As Label

		' Token: 0x17004D04 RID: 19716
		' (get) Token: 0x0600C1BA RID: 49594 RVA: 0x000569CE File Offset: 0x00054BCE
		' (set) Token: 0x0600C1BB RID: 49595 RVA: 0x000569D8 File Offset: 0x00054BD8
		Friend Overridable Property Label3 As Label

		' Token: 0x17004D05 RID: 19717
		' (get) Token: 0x0600C1BC RID: 49596 RVA: 0x000569E1 File Offset: 0x00054BE1
		' (set) Token: 0x0600C1BD RID: 49597 RVA: 0x007B30F4 File Offset: 0x007B12F4
		Private _OvertimeRate As TextBox
		Friend Overridable Property OvertimeRate As TextBox
			<CompilerGenerated()>
			Get
				Return Me._OvertimeRate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.OvertimeRate_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.OvertimeRate_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.OvertimeRate_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._OvertimeRate
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._OvertimeRate = value
				textBox = Me._OvertimeRate
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D06 RID: 19718
		' (get) Token: 0x0600C1BE RID: 49598 RVA: 0x000569EB File Offset: 0x00054BEB
		' (set) Token: 0x0600C1BF RID: 49599 RVA: 0x000569F5 File Offset: 0x00054BF5
		Friend Overridable Property Label10 As Label

		' Token: 0x17004D07 RID: 19719
		' (get) Token: 0x0600C1C0 RID: 49600 RVA: 0x000569FE File Offset: 0x00054BFE
		' (set) Token: 0x0600C1C1 RID: 49601 RVA: 0x00056A08 File Offset: 0x00054C08
		Friend Overridable Property NetPay As TextBox

		' Token: 0x17004D08 RID: 19720
		' (get) Token: 0x0600C1C2 RID: 49602 RVA: 0x00056A11 File Offset: 0x00054C11
		' (set) Token: 0x0600C1C3 RID: 49603 RVA: 0x007B3194 File Offset: 0x007B1394
		Private _PaymentDate As DateTimePicker
		Friend Overridable Property PaymentDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._PaymentDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.PaymentDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._PaymentDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._PaymentDate = value
				dateTimePicker = Me._PaymentDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D09 RID: 19721
		' (get) Token: 0x0600C1C4 RID: 49604 RVA: 0x00056A1B File Offset: 0x00054C1B
		' (set) Token: 0x0600C1C5 RID: 49605 RVA: 0x007B31D8 File Offset: 0x007B13D8
		Private _Deduction As TextBox
		Friend Overridable Property Deduction As TextBox
			<CompilerGenerated()>
			Get
				Return Me._Deduction
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.Deduction_TextChanged
				Dim keyPressEventHandler As KeyPressEventHandler = AddressOf Me.Deduction_KeyPress
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.Deduction_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._Deduction
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
					RemoveHandler textBox.KeyPress, keyPressEventHandler
					RemoveHandler textBox.KeyDown, keyEventHandler
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._Deduction = value
				textBox = Me._Deduction
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
					AddHandler textBox.KeyPress, keyPressEventHandler
					AddHandler textBox.KeyDown, keyEventHandler
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D0A RID: 19722
		' (get) Token: 0x0600C1C6 RID: 49606 RVA: 0x00056A25 File Offset: 0x00054C25
		' (set) Token: 0x0600C1C7 RID: 49607 RVA: 0x00056A2F File Offset: 0x00054C2F
		Friend Overridable Property Salary As TextBox

		' Token: 0x17004D0B RID: 19723
		' (get) Token: 0x0600C1C8 RID: 49608 RVA: 0x00056A38 File Offset: 0x00054C38
		' (set) Token: 0x0600C1C9 RID: 49609 RVA: 0x007B3278 File Offset: 0x007B1478
		Private _paymentmode As ComboBox
		Friend Overridable Property paymentmode As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._paymentmode
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.paymentmode_KeyDown
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim eventHandler As EventHandler = AddressOf Me.paymentmode_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._paymentmode
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._paymentmode = value
				comboBox = Me._paymentmode
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
					AddHandler comboBox.Validating, cancelEventHandler
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D0C RID: 19724
		' (get) Token: 0x0600C1CA RID: 49610 RVA: 0x00056A42 File Offset: 0x00054C42
		' (set) Token: 0x0600C1CB RID: 49611 RVA: 0x00056A4C File Offset: 0x00054C4C
		Friend Overridable Property EmployeeName As TextBox

		' Token: 0x17004D0D RID: 19725
		' (get) Token: 0x0600C1CC RID: 49612 RVA: 0x00056A55 File Offset: 0x00054C55
		' (set) Token: 0x0600C1CD RID: 49613 RVA: 0x00056A5F File Offset: 0x00054C5F
		Friend Overridable Property Label8 As Label

		' Token: 0x17004D0E RID: 19726
		' (get) Token: 0x0600C1CE RID: 49614 RVA: 0x00056A68 File Offset: 0x00054C68
		' (set) Token: 0x0600C1CF RID: 49615 RVA: 0x00056A72 File Offset: 0x00054C72
		Friend Overridable Property Label5 As Label

		' Token: 0x17004D0F RID: 19727
		' (get) Token: 0x0600C1D0 RID: 49616 RVA: 0x00056A7B File Offset: 0x00054C7B
		' (set) Token: 0x0600C1D1 RID: 49617 RVA: 0x00056A85 File Offset: 0x00054C85
		Friend Overridable Property Label6 As Label

		' Token: 0x17004D10 RID: 19728
		' (get) Token: 0x0600C1D2 RID: 49618 RVA: 0x00056A8E File Offset: 0x00054C8E
		' (set) Token: 0x0600C1D3 RID: 49619 RVA: 0x00056A98 File Offset: 0x00054C98
		Friend Overridable Property Label7 As Label

		' Token: 0x17004D11 RID: 19729
		' (get) Token: 0x0600C1D4 RID: 49620 RVA: 0x00056AA1 File Offset: 0x00054CA1
		' (set) Token: 0x0600C1D5 RID: 49621 RVA: 0x00056AAB File Offset: 0x00054CAB
		Friend Overridable Property Label9 As Label

		' Token: 0x17004D12 RID: 19730
		' (get) Token: 0x0600C1D6 RID: 49622 RVA: 0x00056AB4 File Offset: 0x00054CB4
		' (set) Token: 0x0600C1D7 RID: 49623 RVA: 0x00056ABE File Offset: 0x00054CBE
		Friend Overridable Property Label4 As Label

		' Token: 0x17004D13 RID: 19731
		' (get) Token: 0x0600C1D8 RID: 49624 RVA: 0x00056AC7 File Offset: 0x00054CC7
		' (set) Token: 0x0600C1D9 RID: 49625 RVA: 0x00056AD1 File Offset: 0x00054CD1
		Friend Overridable Property Label2 As Label

		' Token: 0x17004D14 RID: 19732
		' (get) Token: 0x0600C1DA RID: 49626 RVA: 0x00056ADA File Offset: 0x00054CDA
		' (set) Token: 0x0600C1DB RID: 49627 RVA: 0x00056AE4 File Offset: 0x00054CE4
		Friend Overridable Property EmployeeID As TextBox

		' Token: 0x17004D15 RID: 19733
		' (get) Token: 0x0600C1DC RID: 49628 RVA: 0x00056AED File Offset: 0x00054CED
		' (set) Token: 0x0600C1DD RID: 49629 RVA: 0x00056AF7 File Offset: 0x00054CF7
		Friend Overridable Property txtSalary As TextBox

		' Token: 0x17004D16 RID: 19734
		' (get) Token: 0x0600C1DE RID: 49630 RVA: 0x00056B00 File Offset: 0x00054D00
		' (set) Token: 0x0600C1DF RID: 49631 RVA: 0x00056B0A File Offset: 0x00054D0A
		Friend Overridable Property txtID1 As TextBox

		' Token: 0x17004D17 RID: 19735
		' (get) Token: 0x0600C1E0 RID: 49632 RVA: 0x00056B13 File Offset: 0x00054D13
		' (set) Token: 0x0600C1E1 RID: 49633 RVA: 0x00056B1D File Offset: 0x00054D1D
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004D18 RID: 19736
		' (get) Token: 0x0600C1E2 RID: 49634 RVA: 0x00056B26 File Offset: 0x00054D26
		' (set) Token: 0x0600C1E3 RID: 49635 RVA: 0x00056B30 File Offset: 0x00054D30
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004D19 RID: 19737
		' (get) Token: 0x0600C1E4 RID: 49636 RVA: 0x00056B39 File Offset: 0x00054D39
		' (set) Token: 0x0600C1E5 RID: 49637 RVA: 0x00056B43 File Offset: 0x00054D43
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004D1A RID: 19738
		' (get) Token: 0x0600C1E6 RID: 49638 RVA: 0x00056B4C File Offset: 0x00054D4C
		' (set) Token: 0x0600C1E7 RID: 49639 RVA: 0x00056B56 File Offset: 0x00054D56
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17004D1B RID: 19739
		' (get) Token: 0x0600C1E8 RID: 49640 RVA: 0x00056B5F File Offset: 0x00054D5F
		' (set) Token: 0x0600C1E9 RID: 49641 RVA: 0x00056B69 File Offset: 0x00054D69
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004D1C RID: 19740
		' (get) Token: 0x0600C1EA RID: 49642 RVA: 0x00056B72 File Offset: 0x00054D72
		' (set) Token: 0x0600C1EB RID: 49643 RVA: 0x00056B7C File Offset: 0x00054D7C
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004D1D RID: 19741
		' (get) Token: 0x0600C1EC RID: 49644 RVA: 0x00056B85 File Offset: 0x00054D85
		' (set) Token: 0x0600C1ED RID: 49645 RVA: 0x00056B8F File Offset: 0x00054D8F
		Friend Overridable Property GroupBox4 As GroupBox

		' Token: 0x17004D1E RID: 19742
		' (get) Token: 0x0600C1EE RID: 49646 RVA: 0x00056B98 File Offset: 0x00054D98
		' (set) Token: 0x0600C1EF RID: 49647 RVA: 0x00056BA2 File Offset: 0x00054DA2
		Friend Overridable Property txtCompanyName As TextBox

		' Token: 0x17004D1F RID: 19743
		' (get) Token: 0x0600C1F0 RID: 49648 RVA: 0x00056BAB File Offset: 0x00054DAB
		' (set) Token: 0x0600C1F1 RID: 49649 RVA: 0x00056BB5 File Offset: 0x00054DB5
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004D20 RID: 19744
		' (get) Token: 0x0600C1F2 RID: 49650 RVA: 0x00056BBE File Offset: 0x00054DBE
		' (set) Token: 0x0600C1F3 RID: 49651 RVA: 0x00056BC8 File Offset: 0x00054DC8
		Friend Overridable Property Label74 As Label

		' Token: 0x17004D21 RID: 19745
		' (get) Token: 0x0600C1F4 RID: 49652 RVA: 0x00056BD1 File Offset: 0x00054DD1
		' (set) Token: 0x0600C1F5 RID: 49653 RVA: 0x007B32F4 File Offset: 0x007B14F4
		Private _cmbAccountNo As ComboBox
		Friend Overridable Property cmbAccountNo As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbAccountNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.cmbAccountNo_KeyDown
				Dim comboBox As ComboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.KeyDown, keyEventHandler
				End If
				Me._cmbAccountNo = value
				comboBox = Me._cmbAccountNo
				If comboBox IsNot Nothing Then
					AddHandler comboBox.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D22 RID: 19746
		' (get) Token: 0x0600C1F6 RID: 49654 RVA: 0x00056BDB File Offset: 0x00054DDB
		' (set) Token: 0x0600C1F7 RID: 49655 RVA: 0x007B3338 File Offset: 0x007B1538
		Private _btngetData As GelButton
		Friend Overridable Property btngetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btngetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btngetData_Click
				Dim gelButton As GelButton = Me._btngetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btngetData = value
				gelButton = Me._btngetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D23 RID: 19747
		' (get) Token: 0x0600C1F8 RID: 49656 RVA: 0x00056BE5 File Offset: 0x00054DE5
		' (set) Token: 0x0600C1F9 RID: 49657 RVA: 0x007B337C File Offset: 0x007B157C
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

		' Token: 0x17004D24 RID: 19748
		' (get) Token: 0x0600C1FA RID: 49658 RVA: 0x00056BEF File Offset: 0x00054DEF
		' (set) Token: 0x0600C1FB RID: 49659 RVA: 0x007B33C0 File Offset: 0x007B15C0
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

		' Token: 0x17004D25 RID: 19749
		' (get) Token: 0x0600C1FC RID: 49660 RVA: 0x00056BF9 File Offset: 0x00054DF9
		' (set) Token: 0x0600C1FD RID: 49661 RVA: 0x007B3404 File Offset: 0x007B1604
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

		' Token: 0x17004D26 RID: 19750
		' (get) Token: 0x0600C1FE RID: 49662 RVA: 0x00056C03 File Offset: 0x00054E03
		' (set) Token: 0x0600C1FF RID: 49663 RVA: 0x007B3448 File Offset: 0x007B1648
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

		' Token: 0x17004D27 RID: 19751
		' (get) Token: 0x0600C200 RID: 49664 RVA: 0x00056C0D File Offset: 0x00054E0D
		' (set) Token: 0x0600C201 RID: 49665 RVA: 0x007B348C File Offset: 0x007B168C
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

		' Token: 0x0600C202 RID: 49666 RVA: 0x007B34D0 File Offset: 0x007B16D0
		Public Sub Reset()
			Me.DateFrom.Value = DateAndTime.Today
			Me.DateTo.Value = DateAndTime.Today
			Me.EmployeeID.Text = ""
			Me.EmployeeName.Text = ""
			Me.Designation.Text = ""
			Me.Department.Text = ""
			Me.Salary.Text = ""
			Me.PresentDays.Text = ""
			Me.Advance.Text = ""
			Me.Deduction.Text = ""
			Me.Overtime.Text = ""
			Me.OvertimeRate.Text = ""
			Me.OvertimeAmount.Text = ""
			Me.PaymentDate.Text = Conversions.ToString(DateAndTime.Now)
			Me.paymentmode.SelectedIndex = -1
			Me.PaymentModeDetails.Text = ""
			Me.NetPay.Text = ""
			Me.PaymentID.Text = ""
			Me.txtEmployee.Text = ""
			Me.txtEmployee.Text = ""
			Me.GetData()
			Me.btnSave.Enabled = True
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.btnPrint.Enabled = False
			Me.DateFrom.Enabled = True
			Me.DateTo.Enabled = True
			Me.PaymentDate.Enabled = True
			Me.Deduction.[ReadOnly] = False
			Me.dgw.Enabled = True
			Me.cmbAccountNo.SelectedIndex = -1
			Me.cmbAccountNo.Enabled = False
			Me.auto()
		End Sub

		' Token: 0x0600C203 RID: 49667 RVA: 0x007B36D0 File Offset: 0x007B18D0
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(EmployeeRegistration.ID),RTRIM(EmployeeRegistration.EmployeeID),RTRIM(EmployeeName),RTRIM(Department),RTRIM(Designation),RTRIM(Salary) from EmployeeRegistration where Active='Yes' order by EmployeeName"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C204 RID: 49668 RVA: 0x007B37FC File Offset: 0x007B19FC
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from EmployeePayment where id=" + Me.txtID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					ModFunc.LedgerDelete(Me.PaymentID.Text, "Payroll Payment")
					ModFunc.BankAccountLedgerDelete(Me.PaymentID.Text, "Payroll Payment-By Cheque")
					ModFunc.BankAccountLedgerDelete(Me.PaymentID.Text, "Payroll Payment-By Online Transfer")
					Dim text2 As String = "deleted the payment entry having payment id '" + Me.PaymentID.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully Deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.GetData()
					Me.Reset()
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

		' Token: 0x0600C205 RID: 49669 RVA: 0x00056C17 File Offset: 0x00054E17
		Private Sub frmAdvanceEntry_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.auto()
			Me.GetCompanyname()
			Me.fillAccountInfo()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C206 RID: 49670 RVA: 0x007B3994 File Offset: 0x007B1B94
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

		' Token: 0x0600C207 RID: 49671 RVA: 0x007B3B0C File Offset: 0x007B1D0C
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

		' Token: 0x0600C208 RID: 49672 RVA: 0x007B3BC8 File Offset: 0x007B1DC8
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

		' Token: 0x0600C209 RID: 49673 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C20A RID: 49674 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C20B RID: 49675 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C20C RID: 49676 RVA: 0x007B3C94 File Offset: 0x007B1E94
		Public Sub Compute()
			Try
				Dim num As Double = Conversion.Val(Me.txtSalary.Text) * Conversion.Val(Me.PresentDays.Text) / 30.0
				num = Math.Round(num, 2)
				Me.Salary.Text = Conversions.ToString(num)
				Dim timeSpan As TimeSpan
				Dim flag As Boolean = TimeSpan.TryParse(Me.Overtime.Text, timeSpan)
				If flag Then
					Dim num2 As Integer
					Dim flag2 As Boolean = Integer.TryParse(Me.OvertimeRate.Text, num2)
					If flag2 Then
						Me.OvertimeAmount.Text = Conversions.ToString(timeSpan.TotalMinutes * CDbl(num2) / 60.0)
					End If
				End If
				Dim num3 As Double = Conversion.Val(Me.OvertimeAmount.Text)
				num3 = Math.Round(num3, 2)
				Me.OvertimeAmount.Text = Conversions.ToString(num3)
				Dim num4 As Double = Conversion.Val(Me.OvertimeAmount.Text)
				num4 = Math.Round(num4, 3)
				Me.OvertimeAmount.Text = Conversions.ToString(num4)
				Dim num5 As Double = Conversion.Val(Me.Salary.Text) + Conversion.Val(Me.OvertimeAmount.Text) - Conversion.Val(Me.Deduction.Text)
				num5 = Math.Round(num5, 2)
				Me.NetPay.Text = Conversions.ToString(num5)
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C20D RID: 49677 RVA: 0x007B3E30 File Offset: 0x007B2030
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = DateTime.Compare(Me.DateTo.Value.[Date], Me.DateFrom.Value.[Date]) < 0
					If flag2 Then
						MessageBox.Show("Selected 'Date To' must be greater than 'Date From'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						Me.DateTo.Focus()
					Else
						Dim flag3 As Boolean = DateTime.Compare(Me.DateTo.Value.[Date], Me.DateFrom.Value.[Date]) = 0
						If flag3 Then
							MessageBox.Show("Selected 'Date From' is equal to 'Date To'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							Me.DateFrom.Focus()
						Else
							Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM EmployeePayment WHERE DateFrom <= @d1 AND DateTo >= @d2 and EmployeeID=", dataGridViewRow.Cells(0).Value), ""))
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.DateTo.Value.[Date])
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.DateFrom.Value.[Date])
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								MessageBox.Show("Salary already paid..Select correct payment date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								Me.txtEmpID.Text = dataGridViewRow.Cells(0).Value.ToString()
								Me.EmployeeID.Text = dataGridViewRow.Cells(1).Value.ToString()
								Me.EmployeeName.Text = dataGridViewRow.Cells(2).Value.ToString()
								Me.Department.Text = dataGridViewRow.Cells(3).Value.ToString()
								Me.Designation.Text = dataGridViewRow.Cells(4).Value.ToString()
								Me.txtSalary.Text = dataGridViewRow.Cells(5).Value.ToString()
								ModCommonClasses.con.Open()
								Dim text2 As String = If(("select count(status) from employeeattendance where WorkingDate between @d1 and @d2 and status='P' and  employeeid=" + Me.txtEmpID.Text), "")
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value.[Date]
								Dim objectValue As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar())
								Me.PresentDays.Text = Convert.ToString(RuntimeHelpers.GetObjectValue(objectValue))
								Dim num As Double = Conversion.Val(Me.txtSalary.Text) * Conversion.Val(Me.PresentDays.Text) / 30.0
								num = Math.Round(num, 2)
								Me.Salary.Text = Conversions.ToString(num)
								Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
								If flag6 Then
									ModCommonClasses.con.Close()
								End If
								ModCommonClasses.con.Open()
								Dim text3 As String = If(("select sum(amount)-sum(deduction) from advanceentry where employeeid=" + Me.txtEmpID.Text), "")
								ModCommonClasses.cmd = New SqlCommand(text3)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar())
								Me.Advance.Text = Convert.ToString(RuntimeHelpers.GetObjectValue(objectValue2))
								Dim flag7 As Boolean = Operators.CompareString(Me.Advance.Text, Nothing, False) = 0
								If flag7 Then
									Me.Advance.Text = Conversions.ToString(0)
								End If
								Dim flag8 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
								If flag8 Then
									ModCommonClasses.con.Close()
								End If
								ModCommonClasses.con.Open()
								ModCommonClasses.cmd = New SqlCommand(If(("select (Overtime) as [Overtime] from employeeAttendance where WorkingDate between @d3 and @d4 and EmployeeId=" + Me.txtEmpID.Text), ""), ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value.[Date]
								Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
								Dim dataSet As DataSet = New DataSet()
								sqlDataAdapter.Fill(dataSet, "EmployeeAttendance")
								Dim num2 As Integer = 0
								Dim num3 As Integer = 0
								Dim num4 As Integer = 0
								Try
									For Each obj As Object In dataSet.Tables("EmployeeAttendance").Rows
										Dim dataRow As DataRow = CType(obj, DataRow)
										Dim timeSpan As TimeSpan = TimeSpan.Parse(dataRow("Overtime").ToString())
										num2 += timeSpan.Hours
										num3 += timeSpan.Minutes
										num4 += timeSpan.Seconds
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								Dim timeSpan2 As TimeSpan = New TimeSpan(num2, num3, num4)
								Me.Overtime.Text = timeSpan2.ToString()
								ModCommonClasses.con.Close()
								Me.Deduction.Focus()
							End If
						End If
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C20E RID: 49678 RVA: 0x007B4504 File Offset: 0x007B2704
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

		' Token: 0x0600C20F RID: 49679 RVA: 0x007B45EC File Offset: 0x007B27EC
		Private Sub auto1()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT MAX(ID) FROM AdvanceEntry"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
			If flag Then
				Dim num As Integer = 1
				Me.txtID1.Text = num.ToString()
			Else
				Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
				Me.txtID1.Text = num.ToString()
			End If
			ModCommonClasses.cmd.Dispose()
			ModCommonClasses.con.Close()
			ModCommonClasses.con.Dispose()
		End Sub

		' Token: 0x0600C210 RID: 49680 RVA: 0x007B46B8 File Offset: 0x007B28B8
		Private Sub auto()
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			ModCommonClasses.con.Open()
			Dim text As String = "SELECT MAX(ID) FROM EmployeePayment"
			ModCommonClasses.cmd = New SqlCommand(text)
			ModCommonClasses.cmd.Connection = ModCommonClasses.con
			Dim flag As Boolean = Information.IsDBNull(RuntimeHelpers.GetObjectValue(ModCommonClasses.cmd.ExecuteScalar()))
			If flag Then
				Dim num As Integer = 1
				Me.txtID.Text = num.ToString()
				Me.PaymentID.Text = "P-" + num.ToString()
			Else
				Dim num As Integer = Conversions.ToInteger(Operators.AddObject(ModCommonClasses.cmd.ExecuteScalar(), 1))
				Me.txtID.Text = num.ToString()
				Me.PaymentID.Text = "P-" + num.ToString()
			End If
			ModCommonClasses.cmd.Dispose()
			ModCommonClasses.con.Close()
			ModCommonClasses.con.Dispose()
		End Sub

		' Token: 0x0600C211 RID: 49681 RVA: 0x007B47C0 File Offset: 0x007B29C0
		Private Sub txtEmployee_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(EmployeeRegistration.ID),RTRIM(EmployeeRegistration.EmployeeID),RTRIM(EmployeeName),RTRIM(Department),RTRIM(Designation),RTRIM(Salary) from EmployeeRegistration where Active='Yes' and EmployeeName like N'%" + Me.txtEmployee.Text + "%' order by EmployeeName"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C212 RID: 49682 RVA: 0x00056C3D File Offset: 0x00054E3D
		Private Sub OvertimeRate_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x0600C213 RID: 49683 RVA: 0x00056C3D File Offset: 0x00054E3D
		Private Sub Deduction_TextChanged(sender As Object, e As EventArgs)
			Me.Compute()
		End Sub

		' Token: 0x0600C214 RID: 49684 RVA: 0x007B4900 File Offset: 0x007B2B00
		Private Sub DateTo_Validating(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = DateTime.Compare(Me.DateTo.Value.[Date], Me.DateFrom.Value.[Date]) < 0
			If flag Then
				MessageBox.Show("Selected 'Date To' must be greater than 'Date From'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.DateTo.Focus()
			Else
				Dim flag2 As Boolean = DateTime.Compare(Me.DateTo.Value.[Date], Me.DateFrom.Value.[Date]) = 0
				If flag2 Then
					MessageBox.Show("Selected 'Date To' is equal to 'Date From'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Me.DateFrom.Focus()
				End If
			End If
		End Sub

		' Token: 0x0600C215 RID: 49685 RVA: 0x007B49B8 File Offset: 0x007B2BB8
		Public Sub Print()
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptSalarySlip As rptSalarySlip = New rptSalarySlip()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT EmployeeRegistration.EmployeeID, EmployeePayment.EmployeeID as expr10, EmployeePayment.PaymentID, EmployeePayment.DateFrom, EmployeePayment.DateTo, EmployeePayment.PresentDays, EmployeePayment.Salary,EmployeePayment.Advance, EmployeePayment.Deduction, EmployeePayment.Overtime, EmployeePayment.OvertimeRate, EmployeePayment.OvertimeAmount, EmployeePayment.PaymentDate,EmployeePayment.ModeOfPayment, EmployeePayment.PaymentModeDetails, EmployeePayment.NetPay, EmployeeRegistration.Id AS Expr1,EmployeeRegistration.EmployeeName, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department, EmployeeRegistration.Designation, EmployeeRegistration.DateOfJoining, EmployeeRegistration.Salary AS Expr3,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM EmployeePayment INNER JOIN EmployeeRegistration ON EmployeePayment.EmployeeID = EmployeeRegistration.Id where PaymentID='" + Me.PaymentID.Text + "'"
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "EmployeePayment")
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				sqlDataAdapter2.Fill(dataSet, "Hotel")
				rptSalarySlip.SetDataSource(dataSet)
				Dim textObject As TextObject = CType(rptSalarySlip.ReportDefinition.Sections("Section1").ReportObjects("Text1"), TextObject)
				textObject.Text = Me.txtCompanyName.Text
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSalarySlip
				MyProject.Forms.frmReport.ShowDialog()
				rptSalarySlip.Close()
				rptSalarySlip.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C216 RID: 49686 RVA: 0x007B4B60 File Offset: 0x007B2D60
		Public Sub GetCompanyname()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(CompanyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.txtCompanyName.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x0600C217 RID: 49687 RVA: 0x00056C47 File Offset: 0x00054E47
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600C218 RID: 49688 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub Deduction_Validating(sender As Object, e As CancelEventArgs)
		End Sub

		' Token: 0x0600C219 RID: 49689 RVA: 0x007B4C50 File Offset: 0x007B2E50
		Private Sub Deduction_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.Deduction.Text
					Dim selectionStart As Integer = Me.Deduction.SelectionStart
					Dim selectionLength As Integer = Me.Deduction.SelectionLength
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

		' Token: 0x0600C21A RID: 49690 RVA: 0x007B4D48 File Offset: 0x007B2F48
		Private Sub OvertimeRate_KeyPress(sender As Object, e As KeyPressEventArgs)
			Dim keyChar As Char = e.KeyChar
			Dim flag As Boolean = Char.IsControl(keyChar)
			If Not flag Then
				Dim flag2 As Boolean = Char.IsDigit(keyChar) OrElse keyChar = "."c
				If flag2 Then
					Dim text As String = Me.OvertimeRate.Text
					Dim selectionStart As Integer = Me.OvertimeRate.SelectionStart
					Dim selectionLength As Integer = Me.OvertimeRate.SelectionLength
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

		' Token: 0x0600C21B RID: 49691 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub Deduction_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600C21C RID: 49692 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub OvertimeRate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600C21D RID: 49693 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub paymentmode_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600C21E RID: 49694 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub PaymentModeDetails_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600C21F RID: 49695 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub PaymentDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600C220 RID: 49696 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub DateFrom_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600C221 RID: 49697 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub DateTo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600C222 RID: 49698 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEmployeePayment_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C223 RID: 49699 RVA: 0x007B4E40 File Offset: 0x007B3040
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.paymentmode.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.paymentmode, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.paymentmode, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.OvertimeRate.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.OvertimeRate, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.OvertimeRate, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.Deduction.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.Deduction, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.Deduction, String.Empty)
			End If
		End Sub

		' Token: 0x0600C224 RID: 49700 RVA: 0x007B4F34 File Offset: 0x007B3134
		Public Sub fillAccountInfo()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(AccountNo) FROM BankAccountRegistration where Active='Yes' order by 1", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbAccountNo.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbAccountNo.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600C225 RID: 49701 RVA: 0x007B505C File Offset: 0x007B325C
		Private Sub paymentmode_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.paymentmode.SelectedIndex = 1 OrElse Me.paymentmode.SelectedIndex = 2
			If flag Then
				Me.cmbAccountNo.Enabled = True
			Else
				Me.cmbAccountNo.SelectedIndex = -1
				Me.cmbAccountNo.Enabled = False
			End If
		End Sub

		' Token: 0x0600C226 RID: 49702 RVA: 0x00132EA4 File Offset: 0x001310A4
		Private Sub cmbAccountNo_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				SendKeys.Send("{TAB}")
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x0600C227 RID: 49703 RVA: 0x00056C63 File Offset: 0x00054E63
		Private Sub btnPrint_Click(sender As Object, e As EventArgs)
			Me.Print()
		End Sub

		' Token: 0x0600C228 RID: 49704 RVA: 0x00056C6D File Offset: 0x00054E6D
		Private Sub btngetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmEmployeePaymentRecord.lblSet.Text = "Payment"
			MyProject.Forms.frmEmployeePaymentRecord.Reset()
			MyProject.Forms.frmEmployeePaymentRecord.ShowDialog()
		End Sub

		' Token: 0x0600C229 RID: 49705 RVA: 0x007B50BC File Offset: 0x007B32BC
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

		' Token: 0x0600C22A RID: 49706 RVA: 0x007B5124 File Offset: 0x007B3324
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.EmployeeID.Text)) = 0
				If flag Then
					MessageBox.Show("Please retrieve employee id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.EmployeeID.Focus()
				Else
					Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.OvertimeRate.Text)) = 0
					If flag2 Then
						MessageBox.Show("Please enter overtime rate", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.OvertimeRate.Focus()
					Else
						Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.paymentmode.Text)) = 0
						If flag3 Then
							MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.paymentmode.Focus()
						Else
							Dim flag4 As Boolean = Me.paymentmode.SelectedIndex = 1 OrElse Me.paymentmode.SelectedIndex = 2
							If flag4 Then
								Dim flag5 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
								If flag5 Then
									MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.cmbAccountNo.Focus()
									Return
								End If
							End If
							Dim flag6 As Boolean = Operators.CompareString(Me.OvertimeAmount.Text, Nothing, False) = 0
							If flag6 Then
								Me.OvertimeAmount.Text = Conversions.ToString(0)
							End If
							Dim flag7 As Boolean = Operators.CompareString(Me.Advance.Text, Nothing, False) = 0
							If flag7 Then
								Me.Advance.Text = Conversions.ToString(0)
							End If
							Dim flag8 As Boolean = Conversion.Val(Me.Advance.Text) < Conversion.Val(Me.Deduction.Text)
							If flag8 Then
								MessageBox.Show("You can not deduct amount more than advance amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Me.Deduction.Focus()
							Else
								Dim flag9 As Boolean = Conversion.Val(Me.NetPay.Text) <= 0.0
								If flag9 Then
									MessageBox.Show("Net pay should be more than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Else
									Dim flag10 As Boolean = DateTime.Compare(Me.DateTo.Value.[Date], Me.DateFrom.Value.[Date]) < 0
									If flag10 Then
										MessageBox.Show("Selected 'Date To' must be greater than 'Date From'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
										Me.DateTo.Focus()
									Else
										Dim flag11 As Boolean = DateTime.Compare(Me.DateTo.Value.[Date], Me.DateFrom.Value.[Date]) = 0
										If flag11 Then
											MessageBox.Show("Selected 'Date From' is equal to 'Date To'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Me.DateFrom.Focus()
										Else
											ModCommonClasses.con = New SqlConnection(ModCS.cs)
											ModCommonClasses.con.Open()
											Dim text As String = If(("update employeepayment set PaymentID=@d1,EmployeeID=@d4,PresentDays=@d5,Salary=@d6,Advance=@d7,Deduction=@d8,OverTime=@d9,OverTimeRate=@d10,OverTimeAmount=@d11,ModeOfPayment=@d13,PaymentModeDetails=@d14,Netpay=@d15,BankAccount=@d16 where ID=" + Me.txtID.Text), "")
											ModCommonClasses.cmd = New SqlCommand(text)
											ModCommonClasses.cmd.Connection = ModCommonClasses.con
											ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.PaymentID.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtEmpID.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.PresentDays.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.Salary.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.Advance.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.Deduction.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.Overtime.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.OvertimeRate.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.OvertimeAmount.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.paymentmode.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.PaymentModeDetails.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(Me.NetPay.Text))
											ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.cmbAccountNo.Text)
											ModCommonClasses.cmd.ExecuteNonQuery()
											ModCommonClasses.con.Close()
											Dim flag12 As Boolean = Conversion.Val(Me.NetPay.Text) > 0.0
											If flag12 Then
												ModFunc.LedgerDelete(Me.PaymentID.Text, "Payroll Payment")
												Dim flag13 As Boolean = Me.paymentmode.SelectedIndex = 0
												If flag13 Then
													ModFunc.LedgerSave(Me.PaymentDate.Value.[Date], "Cash Account", Me.PaymentID.Text, "Payroll Payment", New Decimal(Conversion.Val(Me.NetPay.Text)), 0D, Me.EmployeeID.Text, Me.EmployeeName.Text)
													ModFunc.LedgerSave(Me.PaymentDate.Value.[Date], Me.EmployeeName.Text, Me.PaymentID.Text, "Payroll Payment", 0D, New Decimal(Conversion.Val(Me.NetPay.Text)), Me.EmployeeID.Text, Me.EmployeeName.Text)
												End If
												Dim flag14 As Boolean = (Me.paymentmode.SelectedIndex = 1) Or (Me.paymentmode.SelectedIndex = 2)
												If flag14 Then
													ModFunc.LedgerSave(Me.PaymentDate.Value.[Date], "Bank Account", Me.PaymentID.Text, "Payroll Payment", New Decimal(Conversion.Val(Me.NetPay.Text)), 0D, Me.EmployeeID.Text, Me.EmployeeName.Text)
													ModFunc.LedgerSave(Me.PaymentDate.Value.[Date], Me.EmployeeName.Text, Me.PaymentID.Text, "Payroll Payment", 0D, New Decimal(Conversion.Val(Me.NetPay.Text)), Me.EmployeeID.Text, Me.EmployeeName.Text)
												End If
												ModFunc.BankAccountLedgerDelete(Me.PaymentID.Text, "Payroll Payment-By Cheque")
												ModFunc.BankAccountLedgerDelete(Me.PaymentID.Text, "Payroll Payment-By Online Transfer")
												Dim flag15 As Boolean = Me.paymentmode.SelectedIndex = 1
												If flag15 Then
													ModFunc.BankAccountLedgerSave(Me.PaymentDate.Value.[Date], Me.cmbAccountNo.Text, Me.PaymentID.Text, "Payroll Payment-By Cheque", New Decimal(Conversion.Val(Me.NetPay.Text)), 0D)
												End If
												Dim flag16 As Boolean = Me.paymentmode.SelectedIndex = 2
												If flag16 Then
													ModFunc.BankAccountLedgerSave(Me.PaymentDate.Value.[Date], Me.cmbAccountNo.Text, Me.PaymentID.Text, "Payroll Payment-By Online Transfer", New Decimal(Conversion.Val(Me.NetPay.Text)), 0D)
												End If
											End If
											Dim text2 As String = "updated the payment entry having payment id '" + Me.PaymentID.Text + "'"
											ModFunc.LogFunc(Me.lblUser.Text, text2)
											MessageBox.Show("Successfully Updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
											Me.btnUpdate.Enabled = False
											ModCommonClasses.con.Close()
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C22B RID: 49707 RVA: 0x007B59E8 File Offset: 0x007B3BE8
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.auto()
			Try
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
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.EmployeeID.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please retrieve employee id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.EmployeeID.Focus()
					Else
						Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.OvertimeRate.Text)) = 0
						If flag4 Then
							MessageBox.Show("Please enter overtime rate", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.OvertimeRate.Focus()
						Else
							Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.paymentmode.Text)) = 0
							If flag5 Then
								MessageBox.Show("Please select payment mode", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.paymentmode.Focus()
							Else
								Dim flag6 As Boolean = Me.paymentmode.SelectedIndex = 1 OrElse Me.paymentmode.SelectedIndex = 2
								If flag6 Then
									Dim flag7 As Boolean = Me.cmbAccountNo.SelectedIndex = -1
									If flag7 Then
										MessageBox.Show("Please select bank account number", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
										Me.cmbAccountNo.Focus()
										Return
									End If
								End If
								Dim flag8 As Boolean = Operators.CompareString(Me.OvertimeAmount.Text, Nothing, False) = 0
								If flag8 Then
									Me.OvertimeAmount.Text = Conversions.ToString(0)
								End If
								Dim flag9 As Boolean = Operators.CompareString(Me.Advance.Text, Nothing, False) = 0
								If flag9 Then
									Me.Advance.Text = Conversions.ToString(0)
								End If
								Dim flag10 As Boolean = Conversion.Val(Me.Advance.Text) < Conversion.Val(Me.Deduction.Text)
								If flag10 Then
									MessageBox.Show("You can not deduct amount more than advance amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Me.Deduction.Focus()
								Else
									Dim flag11 As Boolean = Conversion.Val(Me.NetPay.Text) <= 0.0
									If flag11 Then
										MessageBox.Show("Net pay should be more than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Else
										Dim flag12 As Boolean = DateTime.Compare(Me.DateTo.Value.[Date], Me.DateFrom.Value.[Date]) < 0
										If flag12 Then
											MessageBox.Show("Selected 'Date To' must be greater than 'Date From'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
											Me.DateTo.Focus()
										Else
											Dim flag13 As Boolean = DateTime.Compare(Me.DateTo.Value.[Date], Me.DateFrom.Value.[Date]) = 0
											If flag13 Then
												MessageBox.Show("Selected 'Date From' is equal to 'Date To'", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
												Me.DateFrom.Focus()
											Else
												ModCommonClasses.con = New SqlConnection(ModCS.cs)
												ModCommonClasses.con.Open()
												Dim text2 As String = If(("SELECT * FROM EmployeePayment WHERE DateFrom <= @d1 AND DateTo >= @d2 and EmployeeID=" + Me.txtEmpID.Text), "")
												ModCommonClasses.cmd = New SqlCommand(text2)
												ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.DateTo.Value.[Date])
												ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.DateFrom.Value.[Date])
												ModCommonClasses.cmd.Connection = ModCommonClasses.con
												ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
												Dim flag14 As Boolean = ModCommonClasses.rdr.Read()
												If flag14 Then
													MessageBox.Show("Salary already paid..Select correct payment date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
													Dim flag15 As Boolean = ModCommonClasses.rdr IsNot Nothing
													If flag15 Then
														ModCommonClasses.rdr.Close()
													End If
												Else
													ModCommonClasses.con = New SqlConnection(ModCS.cs)
													ModCommonClasses.con.Open()
													Dim text3 As String = "insert into employeepayment(ID,PaymentID,DateFrom,DateTo,EmployeeID,PresentDays,Salary,Advance,Deduction,OverTime,OverTimeRate,OverTimeAmount,PaymentDate,ModeOfPayment,PaymentModeDetails,Netpay,BankAccount) values(" + Me.txtID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16)"
													ModCommonClasses.cmd = New SqlCommand(text3)
													ModCommonClasses.cmd.Connection = ModCommonClasses.con
													ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.PaymentID.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.DateFrom.Value.[Date])
													ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.DateTo.Value.[Date])
													ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.txtEmpID.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Conversion.Val(Me.PresentDays.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(Me.Salary.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Conversion.Val(Me.Advance.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Me.Deduction.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d9", Me.Overtime.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Conversion.Val(Me.OvertimeRate.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d11", Conversion.Val(Me.OvertimeAmount.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Me.PaymentDate.Value)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Me.paymentmode.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Me.PaymentModeDetails.Text)
													ModCommonClasses.cmd.Parameters.AddWithValue("@d15", Conversion.Val(Me.NetPay.Text))
													ModCommonClasses.cmd.Parameters.AddWithValue("@d16", Me.cmbAccountNo.Text)
													ModCommonClasses.cmd.ExecuteNonQuery()
													ModCommonClasses.con.Close()
													Dim flag16 As Boolean = Conversion.Val(Me.Deduction.Text) > 0.0
													If flag16 Then
														Me.auto1()
														ModCommonClasses.con = New SqlConnection(ModCS.cs)
														ModCommonClasses.con.Open()
														Dim text4 As String = "insert into advanceentry(ID,workingdate,employeeid,amount,deduction) VALUES (" + Me.txtID1.Text + ",@d1,@d2,@d3,@d4)"
														ModCommonClasses.cmd = New SqlCommand(text4)
														ModCommonClasses.cmd.Connection = ModCommonClasses.con
														ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.PaymentDate.Value)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtEmpID.Text))
														ModCommonClasses.cmd.Parameters.AddWithValue("@d3", 0)
														ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(Me.Deduction.Text))
														ModCommonClasses.cmd.ExecuteReader()
														ModCommonClasses.con.Close()
													End If
													Dim flag17 As Boolean = Conversion.Val(Me.NetPay.Text) > 0.0
													If flag17 Then
														Dim flag18 As Boolean = Me.paymentmode.SelectedIndex = 0
														If flag18 Then
															ModFunc.LedgerSave(Me.PaymentDate.Value.[Date], "Cash Account", Me.PaymentID.Text, "Payroll Payment", New Decimal(Conversion.Val(Me.NetPay.Text)), 0D, Me.EmployeeID.Text, Me.EmployeeName.Text)
															ModFunc.LedgerSave(Me.PaymentDate.Value.[Date], Me.EmployeeName.Text, Me.PaymentID.Text, "Payroll Payment", 0D, New Decimal(Conversion.Val(Me.NetPay.Text)), Me.EmployeeID.Text, Me.EmployeeName.Text)
														End If
														Dim flag19 As Boolean = Me.paymentmode.SelectedIndex = 1 OrElse Me.paymentmode.SelectedIndex = 2
														If flag19 Then
															ModFunc.LedgerSave(Me.PaymentDate.Value.[Date], "Bank Account", Me.PaymentID.Text, "Payroll Payment", New Decimal(Conversion.Val(Me.NetPay.Text)), 0D, Me.EmployeeID.Text, Me.EmployeeName.Text)
															ModFunc.LedgerSave(Me.PaymentDate.Value.[Date], Me.EmployeeName.Text, Me.PaymentID.Text, "Payroll Payment", 0D, New Decimal(Conversion.Val(Me.NetPay.Text)), Me.EmployeeID.Text, Me.EmployeeName.Text)
														End If
														Dim flag20 As Boolean = Me.paymentmode.SelectedIndex = 1
														If flag20 Then
															ModFunc.BankAccountLedgerSave(Me.PaymentDate.Value.[Date], Me.cmbAccountNo.Text, Me.PaymentID.Text, "Payroll Payment-By Cheque", New Decimal(Conversion.Val(Me.NetPay.Text)), 0D)
														End If
														Dim flag21 As Boolean = Me.paymentmode.SelectedIndex = 2
														If flag21 Then
															ModFunc.BankAccountLedgerSave(Me.PaymentDate.Value.[Date], Me.cmbAccountNo.Text, Me.PaymentID.Text, "Payroll Payment-By Online Transfer", New Decimal(Conversion.Val(Me.NetPay.Text)), 0D)
														End If
													End If
													Dim text5 As String = "added the new payment entry having payment id '" + Me.PaymentID.Text + "'"
													ModFunc.LogFunc(Me.lblUser.Text, text5)
													MessageBox.Show("Successfully Paid", "Employee", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
													Me.btnSave.Enabled = False
													ModCommonClasses.con.Close()
													Me.Print()
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C22C RID: 49708 RVA: 0x00056CAA File Offset: 0x00054EAA
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Reset()
		End Sub
	End Class
End Namespace
