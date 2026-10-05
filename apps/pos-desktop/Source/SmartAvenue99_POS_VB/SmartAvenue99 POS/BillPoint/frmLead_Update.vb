Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x020000C9 RID: 201
	<DesignerGenerated()>
	Public Partial Class frmLead_Update
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002295 RID: 8853 RVA: 0x00017ED4 File Offset: 0x000160D4
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmFollowUp_Lead_Load
			AddHandler MyBase.FormClosing, AddressOf Me.frmLead_Update_FormClosing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000DC7 RID: 3527
		' (get) Token: 0x06002298 RID: 8856 RVA: 0x00017F06 File Offset: 0x00016106
		' (set) Token: 0x06002299 RID: 8857 RVA: 0x00161D80 File Offset: 0x0015FF80
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

		' Token: 0x17000DC8 RID: 3528
		' (get) Token: 0x0600229A RID: 8858 RVA: 0x00017F10 File Offset: 0x00016110
		' (set) Token: 0x0600229B RID: 8859 RVA: 0x00161DC4 File Offset: 0x0015FFC4
		Private _btnUpdate As GelButton
		Friend Overridable Property btnUpdate As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnUpdate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpdate_Click
				Dim gelButton As GelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnUpdate = value
				gelButton = Me._btnUpdate
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DC9 RID: 3529
		' (get) Token: 0x0600229C RID: 8860 RVA: 0x00017F1A File Offset: 0x0001611A
		' (set) Token: 0x0600229D RID: 8861 RVA: 0x00161E08 File Offset: 0x00160008
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DCA RID: 3530
		' (get) Token: 0x0600229E RID: 8862 RVA: 0x00017F24 File Offset: 0x00016124
		' (set) Token: 0x0600229F RID: 8863 RVA: 0x00161E4C File Offset: 0x0016004C
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DCB RID: 3531
		' (get) Token: 0x060022A0 RID: 8864 RVA: 0x00017F2E File Offset: 0x0001612E
		' (set) Token: 0x060022A1 RID: 8865 RVA: 0x00017F38 File Offset: 0x00016138
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17000DCC RID: 3532
		' (get) Token: 0x060022A2 RID: 8866 RVA: 0x00017F41 File Offset: 0x00016141
		' (set) Token: 0x060022A3 RID: 8867 RVA: 0x00161E90 File Offset: 0x00160090
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

		' Token: 0x17000DCD RID: 3533
		' (get) Token: 0x060022A4 RID: 8868 RVA: 0x00017F4B File Offset: 0x0001614B
		' (set) Token: 0x060022A5 RID: 8869 RVA: 0x00017F55 File Offset: 0x00016155
		Friend Overridable Property Label13 As Label

		' Token: 0x17000DCE RID: 3534
		' (get) Token: 0x060022A6 RID: 8870 RVA: 0x00017F5E File Offset: 0x0001615E
		' (set) Token: 0x060022A7 RID: 8871 RVA: 0x00017F68 File Offset: 0x00016168
		Friend Overridable Property Label4 As Label

		' Token: 0x17000DCF RID: 3535
		' (get) Token: 0x060022A8 RID: 8872 RVA: 0x00017F71 File Offset: 0x00016171
		' (set) Token: 0x060022A9 RID: 8873 RVA: 0x00017F7B File Offset: 0x0001617B
		Friend Overridable Property cmbIntrestMode As ComboBox

		' Token: 0x17000DD0 RID: 3536
		' (get) Token: 0x060022AA RID: 8874 RVA: 0x00017F84 File Offset: 0x00016184
		' (set) Token: 0x060022AB RID: 8875 RVA: 0x00017F8E File Offset: 0x0001618E
		Friend Overridable Property Label10 As Label

		' Token: 0x17000DD1 RID: 3537
		' (get) Token: 0x060022AC RID: 8876 RVA: 0x00017F97 File Offset: 0x00016197
		' (set) Token: 0x060022AD RID: 8877 RVA: 0x00017FA1 File Offset: 0x000161A1
		Friend Overridable Property txtRemarks As TextBox

		' Token: 0x17000DD2 RID: 3538
		' (get) Token: 0x060022AE RID: 8878 RVA: 0x00017FAA File Offset: 0x000161AA
		' (set) Token: 0x060022AF RID: 8879 RVA: 0x00017FB4 File Offset: 0x000161B4
		Friend Overridable Property cmbAlloted As ComboBox

		' Token: 0x17000DD3 RID: 3539
		' (get) Token: 0x060022B0 RID: 8880 RVA: 0x00017FBD File Offset: 0x000161BD
		' (set) Token: 0x060022B1 RID: 8881 RVA: 0x00017FC7 File Offset: 0x000161C7
		Friend Overridable Property Label2 As Label

		' Token: 0x17000DD4 RID: 3540
		' (get) Token: 0x060022B2 RID: 8882 RVA: 0x00017FD0 File Offset: 0x000161D0
		' (set) Token: 0x060022B3 RID: 8883 RVA: 0x00017FDA File Offset: 0x000161DA
		Friend Overridable Property Label3 As Label

		' Token: 0x17000DD5 RID: 3541
		' (get) Token: 0x060022B4 RID: 8884 RVA: 0x00017FE3 File Offset: 0x000161E3
		' (set) Token: 0x060022B5 RID: 8885 RVA: 0x00017FED File Offset: 0x000161ED
		Friend Overridable Property txtLead_Id As TextBox

		' Token: 0x17000DD6 RID: 3542
		' (get) Token: 0x060022B6 RID: 8886 RVA: 0x00017FF6 File Offset: 0x000161F6
		' (set) Token: 0x060022B7 RID: 8887 RVA: 0x00018000 File Offset: 0x00016200
		Friend Overridable Property Panel4 As Panel

		' Token: 0x17000DD7 RID: 3543
		' (get) Token: 0x060022B8 RID: 8888 RVA: 0x00018009 File Offset: 0x00016209
		' (set) Token: 0x060022B9 RID: 8889 RVA: 0x00018013 File Offset: 0x00016213
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17000DD8 RID: 3544
		' (get) Token: 0x060022BA RID: 8890 RVA: 0x0001801C File Offset: 0x0001621C
		' (set) Token: 0x060022BB RID: 8891 RVA: 0x00018026 File Offset: 0x00016226
		Friend Overridable Property lblUser As Label

		' Token: 0x17000DD9 RID: 3545
		' (get) Token: 0x060022BC RID: 8892 RVA: 0x0001802F File Offset: 0x0001622F
		' (set) Token: 0x060022BD RID: 8893 RVA: 0x00018039 File Offset: 0x00016239
		Friend Overridable Property Label1 As Label

		' Token: 0x17000DDA RID: 3546
		' (get) Token: 0x060022BE RID: 8894 RVA: 0x00018042 File Offset: 0x00016242
		' (set) Token: 0x060022BF RID: 8895 RVA: 0x0001804C File Offset: 0x0001624C
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17000DDB RID: 3547
		' (get) Token: 0x060022C0 RID: 8896 RVA: 0x00018055 File Offset: 0x00016255
		' (set) Token: 0x060022C1 RID: 8897 RVA: 0x0001805F File Offset: 0x0001625F
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x17000DDC RID: 3548
		' (get) Token: 0x060022C2 RID: 8898 RVA: 0x00018068 File Offset: 0x00016268
		' (set) Token: 0x060022C3 RID: 8899 RVA: 0x00018072 File Offset: 0x00016272
		Friend Overridable Property lbl_Id As Label

		' Token: 0x17000DDD RID: 3549
		' (get) Token: 0x060022C4 RID: 8900 RVA: 0x0001807B File Offset: 0x0001627B
		' (set) Token: 0x060022C5 RID: 8901 RVA: 0x00018085 File Offset: 0x00016285
		Friend Overridable Property lblUserType As Label

		' Token: 0x17000DDE RID: 3550
		' (get) Token: 0x060022C6 RID: 8902 RVA: 0x0001808E File Offset: 0x0001628E
		' (set) Token: 0x060022C7 RID: 8903 RVA: 0x00018098 File Offset: 0x00016298
		Friend Overridable Property lblFollowupID As Label

		' Token: 0x17000DDF RID: 3551
		' (get) Token: 0x060022C8 RID: 8904 RVA: 0x000180A1 File Offset: 0x000162A1
		' (set) Token: 0x060022C9 RID: 8905 RVA: 0x00161ED4 File Offset: 0x001600D4
		Private _btnQuotation As GelButton
		Friend Overridable Property btnQuotation As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnQuotation
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnQuotation_Click
				Dim gelButton As GelButton = Me._btnQuotation
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnQuotation = value
				gelButton = Me._btnQuotation
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000DE0 RID: 3552
		' (get) Token: 0x060022CA RID: 8906 RVA: 0x000180AB File Offset: 0x000162AB
		' (set) Token: 0x060022CB RID: 8907 RVA: 0x000180B5 File Offset: 0x000162B5
		Friend Overridable Property txtCustcode As TextBox

		' Token: 0x17000DE1 RID: 3553
		' (get) Token: 0x060022CC RID: 8908 RVA: 0x000180BE File Offset: 0x000162BE
		' (set) Token: 0x060022CD RID: 8909 RVA: 0x000180C8 File Offset: 0x000162C8
		Friend Overridable Property txtIDCus As TextBox

		' Token: 0x17000DE2 RID: 3554
		' (get) Token: 0x060022CE RID: 8910 RVA: 0x000180D1 File Offset: 0x000162D1
		' (set) Token: 0x060022CF RID: 8911 RVA: 0x000180DB File Offset: 0x000162DB
		Public Overridable Property pbgiftqr As PictureBox

		' Token: 0x17000DE3 RID: 3555
		' (get) Token: 0x060022D0 RID: 8912 RVA: 0x000180E4 File Offset: 0x000162E4
		' (set) Token: 0x060022D1 RID: 8913 RVA: 0x000180EE File Offset: 0x000162EE
		Friend Overridable Property lblState As Label

		' Token: 0x17000DE4 RID: 3556
		' (get) Token: 0x060022D2 RID: 8914 RVA: 0x000180F7 File Offset: 0x000162F7
		' (set) Token: 0x060022D3 RID: 8915 RVA: 0x00018101 File Offset: 0x00016301
		Friend Overridable Property lblMobileno As Label

		' Token: 0x17000DE5 RID: 3557
		' (get) Token: 0x060022D4 RID: 8916 RVA: 0x0001810A File Offset: 0x0001630A
		' (set) Token: 0x060022D5 RID: 8917 RVA: 0x00018114 File Offset: 0x00016314
		Friend Overridable Property Label6 As Label

		' Token: 0x17000DE6 RID: 3558
		' (get) Token: 0x060022D6 RID: 8918 RVA: 0x0001811D File Offset: 0x0001631D
		' (set) Token: 0x060022D7 RID: 8919 RVA: 0x00018127 File Offset: 0x00016327
		Friend Overridable Property cmbCordinate_mode As ComboBox

		' Token: 0x17000DE7 RID: 3559
		' (get) Token: 0x060022D8 RID: 8920 RVA: 0x00018130 File Offset: 0x00016330
		' (set) Token: 0x060022D9 RID: 8921 RVA: 0x0001813A File Offset: 0x0001633A
		Friend Overridable Property Label9 As Label

		' Token: 0x17000DE8 RID: 3560
		' (get) Token: 0x060022DA RID: 8922 RVA: 0x00018143 File Offset: 0x00016343
		' (set) Token: 0x060022DB RID: 8923 RVA: 0x0001814D File Offset: 0x0001634D
		Friend Overridable Property txtAddress As TextBox

		' Token: 0x17000DE9 RID: 3561
		' (get) Token: 0x060022DC RID: 8924 RVA: 0x00018156 File Offset: 0x00016356
		' (set) Token: 0x060022DD RID: 8925 RVA: 0x00018160 File Offset: 0x00016360
		Friend Overridable Property Label8 As Label

		' Token: 0x17000DEA RID: 3562
		' (get) Token: 0x060022DE RID: 8926 RVA: 0x00018169 File Offset: 0x00016369
		' (set) Token: 0x060022DF RID: 8927 RVA: 0x00018173 File Offset: 0x00016373
		Friend Overridable Property cmbState As ComboBox

		' Token: 0x17000DEB RID: 3563
		' (get) Token: 0x060022E0 RID: 8928 RVA: 0x0001817C File Offset: 0x0001637C
		' (set) Token: 0x060022E1 RID: 8929 RVA: 0x00018186 File Offset: 0x00016386
		Friend Overridable Property Label7 As Label

		' Token: 0x17000DEC RID: 3564
		' (get) Token: 0x060022E2 RID: 8930 RVA: 0x0001818F File Offset: 0x0001638F
		' (set) Token: 0x060022E3 RID: 8931 RVA: 0x00018199 File Offset: 0x00016399
		Friend Overridable Property txtMobile As TextBox

		' Token: 0x17000DED RID: 3565
		' (get) Token: 0x060022E4 RID: 8932 RVA: 0x000181A2 File Offset: 0x000163A2
		' (set) Token: 0x060022E5 RID: 8933 RVA: 0x000181AC File Offset: 0x000163AC
		Friend Overridable Property Label11 As Label

		' Token: 0x17000DEE RID: 3566
		' (get) Token: 0x060022E6 RID: 8934 RVA: 0x000181B5 File Offset: 0x000163B5
		' (set) Token: 0x060022E7 RID: 8935 RVA: 0x000181BF File Offset: 0x000163BF
		Friend Overridable Property cmbProduct As ComboBox

		' Token: 0x060022E8 RID: 8936 RVA: 0x000181C8 File Offset: 0x000163C8
		Private Sub frmFollowUp_Lead_Load(sender As Object, e As EventArgs)
			Me.LoadStates()
			Me.LoadProducts()
			Me.LoadUsers()
			Me.LeadDataFetch()
		End Sub

		' Token: 0x060022E9 RID: 8937 RVA: 0x00161F18 File Offset: 0x00160118
		Private Sub LoadStates()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT name as StateName FROM tbl_state ORDER BY name"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.cmbState.DataSource = dataTable.Copy()
							Me.cmbState.DisplayMember = "StateName"
							Me.cmbState.ValueMember = "StateName"
							Me.cmbState.SelectedIndex = -1
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error loading states: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060022EA RID: 8938 RVA: 0x0016202C File Offset: 0x0016022C
		Private Sub LoadProducts()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT product_name FROM tbl_lead_product ORDER BY product_name"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.cmbProduct.DataSource = dataTable
							Me.cmbProduct.DisplayMember = "product_name"
							Me.cmbProduct.ValueMember = "product_name"
							Me.cmbProduct.SelectedIndex = -1
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error loading products: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060022EB RID: 8939 RVA: 0x0016213C File Offset: 0x0016033C
		Private Sub LoadUsers()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim text As String = "SELECT RTRIM(UserID) AS UserID, RTRIM(UserID) AS UserName" & vbCrLf & "                                   FROM Registration " & vbCrLf & "                                   WHERE RTRIM(UserType)='Sales Person'" & vbCrLf & "                                   ORDER BY UserID"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(sqlCommand)
							Dim dataTable As DataTable = New DataTable()
							sqlDataAdapter.Fill(dataTable)
							Me.cmbAlloted.DataSource = dataTable.Copy()
							Me.cmbAlloted.DisplayMember = "UserName"
							Me.cmbAlloted.ValueMember = "UserName"
							Me.cmbAlloted.SelectedIndex = -1
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error loading users: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060022EC RID: 8940 RVA: 0x00162250 File Offset: 0x00160450
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.lbl_Id.Text)) = 0
			If flag Then
				MessageBox.Show("Please Select Lead", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.txtRemarks.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please write remarks", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtRemarks.Focus()
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.txtMobile.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please write mobile no.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.txtMobile.Focus()
					Else
						Dim flag4 As Boolean = Strings.Len(Strings.Trim(Me.cmbState.Text)) = 0
						If flag4 Then
							MessageBox.Show("Please State Select", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
							Me.cmbState.Focus()
						Else
							Dim flag5 As Boolean = Me.cmbAlloted.SelectedIndex = -1
							If flag5 Then
								MessageBox.Show("Please select User", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
								Me.cmbAlloted.Focus()
							Else
								Dim text As String = Strings.Trim(Me.txtMobile.Text)
								Dim flag6 As Boolean = Not Regex.IsMatch(text, "^[0-9]+$")
								If flag6 Then
									MessageBox.Show("Mobile number must contain digits only (0–9).", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
									Me.txtMobile.Focus()
								Else
									Try
										Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
											sqlConnection.Open()
											Dim text2 As String = "INSERT INTO tbl_lead_master " & vbCrLf & "                                (id, lead_id, lead_date, customer_name, coordinate_mode, mobile, state, address, " & vbCrLf & "                                 interest_mode, productname, remarks, alloted_user) " & vbCrLf & "                                VALUES " & vbCrLf & "                                (@id, @lead_id, @lead_date, @customer_name, @coordinate_mode, @mobile, @state, @address, " & vbCrLf & "                                 @interest_mode, @productname, @remarks, @alloted_user)"
											Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
												sqlCommand.Parameters.AddWithValue("@id", Me.lbl_Id.Text)
												sqlCommand.Parameters.AddWithValue("@lead_id", Me.txtLead_Id.Text)
												sqlCommand.Parameters.Add("@lead_date", DateTime.Now)
												Dim flag7 As Boolean = Operators.CompareString(Me.txtCustomerName.Text, "", False) = 0
												If flag7 Then
													sqlCommand.Parameters.AddWithValue("@customer_name", "NA")
												Else
													sqlCommand.Parameters.AddWithValue("@customer_name", Me.txtCustomerName.Text)
												End If
												Dim flag8 As Boolean = Operators.CompareString(Me.cmbCordinate_mode.Text, "", False) = 0
												If flag8 Then
													sqlCommand.Parameters.AddWithValue("@coordinate_mode", "Owner")
												Else
													sqlCommand.Parameters.AddWithValue("@coordinate_mode", Me.cmbCordinate_mode.Text)
												End If
												sqlCommand.Parameters.AddWithValue("@mobile", Me.txtMobile.Text)
												sqlCommand.Parameters.AddWithValue("@state", Me.cmbState.Text)
												sqlCommand.Parameters.AddWithValue("@address", Me.txtAddress.Text)
												sqlCommand.Parameters.AddWithValue("@interest_mode", Me.cmbIntrestMode.Text)
												Dim flag9 As Boolean = Operators.CompareString(Me.cmbProduct.Text, "", False) = 0
												If flag9 Then
													sqlCommand.Parameters.AddWithValue("@productname", "NA")
												Else
													sqlCommand.Parameters.AddWithValue("@productname", Me.cmbProduct.Text)
												End If
												sqlCommand.Parameters.AddWithValue("@remarks", Me.txtRemarks.Text)
												sqlCommand.Parameters.AddWithValue("@alloted_user", Me.cmbAlloted.Text)
												sqlCommand.ExecuteNonQuery()
											End Using
										End Using
										MessageBox.Show("Lead inserted successfully", "Lead Master", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
										Me.Reset()
										Me.auto()
									Catch ex As Exception
										MessageBox.Show("Error inserting lead: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End Try
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060022ED RID: 8941 RVA: 0x001626D8 File Offset: 0x001608D8
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmFollowUp_LeadRecords.lblUser.Text = Me.lblUser.Text
			MyProject.Forms.frmFollowUp_LeadRecords.lblUserType.Text = Me.lblUserType.Text
			MyProject.Forms.frmFollowUp_LeadRecords.ShowDialog()
			MyProject.Forms.frmFollowUp_LeadRecords.Dispose()
		End Sub

		' Token: 0x060022EE RID: 8942 RVA: 0x00162748 File Offset: 0x00160948
		Private Sub Reset()
			Try
				Me.txtCustomerName.Clear()
				Me.txtMobile.Clear()
				Me.txtAddress.Clear()
				Me.txtRemarks.Clear()
				Me.txtLead_Id.Clear()
				Me.lbl_Id.Text = ""
				Me.cmbCordinate_mode.SelectedIndex = -1
				Me.cmbState.SelectedIndex = -1
				Me.cmbIntrestMode.SelectedIndex = -1
				Me.cmbProduct.SelectedIndex = -1
				Me.cmbAlloted.SelectedIndex = -1
				Me.lblUser.Text = String.Empty
				Me.btnSave.Enabled = True
				Me.btnUpdate.Enabled = False
				Me.btnDelete.Enabled = False
				Me.txtCustomerName.Focus()
			Catch ex As Exception
				MessageBox.Show("Error resetting form: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060022EF RID: 8943 RVA: 0x00162864 File Offset: 0x00160A64
		Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
			Dim text As String = Strings.Trim(Me.txtMobile.Text)
			Dim flag As Boolean = Not Regex.IsMatch(text, "^[0-9]+$")
			If flag Then
				MessageBox.Show("Mobile number must contain digits only (0–9).", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Me.txtMobile.Focus()
			Else
				Try
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text2 As String = "UPDATE tbl_lead_master " & vbCrLf & "                                SET customer_name=@customer_name, " & vbCrLf & "                                    coordinate_mode=@coordinate_mode, " & vbCrLf & "                                    mobile=@mobile, " & vbCrLf & "                                    state=@state, " & vbCrLf & "                                    address=@address, " & vbCrLf & "                                    interest_mode=@interest_mode, " & vbCrLf & "                                    productname=@productname, " & vbCrLf & "                                    remarks=@remarks, " & vbCrLf & "                                    alloted_user=@alloted_user" & vbCrLf & "                                WHERE id=@lead_id"
						Using sqlCommand As SqlCommand = New SqlCommand(text2, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@customer_name", Me.txtCustomerName.Text)
							sqlCommand.Parameters.AddWithValue("@coordinate_mode", Me.cmbCordinate_mode.Text)
							sqlCommand.Parameters.AddWithValue("@mobile", Me.txtMobile.Text)
							sqlCommand.Parameters.AddWithValue("@state", Me.cmbState.Text)
							sqlCommand.Parameters.AddWithValue("@address", Me.txtAddress.Text)
							sqlCommand.Parameters.AddWithValue("@interest_mode", Me.cmbIntrestMode.Text)
							sqlCommand.Parameters.AddWithValue("@productname", Me.cmbProduct.Text)
							sqlCommand.Parameters.AddWithValue("@remarks", Me.txtRemarks.Text)
							sqlCommand.Parameters.AddWithValue("@alloted_user", Me.cmbAlloted.Text)
							sqlCommand.Parameters.AddWithValue("@lead_id", Convert.ToInt32(Me.lbl_Id.Text))
							sqlCommand.ExecuteNonQuery()
						End Using
					End Using
					MessageBox.Show("Successfully Updated", "Lead Master", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Me.btnUpdate.Enabled = False
					MyProject.Forms.frmFollowUp_Lead.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.frmFollowUp_Lead.lblUserType.Text = Me.lblUserType.Text
					MyProject.Forms.frmFollowUp_Lead.lbl_Id.Text = Me.lbl_Id.Text
					MyProject.Forms.frmFollowUp_Lead.txtLead_Id.Text = Me.txtLead_Id.Text
					MyProject.Forms.frmFollowUp_Lead.txtCustomerName.Text = Me.txtCustomerName.Text
					MyProject.Forms.frmFollowUp_Lead.lblMobileno.Text = Me.txtMobile.Text
					MyProject.Forms.frmFollowUp_Lead.lblState.Text = Me.cmbState.Text
					MyBase.Dispose()
					MyProject.Forms.frmFollowUp_Lead.ShowDialog()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x060022F0 RID: 8944 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060022F1 RID: 8945 RVA: 0x000181E7 File Offset: 0x000163E7
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.auto()
		End Sub

		' Token: 0x060022F2 RID: 8946 RVA: 0x00162BBC File Offset: 0x00160DBC
		Public Sub auto()
			Try
				Me.lbl_Id.Text = Me.GenerateID()
				Me.txtLead_Id.Text = "L-" + Me.GenerateID()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060022F3 RID: 8947 RVA: 0x00162C30 File Offset: 0x00160E30
		Private Function GenerateID() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 id FROM tbl_lead_master ORDER BY id DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("id"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x060022F4 RID: 8948 RVA: 0x00162D9C File Offset: 0x00160F9C
		Private Sub btnQuotation_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = MessageBox.Show("Do you really want to Generate Quotation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes
				If flag Then
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUser.Text = Me.lblUser.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.lblUserType.Text = Me.lblUserType.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.lblLQS.Text = "Lead"
					MyProject.Forms.frmPOSNewTuch_Quotation.lblLead_Id.Text = Me.lbl_Id.Text
					MyProject.Forms.frmPOSNewTuch_Quotation.ShowDialog()
					MyProject.Forms.frmPOSNewTuch_Quotation.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060022F5 RID: 8949 RVA: 0x00162E9C File Offset: 0x0016109C
		Public Sub LeadDataFetch()
			Try
				Dim flag As Boolean = Operators.CompareString(Me.lbl_Id.Text, "", False) <> 0
				If flag Then
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text As String = "SELECT" & vbCrLf & "lead_id," & vbCrLf & "customer_name," & vbCrLf & "coordinate_mode," & vbCrLf & "mobile," & vbCrLf & "state," & vbCrLf & "address," & vbCrLf & "interest_mode," & vbCrLf & "productname," & vbCrLf & "remarks," & vbCrLf & "alloted_user " & vbCrLf & "                                    FROM [tbl_lead_master] " & vbCrLf & "                                    WHERE id=@d1"
						Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@d1", Me.lbl_Id.Text)
							Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
								Dim flag2 As Boolean = sqlDataReader.Read()
								If flag2 Then
									Me.txtLead_Id.Text = sqlDataReader("lead_id").ToString().Trim()
									Me.txtCustomerName.Text = sqlDataReader("customer_name").ToString().Trim()
									Me.cmbCordinate_mode.Text = sqlDataReader("coordinate_mode").ToString().Trim()
									Me.txtMobile.Text = sqlDataReader("mobile").ToString().Trim()
									Me.cmbState.Text = sqlDataReader("state").ToString().Trim()
									Me.txtAddress.Text = sqlDataReader("address").ToString().Trim()
									Me.cmbIntrestMode.Text = sqlDataReader("interest_mode").ToString().Trim()
									Me.cmbProduct.Text = sqlDataReader("productname").ToString().Trim()
									Me.txtRemarks.Text = sqlDataReader("remarks").ToString().Trim()
									Me.cmbAlloted.Text = sqlDataReader("alloted_user").ToString().Trim()
									sqlDataReader.Close()
								End If
							End Using
						End Using
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060022F6 RID: 8950 RVA: 0x00163144 File Offset: 0x00161344
		Private Sub FillCustomerFromReader(rdr As SqlDataReader)
			MyProject.Forms.frmPOSNewTuch.txtCID.Text = rdr(0).ToString()
			MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = rdr(1).ToString()
			MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = rdr(2).ToString()
			MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = rdr(3).ToString()
			MyProject.Forms.frmPOSNewTuch.GridGetCustomer.Visible = False
			MessageBox.Show("Entered customer is already registered", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
		End Sub

		' Token: 0x060022F7 RID: 8951 RVA: 0x00163200 File Offset: 0x00161400
		Public Sub InsertCustomer()
			Me.autoCust()
			Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
			If flag Then
				MessageBox.Show("Please enter Customer name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Strings.Len(Strings.Trim(Me.lblState.Text)) = 0
				If flag2 Then
					MessageBox.Show("Please select state", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Strings.Len(Strings.Trim(Me.lblMobileno.Text)) = 0
					If flag3 Then
						MessageBox.Show("Please Enter Contact No.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Try
							Dim flag4 As Boolean = Operators.CompareString(Me.txtCustomerName.Text, "", False) = 0
							If flag4 Then
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text As String = "select RTRIM(Name) from Customer where Name=@d1"
								ModCommonClasses.cmd = New SqlCommand(text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text)
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
								Dim flag5 As Boolean = ModCommonClasses.rdr.Read()
								If flag5 Then
									MessageBox.Show("Entered name is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									Dim flag6 As Boolean = ModCommonClasses.rdr IsNot Nothing
									If flag6 Then
										ModCommonClasses.rdr.Close()
									End If
									Return
								End If
								ModCommonClasses.con.Close()
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text2 As String = "select RTRIM(ContactNo) from Customer where ContactNo=@d1"
							ModCommonClasses.cmd = New SqlCommand(text2)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.lblMobileno.Text)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
							If flag7 Then
								MessageBox.Show("Entered contact no. is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								Dim flag8 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag8 Then
									ModCommonClasses.rdr.Close()
								End If
							Else
								ModCommonClasses.con.Close()
								ModCommonClasses.con = New SqlConnection(ModCS.cs)
								ModCommonClasses.con.Open()
								Dim text3 As String = "insert into Customer(ID, CustomerID, [Name], Address, City, ContactNo, EmailID,Remarks,State,ZipCode,GSTIN,CIN,PAN,AccountName,AccountNumber,Bank,Branch,IFSCCode,Optype,Opbal,Photo,Tcs,Limit,Lstatus,Route,Taround,DiscPer,DiscStatus,QrCustomer) VALUES (@d1,@d2,@d3,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@qr)"
								ModCommonClasses.cmd = New SqlCommand(text3)
								Me.Generate_GiftQR(Me.lblMobileno.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtIDCus.Text))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Me.txtCustcode.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d5", "local")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "localcity")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", Me.lblMobileno.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "abc@gmail.com")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d10", Me.lblState.Text)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d11", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d14", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d16", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d17", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d19", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d20", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d21", "Cr")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d22", Conversion.Val("0.00"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d24", "No")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d25", Conversion.Val("0.00"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d26", "No")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d27", String.Empty)
								ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val("0"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d29", Conversion.Val("0"))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d30", "No")
								ModCommonClasses.cmd.Connection = ModCommonClasses.con
								Dim memoryStream As MemoryStream = New MemoryStream()
								Dim bitmap As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap.Save(memoryStream, ImageFormat.Jpeg)
								Dim buffer As Byte() = memoryStream.GetBuffer()
								Dim sqlParameter As SqlParameter = New SqlParameter("@d23", SqlDbType.Image)
								sqlParameter.Value = buffer
								ModCommonClasses.cmd.Parameters.Add(sqlParameter)
								Dim memoryStream2 As MemoryStream = New MemoryStream()
								Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
								bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
								Dim buffer2 As Byte() = memoryStream2.GetBuffer()
								Dim sqlParameter2 As SqlParameter = New SqlParameter("@qr", SqlDbType.Image)
								sqlParameter2.Value = buffer2
								ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
								ModCommonClasses.cmd.ExecuteNonQuery()
								ModCommonClasses.con.Close()
								ModFunc.LedgerSave(DateAndTime.Today, Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text, Me.txtCustcode.Text, "Opening Balance", 0D, New Decimal(Conversion.Val("0.00")), Me.txtCustcode.Text, Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text)
								ModFunc.CustomerLedgerSave(DateAndTime.Today, Me.txtCustomerName.Text + "_" + Me.lblMobileno.Text, Me.txtCustcode.Text, "Opening Balance", 0D, New Decimal(Conversion.Val("0.00")), Me.txtCustcode.Text, Me.txtCustcode.Text, String.Empty)
								ModFunc.LogFunc(Me.lblUser.Text, "added the new Customer having Customer id '" + Me.txtCustcode.Text + "'")
								MyProject.Forms.frmPOSNewTuch.txtCID.Text = Me.txtIDCus.Text
								MyProject.Forms.frmPOSNewTuch.cmbCustomerName.Text = Me.txtCustomerName.Text
								MyProject.Forms.frmPOSNewTuch.txtContactNo.Text = Me.lblMobileno.Text
								MyProject.Forms.frmPOSNewTuch.cmbCustomerState.Text = Me.lblState.Text
								MyProject.Forms.frmPOSNewTuch.GridGetCustomer.Visible = False
							End If
						Catch ex As Exception
						End Try
					End If
				End If
			End If
		End Sub

		' Token: 0x060022F8 RID: 8952 RVA: 0x00163A80 File Offset: 0x00161C80
		Public Sub autoCust()
			Try
				Me.txtIDCus.Text = Me.GenerateIDCus()
				Me.txtCustcode.Text = "C-" + Me.GenerateIDCus()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060022F9 RID: 8953 RVA: 0x00163AF4 File Offset: 0x00161CF4
		Private Function GenerateIDCus() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Customer ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x060022FA RID: 8954 RVA: 0x00163C60 File Offset: 0x00161E60
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x060022FB RID: 8955 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmLead_Update_FormClosing(sender As Object, e As FormClosingEventArgs)
		End Sub
	End Class
End Namespace
