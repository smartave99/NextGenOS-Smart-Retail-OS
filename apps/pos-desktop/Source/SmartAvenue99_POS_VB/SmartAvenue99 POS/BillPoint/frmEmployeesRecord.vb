Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000342 RID: 834
	<DesignerGenerated()>
	Public Partial Class frmEmployeesRecord
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C315 RID: 49941 RVA: 0x00057355 File Offset: 0x00055555
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLogs_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmEmployeesRecord_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004D7C RID: 19836
		' (get) Token: 0x0600C318 RID: 49944 RVA: 0x00057387 File Offset: 0x00055587
		' (set) Token: 0x0600C319 RID: 49945 RVA: 0x00057391 File Offset: 0x00055591
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004D7D RID: 19837
		' (get) Token: 0x0600C31A RID: 49946 RVA: 0x0005739A File Offset: 0x0005559A
		' (set) Token: 0x0600C31B RID: 49947 RVA: 0x000573A4 File Offset: 0x000555A4
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17004D7E RID: 19838
		' (get) Token: 0x0600C31C RID: 49948 RVA: 0x000573AD File Offset: 0x000555AD
		' (set) Token: 0x0600C31D RID: 49949 RVA: 0x007BFB54 File Offset: 0x007BDD54
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

		' Token: 0x17004D7F RID: 19839
		' (get) Token: 0x0600C31E RID: 49950 RVA: 0x000573B7 File Offset: 0x000555B7
		' (set) Token: 0x0600C31F RID: 49951 RVA: 0x000573C1 File Offset: 0x000555C1
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004D80 RID: 19840
		' (get) Token: 0x0600C320 RID: 49952 RVA: 0x000573CA File Offset: 0x000555CA
		' (set) Token: 0x0600C321 RID: 49953 RVA: 0x000573D4 File Offset: 0x000555D4
		Friend Overridable Property Label3 As Label

		' Token: 0x17004D81 RID: 19841
		' (get) Token: 0x0600C322 RID: 49954 RVA: 0x000573DD File Offset: 0x000555DD
		' (set) Token: 0x0600C323 RID: 49955 RVA: 0x000573E7 File Offset: 0x000555E7
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004D82 RID: 19842
		' (get) Token: 0x0600C324 RID: 49956 RVA: 0x000573F0 File Offset: 0x000555F0
		' (set) Token: 0x0600C325 RID: 49957 RVA: 0x007BFBB4 File Offset: 0x007BDDB4
		Private _txtEmployeeName As TextBox
		Friend Overridable Property txtEmployeeName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtEmployeeName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtEmployeeRegistrationName_TextChanged
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

		' Token: 0x17004D83 RID: 19843
		' (get) Token: 0x0600C326 RID: 49958 RVA: 0x000573FA File Offset: 0x000555FA
		' (set) Token: 0x0600C327 RID: 49959 RVA: 0x00057404 File Offset: 0x00055604
		Friend Overridable Property lblSet As Label

		' Token: 0x17004D84 RID: 19844
		' (get) Token: 0x0600C328 RID: 49960 RVA: 0x0005740D File Offset: 0x0005560D
		' (set) Token: 0x0600C329 RID: 49961 RVA: 0x00057417 File Offset: 0x00055617
		Friend Overridable Property Label1 As Label

		' Token: 0x17004D85 RID: 19845
		' (get) Token: 0x0600C32A RID: 49962 RVA: 0x00057420 File Offset: 0x00055620
		' (set) Token: 0x0600C32B RID: 49963 RVA: 0x0005742A File Offset: 0x0005562A
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17004D86 RID: 19846
		' (get) Token: 0x0600C32C RID: 49964 RVA: 0x00057433 File Offset: 0x00055633
		' (set) Token: 0x0600C32D RID: 49965 RVA: 0x007BFBF8 File Offset: 0x007BDDF8
		Private _txtDesignation As TextBox
		Friend Overridable Property txtDesignation As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDesignation
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtDesignation_TextChanged
				Dim textBox As TextBox = Me._txtDesignation
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtDesignation = value
				textBox = Me._txtDesignation
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D87 RID: 19847
		' (get) Token: 0x0600C32E RID: 49966 RVA: 0x0005743D File Offset: 0x0005563D
		' (set) Token: 0x0600C32F RID: 49967 RVA: 0x00057447 File Offset: 0x00055647
		Friend Overridable Property Label4 As Label

		' Token: 0x17004D88 RID: 19848
		' (get) Token: 0x0600C330 RID: 49968 RVA: 0x00057450 File Offset: 0x00055650
		' (set) Token: 0x0600C331 RID: 49969 RVA: 0x0005745A File Offset: 0x0005565A
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17004D89 RID: 19849
		' (get) Token: 0x0600C332 RID: 49970 RVA: 0x00057463 File Offset: 0x00055663
		' (set) Token: 0x0600C333 RID: 49971 RVA: 0x007BFC3C File Offset: 0x007BDE3C
		Private _txtDepartment As TextBox
		Friend Overridable Property txtDepartment As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtDepartment
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtDepartment_TextChanged
				Dim textBox As TextBox = Me._txtDepartment
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtDepartment = value
				textBox = Me._txtDepartment
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004D8A RID: 19850
		' (get) Token: 0x0600C334 RID: 49972 RVA: 0x0005746D File Offset: 0x0005566D
		' (set) Token: 0x0600C335 RID: 49973 RVA: 0x00057477 File Offset: 0x00055677
		Friend Overridable Property Label2 As Label

		' Token: 0x17004D8B RID: 19851
		' (get) Token: 0x0600C336 RID: 49974 RVA: 0x00057480 File Offset: 0x00055680
		' (set) Token: 0x0600C337 RID: 49975 RVA: 0x007BFC80 File Offset: 0x007BDE80
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

		' Token: 0x0600C338 RID: 49976 RVA: 0x00010FC9 File Offset: 0x0000F1C9
		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		' Token: 0x0600C339 RID: 49977 RVA: 0x007BFCC4 File Offset: 0x007BDEC4
		Public Sub GetData()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(employeeid) as [Employee ID],RTRIM(employeename) as [Employee Name],RTRIM(Gender) as [Gender],RTRIM(address) as [Address],RTRIM(City) as [City],RTRIM(contactno) as [Contact No.],RTRIM(email) as [Email],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(bloodgroup) as [Blood Group],CONVERT(DateTime,DateOfJoining,103) as [Joining Date],RTRIM(salary) as [Salary],RTRIM(basicworkingtime) as [Basic Working Time],RTRIM(Active) as [Active] from EmployeeRegistration order by EmployeeName", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C33A RID: 49978 RVA: 0x007BFD90 File Offset: 0x007BDF90
		Private Sub frmLogs_Load(sender As Object, e As EventArgs)
			Me.GetData()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
		End Sub

		' Token: 0x0600C33B RID: 49979 RVA: 0x0005748A File Offset: 0x0005568A
		Public Sub Reset()
			Me.txtEmployeeName.Text = ""
			Me.txtDepartment.Text = ""
			Me.txtDesignation.Text = ""
			Me.GetData()
		End Sub

		' Token: 0x0600C33C RID: 49980 RVA: 0x007BFE14 File Offset: 0x007BE014
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
			Try
				Dim flag As Boolean = Me.dgw.Rows.Count > 0
				If flag Then
					Dim flag2 As Boolean = Operators.CompareString(Me.lblSet.Text, "Employee", False) = 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyBase.Hide()
						MyProject.Forms.frmEmployeeRegistration.Show()
						MyProject.Forms.frmEmployeeRegistration.txtID.Text = dataGridViewRow.Cells(0).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.txtEmployeeID.Text = dataGridViewRow.Cells(1).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.txtEmployeeName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.txtEmpName.Text = dataGridViewRow.Cells(2).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.cmbGender.Text = dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.txtAddress.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.txtCity.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.txtContactNo.Text = dataGridViewRow.Cells(6).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.txtEmail.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.cmbDepartment.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.cmbDesignation.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.cmbBloodGroup.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.dtpDateOfJoining.Text = dataGridViewRow.Cells(11).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.txtSalary.Text = dataGridViewRow.Cells(12).Value.ToString()
						MyProject.Forms.frmEmployeeRegistration.txtBasicWorkingTime.Text = dataGridViewRow.Cells(13).Value.ToString()
						Dim flag3 As Boolean = Operators.CompareString(dataGridViewRow.Cells(14).Value.ToString(), "Yes", False) = 0
						If flag3 Then
							MyProject.Forms.frmEmployeeRegistration.chkActive.Checked = True
						Else
							MyProject.Forms.frmEmployeeRegistration.chkActive.Checked = False
						End If
						MyProject.Forms.frmEmployeeRegistration.btnUpdate.Enabled = True
						MyProject.Forms.frmEmployeeRegistration.btnDelete.Enabled = True
						MyProject.Forms.frmEmployeeRegistration.btnSave.Enabled = False
						MyProject.Forms.frmEmployeeRegistration.txtEmployeeName.Focus()
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT Photo from EmployeeRegistration where EmployeeRegistration.EmployeeID='", dataGridViewRow.Cells(1).Value), "'")), ModCommonClasses.con)
						ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
						While ModCommonClasses.rdr.Read()
							Dim array As Byte() = CType(ModCommonClasses.rdr(0), Byte())
							Dim memoryStream As MemoryStream = New MemoryStream(array)
							MyProject.Forms.frmEmployeeRegistration.Picture.Image = Image.FromStream(memoryStream)
						End While
						ModCommonClasses.con.Close()
						Me.lblSet.Text = ""
					End If
					Dim flag4 As Boolean = Operators.CompareString(Me.lblSet.Text, "Employee Account Master", False) = 0
					If flag4 Then
						Dim dataGridViewRow2 As DataGridViewRow = Me.dgw.SelectedRows(0)
						MyBase.Hide()
					End If
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600C33D RID: 49981 RVA: 0x007C02FC File Offset: 0x007BE4FC
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

		' Token: 0x0600C33E RID: 49982 RVA: 0x007C03E4 File Offset: 0x007BE5E4
		Private Sub txtEmployeeRegistrationName_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(employeeid) as [Employee ID],RTRIM(employeename) as [Employee Name],RTRIM(Gender) as [Gender],RTRIM(address) as [Address],RTRIM(City) as [City],RTRIM(contactno) as [Contact No.],RTRIM(email) as [Email],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(bloodgroup) as [Blood Group],CONVERT(DateTime,DateOfJoining,103) as [Joining Date],RTRIM(salary) as [Salary],RTRIM(basicworkingtime) as [Basic Working Time],RTRIM(Active) as [Active] from EmployeeRegistration where EmployeeName like N'%" + Me.txtEmployeeName.Text + "%' order by EmployeeName", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C33F RID: 49983 RVA: 0x007C04C4 File Offset: 0x007BE6C4
		Private Sub txtDepartment_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(employeeid) as [Employee ID],RTRIM(employeename) as [Employee Name],RTRIM(Gender) as [Gender],RTRIM(address) as [Address],RTRIM(City) as [City],RTRIM(contactno) as [Contact No.],RTRIM(email) as [Email],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(bloodgroup) as [Blood Group],CONVERT(DateTime,DateOfJoining,103) as [Joining Date],RTRIM(salary) as [Salary],RTRIM(basicworkingtime) as [Basic Working Time],RTRIM(Active) as [Active] from EmployeeRegistration where Department like N'%" + Me.txtDepartment.Text + "%' order by EmployeeName", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C340 RID: 49984 RVA: 0x007C05A4 File Offset: 0x007BE7A4
		Private Sub txtDesignation_TextChanged(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(employeeid) as [Employee ID],RTRIM(employeename) as [Employee Name],RTRIM(Gender) as [Gender],RTRIM(address) as [Address],RTRIM(City) as [City],RTRIM(contactno) as [Contact No.],RTRIM(email) as [Email],RTRIM(department) as [Department],RTRIM(designation) as [Designation],RTRIM(bloodgroup) as [Blood Group],CONVERT(DateTime,DateOfJoining,103) as [Joining Date],RTRIM(salary) as [Salary],RTRIM(basicworkingtime) as [Basic Working Time],RTRIM(Active) as [Active] from EmployeeRegistration where Designation like N'%" + Me.txtDesignation.Text + "%' order by EmployeeName", ModCommonClasses.con)
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(ModCommonClasses.cmd)
				Dim dataSet As DataSet = New DataSet()
				sqlDataAdapter.Fill(dataSet, "EmployeeRegistration")
				Me.dgw.DataSource = dataSet.Tables("EmployeeRegistration").DefaultView
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C341 RID: 49985 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmEmployeesRecord_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C342 RID: 49986 RVA: 0x000574C7 File Offset: 0x000556C7
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub
	End Class
End Namespace
