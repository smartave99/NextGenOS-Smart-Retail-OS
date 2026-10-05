Imports System
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
	' Token: 0x020000C7 RID: 199
	<DesignerGenerated()>
	Public Partial Class frmCustomerSupportLog_Report
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060021EE RID: 8686 RVA: 0x0001794F File Offset: 0x00015B4F
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSheet_Report_Load
			Me.dt = New DataTable()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000D81 RID: 3457
		' (get) Token: 0x060021F1 RID: 8689 RVA: 0x0001797D File Offset: 0x00015B7D
		' (set) Token: 0x060021F2 RID: 8690 RVA: 0x0015BD24 File Offset: 0x00159F24
		Private _btnShowAll As GelButton
		Friend Overridable Property btnShowAll As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click
				Dim gelButton As GelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnShowAll = value
				gelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000D82 RID: 3458
		' (get) Token: 0x060021F3 RID: 8691 RVA: 0x00017987 File Offset: 0x00015B87
		' (set) Token: 0x060021F4 RID: 8692 RVA: 0x00017991 File Offset: 0x00015B91
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17000D83 RID: 3459
		' (get) Token: 0x060021F5 RID: 8693 RVA: 0x0001799A File Offset: 0x00015B9A
		' (set) Token: 0x060021F6 RID: 8694 RVA: 0x0015BD68 File Offset: 0x00159F68
		Private _txtTokenNo As TextBox
		Friend Overridable Property txtTokenNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtTokenNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerName_TextChanged
				Dim textBox As TextBox = Me._txtTokenNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtTokenNo = value
				textBox = Me._txtTokenNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000D84 RID: 3460
		' (get) Token: 0x060021F7 RID: 8695 RVA: 0x000179A4 File Offset: 0x00015BA4
		' (set) Token: 0x060021F8 RID: 8696 RVA: 0x000179AE File Offset: 0x00015BAE
		Friend Overridable Property Label3 As Label

		' Token: 0x17000D85 RID: 3461
		' (get) Token: 0x060021F9 RID: 8697 RVA: 0x000179B7 File Offset: 0x00015BB7
		' (set) Token: 0x060021FA RID: 8698 RVA: 0x000179C1 File Offset: 0x00015BC1
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17000D86 RID: 3462
		' (get) Token: 0x060021FB RID: 8699 RVA: 0x000179CA File Offset: 0x00015BCA
		' (set) Token: 0x060021FC RID: 8700 RVA: 0x000179D4 File Offset: 0x00015BD4
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17000D87 RID: 3463
		' (get) Token: 0x060021FD RID: 8701 RVA: 0x000179DD File Offset: 0x00015BDD
		' (set) Token: 0x060021FE RID: 8702 RVA: 0x0015BDAC File Offset: 0x00159FAC
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

		' Token: 0x17000D88 RID: 3464
		' (get) Token: 0x060021FF RID: 8703 RVA: 0x000179E7 File Offset: 0x00015BE7
		' (set) Token: 0x06002200 RID: 8704 RVA: 0x000179F1 File Offset: 0x00015BF1
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17000D89 RID: 3465
		' (get) Token: 0x06002201 RID: 8705 RVA: 0x000179FA File Offset: 0x00015BFA
		' (set) Token: 0x06002202 RID: 8706 RVA: 0x00017A04 File Offset: 0x00015C04
		Friend Overridable Property Label2 As Label

		' Token: 0x17000D8A RID: 3466
		' (get) Token: 0x06002203 RID: 8707 RVA: 0x00017A0D File Offset: 0x00015C0D
		' (set) Token: 0x06002204 RID: 8708 RVA: 0x00017A17 File Offset: 0x00015C17
		Friend Overridable Property Label1 As Label

		' Token: 0x17000D8B RID: 3467
		' (get) Token: 0x06002205 RID: 8709 RVA: 0x00017A20 File Offset: 0x00015C20
		' (set) Token: 0x06002206 RID: 8710 RVA: 0x00017A2A File Offset: 0x00015C2A
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17000D8C RID: 3468
		' (get) Token: 0x06002207 RID: 8711 RVA: 0x00017A33 File Offset: 0x00015C33
		' (set) Token: 0x06002208 RID: 8712 RVA: 0x0015BDF0 File Offset: 0x00159FF0
		Private _btnSetting As GelButton
		Friend Overridable Property btnSetting As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSetting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSetting_Click
				Dim gelButton As GelButton = Me._btnSetting
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSetting = value
				gelButton = Me._btnSetting
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000D8D RID: 3469
		' (get) Token: 0x06002209 RID: 8713 RVA: 0x00017A3D File Offset: 0x00015C3D
		' (set) Token: 0x0600220A RID: 8714 RVA: 0x00017A47 File Offset: 0x00015C47
		Friend Overridable Property Label4 As Label

		' Token: 0x17000D8E RID: 3470
		' (get) Token: 0x0600220B RID: 8715 RVA: 0x00017A50 File Offset: 0x00015C50
		' (set) Token: 0x0600220C RID: 8716 RVA: 0x0015BE34 File Offset: 0x0015A034
		Private _rdo_Closed As RadioButton
		Friend Overridable Property rdo_Closed As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._rdo_Closed
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.rdo_Closed_CheckedChanged
				Dim radioButton As RadioButton = Me._rdo_Closed
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._rdo_Closed = value
				radioButton = Me._rdo_Closed
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000D8F RID: 3471
		' (get) Token: 0x0600220D RID: 8717 RVA: 0x00017A5A File Offset: 0x00015C5A
		' (set) Token: 0x0600220E RID: 8718 RVA: 0x0015BE78 File Offset: 0x0015A078
		Private _rdo_Process As RadioButton
		Friend Overridable Property rdo_Process As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._rdo_Process
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.rdo_Process_CheckedChanged
				Dim radioButton As RadioButton = Me._rdo_Process
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._rdo_Process = value
				radioButton = Me._rdo_Process
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000D90 RID: 3472
		' (get) Token: 0x0600220F RID: 8719 RVA: 0x00017A64 File Offset: 0x00015C64
		' (set) Token: 0x06002210 RID: 8720 RVA: 0x0015BEBC File Offset: 0x0015A0BC
		Private _rdo_Open As RadioButton
		Friend Overridable Property rdo_Open As RadioButton
			<CompilerGenerated()>
			Get
				Return Me._rdo_Open
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.rdo_Open_CheckedChanged
				Dim radioButton As RadioButton = Me._rdo_Open
				If radioButton IsNot Nothing Then
					RemoveHandler radioButton.CheckedChanged, eventHandler
				End If
				Me._rdo_Open = value
				radioButton = Me._rdo_Open
				If radioButton IsNot Nothing Then
					AddHandler radioButton.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000D91 RID: 3473
		' (get) Token: 0x06002211 RID: 8721 RVA: 0x00017A6E File Offset: 0x00015C6E
		' (set) Token: 0x06002212 RID: 8722 RVA: 0x00017A78 File Offset: 0x00015C78
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000D92 RID: 3474
		' (get) Token: 0x06002213 RID: 8723 RVA: 0x00017A81 File Offset: 0x00015C81
		' (set) Token: 0x06002214 RID: 8724 RVA: 0x00017A8B File Offset: 0x00015C8B
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000D93 RID: 3475
		' (get) Token: 0x06002215 RID: 8725 RVA: 0x00017A94 File Offset: 0x00015C94
		' (set) Token: 0x06002216 RID: 8726 RVA: 0x00017A9E File Offset: 0x00015C9E
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x17000D94 RID: 3476
		' (get) Token: 0x06002217 RID: 8727 RVA: 0x00017AA7 File Offset: 0x00015CA7
		' (set) Token: 0x06002218 RID: 8728 RVA: 0x00017AB1 File Offset: 0x00015CB1
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000D95 RID: 3477
		' (get) Token: 0x06002219 RID: 8729 RVA: 0x00017ABA File Offset: 0x00015CBA
		' (set) Token: 0x0600221A RID: 8730 RVA: 0x00017AC4 File Offset: 0x00015CC4
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000D96 RID: 3478
		' (get) Token: 0x0600221B RID: 8731 RVA: 0x00017ACD File Offset: 0x00015CCD
		' (set) Token: 0x0600221C RID: 8732 RVA: 0x00017AD7 File Offset: 0x00015CD7
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000D97 RID: 3479
		' (get) Token: 0x0600221D RID: 8733 RVA: 0x00017AE0 File Offset: 0x00015CE0
		' (set) Token: 0x0600221E RID: 8734 RVA: 0x00017AEA File Offset: 0x00015CEA
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000D98 RID: 3480
		' (get) Token: 0x0600221F RID: 8735 RVA: 0x00017AF3 File Offset: 0x00015CF3
		' (set) Token: 0x06002220 RID: 8736 RVA: 0x00017AFD File Offset: 0x00015CFD
		Friend Overridable Property Column8 As DataGridViewTextBoxColumn

		' Token: 0x17000D99 RID: 3481
		' (get) Token: 0x06002221 RID: 8737 RVA: 0x00017B06 File Offset: 0x00015D06
		' (set) Token: 0x06002222 RID: 8738 RVA: 0x00017B10 File Offset: 0x00015D10
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17000D9A RID: 3482
		' (get) Token: 0x06002223 RID: 8739 RVA: 0x00017B19 File Offset: 0x00015D19
		' (set) Token: 0x06002224 RID: 8740 RVA: 0x00017B23 File Offset: 0x00015D23
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17000D9B RID: 3483
		' (get) Token: 0x06002225 RID: 8741 RVA: 0x00017B2C File Offset: 0x00015D2C
		' (set) Token: 0x06002226 RID: 8742 RVA: 0x00017B36 File Offset: 0x00015D36
		Friend Overridable Property Column11 As DataGridViewTextBoxColumn

		' Token: 0x17000D9C RID: 3484
		' (get) Token: 0x06002227 RID: 8743 RVA: 0x00017B3F File Offset: 0x00015D3F
		' (set) Token: 0x06002228 RID: 8744 RVA: 0x00017B49 File Offset: 0x00015D49
		Friend Overridable Property Column12 As DataGridViewTextBoxColumn

		' Token: 0x06002229 RID: 8745 RVA: 0x00017B52 File Offset: 0x00015D52
		Private Sub frmGSheet_Report_Load(sender As Object, e As EventArgs)
			Me.rdo_Open.Checked = False
			Me.rdo_Process.Checked = False
			Me.rdo_Closed.Checked = False
			Me.LoadCustomerSupportLogs("")
		End Sub

		' Token: 0x0600222A RID: 8746 RVA: 0x0015BF00 File Offset: 0x0015A100
		Public Sub LoadCustomerSupportLogs(Optional statusFilter As String = "")
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
					sqlConnection.Open()
					Dim text As String = "SELECT LogID, support_token_no, LogTimestamp, CurrentIssue, SoftwareValidity, Status, Remark, Feedback, Rating FROM CustomerSupportLog"
					Dim flag As Boolean = Operators.CompareString(statusFilter, "", False) <> 0
					If flag Then
						text += " WHERE Status = @status"
					End If
					text += " ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Dim flag2 As Boolean = Operators.CompareString(statusFilter, "", False) <> 0
						If flag2 Then
							sqlCommand.Parameters.AddWithValue("@status", statusFilter)
						End If
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600222B RID: 8747 RVA: 0x00017B52 File Offset: 0x00015D52
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			Me.rdo_Open.Checked = False
			Me.rdo_Process.Checked = False
			Me.rdo_Closed.Checked = False
			Me.LoadCustomerSupportLogs("")
		End Sub

		' Token: 0x0600222C RID: 8748 RVA: 0x0000F1EA File Offset: 0x0000D3EA
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			FileSystem.Reset()
		End Sub

		' Token: 0x0600222D RID: 8749 RVA: 0x0015C100 File Offset: 0x0015A300
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count = 0
				If flag Then
					MessageBox.Show("Please select a row.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag2 As Boolean = Me.DataGridView1.Rows.Count > 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
						MyProject.Forms.frmCustomer.Show()
						MyBase.Hide()
						MyProject.Forms.frmCustomer.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString() + " - " + dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCustomer.txtCustName.Text = dataGridViewRow.Cells(2).Value.ToString() + " - " + dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCustomer.txtAddress.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmCustomer.txtCity.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmCustomer.cmbState.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCustomer.txtZipCode.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmCustomer.txtContactNo.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmCustomer.txtPhNo.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmCustomer.txtGSTIN.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmCustomer.txtRemarks.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmCustomer.txtpermentAddress.Text = dataGridViewRow.Cells(11).Value.ToString() + ", Mob:" + dataGridViewRow.Cells(19).Value.ToString()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600222E RID: 8750 RVA: 0x0015C408 File Offset: 0x0015A608
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
					sqlConnection.Open()
					Dim text As String = "SELECT top 5 LogID,support_token_no, LogTimestamp, CurrentIssue, SoftwareValidity, Status, Remark, Feedback, Rating FROM CustomerSupportLog where support_token_no like '%" + Me.txtTokenNo.Text + "%' ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600222F RID: 8751 RVA: 0x0015C5B8 File Offset: 0x0015A7B8
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
					sqlConnection.Open()
					Dim text As String = "SELECT LogID,support_token_no, LogTimestamp, CurrentIssue, SoftwareValidity, Status, Remark, Feedback, Rating FROM CustomerSupportLog WHERE LogTimestamp BETWEEN @d1 AND @d2 "
					Dim flag As Boolean = Not String.IsNullOrWhiteSpace(Me.txtTokenNo.Text)
					If flag Then
						text += "AND support_token_no LIKE @token "
					End If
					text += "ORDER BY LogTimestamp DESC"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@d1", Me.dtpDateFrom.Value.[Date])
						sqlCommand.Parameters.AddWithValue("@d2", Me.dtpDateTo.Value.[Date].AddDays(1.0).AddSeconds(-1.0))
						Dim flag2 As Boolean = Not String.IsNullOrWhiteSpace(Me.txtTokenNo.Text)
						If flag2 Then
							sqlCommand.Parameters.AddWithValue("@token", Me.txtTokenNo.Text + "%")
						End If
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Me.DataGridView1.Rows.Clear()
							While sqlDataReader.Read()
								Me.DataGridView1.Rows.Add(New Object() { sqlDataReader(0), sqlDataReader(1), sqlDataReader(2), sqlDataReader(3), sqlDataReader(4), sqlDataReader(5), sqlDataReader(6), sqlDataReader(7), sqlDataReader(8) })
							End While
						End Using
					End Using
				End Using
				Me.DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
			Catch ex As Exception
				MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06002230 RID: 8752 RVA: 0x0015C84C File Offset: 0x0015AA4C
		Private Sub btnSetting_Click(sender As Object, e As EventArgs)
			Try
				MyProject.Forms.frmCustomerSupportLog.ShowDialog()
				MyProject.Forms.frmCustomerSupportLog.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.ToString())
			End Try
		End Sub

		' Token: 0x06002231 RID: 8753 RVA: 0x0015C8AC File Offset: 0x0015AAAC
		Private Sub rdo_Open_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.rdo_Open.Checked
			If checked Then
				Me.LoadCustomerSupportLogs("Open")
			End If
		End Sub

		' Token: 0x06002232 RID: 8754 RVA: 0x0015C8D8 File Offset: 0x0015AAD8
		Private Sub rdo_Process_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.rdo_Process.Checked
			If checked Then
				Me.LoadCustomerSupportLogs("Process")
			End If
		End Sub

		' Token: 0x06002233 RID: 8755 RVA: 0x0015C904 File Offset: 0x0015AB04
		Private Sub rdo_Closed_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.rdo_Closed.Checked
			If checked Then
				Me.LoadCustomerSupportLogs("Closed")
			End If
		End Sub

		' Token: 0x04000DF4 RID: 3572
		Private dt As DataTable
	End Class
End Namespace
