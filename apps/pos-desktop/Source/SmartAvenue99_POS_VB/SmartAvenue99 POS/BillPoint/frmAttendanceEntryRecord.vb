Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200032E RID: 814
	<DesignerGenerated()>
	Public Partial Class frmAttendanceEntryRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BF1A RID: 48922 RVA: 0x0005568E File Offset: 0x0005388E
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAttendanceEntryRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004C13 RID: 19475
		' (get) Token: 0x0600BF1D RID: 48925 RVA: 0x000556C0 File Offset: 0x000538C0
		' (set) Token: 0x0600BF1E RID: 48926 RVA: 0x000556CA File Offset: 0x000538CA
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004C14 RID: 19476
		' (get) Token: 0x0600BF1F RID: 48927 RVA: 0x000556D3 File Offset: 0x000538D3
		' (set) Token: 0x0600BF20 RID: 48928 RVA: 0x0079DDCC File Offset: 0x0079BFCC
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

		' Token: 0x17004C15 RID: 19477
		' (get) Token: 0x0600BF21 RID: 48929 RVA: 0x000556DD File Offset: 0x000538DD
		' (set) Token: 0x0600BF22 RID: 48930 RVA: 0x000556E7 File Offset: 0x000538E7
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004C16 RID: 19478
		' (get) Token: 0x0600BF23 RID: 48931 RVA: 0x000556F0 File Offset: 0x000538F0
		' (set) Token: 0x0600BF24 RID: 48932 RVA: 0x000556FA File Offset: 0x000538FA
		Friend Overridable Property Label1 As Label

		' Token: 0x17004C17 RID: 19479
		' (get) Token: 0x0600BF25 RID: 48933 RVA: 0x00055703 File Offset: 0x00053903
		' (set) Token: 0x0600BF26 RID: 48934 RVA: 0x0005570D File Offset: 0x0005390D
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004C18 RID: 19480
		' (get) Token: 0x0600BF27 RID: 48935 RVA: 0x00055716 File Offset: 0x00053916
		' (set) Token: 0x0600BF28 RID: 48936 RVA: 0x00055720 File Offset: 0x00053920
		Friend Overridable Property groupBox5 As GroupBox

		' Token: 0x17004C19 RID: 19481
		' (get) Token: 0x0600BF29 RID: 48937 RVA: 0x00055729 File Offset: 0x00053929
		' (set) Token: 0x0600BF2A RID: 48938 RVA: 0x00055733 File Offset: 0x00053933
		Friend Overridable Property groupBox3 As GroupBox

		' Token: 0x17004C1A RID: 19482
		' (get) Token: 0x0600BF2B RID: 48939 RVA: 0x0005573C File Offset: 0x0005393C
		' (set) Token: 0x0600BF2C RID: 48940 RVA: 0x00055746 File Offset: 0x00053946
		Friend Overridable Property DateTo As DateTimePicker

		' Token: 0x17004C1B RID: 19483
		' (get) Token: 0x0600BF2D RID: 48941 RVA: 0x0005574F File Offset: 0x0005394F
		' (set) Token: 0x0600BF2E RID: 48942 RVA: 0x00055759 File Offset: 0x00053959
		Friend Overridable Property DateFrom As DateTimePicker

		' Token: 0x17004C1C RID: 19484
		' (get) Token: 0x0600BF2F RID: 48943 RVA: 0x00055762 File Offset: 0x00053962
		' (set) Token: 0x0600BF30 RID: 48944 RVA: 0x0005576C File Offset: 0x0005396C
		Friend Overridable Property label7 As Label

		' Token: 0x17004C1D RID: 19485
		' (get) Token: 0x0600BF31 RID: 48945 RVA: 0x00055775 File Offset: 0x00053975
		' (set) Token: 0x0600BF32 RID: 48946 RVA: 0x0005577F File Offset: 0x0005397F
		Friend Overridable Property label9 As Label

		' Token: 0x17004C1E RID: 19486
		' (get) Token: 0x0600BF33 RID: 48947 RVA: 0x00055788 File Offset: 0x00053988
		' (set) Token: 0x0600BF34 RID: 48948 RVA: 0x0079DE2C File Offset: 0x0079C02C
		Private _txtEmployeeName As TextBox
		Friend Overridable Property txtEmployeeName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmployeeName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtEmployeeName_TextChanged
				Dim textBox As TextBox = Me._txtEmployeeName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtEmployeeName = value
				textBox = Me._txtEmployeeName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004C1F RID: 19487
		' (get) Token: 0x0600BF35 RID: 48949 RVA: 0x00055792 File Offset: 0x00053992
		' (set) Token: 0x0600BF36 RID: 48950 RVA: 0x0005579C File Offset: 0x0005399C
		Friend Overridable Property lblSet As Label

		' Token: 0x17004C20 RID: 19488
		' (get) Token: 0x0600BF37 RID: 48951 RVA: 0x000557A5 File Offset: 0x000539A5
		' (set) Token: 0x0600BF38 RID: 48952 RVA: 0x000557AF File Offset: 0x000539AF
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004C21 RID: 19489
		' (get) Token: 0x0600BF39 RID: 48953 RVA: 0x000557B8 File Offset: 0x000539B8
		' (set) Token: 0x0600BF3A RID: 48954 RVA: 0x0079DE70 File Offset: 0x0079C070
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

		' Token: 0x17004C22 RID: 19490
		' (get) Token: 0x0600BF3B RID: 48955 RVA: 0x000557C2 File Offset: 0x000539C2
		' (set) Token: 0x0600BF3C RID: 48956 RVA: 0x0079DEB4 File Offset: 0x0079C0B4
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

		' Token: 0x17004C23 RID: 19491
		' (get) Token: 0x0600BF3D RID: 48957 RVA: 0x000557CC File Offset: 0x000539CC
		' (set) Token: 0x0600BF3E RID: 48958 RVA: 0x0079DEF8 File Offset: 0x0079C0F8
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

		' Token: 0x0600BF3F RID: 48959 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600BF40 RID: 48960 RVA: 0x0079DF3C File Offset: 0x0079C13C
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(EmployeeAttendance.ID) as [Attendance ID],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(EmployeeRegistration.BasicWorkingTime) as [Basic Working Time], Convert(DateTime,WorkingDate,103) as [Working Date],RTRIM(Status) as [Status], RTRIM(InTime) as [In Time],RTRIM(OutTime) as [Out Time],RTRIM(Overtime) as [Overtime] from employeeAttendance,EmployeeRegistration where EmployeeRegistration.ID=EmployeeAttendance.EmployeeID order by workingdate", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeeAttendance")
				Me.dgw.DataSource = dataSet.Tables("EmployeeAttendance").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BF41 RID: 48961 RVA: 0x0079E008 File Offset: 0x0079C208
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600BF42 RID: 48962 RVA: 0x000557D6 File Offset: 0x000539D6
		Public Sub Reset()
			Me.txtEmployeeName.Text = ""
			Me.DateFrom.Value = DateAndTime.Today
			Me.DateTo.Value = DateAndTime.Now
			Me.GetData()
		End Sub

		' Token: 0x0600BF43 RID: 48963 RVA: 0x0079E08C File Offset: 0x0079C28C
		Private Sub btnExportExcel_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BF44 RID: 48964 RVA: 0x0079E338 File Offset: 0x0079C538
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Attendance Entry", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyBase.Hide()
						MyProject.Forms.frmAttendance.Show()
						MyProject.Forms.frmAttendance.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmAttendance.txtEmpID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmAttendance.EmployeeID.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmAttendance.EmployeeName.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmAttendance.BasicWorkingTime.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmAttendance.WorkingDate.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmAttendance.Status.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmAttendance.InTime.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmAttendance.OutTime.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmAttendance.Overtime.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmAttendance.btnSave.Enabled = False
						MyProject.Forms.frmAttendance.btnUpdate.Enabled = True
						MyProject.Forms.frmAttendance.btnDelete.Enabled = True
						MyProject.Forms.frmAttendance.WorkingDate.Enabled = False
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600BF45 RID: 48965 RVA: 0x0079E5E4 File Offset: 0x0079C7E4
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

		' Token: 0x0600BF46 RID: 48966 RVA: 0x0079E6CC File Offset: 0x0079C8CC
		Private Sub txtEmployeeName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(EmployeeAttendance.ID) as [Attendance ID],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(EmployeeRegistration.BasicWorkingTime) as [Basic Working Time], Convert(DateTime,WorkingDate,103) as [Working Date],RTRIM(Status) as [Status], RTRIM(InTime) as [In Time],RTRIM(OutTime) as [Out Time],RTRIM(Overtime) as [Overtime] from employeeAttendance,EmployeeRegistration where EmployeeRegistration.ID=EmployeeAttendance.EmployeeID and EmployeeName like N'%" + Me.txtEmployeeName.Text + "%' order by workingdate", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeeAttendance")
				Me.dgw.DataSource = dataSet.Tables("EmployeeAttendance").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BF47 RID: 48967 RVA: 0x0079E7AC File Offset: 0x0079C9AC
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(EmployeeAttendance.ID) as [Attendance ID],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(EmployeeRegistration.BasicWorkingTime) as [Basic Working Time], Convert(DateTime,WorkingDate,103) as [Working Date],RTRIM(Status) as [Status], RTRIM(InTime) as [In Time],RTRIM(OutTime) as [Out Time],RTRIM(Overtime) as [Overtime] from employeeAttendance,EmployeeRegistration where EmployeeRegistration.ID=EmployeeAttendance.EmployeeID and WorkingDate Between @d1 and @d2 order by workingdate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeeAttendance")
				Me.dgw.DataSource = dataSet.Tables("EmployeeAttendance").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BF48 RID: 48968 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAttendanceEntryRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BF49 RID: 48969 RVA: 0x0079E08C File Offset: 0x0079C28C
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
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
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BF4A RID: 48970 RVA: 0x00055813 File Offset: 0x00053A13
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600BF4B RID: 48971 RVA: 0x0079E7AC File Offset: 0x0079C9AC
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(EmployeeAttendance.ID) as [Attendance ID],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(EmployeeRegistration.BasicWorkingTime) as [Basic Working Time], Convert(DateTime,WorkingDate,103) as [Working Date],RTRIM(Status) as [Status], RTRIM(InTime) as [In Time],RTRIM(OutTime) as [Out Time],RTRIM(Overtime) as [Overtime] from employeeAttendance,EmployeeRegistration where EmployeeRegistration.ID=EmployeeAttendance.EmployeeID and WorkingDate Between @d1 and @d2 order by workingdate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeeAttendance")
				Me.dgw.DataSource = dataSet.Tables("EmployeeAttendance").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
