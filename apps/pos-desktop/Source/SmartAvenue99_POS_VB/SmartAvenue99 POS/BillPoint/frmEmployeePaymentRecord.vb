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
	' Token: 0x0200033F RID: 831
	<DesignerGenerated()>
	Public Partial Class frmEmployeePaymentRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C22D RID: 49709 RVA: 0x00056CBB File Offset: 0x00054EBB
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEmployeePaymentRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004D28 RID: 19752
		' (get) Token: 0x0600C230 RID: 49712 RVA: 0x00056CED File Offset: 0x00054EED
		' (set) Token: 0x0600C231 RID: 49713 RVA: 0x00056CF7 File Offset: 0x00054EF7
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004D29 RID: 19753
		' (get) Token: 0x0600C232 RID: 49714 RVA: 0x00056D00 File Offset: 0x00054F00
		' (set) Token: 0x0600C233 RID: 49715 RVA: 0x007B75CC File Offset: 0x007B57CC
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

		' Token: 0x17004D2A RID: 19754
		' (get) Token: 0x0600C234 RID: 49716 RVA: 0x00056D0A File Offset: 0x00054F0A
		' (set) Token: 0x0600C235 RID: 49717 RVA: 0x00056D14 File Offset: 0x00054F14
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004D2B RID: 19755
		' (get) Token: 0x0600C236 RID: 49718 RVA: 0x00056D1D File Offset: 0x00054F1D
		' (set) Token: 0x0600C237 RID: 49719 RVA: 0x00056D27 File Offset: 0x00054F27
		Friend Overridable Property Label1 As Label

		' Token: 0x17004D2C RID: 19756
		' (get) Token: 0x0600C238 RID: 49720 RVA: 0x00056D30 File Offset: 0x00054F30
		' (set) Token: 0x0600C239 RID: 49721 RVA: 0x00056D3A File Offset: 0x00054F3A
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004D2D RID: 19757
		' (get) Token: 0x0600C23A RID: 49722 RVA: 0x00056D43 File Offset: 0x00054F43
		' (set) Token: 0x0600C23B RID: 49723 RVA: 0x00056D4D File Offset: 0x00054F4D
		Friend Overridable Property groupBox5 As GroupBox

		' Token: 0x17004D2E RID: 19758
		' (get) Token: 0x0600C23C RID: 49724 RVA: 0x00056D56 File Offset: 0x00054F56
		' (set) Token: 0x0600C23D RID: 49725 RVA: 0x00056D60 File Offset: 0x00054F60
		Friend Overridable Property groupBox3 As GroupBox

		' Token: 0x17004D2F RID: 19759
		' (get) Token: 0x0600C23E RID: 49726 RVA: 0x00056D69 File Offset: 0x00054F69
		' (set) Token: 0x0600C23F RID: 49727 RVA: 0x00056D73 File Offset: 0x00054F73
		Friend Overridable Property DateTo As DateTimePicker

		' Token: 0x17004D30 RID: 19760
		' (get) Token: 0x0600C240 RID: 49728 RVA: 0x00056D7C File Offset: 0x00054F7C
		' (set) Token: 0x0600C241 RID: 49729 RVA: 0x00056D86 File Offset: 0x00054F86
		Friend Overridable Property DateFrom As DateTimePicker

		' Token: 0x17004D31 RID: 19761
		' (get) Token: 0x0600C242 RID: 49730 RVA: 0x00056D8F File Offset: 0x00054F8F
		' (set) Token: 0x0600C243 RID: 49731 RVA: 0x00056D99 File Offset: 0x00054F99
		Friend Overridable Property label7 As Label

		' Token: 0x17004D32 RID: 19762
		' (get) Token: 0x0600C244 RID: 49732 RVA: 0x00056DA2 File Offset: 0x00054FA2
		' (set) Token: 0x0600C245 RID: 49733 RVA: 0x00056DAC File Offset: 0x00054FAC
		Friend Overridable Property label9 As Label

		' Token: 0x17004D33 RID: 19763
		' (get) Token: 0x0600C246 RID: 49734 RVA: 0x00056DB5 File Offset: 0x00054FB5
		' (set) Token: 0x0600C247 RID: 49735 RVA: 0x007B762C File Offset: 0x007B582C
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

		' Token: 0x17004D34 RID: 19764
		' (get) Token: 0x0600C248 RID: 49736 RVA: 0x00056DBF File Offset: 0x00054FBF
		' (set) Token: 0x0600C249 RID: 49737 RVA: 0x00056DC9 File Offset: 0x00054FC9
		Friend Overridable Property lblSet As Label

		' Token: 0x17004D35 RID: 19765
		' (get) Token: 0x0600C24A RID: 49738 RVA: 0x00056DD2 File Offset: 0x00054FD2
		' (set) Token: 0x0600C24B RID: 49739 RVA: 0x00056DDC File Offset: 0x00054FDC
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004D36 RID: 19766
		' (get) Token: 0x0600C24C RID: 49740 RVA: 0x00056DE5 File Offset: 0x00054FE5
		' (set) Token: 0x0600C24D RID: 49741 RVA: 0x007B7670 File Offset: 0x007B5870
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

		' Token: 0x17004D37 RID: 19767
		' (get) Token: 0x0600C24E RID: 49742 RVA: 0x00056DEF File Offset: 0x00054FEF
		' (set) Token: 0x0600C24F RID: 49743 RVA: 0x007B76B4 File Offset: 0x007B58B4
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

		' Token: 0x17004D38 RID: 19768
		' (get) Token: 0x0600C250 RID: 49744 RVA: 0x00056DF9 File Offset: 0x00054FF9
		' (set) Token: 0x0600C251 RID: 49745 RVA: 0x007B76F8 File Offset: 0x007B58F8
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
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

		' Token: 0x0600C252 RID: 49746 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600C253 RID: 49747 RVA: 0x007B773C File Offset: 0x007B593C
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(EmployeePayment.ID) as [ID],(PaymentID) as [Payment ID],Convert(DateTime,DateFrom,103) as [Date From],Convert(DateTime,dateto,103) as [Date To],RTRIM(EmployeeRegistration.id) as [Emp ID],RTRIM(EmployeeRegistration.employeeid) as [Employee ID],RTRIM(Employeename) as [Employee Name],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(EmployeePayment.salary) as [Salary],RTRIM(presentdays) as [Prsesent Days],RTRIM(advance) as [Advance],RTRIM(deduction) as [Deduction],RTRIM(overtime) as [Overtime],RTRIM(overtimerate) as [Overtime Rate],RTRIM(overtimeamount) as [Overtime Amount],Convert(DateTime,paymentdate,131) as [Payment Date],RTRIM(modeofpayment) as [Payment Mode],RTRIM(paymentmodedetails) as [Note],RTRIM(netpay) as [Net Pay],RTRIM(BankAccount) as [Bank A/c No] from employeepayment,EmployeeRegistration where EmployeeRegistration.ID=EmployeePayment.EmployeeID order by paymentdate", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeePayment")
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("EmployeePayment").DefaultView
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C254 RID: 49748 RVA: 0x007B7834 File Offset: 0x007B5A34
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600C255 RID: 49749 RVA: 0x00056E03 File Offset: 0x00055003
		Public Sub Reset()
			Me.txtEmployeeName.Text = ""
			Me.DateFrom.Value = DateAndTime.Today
			Me.DateTo.Value = DateAndTime.Now
			Me.GetData()
		End Sub

		' Token: 0x0600C256 RID: 49750 RVA: 0x007B78B8 File Offset: 0x007B5AB8
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Payment", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyBase.Hide()
						MyProject.Forms.frmEmployeePayment.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmEmployeePayment.PaymentID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmEmployeePayment.DateFrom.Value = Conversions.ToDate(dataGridViewRow.Cells(2).Value.ToString())
						MyProject.Forms.frmEmployeePayment.DateTo.Value = Conversions.ToDate(dataGridViewRow.Cells(3).Value.ToString())
						MyProject.Forms.frmEmployeePayment.txtEmpID.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmEmployeePayment.EmployeeID.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmEmployeePayment.EmployeeName.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmEmployeePayment.Designation.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmEmployeePayment.Department.Text = dataGridViewRow.Cells(7).Value.ToString()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						Dim text As String = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("select Salary from EmployeeRegistration where id=", dataGridViewRow.Cells(4).Value), ""))
						ModCommonClasses.cmd = New SqlCommand(text)
						ModCommonClasses.cmd.Connection = ModCommonClasses.con
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
						Dim flag3 As Boolean = ModCommonClasses.rdr.Read()
						If flag3 Then
							MyProject.Forms.frmEmployeePayment.txtSalary.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
						End If
						Dim flag4 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag4 Then
							ModCommonClasses.rdr.Close()
						End If
						Dim flag5 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
						If flag5 Then
							ModCommonClasses.con.Close()
						End If
						MyProject.Forms.frmEmployeePayment.Salary.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmEmployeePayment.PresentDays.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmEmployeePayment.Advance.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmEmployeePayment.Deduction.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmEmployeePayment.Overtime.Text = dataGridViewRow.Cells(13).Value.ToString()
						MyProject.Forms.frmEmployeePayment.OvertimeRate.Text = dataGridViewRow.Cells(14).Value.ToString()
						MyProject.Forms.frmEmployeePayment.OvertimeAmount.Text = dataGridViewRow.Cells(15).Value.ToString()
						MyProject.Forms.frmEmployeePayment.PaymentDate.Text = dataGridViewRow.Cells(16).Value.ToString()
						MyProject.Forms.frmEmployeePayment.paymentmode.Text = dataGridViewRow.Cells(17).Value.ToString()
						MyProject.Forms.frmEmployeePayment.PaymentModeDetails.Text = dataGridViewRow.Cells(18).Value.ToString()
						MyProject.Forms.frmEmployeePayment.NetPay.Text = dataGridViewRow.Cells(19).Value.ToString()
						MyProject.Forms.frmEmployeePayment.cmbAccountNo.Text = dataGridViewRow.Cells(20).Value.ToString()
						MyProject.Forms.frmEmployeePayment.btnSave.Enabled = False
						MyProject.Forms.frmEmployeePayment.btnDelete.Enabled = True
						MyProject.Forms.frmEmployeePayment.btnUpdate.Enabled = True
						MyProject.Forms.frmEmployeePayment.btnPrint.Enabled = True
						MyProject.Forms.frmEmployeePayment.DateFrom.Enabled = False
						MyProject.Forms.frmEmployeePayment.DateTo.Enabled = False
						MyProject.Forms.frmEmployeePayment.PaymentDate.Enabled = False
						MyProject.Forms.frmEmployeePayment.Deduction.[ReadOnly] = True
						MyProject.Forms.frmEmployeePayment.dgw.Enabled = False
						Me.lblSet.Text = ""
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C257 RID: 49751 RVA: 0x007B7EA4 File Offset: 0x007B60A4
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

		' Token: 0x0600C258 RID: 49752 RVA: 0x007B7F8C File Offset: 0x007B618C
		Private Sub txtEmployeeName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(EmployeePayment.ID) as [ID],(PaymentID) as [Payment ID],Convert(DateTime,DateFrom,103) as [Date From],Convert(DateTime,dateto,103) as [Date To],RTRIM(EmployeeRegistration.id) as [Emp ID],RTRIM(EmployeeRegistration.employeeid) as [Employee ID],RTRIM(Employeename) as [Employee Name],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(EmployeePayment.salary) as [Salary],RTRIM(presentdays) as [Prsesent Days],RTRIM(advance) as [Advance],RTRIM(deduction) as [Deduction],RTRIM(overtime) as [Overtime],RTRIM(overtimerate) as [Overtime Rate],RTRIM(overtimeamount) as [Overtime Amount],Convert(DateTime,paymentdate,131) as [Payment Date],RTRIM(modeofpayment) as [Payment Mode],RTRIM(paymentmodedetails) as [Note],RTRIM(netpay) as [Net Pay],RTRIM(BankAccount) as [Bank A/c No] from employeepayment,EmployeeRegistration where EmployeeRegistration.ID=EmployeePayment.EmployeeID and Employeename like N'%" + Me.txtEmployeeName.Text + "%' order by paymentdate", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeePayment")
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("EmployeePayment").DefaultView
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C259 RID: 49753 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEmployeePaymentRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C25A RID: 49754 RVA: 0x007B8098 File Offset: 0x007B6298
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("select RTRIM(EmployeePayment.ID) as [ID],(PaymentID) as [Payment ID],Convert(DateTime,DateFrom,103) as [Date From],Convert(DateTime,dateto,103) as [Date To],RTRIM(EmployeeRegistration.id) as [Emp ID],RTRIM(EmployeeRegistration.employeeid) as [Employee ID],RTRIM(Employeename) as [Employee Name],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(EmployeePayment.salary) as [Salary],RTRIM(presentdays) as [Prsesent Days],RTRIM(advance) as [Advance],RTRIM(deduction) as [Deduction],RTRIM(overtime) as [Overtime],RTRIM(overtimerate) as [Overtime Rate],RTRIM(overtimeamount) as [Overtime Amount],Convert(DateTime,paymentdate,131) as [Payment Date],RTRIM(modeofpayment) as [Payment Mode],RTRIM(paymentmodedetails) as [Note],RTRIM(netpay) as [Net Pay],RTRIM(BankAccount) as [Bank A/c No] from employeepayment,EmployeeRegistration where EmployeeRegistration.ID=EmployeePayment.EmployeeID and PaymentDate Between @d1 and @d2 order by paymentdate", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = Me.DateTo.Value
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeePayment")
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("EmployeePayment").DefaultView
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C25B RID: 49755 RVA: 0x00056E40 File Offset: 0x00055040
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600C25C RID: 49756 RVA: 0x007B8208 File Offset: 0x007B6408
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
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
