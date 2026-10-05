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
	' Token: 0x0200036B RID: 875
	<DesignerGenerated()>
	Public Partial Class frmSalaryslip
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600CF08 RID: 53000 RVA: 0x0005C070 File Offset: 0x0005A270
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalaryslip_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005145 RID: 20805
		' (get) Token: 0x0600CF0B RID: 53003 RVA: 0x0005C0A2 File Offset: 0x0005A2A2
		' (set) Token: 0x0600CF0C RID: 53004 RVA: 0x0005C0AC File Offset: 0x0005A2AC
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005146 RID: 20806
		' (get) Token: 0x0600CF0D RID: 53005 RVA: 0x0005C0B5 File Offset: 0x0005A2B5
		' (set) Token: 0x0600CF0E RID: 53006 RVA: 0x0005C0BF File Offset: 0x0005A2BF
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005147 RID: 20807
		' (get) Token: 0x0600CF0F RID: 53007 RVA: 0x0005C0C8 File Offset: 0x0005A2C8
		' (set) Token: 0x0600CF10 RID: 53008 RVA: 0x0005C0D2 File Offset: 0x0005A2D2
		Friend Overridable Property Label1 As Label

		' Token: 0x17005148 RID: 20808
		' (get) Token: 0x0600CF11 RID: 53009 RVA: 0x0005C0DB File Offset: 0x0005A2DB
		' (set) Token: 0x0600CF12 RID: 53010 RVA: 0x0005C0E5 File Offset: 0x0005A2E5
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005149 RID: 20809
		' (get) Token: 0x0600CF13 RID: 53011 RVA: 0x0005C0EE File Offset: 0x0005A2EE
		' (set) Token: 0x0600CF14 RID: 53012 RVA: 0x00813D90 File Offset: 0x00811F90
		Private _cmbPaymentID As ComboBox
		Friend Overridable Property cmbPaymentID As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._cmbPaymentID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim listControlConvertEventHandler As ListControlConvertEventHandler = AddressOf Me.cmbPaymentID_Format
				Dim comboBox As ComboBox = Me._cmbPaymentID
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.Format, listControlConvertEventHandler
				End If
				Me._cmbPaymentID = value
				comboBox = Me._cmbPaymentID
				If comboBox IsNot Nothing Then
					AddHandler comboBox.Format, listControlConvertEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700514A RID: 20810
		' (get) Token: 0x0600CF15 RID: 53013 RVA: 0x0005C0F8 File Offset: 0x0005A2F8
		' (set) Token: 0x0600CF16 RID: 53014 RVA: 0x0005C102 File Offset: 0x0005A302
		Friend Overridable Property Label9 As Label

		' Token: 0x1700514B RID: 20811
		' (get) Token: 0x0600CF17 RID: 53015 RVA: 0x0005C10B File Offset: 0x0005A30B
		' (set) Token: 0x0600CF18 RID: 53016 RVA: 0x0005C115 File Offset: 0x0005A315
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x1700514C RID: 20812
		' (get) Token: 0x0600CF19 RID: 53017 RVA: 0x0005C11E File Offset: 0x0005A31E
		' (set) Token: 0x0600CF1A RID: 53018 RVA: 0x00813DD4 File Offset: 0x00811FD4
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

		' Token: 0x1700514D RID: 20813
		' (get) Token: 0x0600CF1B RID: 53019 RVA: 0x0005C128 File Offset: 0x0005A328
		' (set) Token: 0x0600CF1C RID: 53020 RVA: 0x0005C132 File Offset: 0x0005A332
		Friend Overridable Property txtCompanyName As TextBox

		' Token: 0x1700514E RID: 20814
		' (get) Token: 0x0600CF1D RID: 53021 RVA: 0x0005C13B File Offset: 0x0005A33B
		' (set) Token: 0x0600CF1E RID: 53022 RVA: 0x00813E18 File Offset: 0x00812018
		Private _btnView As GelButton
		Friend Overridable Property btnView As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnView
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnView_Click
				Dim gelButton As GelButton = Me._btnView
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnView = value
				gelButton = Me._btnView
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700514F RID: 20815
		' (get) Token: 0x0600CF1F RID: 53023 RVA: 0x0005C145 File Offset: 0x0005A345
		' (set) Token: 0x0600CF20 RID: 53024 RVA: 0x00813E5C File Offset: 0x0081205C
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

		' Token: 0x0600CF21 RID: 53025 RVA: 0x00813EA0 File Offset: 0x008120A0
		Public Sub fillPaymentID()
			Try
				Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				ModCommonClasses.adp = New SqlDataAdapter()
				ModCommonClasses.adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(PaymentID) FROM EmployeePayment", sqlConnection)
				ModCommonClasses.ds = New DataSet("ds")
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.dtable = ModCommonClasses.ds.Tables(0)
				Me.cmbPaymentID.Items.Clear()
				Try
					For Each obj As Object In ModCommonClasses.dtable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Me.cmbPaymentID.Items.Add(dataRow(0).ToString())
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

		' Token: 0x0600CF22 RID: 53026 RVA: 0x0005C14F File Offset: 0x0005A34F
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.GetCompanyname()
			Me.fillPaymentID()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600CF23 RID: 53027 RVA: 0x00813FC8 File Offset: 0x008121C8
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

		' Token: 0x0600CF24 RID: 53028 RVA: 0x00814140 File Offset: 0x00812340
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

		' Token: 0x0600CF25 RID: 53029 RVA: 0x008141FC File Offset: 0x008123FC
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

		' Token: 0x0600CF26 RID: 53030 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600CF27 RID: 53031 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600CF28 RID: 53032 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600CF29 RID: 53033 RVA: 0x0005C167 File Offset: 0x0005A367
		Public Sub Reset()
			Me.cmbPaymentID.Text = ""
			Me.fillPaymentID()
		End Sub

		' Token: 0x0600CF2A RID: 53034 RVA: 0x008142C8 File Offset: 0x008124C8
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

		' Token: 0x0600CF2B RID: 53035 RVA: 0x0005C182 File Offset: 0x0005A382
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600CF2C RID: 53036 RVA: 0x0067E998 File Offset: 0x0067CB98
		Private Sub cmbPaymentID_Format(sender As Object, e As ListControlConvertEventArgs)
			Dim flag As Boolean = e.DesiredType Is GetType(String)
			If flag Then
				e.Value = e.Value.ToString().Trim()
			End If
		End Sub

		' Token: 0x0600CF2D RID: 53037 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalaryslip_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600CF2E RID: 53038 RVA: 0x0005C19E File Offset: 0x0005A39E
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600CF2F RID: 53039 RVA: 0x008143B8 File Offset: 0x008125B8
		Private Sub btnView_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.cmbPaymentID.Text)) = 0
				If flag Then
					MessageBox.Show("Please select payment id", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.cmbPaymentID.Focus()
				Else
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
					sqlCommand.CommandText = "SELECT EmployeeRegistration.EmployeeID, EmployeePayment.EmployeeID as expr10, EmployeePayment.PaymentID, EmployeePayment.DateFrom, EmployeePayment.DateTo, EmployeePayment.PresentDays, EmployeePayment.Salary,EmployeePayment.Advance, EmployeePayment.Deduction, EmployeePayment.Overtime, EmployeePayment.OvertimeRate, EmployeePayment.OvertimeAmount, EmployeePayment.PaymentDate,EmployeePayment.ModeOfPayment, EmployeePayment.PaymentModeDetails, EmployeePayment.NetPay, EmployeeRegistration.Id AS Expr1,EmployeeRegistration.EmployeeName, EmployeeRegistration.Gender, EmployeeRegistration.Address, EmployeeRegistration.City, EmployeeRegistration.ContactNo, EmployeeRegistration.Email,EmployeeRegistration.BloodGroup, EmployeeRegistration.Department, EmployeeRegistration.Designation, EmployeeRegistration.DateOfJoining, EmployeeRegistration.Salary AS Expr3,EmployeeRegistration.BasicWorkingTime, EmployeeRegistration.Photo FROM EmployeePayment INNER JOIN EmployeeRegistration ON EmployeePayment.EmployeeID = EmployeeRegistration.Id where PaymentID='" + Me.cmbPaymentID.Text + "'"
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
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
