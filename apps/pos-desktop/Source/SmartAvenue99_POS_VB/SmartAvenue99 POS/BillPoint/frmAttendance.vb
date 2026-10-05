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
	' Token: 0x0200032D RID: 813
	<DesignerGenerated()>
	Public Partial Class frmAttendance
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BEAC RID: 48812 RVA: 0x00055365 File Offset: 0x00053565
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAdvanceEntry_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAttendance_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004BEA RID: 19434
		' (get) Token: 0x0600BEAF RID: 48815 RVA: 0x00055397 File Offset: 0x00053597
		' (set) Token: 0x0600BEB0 RID: 48816 RVA: 0x000553A1 File Offset: 0x000535A1
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004BEB RID: 19435
		' (get) Token: 0x0600BEB1 RID: 48817 RVA: 0x000553AA File Offset: 0x000535AA
		' (set) Token: 0x0600BEB2 RID: 48818 RVA: 0x000553B4 File Offset: 0x000535B4
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004BEC RID: 19436
		' (get) Token: 0x0600BEB3 RID: 48819 RVA: 0x000553BD File Offset: 0x000535BD
		' (set) Token: 0x0600BEB4 RID: 48820 RVA: 0x000553C7 File Offset: 0x000535C7
		Friend Overridable Property Label1 As Label

		' Token: 0x17004BED RID: 19437
		' (get) Token: 0x0600BEB5 RID: 48821 RVA: 0x000553D0 File Offset: 0x000535D0
		' (set) Token: 0x0600BEB6 RID: 48822 RVA: 0x000553DA File Offset: 0x000535DA
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog

		' Token: 0x17004BEE RID: 19438
		' (get) Token: 0x0600BEB7 RID: 48823 RVA: 0x000553E3 File Offset: 0x000535E3
		' (set) Token: 0x0600BEB8 RID: 48824 RVA: 0x000553ED File Offset: 0x000535ED
		Friend Overridable Property Timer1 As Timer

		' Token: 0x17004BEF RID: 19439
		' (get) Token: 0x0600BEB9 RID: 48825 RVA: 0x000553F6 File Offset: 0x000535F6
		' (set) Token: 0x0600BEBA RID: 48826 RVA: 0x00055400 File Offset: 0x00053600
		Friend Overridable Property txtID As TextBox

		' Token: 0x17004BF0 RID: 19440
		' (get) Token: 0x0600BEBB RID: 48827 RVA: 0x00055409 File Offset: 0x00053609
		' (set) Token: 0x0600BEBC RID: 48828 RVA: 0x00055413 File Offset: 0x00053613
		Friend Overridable Property lblUser As Label

		' Token: 0x17004BF1 RID: 19441
		' (get) Token: 0x0600BEBD RID: 48829 RVA: 0x0005541C File Offset: 0x0005361C
		' (set) Token: 0x0600BEBE RID: 48830 RVA: 0x0079B390 File Offset: 0x00799590
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

		' Token: 0x17004BF2 RID: 19442
		' (get) Token: 0x0600BEBF RID: 48831 RVA: 0x00055426 File Offset: 0x00053626
		' (set) Token: 0x0600BEC0 RID: 48832 RVA: 0x00055430 File Offset: 0x00053630
		Friend Overridable Property txtEmpID As TextBox

		' Token: 0x17004BF3 RID: 19443
		' (get) Token: 0x0600BEC1 RID: 48833 RVA: 0x00055439 File Offset: 0x00053639
		' (set) Token: 0x0600BEC2 RID: 48834 RVA: 0x00055443 File Offset: 0x00053643
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004BF4 RID: 19444
		' (get) Token: 0x0600BEC3 RID: 48835 RVA: 0x0005544C File Offset: 0x0005364C
		' (set) Token: 0x0600BEC4 RID: 48836 RVA: 0x00055456 File Offset: 0x00053656
		Friend Overridable Property EmployeeID As TextBox

		' Token: 0x17004BF5 RID: 19445
		' (get) Token: 0x0600BEC5 RID: 48837 RVA: 0x0005545F File Offset: 0x0005365F
		' (set) Token: 0x0600BEC6 RID: 48838 RVA: 0x0079B3F0 File Offset: 0x007995F0
		Private _txtInTime As TextBox
		Friend Overridable Property txtInTime As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtInTime
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtInTime
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtInTime = value
				textBox = Me._txtInTime
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004BF6 RID: 19446
		' (get) Token: 0x0600BEC7 RID: 48839 RVA: 0x00055469 File Offset: 0x00053669
		' (set) Token: 0x0600BEC8 RID: 48840 RVA: 0x0079B434 File Offset: 0x00799634
		Private _txtOutTime As TextBox
		Friend Overridable Property txtOutTime As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtOutTime
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim textBox As TextBox = Me._txtOutTime
				If textBox IsNot Nothing Then
					RemoveHandler textBox.Validating, cancelEventHandler
				End If
				Me._txtOutTime = value
				textBox = Me._txtOutTime
				If textBox IsNot Nothing Then
					AddHandler textBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004BF7 RID: 19447
		' (get) Token: 0x0600BEC9 RID: 48841 RVA: 0x00055473 File Offset: 0x00053673
		' (set) Token: 0x0600BECA RID: 48842 RVA: 0x0005547D File Offset: 0x0005367D
		Friend Overridable Property BasicWorkingTime As TextBox

		' Token: 0x17004BF8 RID: 19448
		' (get) Token: 0x0600BECB RID: 48843 RVA: 0x00055486 File Offset: 0x00053686
		' (set) Token: 0x0600BECC RID: 48844 RVA: 0x00055490 File Offset: 0x00053690
		Friend Overridable Property Label9 As Label

		' Token: 0x17004BF9 RID: 19449
		' (get) Token: 0x0600BECD RID: 48845 RVA: 0x00055499 File Offset: 0x00053699
		' (set) Token: 0x0600BECE RID: 48846 RVA: 0x0079B478 File Offset: 0x00799678
		Private _Status As ComboBox
		Friend Overridable Property Status As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._Status
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.Status_SelectedIndexChanged
				Dim cancelEventHandler As CancelEventHandler = AddressOf Me.TV
				Dim comboBox As ComboBox = Me._Status
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
					RemoveHandler comboBox.Validating, cancelEventHandler
				End If
				Me._Status = value
				comboBox = Me._Status
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
					AddHandler comboBox.Validating, cancelEventHandler
				End If
			End Set
		End Property

		' Token: 0x17004BFA RID: 19450
		' (get) Token: 0x0600BECF RID: 48847 RVA: 0x000554A3 File Offset: 0x000536A3
		' (set) Token: 0x0600BED0 RID: 48848 RVA: 0x000554AD File Offset: 0x000536AD
		Friend Overridable Property Label8 As Label

		' Token: 0x17004BFB RID: 19451
		' (get) Token: 0x0600BED1 RID: 48849 RVA: 0x000554B6 File Offset: 0x000536B6
		' (set) Token: 0x0600BED2 RID: 48850 RVA: 0x0079B4D8 File Offset: 0x007996D8
		Private _OutTime As DateTimePicker
		Friend Overridable Property OutTime As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._OutTime
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.OutTime_ValueChanged
				Dim dateTimePicker As DateTimePicker = Me._OutTime
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.ValueChanged, eventHandler
				End If
				Me._OutTime = value
				dateTimePicker = Me._OutTime
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004BFC RID: 19452
		' (get) Token: 0x0600BED3 RID: 48851 RVA: 0x000554C0 File Offset: 0x000536C0
		' (set) Token: 0x0600BED4 RID: 48852 RVA: 0x0079B51C File Offset: 0x0079971C
		Private _InTime As DateTimePicker
		Friend Overridable Property InTime As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._InTime
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim eventHandler As EventHandler = AddressOf Me.InTime_ValueChanged
				Dim dateTimePicker As DateTimePicker = Me._InTime
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.ValueChanged, eventHandler
				End If
				Me._InTime = value
				dateTimePicker = Me._InTime
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.ValueChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004BFD RID: 19453
		' (get) Token: 0x0600BED5 RID: 48853 RVA: 0x000554CA File Offset: 0x000536CA
		' (set) Token: 0x0600BED6 RID: 48854 RVA: 0x000554D4 File Offset: 0x000536D4
		Friend Overridable Property Label7 As Label

		' Token: 0x17004BFE RID: 19454
		' (get) Token: 0x0600BED7 RID: 48855 RVA: 0x000554DD File Offset: 0x000536DD
		' (set) Token: 0x0600BED8 RID: 48856 RVA: 0x000554E7 File Offset: 0x000536E7
		Friend Overridable Property Overtime As TextBox

		' Token: 0x17004BFF RID: 19455
		' (get) Token: 0x0600BED9 RID: 48857 RVA: 0x000554F0 File Offset: 0x000536F0
		' (set) Token: 0x0600BEDA RID: 48858 RVA: 0x000554FA File Offset: 0x000536FA
		Friend Overridable Property EmployeeName As TextBox

		' Token: 0x17004C00 RID: 19456
		' (get) Token: 0x0600BEDB RID: 48859 RVA: 0x00055503 File Offset: 0x00053703
		' (set) Token: 0x0600BEDC RID: 48860 RVA: 0x0005550D File Offset: 0x0005370D
		Friend Overridable Property WorkingDate As DateTimePicker

		' Token: 0x17004C01 RID: 19457
		' (get) Token: 0x0600BEDD RID: 48861 RVA: 0x00055516 File Offset: 0x00053716
		' (set) Token: 0x0600BEDE RID: 48862 RVA: 0x00055520 File Offset: 0x00053720
		Friend Overridable Property Label6 As Label

		' Token: 0x17004C02 RID: 19458
		' (get) Token: 0x0600BEDF RID: 48863 RVA: 0x00055529 File Offset: 0x00053729
		' (set) Token: 0x0600BEE0 RID: 48864 RVA: 0x00055533 File Offset: 0x00053733
		Friend Overridable Property Label5 As Label

		' Token: 0x17004C03 RID: 19459
		' (get) Token: 0x0600BEE1 RID: 48865 RVA: 0x0005553C File Offset: 0x0005373C
		' (set) Token: 0x0600BEE2 RID: 48866 RVA: 0x00055546 File Offset: 0x00053746
		Friend Overridable Property Label4 As Label

		' Token: 0x17004C04 RID: 19460
		' (get) Token: 0x0600BEE3 RID: 48867 RVA: 0x0005554F File Offset: 0x0005374F
		' (set) Token: 0x0600BEE4 RID: 48868 RVA: 0x00055559 File Offset: 0x00053759
		Friend Overridable Property Label3 As Label

		' Token: 0x17004C05 RID: 19461
		' (get) Token: 0x0600BEE5 RID: 48869 RVA: 0x00055562 File Offset: 0x00053762
		' (set) Token: 0x0600BEE6 RID: 48870 RVA: 0x0005556C File Offset: 0x0005376C
		Friend Overridable Property Label2 As Label

		' Token: 0x17004C06 RID: 19462
		' (get) Token: 0x0600BEE7 RID: 48871 RVA: 0x00055575 File Offset: 0x00053775
		' (set) Token: 0x0600BEE8 RID: 48872 RVA: 0x0005557F File Offset: 0x0005377F
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004C07 RID: 19463
		' (get) Token: 0x0600BEE9 RID: 48873 RVA: 0x00055588 File Offset: 0x00053788
		' (set) Token: 0x0600BEEA RID: 48874 RVA: 0x0079B560 File Offset: 0x00799760
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

		' Token: 0x17004C08 RID: 19464
		' (get) Token: 0x0600BEEB RID: 48875 RVA: 0x00055592 File Offset: 0x00053792
		' (set) Token: 0x0600BEEC RID: 48876 RVA: 0x0005559C File Offset: 0x0005379C
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17004C09 RID: 19465
		' (get) Token: 0x0600BEED RID: 48877 RVA: 0x000555A5 File Offset: 0x000537A5
		' (set) Token: 0x0600BEEE RID: 48878 RVA: 0x000555AF File Offset: 0x000537AF
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004C0A RID: 19466
		' (get) Token: 0x0600BEEF RID: 48879 RVA: 0x000555B8 File Offset: 0x000537B8
		' (set) Token: 0x0600BEF0 RID: 48880 RVA: 0x000555C2 File Offset: 0x000537C2
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004C0B RID: 19467
		' (get) Token: 0x0600BEF1 RID: 48881 RVA: 0x000555CB File Offset: 0x000537CB
		' (set) Token: 0x0600BEF2 RID: 48882 RVA: 0x000555D5 File Offset: 0x000537D5
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17004C0C RID: 19468
		' (get) Token: 0x0600BEF3 RID: 48883 RVA: 0x000555DE File Offset: 0x000537DE
		' (set) Token: 0x0600BEF4 RID: 48884 RVA: 0x000555E8 File Offset: 0x000537E8
		Friend Overridable Property ErrorProvider1 As ErrorProvider

		' Token: 0x17004C0D RID: 19469
		' (get) Token: 0x0600BEF5 RID: 48885 RVA: 0x000555F1 File Offset: 0x000537F1
		' (set) Token: 0x0600BEF6 RID: 48886 RVA: 0x000555FB File Offset: 0x000537FB
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17004C0E RID: 19470
		' (get) Token: 0x0600BEF7 RID: 48887 RVA: 0x00055604 File Offset: 0x00053804
		' (set) Token: 0x0600BEF8 RID: 48888 RVA: 0x0079B5A4 File Offset: 0x007997A4
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

		' Token: 0x17004C0F RID: 19471
		' (get) Token: 0x0600BEF9 RID: 48889 RVA: 0x0005560E File Offset: 0x0005380E
		' (set) Token: 0x0600BEFA RID: 48890 RVA: 0x0079B5E8 File Offset: 0x007997E8
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

		' Token: 0x17004C10 RID: 19472
		' (get) Token: 0x0600BEFB RID: 48891 RVA: 0x00055618 File Offset: 0x00053818
		' (set) Token: 0x0600BEFC RID: 48892 RVA: 0x0079B62C File Offset: 0x0079982C
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

		' Token: 0x17004C11 RID: 19473
		' (get) Token: 0x0600BEFD RID: 48893 RVA: 0x00055622 File Offset: 0x00053822
		' (set) Token: 0x0600BEFE RID: 48894 RVA: 0x0079B670 File Offset: 0x00799870
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

		' Token: 0x17004C12 RID: 19474
		' (get) Token: 0x0600BEFF RID: 48895 RVA: 0x0005562C File Offset: 0x0005382C
		' (set) Token: 0x0600BF00 RID: 48896 RVA: 0x0079B6B4 File Offset: 0x007998B4
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

		' Token: 0x0600BF01 RID: 48897 RVA: 0x0079B6F8 File Offset: 0x007998F8
		Public Sub Reset()
			Me.WorkingDate.Text = Conversions.ToString(DateAndTime.Today)
			Me.EmployeeID.Text = ""
			Me.EmployeeName.Text = ""
			Me.InTime.Text = Conversions.ToString(DateAndTime.Now)
			Me.OutTime.Text = Conversions.ToString(DateAndTime.Now)
			Me.Overtime.Text = ""
			Me.Status.SelectedIndex = -1
			Me.BasicWorkingTime.Text = ""
			Me.txtEmployee.Text = ""
			Me.GetData()
			Me.btnDelete.Enabled = False
			Me.btnUpdate.Enabled = False
			Me.txtOutTime.Visible = False
			Me.txtInTime.Visible = False
			Me.btnSave.Enabled = True
			Me.WorkingDate.Enabled = True
			Me.InTime.Enabled = False
			Me.OutTime.Enabled = False
		End Sub

		' Token: 0x0600BF02 RID: 48898 RVA: 0x0079B81C File Offset: 0x00799A1C
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(EmployeeRegistration.ID),RTRIM(EmployeeRegistration.EmployeeID),RTRIM(EmployeeName),RTRIM(BasicWorkingTime) from EmployeeRegistration where Active='Yes' order by EmployeeName"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BF03 RID: 48899 RVA: 0x0079B92C File Offset: 0x00799B2C
		Private Sub DeleteRecord()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = If(("delete from EmployeeAttendance where id=" + Me.txtID.Text), "")
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				Dim num As Integer = ModCommonClasses.cmd.ExecuteNonQuery()
				Dim flag As Boolean = num > 0
				If flag Then
					Dim text2 As String = "deleted the attendance entry having id '" + Me.txtID.Text + "'"
					ModFunc.LogFunc(Me.lblUser.Text, text2)
					MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.GetData()
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

		' Token: 0x0600BF04 RID: 48900 RVA: 0x00055636 File Offset: 0x00053836
		Private Sub frmAdvanceEntry_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600BF05 RID: 48901 RVA: 0x0079BA6C File Offset: 0x00799C6C
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

		' Token: 0x0600BF06 RID: 48902 RVA: 0x0079BBE4 File Offset: 0x00799DE4
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

		' Token: 0x0600BF07 RID: 48903 RVA: 0x0079BCA0 File Offset: 0x00799EA0
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

		' Token: 0x0600BF08 RID: 48904 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600BF09 RID: 48905 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600BF0A RID: 48906 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600BF0B RID: 48907 RVA: 0x0079BD6C File Offset: 0x00799F6C
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
					Me.txtEmpID.Text = dataGridViewRow.Cells(0).Value.ToString()
					Me.EmployeeID.Text = dataGridViewRow.Cells(1).Value.ToString()
					Me.EmployeeName.Text = dataGridViewRow.Cells(2).Value.ToString()
					Me.BasicWorkingTime.Text = dataGridViewRow.Cells(3).Value.ToString()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BF0C RID: 48908 RVA: 0x0079BE68 File Offset: 0x0079A068
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

		' Token: 0x0600BF0D RID: 48909 RVA: 0x0079BF50 File Offset: 0x0079A150
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 (ID) FROM EmployeeAttendance ORDER BY ID DESC", ModCommonClasses.con)
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

		' Token: 0x0600BF0E RID: 48910 RVA: 0x0079C0BC File Offset: 0x0079A2BC
		Public Sub auto()
			Try
				Me.txtID.Text = Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BF0F RID: 48911 RVA: 0x0079C114 File Offset: 0x0079A314
		Private Sub Status_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.Status.Text, "P", False) = 0
			If flag Then
				Me.txtOutTime.Visible = False
				Me.txtInTime.Visible = False
				Me.InTime.Enabled = True
				Me.OutTime.Enabled = True
				Me.InTime.Text = Conversions.ToString(DateAndTime.Now)
				Me.OutTime.Text = Conversions.ToString(DateAndTime.Now)
				Me.Overtime.Text = ""
			Else
				Dim flag2 As Boolean = Operators.CompareString(Me.Status.Text, "A", False) = 0
				If flag2 Then
					Me.txtOutTime.Visible = True
					Me.txtInTime.Visible = True
					Me.txtOutTime.Text = "00:00:00"
					Me.txtInTime.Text = "00:00:00"
					Me.Overtime.Text = "00:00:00"
				End If
			End If
		End Sub

		' Token: 0x0600BF10 RID: 48912 RVA: 0x0079C220 File Offset: 0x0079A420
		Private Sub InTime_ValueChanged(sender As Object, e As EventArgs)
			Dim timeSpan As TimeSpan
			TimeSpan.TryParse(Me.BasicWorkingTime.Text, timeSpan)
			Dim timeSpan2 As TimeSpan = Me.OutTime.Value - Me.InTime.Value
			Me.Overtime.Text = Convert.ToString(timeSpan2 - timeSpan)
		End Sub

		' Token: 0x0600BF11 RID: 48913 RVA: 0x0079C220 File Offset: 0x0079A420
		Private Sub OutTime_ValueChanged(sender As Object, e As EventArgs)
			Dim timeSpan As TimeSpan
			TimeSpan.TryParse(Me.BasicWorkingTime.Text, timeSpan)
			Dim timeSpan2 As TimeSpan = Me.OutTime.Value - Me.InTime.Value
			Me.Overtime.Text = Convert.ToString(timeSpan2 - timeSpan)
		End Sub

		' Token: 0x0600BF12 RID: 48914 RVA: 0x0079C27C File Offset: 0x0079A47C
		Private Sub txtEmployee_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT RTRIM(EmployeeRegistration.ID),RTRIM(EmployeeRegistration.EmployeeID),RTRIM(EmployeeName),RTRIM(BasicWorkingTime) from EmployeeRegistration where Active='Yes' and EmployeeName like N'%" + Me.txtEmployee.Text + "%' order by EmployeeName"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BF13 RID: 48915 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAttendance_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BF14 RID: 48916 RVA: 0x0079C3A0 File Offset: 0x0079A5A0
		Private Sub TV(sender As Object, e As CancelEventArgs)
			Dim flag As Boolean = String.IsNullOrEmpty(Me.txtOutTime.Text.Trim())
			If flag Then
				Me.ErrorProvider1.SetError(Me.txtOutTime, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtOutTime, String.Empty)
			End If
			Dim flag2 As Boolean = String.IsNullOrEmpty(Me.txtInTime.Text.Trim())
			If flag2 Then
				Me.ErrorProvider1.SetError(Me.txtInTime, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.txtInTime, String.Empty)
			End If
			Dim flag3 As Boolean = String.IsNullOrEmpty(Me.Status.Text.Trim())
			If flag3 Then
				Me.ErrorProvider1.SetError(Me.Status, "Please Fill")
			Else
				Me.ErrorProvider1.SetError(Me.Status, String.Empty)
			End If
		End Sub

		' Token: 0x0600BF15 RID: 48917 RVA: 0x00055647 File Offset: 0x00053847
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600BF16 RID: 48918 RVA: 0x0079C494 File Offset: 0x0079A694
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
				Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.EmployeeID.Text)) = 0
				If flag3 Then
					MessageBox.Show("Please retrieve employee id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.EmployeeID.Focus()
				Else
					Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.Status.Text)) = 0
					If flag4 Then
						MessageBox.Show("Please select Status", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.Status.Focus()
					Else
						Dim flag5 As Boolean = Strings.Len(Strings.Trim(Me.Overtime.Text)) = 0
						If flag5 Then
							MessageBox.Show("Please select retrieve overtime", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.Overtime.Focus()
						Else
							Try
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text2 As String = "select employeeid,workingdate from employeeattendance where employeeid=" + Me.txtEmpID.Text + " and workingdate=@d1"
								ModCommonClasses.cmd = New SqlCommand(text2)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Convert.ToDateTime(Me.WorkingDate.Value.[Date]))
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag6 As Boolean = ModCommonClasses.rdr.Read()
								If flag6 Then
									MessageBox.Show("Employee today's attendance is already saved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag7 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag7 Then
										ModCommonClasses.rdr.Close()
									End If
								Else
									Me.auto()
									ModCommonClasses.con = New SqlConnection(ModCS.cs)
									ModCommonClasses.con.Open()
									Dim text3 As String = "insert into employeeAttendance(ID,Workingdate,employeeid,status,intime,outtime,overtime,basicworkingtime) VALUES (" + Me.txtID.Text + ",@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
									ModCommonClasses.cmd = New SqlCommand(text3)
									ModCommonClasses.cmd.Connection = ModCommonClasses.con
									ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.WorkingDate.Value.[Date])
									ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtEmpID.Text))
									ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.Status.Text)
									Dim flag8 As Boolean = Operators.CompareString(Me.Status.Text, "P", False) = 0
									If flag8 Then
										ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.InTime.Text)
										ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.OutTime.Text)
									Else
										Dim flag9 As Boolean = Operators.CompareString(Me.Status.Text, "A", False) = 0
										If flag9 Then
											ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtInTime.Text)
											ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtOutTime.Text)
										End If
									End If
									ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.Overtime.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.BasicWorkingTime.Text)
									ModCommonClasses.cmd.ExecuteReader()
									Dim flag10 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
									If flag10 Then
										ModCommonClasses.con.Close()
									End If
									ModCommonClasses.con.Close()
									Dim text4 As String = "added the new attendance entry having id '" + Me.txtID.Text + "'"
									ModFunc.LogFunc(Me.lblUser.Text, text4)
									MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
									Me.btnSave.Enabled = False
									ModCommonClasses.con.Close()
									Me.GetData()
								End If
							Catch ex As Exception
								MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BF17 RID: 48919 RVA: 0x0079C988 File Offset: 0x0079AB88
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.EmployeeID.Text)) = 0
			If flag Then
				MessageBox.Show("Please retrieve employee id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.EmployeeID.Focus()
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.Status.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please select Status", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.Status.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.Overtime.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please select retrieve overtime", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.Overtime.Focus()
					Else
						Try
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text As String = If(("Update employeeAttendance set employeeid=@d2,status=@d3,intime=@d4,outtime=@d5,overtime=@d6,basicworkingtime=@d7 where ID=" + Me.txtID.Text), "")
							ModCommonClasses.cmd = New SqlCommand(text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(Me.txtEmpID.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.Status.Text)
							Dim flag4 As Boolean = Operators.CompareString(Me.Status.Text, "P", False) = 0
							If flag4 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.InTime.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.OutTime.Text)
							Else
								Dim flag5 As Boolean = Operators.CompareString(Me.Status.Text, "A", False) = 0
								If flag5 Then
									ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Me.txtInTime.Text)
									ModCommonClasses.cmd.Parameters.AddWithValue("@d5", Me.txtOutTime.Text)
								End If
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Me.Overtime.Text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.BasicWorkingTime.Text)
							ModCommonClasses.cmd.ExecuteReader()
							Dim flag6 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
							If flag6 Then
								ModCommonClasses.con.Close()
							End If
							ModCommonClasses.con.Close()
							Dim text2 As String = "updated the attendance entry having id '" + Me.txtID.Text + "'"
							ModFunc.LogFunc(Me.lblUser.Text, text2)
							MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.btnUpdate.Enabled = False
							ModCommonClasses.con.Close()
							Me.GetData()
						Catch ex As Exception
							MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x0600BF18 RID: 48920 RVA: 0x0079CCD8 File Offset: 0x0079AED8
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

		' Token: 0x0600BF19 RID: 48921 RVA: 0x00055651 File Offset: 0x00053851
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmAttendanceEntryRecord.lblSet.Text = "Attendance Entry"
			MyProject.Forms.frmAttendanceEntryRecord.Reset()
			MyProject.Forms.frmAttendanceEntryRecord.ShowDialog()
		End Sub
	End Class
End Namespace
