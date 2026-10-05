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
	' Token: 0x02000340 RID: 832
	<DesignerGenerated()>
	Public Partial Class frmEmployeePaymentReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C25D RID: 49757 RVA: 0x00056E4A File Offset: 0x0005504A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEmployeePaymentReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004D39 RID: 19769
		' (get) Token: 0x0600C260 RID: 49760 RVA: 0x00056E7C File Offset: 0x0005507C
		' (set) Token: 0x0600C261 RID: 49761 RVA: 0x00056E86 File Offset: 0x00055086
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004D3A RID: 19770
		' (get) Token: 0x0600C262 RID: 49762 RVA: 0x00056E8F File Offset: 0x0005508F
		' (set) Token: 0x0600C263 RID: 49763 RVA: 0x00056E99 File Offset: 0x00055099
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004D3B RID: 19771
		' (get) Token: 0x0600C264 RID: 49764 RVA: 0x00056EA2 File Offset: 0x000550A2
		' (set) Token: 0x0600C265 RID: 49765 RVA: 0x00056EAC File Offset: 0x000550AC
		Friend Overridable Property Label1 As Label

		' Token: 0x17004D3C RID: 19772
		' (get) Token: 0x0600C266 RID: 49766 RVA: 0x00056EB5 File Offset: 0x000550B5
		' (set) Token: 0x0600C267 RID: 49767 RVA: 0x00056EBF File Offset: 0x000550BF
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004D3D RID: 19773
		' (get) Token: 0x0600C268 RID: 49768 RVA: 0x00056EC8 File Offset: 0x000550C8
		' (set) Token: 0x0600C269 RID: 49769 RVA: 0x00056ED2 File Offset: 0x000550D2
		Friend Overridable Property Label3 As Label

		' Token: 0x17004D3E RID: 19774
		' (get) Token: 0x0600C26A RID: 49770 RVA: 0x00056EDB File Offset: 0x000550DB
		' (set) Token: 0x0600C26B RID: 49771 RVA: 0x00056EE5 File Offset: 0x000550E5
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17004D3F RID: 19775
		' (get) Token: 0x0600C26C RID: 49772 RVA: 0x00056EEE File Offset: 0x000550EE
		' (set) Token: 0x0600C26D RID: 49773 RVA: 0x00056EF8 File Offset: 0x000550F8
		Friend Overridable Property Label4 As Label

		' Token: 0x17004D40 RID: 19776
		' (get) Token: 0x0600C26E RID: 49774 RVA: 0x00056F01 File Offset: 0x00055101
		' (set) Token: 0x0600C26F RID: 49775 RVA: 0x00056F0B File Offset: 0x0005510B
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17004D41 RID: 19777
		' (get) Token: 0x0600C270 RID: 49776 RVA: 0x00056F14 File Offset: 0x00055114
		' (set) Token: 0x0600C271 RID: 49777 RVA: 0x00056F1E File Offset: 0x0005511E
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004D42 RID: 19778
		' (get) Token: 0x0600C272 RID: 49778 RVA: 0x00056F27 File Offset: 0x00055127
		' (set) Token: 0x0600C273 RID: 49779 RVA: 0x00056F31 File Offset: 0x00055131
		Friend Overridable Property cmbEmployeeName As ComboBox

		' Token: 0x17004D43 RID: 19779
		' (get) Token: 0x0600C274 RID: 49780 RVA: 0x00056F3A File Offset: 0x0005513A
		' (set) Token: 0x0600C275 RID: 49781 RVA: 0x00056F44 File Offset: 0x00055144
		Friend Overridable Property Label9 As Label

		' Token: 0x17004D44 RID: 19780
		' (get) Token: 0x0600C276 RID: 49782 RVA: 0x00056F4D File Offset: 0x0005514D
		' (set) Token: 0x0600C277 RID: 49783 RVA: 0x00056F57 File Offset: 0x00055157
		Friend Overridable Property Label10 As Label

		' Token: 0x17004D45 RID: 19781
		' (get) Token: 0x0600C278 RID: 49784 RVA: 0x00056F60 File Offset: 0x00055160
		' (set) Token: 0x0600C279 RID: 49785 RVA: 0x00056F6A File Offset: 0x0005516A
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004D46 RID: 19782
		' (get) Token: 0x0600C27A RID: 49786 RVA: 0x00056F73 File Offset: 0x00055173
		' (set) Token: 0x0600C27B RID: 49787 RVA: 0x00056F7D File Offset: 0x0005517D
		Friend Overridable Property Label11 As Label

		' Token: 0x17004D47 RID: 19783
		' (get) Token: 0x0600C27C RID: 49788 RVA: 0x00056F86 File Offset: 0x00055186
		' (set) Token: 0x0600C27D RID: 49789 RVA: 0x00056F90 File Offset: 0x00055190
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004D48 RID: 19784
		' (get) Token: 0x0600C27E RID: 49790 RVA: 0x00056F99 File Offset: 0x00055199
		' (set) Token: 0x0600C27F RID: 49791 RVA: 0x00056FA3 File Offset: 0x000551A3
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17004D49 RID: 19785
		' (get) Token: 0x0600C280 RID: 49792 RVA: 0x00056FAC File Offset: 0x000551AC
		' (set) Token: 0x0600C281 RID: 49793 RVA: 0x007B94C4 File Offset: 0x007B76C4
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

		' Token: 0x17004D4A RID: 19786
		' (get) Token: 0x0600C282 RID: 49794 RVA: 0x00056FB6 File Offset: 0x000551B6
		' (set) Token: 0x0600C283 RID: 49795 RVA: 0x00056FC0 File Offset: 0x000551C0
		Friend Overridable Property txtCompanyName As TextBox

		' Token: 0x17004D4B RID: 19787
		' (get) Token: 0x0600C284 RID: 49796 RVA: 0x00056FC9 File Offset: 0x000551C9
		' (set) Token: 0x0600C285 RID: 49797 RVA: 0x007B9508 File Offset: 0x007B7708
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._Button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button2 = value
				gelButton = Me._Button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D4C RID: 19788
		' (get) Token: 0x0600C286 RID: 49798 RVA: 0x00056FD3 File Offset: 0x000551D3
		' (set) Token: 0x0600C287 RID: 49799 RVA: 0x007B954C File Offset: 0x007B774C
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

		' Token: 0x17004D4D RID: 19789
		' (get) Token: 0x0600C288 RID: 49800 RVA: 0x00056FDD File Offset: 0x000551DD
		' (set) Token: 0x0600C289 RID: 49801 RVA: 0x007B9590 File Offset: 0x007B7790
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim gelButton As GelButton = Me._Button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button1 = value
				gelButton = Me._Button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600C28A RID: 49802 RVA: 0x007B95D4 File Offset: 0x007B77D4
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

		' Token: 0x0600C28B RID: 49803 RVA: 0x00056FE7 File Offset: 0x000551E7
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fillEmployee()
			Me.GetCompanyname()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C28C RID: 49804 RVA: 0x007B96FC File Offset: 0x007B78FC
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

		' Token: 0x0600C28D RID: 49805 RVA: 0x007B9874 File Offset: 0x007B7A74
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

		' Token: 0x0600C28E RID: 49806 RVA: 0x007B9930 File Offset: 0x007B7B30
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

		' Token: 0x0600C28F RID: 49807 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C290 RID: 49808 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C291 RID: 49809 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C292 RID: 49810 RVA: 0x007B99FC File Offset: 0x007B7BFC
		Public Sub Reset()
			Me.cmbEmployeeName.SelectedIndex = -1
			Me.DateTimePicker1.Value = DateAndTime.Now
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Now
			Me.fillEmployee()
		End Sub

		' Token: 0x0600C293 RID: 49811 RVA: 0x00056FFF File Offset: 0x000551FF
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600C294 RID: 49812 RVA: 0x007B9A64 File Offset: 0x007B7C64
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

		' Token: 0x0600C295 RID: 49813 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEmployeePaymentReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C296 RID: 49814 RVA: 0x0005701B File Offset: 0x0005521B
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600C297 RID: 49815 RVA: 0x007B9B54 File Offset: 0x007B7D54
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptEmployeePayment As rptEmployeePayment1 = New rptEmployeePayment1()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlCommand3 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter3 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand3.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT EmployeePayment.EmployeeID,EmployeeRegistration.ID,EmployeeRegistration.EmployeeName,EmployeeRegistration.Designation, EmployeePayment.PaymentID, EmployeePayment.DateFrom, EmployeePayment.DateTo, EmployeePayment.PresentDays, EmployeePayment.Salary,EmployeePayment.Advance, EmployeePayment.Deduction, EmployeePayment.Overtime, EmployeePayment.OvertimeRate, EmployeePayment.OvertimeAmount, EmployeePayment.PaymentDate,EmployeePayment.ModeOfPayment, EmployeePayment.PaymentModeDetails, EmployeePayment.NetPay, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department,  EmployeeRegistration.DateOfJoining,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM EmployeePayment INNER JOIN EmployeeRegistration ON EmployeePayment.EmployeeID = EmployeeRegistration.Id where PaymentDate between @d1 and @d2 order by PaymentDate"
				sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTimePicker2.Value.[Date]
				sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTimePicker1.Value
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand3.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlCommand3.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter3.SelectCommand = sqlCommand3
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				sqlDataAdapter.Fill(dataSet, "EmployeePayment")
				sqlDataAdapter2.Fill(dataSet, "Hotel")
				sqlDataAdapter3.Fill(dataSet, "Currency")
				rptEmployeePayment.SetDataSource(dataSet)
				rptEmployeePayment.SetParameterValue("v1", Me.DateTimePicker2.Value.[Date])
				rptEmployeePayment.SetParameterValue("v2", Me.DateTimePicker1.Value.[Date])
				Dim textObject As TextObject = CType(rptEmployeePayment.ReportDefinition.Sections("Section1").ReportObjects("Text3"), TextObject)
				textObject.Text = Me.txtCompanyName.Text
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptEmployeePayment
				MyProject.Forms.frmReport.ShowDialog()
				rptEmployeePayment.Close()
				rptEmployeePayment.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C298 RID: 49816 RVA: 0x007B9DDC File Offset: 0x007B7FDC
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbEmployeeName.Text)) = 0
				If flag Then
					MessageBox.Show("Please select employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbEmployeeName.Focus()
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim rptEmployeePayment As rptEmployeePayment = New rptEmployeePayment()
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
					rptEmployeePayment.SetDataSource(dataSet)
					rptEmployeePayment.SetParameterValue("v1", Me.dtpDateFrom.Value.[Date])
					rptEmployeePayment.SetParameterValue("v2", Me.dtpDateTo.Value.[Date])
					Dim textObject As TextObject = CType(rptEmployeePayment.ReportDefinition.Sections("Section1").ReportObjects("Text19"), TextObject)
					textObject.Text = Me.txtCompanyName.Text
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptEmployeePayment
					MyProject.Forms.frmReport.ShowDialog()
					rptEmployeePayment.Close()
					rptEmployeePayment.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
