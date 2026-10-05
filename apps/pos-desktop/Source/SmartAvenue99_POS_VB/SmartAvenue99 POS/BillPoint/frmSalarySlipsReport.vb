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
	' Token: 0x0200036C RID: 876
	<DesignerGenerated()>
	Public Partial Class frmSalarySlipsReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CF30 RID: 53040 RVA: 0x0005C1A8 File Offset: 0x0005A3A8
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalarySlipsReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005150 RID: 20816
		' (get) Token: 0x0600CF33 RID: 53043 RVA: 0x0005C1DA File Offset: 0x0005A3DA
		' (set) Token: 0x0600CF34 RID: 53044 RVA: 0x0005C1E4 File Offset: 0x0005A3E4
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005151 RID: 20817
		' (get) Token: 0x0600CF35 RID: 53045 RVA: 0x0005C1ED File Offset: 0x0005A3ED
		' (set) Token: 0x0600CF36 RID: 53046 RVA: 0x0005C1F7 File Offset: 0x0005A3F7
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005152 RID: 20818
		' (get) Token: 0x0600CF37 RID: 53047 RVA: 0x0005C200 File Offset: 0x0005A400
		' (set) Token: 0x0600CF38 RID: 53048 RVA: 0x0005C20A File Offset: 0x0005A40A
		Friend Overridable Property Label1 As Label

		' Token: 0x17005153 RID: 20819
		' (get) Token: 0x0600CF39 RID: 53049 RVA: 0x0005C213 File Offset: 0x0005A413
		' (set) Token: 0x0600CF3A RID: 53050 RVA: 0x0005C21D File Offset: 0x0005A41D
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005154 RID: 20820
		' (get) Token: 0x0600CF3B RID: 53051 RVA: 0x0005C226 File Offset: 0x0005A426
		' (set) Token: 0x0600CF3C RID: 53052 RVA: 0x0005C230 File Offset: 0x0005A430
		Friend Overridable Property Label3 As Label

		' Token: 0x17005155 RID: 20821
		' (get) Token: 0x0600CF3D RID: 53053 RVA: 0x0005C239 File Offset: 0x0005A439
		' (set) Token: 0x0600CF3E RID: 53054 RVA: 0x0005C243 File Offset: 0x0005A443
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17005156 RID: 20822
		' (get) Token: 0x0600CF3F RID: 53055 RVA: 0x0005C24C File Offset: 0x0005A44C
		' (set) Token: 0x0600CF40 RID: 53056 RVA: 0x0005C256 File Offset: 0x0005A456
		Friend Overridable Property Label4 As Label

		' Token: 0x17005157 RID: 20823
		' (get) Token: 0x0600CF41 RID: 53057 RVA: 0x0005C25F File Offset: 0x0005A45F
		' (set) Token: 0x0600CF42 RID: 53058 RVA: 0x0005C269 File Offset: 0x0005A469
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17005158 RID: 20824
		' (get) Token: 0x0600CF43 RID: 53059 RVA: 0x0005C272 File Offset: 0x0005A472
		' (set) Token: 0x0600CF44 RID: 53060 RVA: 0x0005C27C File Offset: 0x0005A47C
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005159 RID: 20825
		' (get) Token: 0x0600CF45 RID: 53061 RVA: 0x0005C285 File Offset: 0x0005A485
		' (set) Token: 0x0600CF46 RID: 53062 RVA: 0x0005C28F File Offset: 0x0005A48F
		Friend Overridable Property cmbEmployeeName As ComboBox

		' Token: 0x1700515A RID: 20826
		' (get) Token: 0x0600CF47 RID: 53063 RVA: 0x0005C298 File Offset: 0x0005A498
		' (set) Token: 0x0600CF48 RID: 53064 RVA: 0x0005C2A2 File Offset: 0x0005A4A2
		Friend Overridable Property Label9 As Label

		' Token: 0x1700515B RID: 20827
		' (get) Token: 0x0600CF49 RID: 53065 RVA: 0x0005C2AB File Offset: 0x0005A4AB
		' (set) Token: 0x0600CF4A RID: 53066 RVA: 0x0005C2B5 File Offset: 0x0005A4B5
		Friend Overridable Property Label10 As Label

		' Token: 0x1700515C RID: 20828
		' (get) Token: 0x0600CF4B RID: 53067 RVA: 0x0005C2BE File Offset: 0x0005A4BE
		' (set) Token: 0x0600CF4C RID: 53068 RVA: 0x0005C2C8 File Offset: 0x0005A4C8
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700515D RID: 20829
		' (get) Token: 0x0600CF4D RID: 53069 RVA: 0x0005C2D1 File Offset: 0x0005A4D1
		' (set) Token: 0x0600CF4E RID: 53070 RVA: 0x0005C2DB File Offset: 0x0005A4DB
		Friend Overridable Property Label11 As Label

		' Token: 0x1700515E RID: 20830
		' (get) Token: 0x0600CF4F RID: 53071 RVA: 0x0005C2E4 File Offset: 0x0005A4E4
		' (set) Token: 0x0600CF50 RID: 53072 RVA: 0x0005C2EE File Offset: 0x0005A4EE
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700515F RID: 20831
		' (get) Token: 0x0600CF51 RID: 53073 RVA: 0x0005C2F7 File Offset: 0x0005A4F7
		' (set) Token: 0x0600CF52 RID: 53074 RVA: 0x0005C301 File Offset: 0x0005A501
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17005160 RID: 20832
		' (get) Token: 0x0600CF53 RID: 53075 RVA: 0x0005C30A File Offset: 0x0005A50A
		' (set) Token: 0x0600CF54 RID: 53076 RVA: 0x008155B0 File Offset: 0x008137B0
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

		' Token: 0x17005161 RID: 20833
		' (get) Token: 0x0600CF55 RID: 53077 RVA: 0x0005C314 File Offset: 0x0005A514
		' (set) Token: 0x0600CF56 RID: 53078 RVA: 0x0005C31E File Offset: 0x0005A51E
		Friend Overridable Property txtCompanyName As TextBox

		' Token: 0x17005162 RID: 20834
		' (get) Token: 0x0600CF57 RID: 53079 RVA: 0x0005C327 File Offset: 0x0005A527
		' (set) Token: 0x0600CF58 RID: 53080 RVA: 0x008155F4 File Offset: 0x008137F4
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005163 RID: 20835
		' (get) Token: 0x0600CF59 RID: 53081 RVA: 0x0005C331 File Offset: 0x0005A531
		' (set) Token: 0x0600CF5A RID: 53082 RVA: 0x00815638 File Offset: 0x00813838
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

		' Token: 0x17005164 RID: 20836
		' (get) Token: 0x0600CF5B RID: 53083 RVA: 0x0005C33B File Offset: 0x0005A53B
		' (set) Token: 0x0600CF5C RID: 53084 RVA: 0x0081567C File Offset: 0x0081387C
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

		' Token: 0x0600CF5D RID: 53085 RVA: 0x008156C0 File Offset: 0x008138C0
		Public Sub fillEmployee()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(EmployeeName) FROM EmployeeRegistration,EmployeePayment where EmployeeRegistration.ID=EmployeePayment.EmployeeID", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbEmployeeName.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbEmployeeName.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600CF5E RID: 53086 RVA: 0x0005C345 File Offset: 0x0005A545
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.GetCompanyname()
			Me.fillEmployee()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600CF5F RID: 53087 RVA: 0x008157E8 File Offset: 0x008139E8
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

		' Token: 0x0600CF60 RID: 53088 RVA: 0x00815960 File Offset: 0x00813B60
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

		' Token: 0x0600CF61 RID: 53089 RVA: 0x00815A1C File Offset: 0x00813C1C
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

		' Token: 0x0600CF62 RID: 53090 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600CF63 RID: 53091 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600CF64 RID: 53092 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600CF65 RID: 53093 RVA: 0x00815AE8 File Offset: 0x00813CE8
		Public Sub Reset()
			Me.cmbEmployeeName.SelectedIndex = -1
			Me.DateTimePicker1.Value = DateAndTime.Now
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Now
			Me.fillEmployee()
		End Sub

		' Token: 0x0600CF66 RID: 53094 RVA: 0x0005C35D File Offset: 0x0005A55D
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600CF67 RID: 53095 RVA: 0x00815B50 File Offset: 0x00813D50
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

		' Token: 0x0600CF68 RID: 53096 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalarySlipsReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CF69 RID: 53097 RVA: 0x0005C379 File Offset: 0x0005A579
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600CF6A RID: 53098 RVA: 0x00815C40 File Offset: 0x00813E40
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptSalarySlips As rptSalarySlips1 = New rptSalarySlips1()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT EmployeePayment.EmployeeID,EmployeeRegistration.ID,EmployeeRegistration.EmployeeName,EmployeeRegistration.Designation, EmployeePayment.PaymentID, EmployeePayment.DateFrom, EmployeePayment.DateTo, EmployeePayment.PresentDays, EmployeePayment.Salary,EmployeePayment.Advance, EmployeePayment.Deduction, EmployeePayment.Overtime, EmployeePayment.OvertimeRate, EmployeePayment.OvertimeAmount, EmployeePayment.PaymentDate,EmployeePayment.ModeOfPayment, EmployeePayment.PaymentModeDetails, EmployeePayment.NetPay, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department,  EmployeeRegistration.DateOfJoining,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM EmployeePayment INNER JOIN EmployeeRegistration ON EmployeePayment.EmployeeID = EmployeeRegistration.Id where PaymentDate between @d1 and @d2 order by PaymentDate"
				sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTimePicker2.Value.[Date]
				sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTimePicker1.Value
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				sqlDataAdapter.Fill(dataSet, "EmployeePayment")
				sqlDataAdapter2.Fill(dataSet, "Hotel")
				rptSalarySlips.SetDataSource(dataSet)
				rptSalarySlips.SetParameterValue("v1", Me.DateTimePicker2.Value.[Date])
				rptSalarySlips.SetParameterValue("v2", Me.DateTimePicker1.Value.[Date])
				Dim textObject As TextObject = CType(rptSalarySlips.ReportDefinition.Sections("Section1").ReportObjects("Text1"), TextObject)
				textObject.Text = Me.txtCompanyName.Text
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSalarySlips
				MyProject.Forms.frmReport.ShowDialog()
				rptSalarySlips.Close()
				rptSalarySlips.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600CF6B RID: 53099 RVA: 0x00815E80 File Offset: 0x00814080
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbEmployeeName.Text)) = 0
				If flag Then
					MessageBox.Show("Please select employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbEmployeeName.Focus()
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim rptSalarySlips As rptSalarySlips = New rptSalarySlips()
					Dim sqlCommand As SqlCommand = New SqlCommand()
					Dim sqlCommand2 As SqlCommand = New SqlCommand()
					Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
					Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
					Dim dataSet As DataSet = New DataSet()
					Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlCommand.Connection = sqlConnection
					sqlCommand2.Connection = sqlConnection
					sqlCommand.CommandText = "SELECT EmployeeRegistration.EmployeeID, EmployeePayment.EmployeeID as expr10, EmployeePayment.PaymentID, EmployeePayment.DateFrom, EmployeePayment.DateTo, EmployeePayment.PresentDays, EmployeePayment.Salary,EmployeePayment.Advance, EmployeePayment.Deduction, EmployeePayment.Overtime, EmployeePayment.OvertimeRate, EmployeePayment.OvertimeAmount, EmployeePayment.PaymentDate,EmployeePayment.ModeOfPayment, EmployeePayment.PaymentModeDetails, EmployeePayment.NetPay, EmployeeRegistration.Id AS Expr1,EmployeeRegistration.EmployeeName, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department, EmployeeRegistration.Designation, EmployeeRegistration.DateOfJoining, EmployeeRegistration.Salary AS Expr3,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM EmployeePayment INNER JOIN EmployeeRegistration ON EmployeePayment.EmployeeID = EmployeeRegistration.Id where PaymentDate between @d1 and @d2 and EmployeeName=@d3 order by PaymentDate"
					sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
					sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value
					sqlCommand.Parameters.Add("@d3", SqlDbType.NChar, 200, "Name").Value = Me.cmbEmployeeName.Text
					sqlCommand2.CommandText = "SELECT * from Company"
					sqlCommand.CommandType = CommandType.Text
					sqlCommand2.CommandType = CommandType.Text
					sqlDataAdapter.SelectCommand = sqlCommand
					sqlDataAdapter2.SelectCommand = sqlCommand2
					sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
					sqlDataAdapter.Fill(dataSet, "EmployeePayment")
					sqlDataAdapter2.Fill(dataSet, "Hotel")
					rptSalarySlips.SetDataSource(dataSet)
					rptSalarySlips.SetParameterValue("v1", Me.dtpDateFrom.Value.[Date])
					rptSalarySlips.SetParameterValue("v2", Me.dtpDateTo.Value.[Date])
					Dim textObject As TextObject = CType(rptSalarySlips.ReportDefinition.Sections("Section1").ReportObjects("Text1"), TextObject)
					textObject.Text = Me.txtCompanyName.Text
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSalarySlips
					MyProject.Forms.frmReport.ShowDialog()
					rptSalarySlips.Close()
					rptSalarySlips.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
