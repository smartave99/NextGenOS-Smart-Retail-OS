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
	' Token: 0x0200033D RID: 829
	<DesignerGenerated()>
	Public Partial Class frmDeductionReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C139 RID: 49465 RVA: 0x00056584 File Offset: 0x00054784
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmDeductionReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004CCE RID: 19662
		' (get) Token: 0x0600C13C RID: 49468 RVA: 0x000565B6 File Offset: 0x000547B6
		' (set) Token: 0x0600C13D RID: 49469 RVA: 0x000565C0 File Offset: 0x000547C0
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004CCF RID: 19663
		' (get) Token: 0x0600C13E RID: 49470 RVA: 0x000565C9 File Offset: 0x000547C9
		' (set) Token: 0x0600C13F RID: 49471 RVA: 0x000565D3 File Offset: 0x000547D3
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004CD0 RID: 19664
		' (get) Token: 0x0600C140 RID: 49472 RVA: 0x000565DC File Offset: 0x000547DC
		' (set) Token: 0x0600C141 RID: 49473 RVA: 0x000565E6 File Offset: 0x000547E6
		Friend Overridable Property Label1 As Label

		' Token: 0x17004CD1 RID: 19665
		' (get) Token: 0x0600C142 RID: 49474 RVA: 0x000565EF File Offset: 0x000547EF
		' (set) Token: 0x0600C143 RID: 49475 RVA: 0x000565F9 File Offset: 0x000547F9
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004CD2 RID: 19666
		' (get) Token: 0x0600C144 RID: 49476 RVA: 0x00056602 File Offset: 0x00054802
		' (set) Token: 0x0600C145 RID: 49477 RVA: 0x0005660C File Offset: 0x0005480C
		Friend Overridable Property Label3 As Label

		' Token: 0x17004CD3 RID: 19667
		' (get) Token: 0x0600C146 RID: 49478 RVA: 0x00056615 File Offset: 0x00054815
		' (set) Token: 0x0600C147 RID: 49479 RVA: 0x0005661F File Offset: 0x0005481F
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17004CD4 RID: 19668
		' (get) Token: 0x0600C148 RID: 49480 RVA: 0x00056628 File Offset: 0x00054828
		' (set) Token: 0x0600C149 RID: 49481 RVA: 0x00056632 File Offset: 0x00054832
		Friend Overridable Property Label4 As Label

		' Token: 0x17004CD5 RID: 19669
		' (get) Token: 0x0600C14A RID: 49482 RVA: 0x0005663B File Offset: 0x0005483B
		' (set) Token: 0x0600C14B RID: 49483 RVA: 0x00056645 File Offset: 0x00054845
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17004CD6 RID: 19670
		' (get) Token: 0x0600C14C RID: 49484 RVA: 0x0005664E File Offset: 0x0005484E
		' (set) Token: 0x0600C14D RID: 49485 RVA: 0x00056658 File Offset: 0x00054858
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004CD7 RID: 19671
		' (get) Token: 0x0600C14E RID: 49486 RVA: 0x00056661 File Offset: 0x00054861
		' (set) Token: 0x0600C14F RID: 49487 RVA: 0x0005666B File Offset: 0x0005486B
		Friend Overridable Property cmbEmployeeName As ComboBox

		' Token: 0x17004CD8 RID: 19672
		' (get) Token: 0x0600C150 RID: 49488 RVA: 0x00056674 File Offset: 0x00054874
		' (set) Token: 0x0600C151 RID: 49489 RVA: 0x0005667E File Offset: 0x0005487E
		Friend Overridable Property Label9 As Label

		' Token: 0x17004CD9 RID: 19673
		' (get) Token: 0x0600C152 RID: 49490 RVA: 0x00056687 File Offset: 0x00054887
		' (set) Token: 0x0600C153 RID: 49491 RVA: 0x00056691 File Offset: 0x00054891
		Friend Overridable Property Label10 As Label

		' Token: 0x17004CDA RID: 19674
		' (get) Token: 0x0600C154 RID: 49492 RVA: 0x0005669A File Offset: 0x0005489A
		' (set) Token: 0x0600C155 RID: 49493 RVA: 0x000566A4 File Offset: 0x000548A4
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004CDB RID: 19675
		' (get) Token: 0x0600C156 RID: 49494 RVA: 0x000566AD File Offset: 0x000548AD
		' (set) Token: 0x0600C157 RID: 49495 RVA: 0x000566B7 File Offset: 0x000548B7
		Friend Overridable Property Label11 As Label

		' Token: 0x17004CDC RID: 19676
		' (get) Token: 0x0600C158 RID: 49496 RVA: 0x000566C0 File Offset: 0x000548C0
		' (set) Token: 0x0600C159 RID: 49497 RVA: 0x000566CA File Offset: 0x000548CA
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004CDD RID: 19677
		' (get) Token: 0x0600C15A RID: 49498 RVA: 0x000566D3 File Offset: 0x000548D3
		' (set) Token: 0x0600C15B RID: 49499 RVA: 0x000566DD File Offset: 0x000548DD
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17004CDE RID: 19678
		' (get) Token: 0x0600C15C RID: 49500 RVA: 0x000566E6 File Offset: 0x000548E6
		' (set) Token: 0x0600C15D RID: 49501 RVA: 0x007AF048 File Offset: 0x007AD248
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

		' Token: 0x17004CDF RID: 19679
		' (get) Token: 0x0600C15E RID: 49502 RVA: 0x000566F0 File Offset: 0x000548F0
		' (set) Token: 0x0600C15F RID: 49503 RVA: 0x000566FA File Offset: 0x000548FA
		Friend Overridable Property txtCompanyName As TextBox

		' Token: 0x17004CE0 RID: 19680
		' (get) Token: 0x0600C160 RID: 49504 RVA: 0x00056703 File Offset: 0x00054903
		' (set) Token: 0x0600C161 RID: 49505 RVA: 0x007AF08C File Offset: 0x007AD28C
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
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

		' Token: 0x17004CE1 RID: 19681
		' (get) Token: 0x0600C162 RID: 49506 RVA: 0x0005670D File Offset: 0x0005490D
		' (set) Token: 0x0600C163 RID: 49507 RVA: 0x007AF0D0 File Offset: 0x007AD2D0
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

		' Token: 0x17004CE2 RID: 19682
		' (get) Token: 0x0600C164 RID: 49508 RVA: 0x00056717 File Offset: 0x00054917
		' (set) Token: 0x0600C165 RID: 49509 RVA: 0x007AF114 File Offset: 0x007AD314
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
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

		' Token: 0x0600C166 RID: 49510 RVA: 0x007AF158 File Offset: 0x007AD358
		Public Sub fillEmployee()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(EmployeeName) FROM EmployeeRegistration,AdvanceEntry where EmployeeRegistration.ID=AdvanceEntry.EmployeeID", sqlConnection)
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

		' Token: 0x0600C167 RID: 49511 RVA: 0x00056721 File Offset: 0x00054921
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fillEmployee()
			Me.GetCompanyname()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C168 RID: 49512 RVA: 0x007AF280 File Offset: 0x007AD480
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

		' Token: 0x0600C169 RID: 49513 RVA: 0x007AF3F8 File Offset: 0x007AD5F8
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

		' Token: 0x0600C16A RID: 49514 RVA: 0x007AF4B4 File Offset: 0x007AD6B4
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

		' Token: 0x0600C16B RID: 49515 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C16C RID: 49516 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C16D RID: 49517 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C16E RID: 49518 RVA: 0x007AF580 File Offset: 0x007AD780
		Public Sub Reset()
			Me.cmbEmployeeName.SelectedIndex = -1
			Me.DateTimePicker1.Value = DateAndTime.Now
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Now
			Me.fillEmployee()
		End Sub

		' Token: 0x0600C16F RID: 49519 RVA: 0x00056739 File Offset: 0x00054939
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600C170 RID: 49520 RVA: 0x007AF5E8 File Offset: 0x007AD7E8
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

		' Token: 0x0600C171 RID: 49521 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmDeductionReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C172 RID: 49522 RVA: 0x00056755 File Offset: 0x00054955
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600C173 RID: 49523 RVA: 0x007AF6D8 File Offset: 0x007AD8D8
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptDeduction As rptDeduction = New rptDeduction()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT AdvanceEntry.EmployeeID, AdvanceEntry.Amount, AdvanceEntry.Deduction, AdvanceEntry.WorkingDate, EmployeeRegistration.Id,EmployeeRegistration.EmployeeName, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department, EmployeeRegistration.Designation, EmployeeRegistration.DateOfJoining, EmployeeRegistration.Salary,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM AdvanceEntry INNER JOIN EmployeeRegistration ON AdvanceEntry.EmployeeID = EmployeeRegistration.Id where WorkingDate between @d1 and @d2 and Deduction > 0 order by WorkingDate"
				sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTimePicker2.Value.[Date]
				sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTimePicker1.Value
				sqlCommand2.CommandText = "SELECT * from Company"
				sqlCommand.CommandType = CommandType.Text
				sqlCommand2.CommandType = CommandType.Text
				sqlDataAdapter.SelectCommand = sqlCommand
				sqlDataAdapter2.SelectCommand = sqlCommand2
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				sqlDataAdapter.Fill(dataSet, "AdvanceEntry")
				sqlDataAdapter2.Fill(dataSet, "Hotel")
				rptDeduction.SetDataSource(dataSet)
				rptDeduction.SetParameterValue("v1", Me.DateTimePicker2.Value.[Date])
				rptDeduction.SetParameterValue("v2", Me.DateTimePicker1.Value.[Date])
				Dim textObject As TextObject = CType(rptDeduction.ReportDefinition.Sections("Section1").ReportObjects("Text6"), TextObject)
				textObject.Text = Me.txtCompanyName.Text
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptDeduction
				MyProject.Forms.frmReport.ShowDialog()
				rptDeduction.Close()
				rptDeduction.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C174 RID: 49524 RVA: 0x007AF918 File Offset: 0x007ADB18
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbEmployeeName.Text)) = 0
				If flag Then
					MessageBox.Show("Please select employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbEmployeeName.Focus()
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim rptDeduction As rptDeduction = New rptDeduction()
					Dim sqlCommand As SqlCommand = New SqlCommand()
					Dim sqlCommand2 As SqlCommand = New SqlCommand()
					Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
					Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
					Dim dataSet As DataSet = New DataSet()
					Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlCommand.Connection = sqlConnection
					sqlCommand2.Connection = sqlConnection
					sqlCommand.CommandText = "SELECT AdvanceEntry.EmployeeID, AdvanceEntry.Amount, AdvanceEntry.Deduction, AdvanceEntry.WorkingDate, EmployeeRegistration.Id, EmployeeRegistration.EmployeeID AS Expr2,EmployeeRegistration.EmployeeName, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department, EmployeeRegistration.Designation, EmployeeRegistration.DateOfJoining, EmployeeRegistration.Salary,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM AdvanceEntry INNER JOIN EmployeeRegistration ON AdvanceEntry.EmployeeID = EmployeeRegistration.Id where WorkingDate between @d1 and @d2 and EmployeeName=@d3 and Deduction > 0 order by WorkingDate"
					sqlCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateFrom.Value.[Date]
					sqlCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.dtpDateTo.Value
					sqlCommand.Parameters.Add("@d3", SqlDbType.NChar, 200, "Name").Value = Me.cmbEmployeeName.Text
					sqlCommand2.CommandText = "SELECT * from Company"
					sqlCommand.CommandType = CommandType.Text
					sqlCommand2.CommandType = CommandType.Text
					sqlDataAdapter.SelectCommand = sqlCommand
					sqlDataAdapter2.SelectCommand = sqlCommand2
					sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
					sqlDataAdapter.Fill(dataSet, "AdvanceEntry")
					sqlDataAdapter2.Fill(dataSet, "Hotel")
					rptDeduction.SetDataSource(dataSet)
					rptDeduction.SetParameterValue("v1", Me.dtpDateFrom.Value.[Date])
					rptDeduction.SetParameterValue("v2", Me.dtpDateTo.Value.[Date])
					Dim textObject As TextObject = CType(rptDeduction.ReportDefinition.Sections("Section1").ReportObjects("Text6"), TextObject)
					textObject.Text = Me.txtCompanyName.Text
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptDeduction
					MyProject.Forms.frmReport.ShowDialog()
					rptDeduction.Close()
					rptDeduction.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
