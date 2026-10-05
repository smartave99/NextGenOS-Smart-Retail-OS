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
	' Token: 0x0200032C RID: 812
	<DesignerGenerated()>
	Public Partial Class frmAdvanceEntryReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BE6F RID: 48751 RVA: 0x0005518A File Offset: 0x0005338A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAdvanceEntryReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004BD5 RID: 19413
		' (get) Token: 0x0600BE72 RID: 48754 RVA: 0x000551BC File Offset: 0x000533BC
		' (set) Token: 0x0600BE73 RID: 48755 RVA: 0x000551C6 File Offset: 0x000533C6
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004BD6 RID: 19414
		' (get) Token: 0x0600BE74 RID: 48756 RVA: 0x000551CF File Offset: 0x000533CF
		' (set) Token: 0x0600BE75 RID: 48757 RVA: 0x000551D9 File Offset: 0x000533D9
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004BD7 RID: 19415
		' (get) Token: 0x0600BE76 RID: 48758 RVA: 0x000551E2 File Offset: 0x000533E2
		' (set) Token: 0x0600BE77 RID: 48759 RVA: 0x000551EC File Offset: 0x000533EC
		Friend Overridable Property Label1 As Label

		' Token: 0x17004BD8 RID: 19416
		' (get) Token: 0x0600BE78 RID: 48760 RVA: 0x000551F5 File Offset: 0x000533F5
		' (set) Token: 0x0600BE79 RID: 48761 RVA: 0x000551FF File Offset: 0x000533FF
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17004BD9 RID: 19417
		' (get) Token: 0x0600BE7A RID: 48762 RVA: 0x00055208 File Offset: 0x00053408
		' (set) Token: 0x0600BE7B RID: 48763 RVA: 0x00055212 File Offset: 0x00053412
		Friend Overridable Property Label3 As Label

		' Token: 0x17004BDA RID: 19418
		' (get) Token: 0x0600BE7C RID: 48764 RVA: 0x0005521B File Offset: 0x0005341B
		' (set) Token: 0x0600BE7D RID: 48765 RVA: 0x00055225 File Offset: 0x00053425
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17004BDB RID: 19419
		' (get) Token: 0x0600BE7E RID: 48766 RVA: 0x0005522E File Offset: 0x0005342E
		' (set) Token: 0x0600BE7F RID: 48767 RVA: 0x00055238 File Offset: 0x00053438
		Friend Overridable Property Label4 As Label

		' Token: 0x17004BDC RID: 19420
		' (get) Token: 0x0600BE80 RID: 48768 RVA: 0x00055241 File Offset: 0x00053441
		' (set) Token: 0x0600BE81 RID: 48769 RVA: 0x0005524B File Offset: 0x0005344B
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17004BDD RID: 19421
		' (get) Token: 0x0600BE82 RID: 48770 RVA: 0x00055254 File Offset: 0x00053454
		' (set) Token: 0x0600BE83 RID: 48771 RVA: 0x0005525E File Offset: 0x0005345E
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004BDE RID: 19422
		' (get) Token: 0x0600BE84 RID: 48772 RVA: 0x00055267 File Offset: 0x00053467
		' (set) Token: 0x0600BE85 RID: 48773 RVA: 0x00055271 File Offset: 0x00053471
		Friend Overridable Property cmbEmployeeName As ComboBox

		' Token: 0x17004BDF RID: 19423
		' (get) Token: 0x0600BE86 RID: 48774 RVA: 0x0005527A File Offset: 0x0005347A
		' (set) Token: 0x0600BE87 RID: 48775 RVA: 0x00055284 File Offset: 0x00053484
		Friend Overridable Property Label9 As Label

		' Token: 0x17004BE0 RID: 19424
		' (get) Token: 0x0600BE88 RID: 48776 RVA: 0x0005528D File Offset: 0x0005348D
		' (set) Token: 0x0600BE89 RID: 48777 RVA: 0x00055297 File Offset: 0x00053497
		Friend Overridable Property Label10 As Label

		' Token: 0x17004BE1 RID: 19425
		' (get) Token: 0x0600BE8A RID: 48778 RVA: 0x000552A0 File Offset: 0x000534A0
		' (set) Token: 0x0600BE8B RID: 48779 RVA: 0x000552AA File Offset: 0x000534AA
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004BE2 RID: 19426
		' (get) Token: 0x0600BE8C RID: 48780 RVA: 0x000552B3 File Offset: 0x000534B3
		' (set) Token: 0x0600BE8D RID: 48781 RVA: 0x000552BD File Offset: 0x000534BD
		Friend Overridable Property Label11 As Label

		' Token: 0x17004BE3 RID: 19427
		' (get) Token: 0x0600BE8E RID: 48782 RVA: 0x000552C6 File Offset: 0x000534C6
		' (set) Token: 0x0600BE8F RID: 48783 RVA: 0x000552D0 File Offset: 0x000534D0
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004BE4 RID: 19428
		' (get) Token: 0x0600BE90 RID: 48784 RVA: 0x000552D9 File Offset: 0x000534D9
		' (set) Token: 0x0600BE91 RID: 48785 RVA: 0x000552E3 File Offset: 0x000534E3
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17004BE5 RID: 19429
		' (get) Token: 0x0600BE92 RID: 48786 RVA: 0x000552EC File Offset: 0x000534EC
		' (set) Token: 0x0600BE93 RID: 48787 RVA: 0x00798878 File Offset: 0x00796A78
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

		' Token: 0x17004BE6 RID: 19430
		' (get) Token: 0x0600BE94 RID: 48788 RVA: 0x000552F6 File Offset: 0x000534F6
		' (set) Token: 0x0600BE95 RID: 48789 RVA: 0x00055300 File Offset: 0x00053500
		Friend Overridable Property txtCompanyName As TextBox

		' Token: 0x17004BE7 RID: 19431
		' (get) Token: 0x0600BE96 RID: 48790 RVA: 0x00055309 File Offset: 0x00053509
		' (set) Token: 0x0600BE97 RID: 48791 RVA: 0x007988BC File Offset: 0x00796ABC
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

		' Token: 0x17004BE8 RID: 19432
		' (get) Token: 0x0600BE98 RID: 48792 RVA: 0x00055313 File Offset: 0x00053513
		' (set) Token: 0x0600BE99 RID: 48793 RVA: 0x00798900 File Offset: 0x00796B00
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnExportExcel_Click
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004BE9 RID: 19433
		' (get) Token: 0x0600BE9A RID: 48794 RVA: 0x0005531D File Offset: 0x0005351D
		' (set) Token: 0x0600BE9B RID: 48795 RVA: 0x00798944 File Offset: 0x00796B44
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

		' Token: 0x0600BE9C RID: 48796 RVA: 0x00798988 File Offset: 0x00796B88
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

		' Token: 0x0600BE9D RID: 48797 RVA: 0x00055327 File Offset: 0x00053527
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.fillEmployee()
			Me.GetCompanyname()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600BE9E RID: 48798 RVA: 0x00798AB0 File Offset: 0x00796CB0
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

		' Token: 0x0600BE9F RID: 48799 RVA: 0x00798C28 File Offset: 0x00796E28
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

		' Token: 0x0600BEA0 RID: 48800 RVA: 0x00798CE4 File Offset: 0x00796EE4
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

		' Token: 0x0600BEA1 RID: 48801 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600BEA2 RID: 48802 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600BEA3 RID: 48803 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600BEA4 RID: 48804 RVA: 0x00798DB0 File Offset: 0x00796FB0
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

		' Token: 0x0600BEA5 RID: 48805 RVA: 0x00798EA0 File Offset: 0x007970A0
		Public Sub Reset()
			Me.cmbEmployeeName.SelectedIndex = -1
			Me.DateTimePicker1.Value = DateAndTime.Now
			Me.DateTimePicker2.Value = DateAndTime.Today
			Me.dtpDateFrom.Value = DateAndTime.Today
			Me.dtpDateTo.Value = DateAndTime.Now
			Me.fillEmployee()
		End Sub

		' Token: 0x0600BEA6 RID: 48806 RVA: 0x00798F08 File Offset: 0x00797108
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptAdvanceEntry As rptAdvanceEntry = New rptAdvanceEntry()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT AdvanceEntry.EmployeeID, AdvanceEntry.Amount, AdvanceEntry.Deduction, AdvanceEntry.WorkingDate, EmployeeRegistration.Id,EmployeeRegistration.EmployeeName, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department, EmployeeRegistration.Designation, EmployeeRegistration.DateOfJoining, EmployeeRegistration.Salary,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM AdvanceEntry INNER JOIN EmployeeRegistration ON AdvanceEntry.EmployeeID = EmployeeRegistration.Id where WorkingDate between @d1 and @d2 and Amount > 0 order by WorkingDate"
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
				rptAdvanceEntry.SetDataSource(dataSet)
				rptAdvanceEntry.SetParameterValue("v1", Me.DateTimePicker2.Value.[Date])
				rptAdvanceEntry.SetParameterValue("v2", Me.DateTimePicker1.Value.[Date])
				Dim textObject As TextObject = CType(rptAdvanceEntry.ReportDefinition.Sections("Section1").ReportObjects("Text1"), TextObject)
				textObject.Text = Me.txtCompanyName.Text
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptAdvanceEntry
				MyProject.Forms.frmReport.ShowDialog()
				rptAdvanceEntry.Close()
				rptAdvanceEntry.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BEA7 RID: 48807 RVA: 0x0005533F File Offset: 0x0005353F
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600BEA8 RID: 48808 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAdvanceEntryReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BEA9 RID: 48809 RVA: 0x0005535B File Offset: 0x0005355B
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600BEAA RID: 48810 RVA: 0x00798F08 File Offset: 0x00797108
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				Dim rptAdvanceEntry As rptAdvanceEntry = New rptAdvanceEntry()
				Dim sqlCommand As SqlCommand = New SqlCommand()
				Dim sqlCommand2 As SqlCommand = New SqlCommand()
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
				Dim dataSet As DataSet = New DataSet()
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlCommand.Connection = sqlConnection
				sqlCommand2.Connection = sqlConnection
				sqlCommand.CommandText = "SELECT AdvanceEntry.EmployeeID, AdvanceEntry.Amount, AdvanceEntry.Deduction, AdvanceEntry.WorkingDate, EmployeeRegistration.Id,EmployeeRegistration.EmployeeName, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department, EmployeeRegistration.Designation, EmployeeRegistration.DateOfJoining, EmployeeRegistration.Salary,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM AdvanceEntry INNER JOIN EmployeeRegistration ON AdvanceEntry.EmployeeID = EmployeeRegistration.Id where WorkingDate between @d1 and @d2 and Amount > 0 order by WorkingDate"
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
				rptAdvanceEntry.SetDataSource(dataSet)
				rptAdvanceEntry.SetParameterValue("v1", Me.DateTimePicker2.Value.[Date])
				rptAdvanceEntry.SetParameterValue("v2", Me.DateTimePicker1.Value.[Date])
				Dim textObject As TextObject = CType(rptAdvanceEntry.ReportDefinition.Sections("Section1").ReportObjects("Text1"), TextObject)
				textObject.Text = Me.txtCompanyName.Text
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptAdvanceEntry
				MyProject.Forms.frmReport.ShowDialog()
				rptAdvanceEntry.Close()
				rptAdvanceEntry.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BEAB RID: 48811 RVA: 0x00799148 File Offset: 0x00797348
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbEmployeeName.Text)) = 0
				If flag Then
					MessageBox.Show("Please select employee name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbEmployeeName.Focus()
				Else
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					Dim rptAdvanceEntry As rptAdvanceEntry = New rptAdvanceEntry()
					Dim sqlCommand As SqlCommand = New SqlCommand()
					Dim sqlCommand2 As SqlCommand = New SqlCommand()
					Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter()
					Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter()
					Dim dataSet As DataSet = New DataSet()
					Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlCommand.Connection = sqlConnection
					sqlCommand2.Connection = sqlConnection
					sqlCommand.CommandText = "SELECT AdvanceEntry.EmployeeID, AdvanceEntry.Amount, AdvanceEntry.Deduction, AdvanceEntry.WorkingDate, EmployeeRegistration.Id, EmployeeRegistration.EmployeeID AS Expr2,EmployeeRegistration.EmployeeName, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department, EmployeeRegistration.Designation, EmployeeRegistration.DateOfJoining, EmployeeRegistration.Salary,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM AdvanceEntry INNER JOIN EmployeeRegistration ON AdvanceEntry.EmployeeID = EmployeeRegistration.Id where WorkingDate between @d1 and @d2 and EmployeeName=@d3 and Amount > 0 order by WorkingDate"
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
					rptAdvanceEntry.SetDataSource(dataSet)
					rptAdvanceEntry.SetParameterValue("v1", Me.dtpDateFrom.Value.[Date])
					rptAdvanceEntry.SetParameterValue("v2", Me.dtpDateTo.Value.[Date])
					Dim textObject As TextObject = CType(rptAdvanceEntry.ReportDefinition.Sections("Section1").ReportObjects("Text1"), TextObject)
					textObject.Text = Me.txtCompanyName.Text
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptAdvanceEntry
					MyProject.Forms.frmReport.ShowDialog()
					rptAdvanceEntry.Close()
					rptAdvanceEntry.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
