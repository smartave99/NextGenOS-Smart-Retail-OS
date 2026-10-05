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
	' Token: 0x0200032B RID: 811
	<DesignerGenerated()>
	Public Partial Class frmAdvanceEntryRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600BE3B RID: 48699 RVA: 0x00055012 File Offset: 0x00053212
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmAdvanceEntryRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004BC2 RID: 19394
		' (get) Token: 0x0600BE3E RID: 48702 RVA: 0x00055044 File Offset: 0x00053244
		' (set) Token: 0x0600BE3F RID: 48703 RVA: 0x0005504E File Offset: 0x0005324E
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004BC3 RID: 19395
		' (get) Token: 0x0600BE40 RID: 48704 RVA: 0x00055057 File Offset: 0x00053257
		' (set) Token: 0x0600BE41 RID: 48705 RVA: 0x00796AB0 File Offset: 0x00794CB0
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

		' Token: 0x17004BC4 RID: 19396
		' (get) Token: 0x0600BE42 RID: 48706 RVA: 0x00055061 File Offset: 0x00053261
		' (set) Token: 0x0600BE43 RID: 48707 RVA: 0x0005506B File Offset: 0x0005326B
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004BC5 RID: 19397
		' (get) Token: 0x0600BE44 RID: 48708 RVA: 0x00055074 File Offset: 0x00053274
		' (set) Token: 0x0600BE45 RID: 48709 RVA: 0x0005507E File Offset: 0x0005327E
		Friend Overridable Property Label1 As Label

		' Token: 0x17004BC6 RID: 19398
		' (get) Token: 0x0600BE46 RID: 48710 RVA: 0x00055087 File Offset: 0x00053287
		' (set) Token: 0x0600BE47 RID: 48711 RVA: 0x00055091 File Offset: 0x00053291
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004BC7 RID: 19399
		' (get) Token: 0x0600BE48 RID: 48712 RVA: 0x0005509A File Offset: 0x0005329A
		' (set) Token: 0x0600BE49 RID: 48713 RVA: 0x000550A4 File Offset: 0x000532A4
		Friend Overridable Property groupBox5 As GroupBox

		' Token: 0x17004BC8 RID: 19400
		' (get) Token: 0x0600BE4A RID: 48714 RVA: 0x000550AD File Offset: 0x000532AD
		' (set) Token: 0x0600BE4B RID: 48715 RVA: 0x000550B7 File Offset: 0x000532B7
		Friend Overridable Property groupBox3 As GroupBox

		' Token: 0x17004BC9 RID: 19401
		' (get) Token: 0x0600BE4C RID: 48716 RVA: 0x000550C0 File Offset: 0x000532C0
		' (set) Token: 0x0600BE4D RID: 48717 RVA: 0x000550CA File Offset: 0x000532CA
		Friend Overridable Property DateTo As DateTimePicker

		' Token: 0x17004BCA RID: 19402
		' (get) Token: 0x0600BE4E RID: 48718 RVA: 0x000550D3 File Offset: 0x000532D3
		' (set) Token: 0x0600BE4F RID: 48719 RVA: 0x000550DD File Offset: 0x000532DD
		Friend Overridable Property DateFrom As DateTimePicker

		' Token: 0x17004BCB RID: 19403
		' (get) Token: 0x0600BE50 RID: 48720 RVA: 0x000550E6 File Offset: 0x000532E6
		' (set) Token: 0x0600BE51 RID: 48721 RVA: 0x000550F0 File Offset: 0x000532F0
		Friend Overridable Property label7 As Label

		' Token: 0x17004BCC RID: 19404
		' (get) Token: 0x0600BE52 RID: 48722 RVA: 0x000550F9 File Offset: 0x000532F9
		' (set) Token: 0x0600BE53 RID: 48723 RVA: 0x00055103 File Offset: 0x00053303
		Friend Overridable Property label9 As Label

		' Token: 0x17004BCD RID: 19405
		' (get) Token: 0x0600BE54 RID: 48724 RVA: 0x0005510C File Offset: 0x0005330C
		' (set) Token: 0x0600BE55 RID: 48725 RVA: 0x00796B10 File Offset: 0x00794D10
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

		' Token: 0x17004BCE RID: 19406
		' (get) Token: 0x0600BE56 RID: 48726 RVA: 0x00055116 File Offset: 0x00053316
		' (set) Token: 0x0600BE57 RID: 48727 RVA: 0x00055120 File Offset: 0x00053320
		Friend Overridable Property Total As GroupBox

		' Token: 0x17004BCF RID: 19407
		' (get) Token: 0x0600BE58 RID: 48728 RVA: 0x00055129 File Offset: 0x00053329
		' (set) Token: 0x0600BE59 RID: 48729 RVA: 0x00055133 File Offset: 0x00053333
		Friend Overridable Property TotalAdvance As TextBox

		' Token: 0x17004BD0 RID: 19408
		' (get) Token: 0x0600BE5A RID: 48730 RVA: 0x0005513C File Offset: 0x0005333C
		' (set) Token: 0x0600BE5B RID: 48731 RVA: 0x00796B54 File Offset: 0x00794D54
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004BD1 RID: 19409
		' (get) Token: 0x0600BE5C RID: 48732 RVA: 0x00055146 File Offset: 0x00053346
		' (set) Token: 0x0600BE5D RID: 48733 RVA: 0x00055150 File Offset: 0x00053350
		Friend Overridable Property lblSet As Label

		' Token: 0x17004BD2 RID: 19410
		' (get) Token: 0x0600BE5E RID: 48734 RVA: 0x00055159 File Offset: 0x00053359
		' (set) Token: 0x0600BE5F RID: 48735 RVA: 0x00055163 File Offset: 0x00053363
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004BD3 RID: 19411
		' (get) Token: 0x0600BE60 RID: 48736 RVA: 0x0005516C File Offset: 0x0005336C
		' (set) Token: 0x0600BE61 RID: 48737 RVA: 0x00796B98 File Offset: 0x00794D98
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

		' Token: 0x17004BD4 RID: 19412
		' (get) Token: 0x0600BE62 RID: 48738 RVA: 0x00055176 File Offset: 0x00053376
		' (set) Token: 0x0600BE63 RID: 48739 RVA: 0x00796BDC File Offset: 0x00794DDC
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

		' Token: 0x0600BE64 RID: 48740 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600BE65 RID: 48741 RVA: 0x00796C20 File Offset: 0x00794E20
		Public Sub GetData()
			Try
				Me.Total.Visible = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(AdvanceEntry.ID) as [ID], Convert(DateTime,workingdate,131) as [Entry Date],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(Amount) as [Advance] from Advanceentry,employeeRegistration where EmployeeRegistration.ID=AdvanceEntry.EmployeeID and Amount > 0 order by workingdate", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "AdvanceEntry")
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("AdvanceEntry").DefaultView
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				Dim num As Double = 0.0
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(5).Value))
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				num = Math.Round(num, 2)
				Me.TotalAdvance.Text = Strings.Format(Math.Round(num, 2), "0.00")
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BE66 RID: 48742 RVA: 0x00796DE8 File Offset: 0x00794FE8
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600BE67 RID: 48743 RVA: 0x00796E6C File Offset: 0x0079506C
		Public Sub Reset()
			Me.txtEmployeeName.Text = ""
			Me.DateFrom.Value = DateAndTime.Today
			Me.DateTo.Value = DateAndTime.Now
			Me.Total.Visible = False
			Me.GetData()
		End Sub

		' Token: 0x0600BE68 RID: 48744 RVA: 0x00796EC4 File Offset: 0x007950C4
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Advance Entry", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyBase.Hide()
						MyProject.Forms.frmAdvanceEntry.Show()
						MyProject.Forms.frmAdvanceEntry.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmAdvanceEntry.dtpEntryDate.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmAdvanceEntry.txtEmpID.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmAdvanceEntry.txtEmployeeID.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmAdvanceEntry.txtEmployeeName.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmAdvanceEntry.txtAmount.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmAdvanceEntry.btnSave.Enabled = False
						MyProject.Forms.frmAdvanceEntry.btnUpdate.Enabled = True
						MyProject.Forms.frmAdvanceEntry.btnDelete.Enabled = True
						MyProject.Forms.frmAdvanceEntry.dtpEntryDate.Enabled = False
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600BE69 RID: 48745 RVA: 0x007970C4 File Offset: 0x007952C4
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

		' Token: 0x0600BE6A RID: 48746 RVA: 0x007971AC File Offset: 0x007953AC
		Private Sub txtEmployeeName_TextChanged(sender As Object, e As EventArgs)
			Try
				Me.Total.Visible = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(AdvanceEntry.ID) as [ID], Convert(DateTime,workingdate,131) as [Entry Date],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(Amount) as [Advance] from Advanceentry,employeeRegistration where EmployeeRegistration.ID=AdvanceEntry.EmployeeID and Amount > 0 and EmployeeName like N'%" + Me.txtEmployeeName.Text + "%' order by workingdate", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "AdvanceEntry")
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("AdvanceEntry").DefaultView
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				Dim num As Double = 0.0
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(5).Value))
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				num = Math.Round(num, 2)
				Me.TotalAdvance.Text = Strings.Format(Math.Round(num, 2), "0.00")
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BE6B RID: 48747 RVA: 0x00797388 File Offset: 0x00795588
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Me.Total.Visible = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(AdvanceEntry.ID) as [ID], Convert(DateTime,workingdate,131) as [Entry Date],RTRIM(EmployeeRegistration.ID) as [Emp ID],RTRIM(EmployeeRegistration.EmployeeID) as [Employee ID],RTRIM(EmployeeName) as [Employee Name],RTRIM(Amount) as [Advance] from Advanceentry,employeeRegistration where EmployeeRegistration.ID=AdvanceEntry.EmployeeID and Amount > 0 and WorkingDate Between @d1 and @d2 order by workingdate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "AdvanceEntry")
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("AdvanceEntry").DefaultView
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				Dim num As Double = 0.0
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						num = Conversions.ToDouble(Operators.AddObject(num, dataGridViewRow.Cells(5).Value))
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				num = Math.Round(num, 2)
				Me.TotalAdvance.Text = Strings.Format(Math.Round(num, 2), "0.00")
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600BE6C RID: 48748 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmAdvanceEntryRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600BE6D RID: 48749 RVA: 0x00055180 File Offset: 0x00053380
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600BE6E RID: 48750 RVA: 0x007975C0 File Offset: 0x007957C0
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
	End Class
End Namespace
