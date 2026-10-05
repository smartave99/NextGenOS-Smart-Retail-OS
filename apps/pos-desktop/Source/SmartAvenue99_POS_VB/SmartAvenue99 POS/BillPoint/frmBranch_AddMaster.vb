Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Management
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200007F RID: 127
	<DesignerGenerated()>
	Public Partial Class frmBranch_AddMaster
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06001509 RID: 5385 RVA: 0x000113C7 File Offset: 0x0000F5C7
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBranch_AddMaster_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000879 RID: 2169
		' (get) Token: 0x0600150C RID: 5388 RVA: 0x000113E7 File Offset: 0x0000F5E7
		' (set) Token: 0x0600150D RID: 5389 RVA: 0x000113F1 File Offset: 0x0000F5F1
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700087A RID: 2170
		' (get) Token: 0x0600150E RID: 5390 RVA: 0x000113FA File Offset: 0x0000F5FA
		' (set) Token: 0x0600150F RID: 5391 RVA: 0x000E2E1C File Offset: 0x000E101C
		Private _btnLogin As Button
		Friend Overridable Property btnLogin As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLogin
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLogin_Click
				Dim button As Button = Me._btnLogin
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLogin = value
				button = Me._btnLogin
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700087B RID: 2171
		' (get) Token: 0x06001510 RID: 5392 RVA: 0x00011404 File Offset: 0x0000F604
		' (set) Token: 0x06001511 RID: 5393 RVA: 0x0001140E File Offset: 0x0000F60E
		Friend Overridable Property txtCompanyId As TextBox

		' Token: 0x1700087C RID: 2172
		' (get) Token: 0x06001512 RID: 5394 RVA: 0x00011417 File Offset: 0x0000F617
		' (set) Token: 0x06001513 RID: 5395 RVA: 0x00011421 File Offset: 0x0000F621
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700087D RID: 2173
		' (get) Token: 0x06001514 RID: 5396 RVA: 0x0001142A File Offset: 0x0000F62A
		' (set) Token: 0x06001515 RID: 5397 RVA: 0x000E2E60 File Offset: 0x000E1060
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700087E RID: 2174
		' (get) Token: 0x06001516 RID: 5398 RVA: 0x00011434 File Offset: 0x0000F634
		' (set) Token: 0x06001517 RID: 5399 RVA: 0x0001143E File Offset: 0x0000F63E
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x1700087F RID: 2175
		' (get) Token: 0x06001518 RID: 5400 RVA: 0x00011447 File Offset: 0x0000F647
		' (set) Token: 0x06001519 RID: 5401 RVA: 0x00011451 File Offset: 0x0000F651
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000880 RID: 2176
		' (get) Token: 0x0600151A RID: 5402 RVA: 0x0001145A File Offset: 0x0000F65A
		' (set) Token: 0x0600151B RID: 5403 RVA: 0x00011464 File Offset: 0x0000F664
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000881 RID: 2177
		' (get) Token: 0x0600151C RID: 5404 RVA: 0x0001146D File Offset: 0x0000F66D
		' (set) Token: 0x0600151D RID: 5405 RVA: 0x00011477 File Offset: 0x0000F677
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000882 RID: 2178
		' (get) Token: 0x0600151E RID: 5406 RVA: 0x00011480 File Offset: 0x0000F680
		' (set) Token: 0x0600151F RID: 5407 RVA: 0x0001148A File Offset: 0x0000F68A
		Friend Overridable Property Column5 As DataGridViewCheckBoxColumn

		' Token: 0x17000883 RID: 2179
		' (get) Token: 0x06001520 RID: 5408 RVA: 0x00011493 File Offset: 0x0000F693
		' (set) Token: 0x06001521 RID: 5409 RVA: 0x0001149D File Offset: 0x0000F69D
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000884 RID: 2180
		' (get) Token: 0x06001522 RID: 5410 RVA: 0x000114A6 File Offset: 0x0000F6A6
		' (set) Token: 0x06001523 RID: 5411 RVA: 0x000114B0 File Offset: 0x0000F6B0
		Friend Overridable Property btnDel As DataGridViewButtonColumn

		' Token: 0x17000885 RID: 2181
		' (get) Token: 0x06001524 RID: 5412 RVA: 0x000114B9 File Offset: 0x0000F6B9
		' (set) Token: 0x06001525 RID: 5413 RVA: 0x000114C3 File Offset: 0x0000F6C3
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x17000886 RID: 2182
		' (get) Token: 0x06001526 RID: 5414 RVA: 0x000114CC File Offset: 0x0000F6CC
		' (set) Token: 0x06001527 RID: 5415 RVA: 0x000114D6 File Offset: 0x0000F6D6
		Friend Overridable Property lblCPhone As Label

		' Token: 0x17000887 RID: 2183
		' (get) Token: 0x06001528 RID: 5416 RVA: 0x000114DF File Offset: 0x0000F6DF
		' (set) Token: 0x06001529 RID: 5417 RVA: 0x000114E9 File Offset: 0x0000F6E9
		Friend Overridable Property lblDB As Label

		' Token: 0x17000888 RID: 2184
		' (get) Token: 0x0600152A RID: 5418 RVA: 0x000114F2 File Offset: 0x0000F6F2
		' (set) Token: 0x0600152B RID: 5419 RVA: 0x000114FC File Offset: 0x0000F6FC
		Friend Overridable Property Label1 As Label

		' Token: 0x0600152C RID: 5420 RVA: 0x00011505 File Offset: 0x0000F705
		Private Sub frmBranch_AddMaster_Load(sender As Object, e As EventArgs)
			Me.getCompanydtl()
			Me.Getdata()
		End Sub

		' Token: 0x0600152D RID: 5421 RVA: 0x000E2EA4 File Offset: 0x000E10A4
		Public Sub getCompanydtl()
			Try
				Dim managementObjectSearcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
				Try
					For Each managementBaseObject As ManagementBaseObject In managementObjectSearcher.[Get]()
						Dim managementObject As ManagementObject = CType(managementBaseObject, ManagementObject)
						Dim text As String = Conversions.ToString(managementObject("SerialNumber"))
						Me.strCompany_id = ModFunc.MD5Encrypt(Me.lblDB.Text.TrimEnd(New Char(-1) {}).ToString() + Strings.StrReverse(text))
					Next
				Finally
					Dim enumerator As ManagementObjectCollection.ManagementObjectEnumerator
					If enumerator IsNot Nothing Then
						CType(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
			End Try
		End Sub

		' Token: 0x0600152E RID: 5422 RVA: 0x000E2F78 File Offset: 0x000E1178
		Private Sub btnLogin_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please Check your internet connection!")
			Else
				Dim text As String = Me.txtCompanyId.Text.Trim()
				Dim flag2 As Boolean = String.IsNullOrEmpty(text)
				If flag2 Then
					MessageBox.Show("Please enter a Company ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag3 As Boolean = Not Me.CheckCompanyExists(Me.txtCompanyId.Text)
					If flag3 Then
						MessageBox.Show("Company ID not found in remote database.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Else
						Dim flag4 As Boolean = Operators.CompareString(Me.strCompany_id, Me.txtCompanyId.Text.Trim(), False) = 0
						If flag4 Then
							MessageBox.Show("⚠️ Source and destination company IDs cannot be the same.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Dim flag5 As Boolean = Me.CheckDuplicate(Me.strCompany_id, Me.txtCompanyId.Text)
							If flag5 Then
								MessageBox.Show("Data Already exist.", "Try Other", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Else
								Try
									Me.ImportCompanyDataToLocal(Me.strCompany_id, Me.txtCompanyId.Text)
									Me.txtCompanyId.Text = ""
									Me.Getdata()
								Catch ex As Exception
									MessageBox.Show("❌ Failed to import company data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
								End Try
								Dim flag6 As Boolean = Operators.CompareString(Me.Label1.Text, "transfer", False) = 0
								If flag6 Then
									MyBase.Dispose()
									MyProject.Forms.frmPOSNewTuch_StockTransfer.lblUser.Text = MyProject.Forms.frmMainMenu.lblUser.Text
									MyProject.Forms.frmPOSNewTuch_StockTransfer.TextBox10.Text = MyProject.Forms.frmMainMenu.lblUser.Text
									MyProject.Forms.frmPOSNewTuch_StockTransfer.lblUserType.Text = MyProject.Forms.frmMainMenu.lblUserType.Text
									MyProject.Forms.frmPOSNewTuch_StockTransfer.lblCPhone.Text = MyProject.Forms.frmMainMenu.lblCName.Text
									MyProject.Forms.frmPOSNewTuch_StockTransfer.lblDB.Text = Me.lblDB.Text
									MyProject.Forms.frmPOSNewTuch_StockTransfer.ShowDialog()
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x0600152F RID: 5423 RVA: 0x000E31F0 File Offset: 0x000E13F0
		Private Function CheckCompanyExists(to_companyId As String) As Boolean
			Dim flag As Boolean = False
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.RaintechMaster_Online_connection())
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM RaintechMaster WHERE company_id = @d1", sqlConnection)
				sqlCommand.Parameters.AddWithValue("@d1", to_companyId)
				flag = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())) > 0
			End Using
			Return flag
		End Function

		' Token: 0x06001530 RID: 5424 RVA: 0x000E3268 File Offset: 0x000E1468
		Private Function CheckDuplicate(from_companyId As String, to_companyId As String) As Boolean
			Dim flag As Boolean = False
			Dim flag2 As Boolean = False
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.RaintechMaster_Online_connection())
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM Branch_Relation WHERE from_company_id = @d1 AND to_company_id = @d2", sqlConnection)
				sqlCommand.Parameters.AddWithValue("@d1", from_companyId)
				sqlCommand.Parameters.AddWithValue("@d2", to_companyId)
				flag = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())) > 0
			End Using
			Dim flag3 As Boolean = flag
			If flag3 Then
				Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection2.Open()
					Dim sqlCommand2 As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM Branch_Relation WHERE from_company_id = @d1 AND to_company_id = @d2", sqlConnection2)
					sqlCommand2.Parameters.AddWithValue("@d1", from_companyId)
					sqlCommand2.Parameters.AddWithValue("@d2", to_companyId)
					flag2 = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand2.ExecuteScalar())) > 0
				End Using
				Dim flag4 As Boolean = Not flag2
				If flag4 Then
					Me.ImportLocal_IfExist(from_companyId, to_companyId)
					flag2 = True
				End If
			End If
			Return flag AndAlso flag2
		End Function

		' Token: 0x06001531 RID: 5425 RVA: 0x000E339C File Offset: 0x000E159C
		Private Sub ImportCompanyDataToLocal(from_companyId As String, to_companyId As String)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.RaintechMaster_Online_connection())
				Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					sqlConnection2.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand("SELECT TOP 1 CompanyName, DBName, Online_DBName, is_active " & vbCrLf & "                                        FROM RaintechMaster " & vbCrLf & "                                        WHERE company_id = @company_id ORDER BY id2 DESC", sqlConnection)
					sqlCommand.Parameters.AddWithValue("@company_id", to_companyId)
					Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
					Dim flag As Boolean = Not sqlDataReader.HasRows
					If flag Then
						MessageBox.Show("❌ Company ID not found in remote RaintechMaster.")
					Else
						Dim dataTable As DataTable = New DataTable()
						dataTable.Load(sqlDataReader)
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text As String = dataRow("CompanyName").ToString()
								Dim text2 As String = dataRow("DBName").ToString()
								Dim text3 As String = dataRow("Online_DBName").ToString()
								Dim flag2 As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataRow("is_active")))
								Dim text4 As String = vbCrLf & "                INSERT INTO Branch_Relation " & vbCrLf & "                (CompanyName, DBName, Online_DBName, from_company_id, to_company_id, is_active)" & vbCrLf & "                VALUES " & vbCrLf & "                (@CompanyName, @DBName, @Online_DBName, @from_company_id, @to_company_id, @is_active)" & vbCrLf & "            "
								Using sqlCommand2 As SqlCommand = New SqlCommand(text4, sqlConnection2)
									sqlCommand2.Parameters.AddWithValue("@CompanyName", text)
									sqlCommand2.Parameters.AddWithValue("@DBName", text2)
									sqlCommand2.Parameters.AddWithValue("@Online_DBName", text3)
									sqlCommand2.Parameters.AddWithValue("@from_company_id", from_companyId)
									sqlCommand2.Parameters.AddWithValue("@to_company_id", to_companyId)
									sqlCommand2.Parameters.AddWithValue("@is_active", flag2)
									sqlCommand2.ExecuteNonQuery()
								End Using
								Using sqlCommand3 As SqlCommand = New SqlCommand(text4, sqlConnection)
									sqlCommand3.Parameters.AddWithValue("@CompanyName", text)
									sqlCommand3.Parameters.AddWithValue("@DBName", text2)
									sqlCommand3.Parameters.AddWithValue("@Online_DBName", text3)
									sqlCommand3.Parameters.AddWithValue("@from_company_id", from_companyId)
									sqlCommand3.Parameters.AddWithValue("@to_company_id", to_companyId)
									sqlCommand3.Parameters.AddWithValue("@is_active", flag2)
									sqlCommand3.ExecuteNonQuery()
								End Using
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						MessageBox.Show("✅ Branch_Relation inserted successfully into both local and remote.")
					End If
				End Using
			End Using
		End Sub

		' Token: 0x06001532 RID: 5426 RVA: 0x000E36A8 File Offset: 0x000E18A8
		Private Sub ImportLocal_IfExist(from_companyId As String, to_companyId As String)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.RaintechMaster_Online_connection())
				Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					sqlConnection2.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand("SELECT TOP 1 CompanyName, DBName, Online_DBName, is_active " & vbCrLf & "                                        FROM RaintechMaster " & vbCrLf & "                                        WHERE company_id = @company_id", sqlConnection)
					sqlCommand.Parameters.AddWithValue("@company_id", to_companyId)
					Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
					Dim flag As Boolean = Not sqlDataReader.HasRows
					If flag Then
						MessageBox.Show("❌ Company ID not found in remote RaintechMaster.")
					Else
						Dim dataTable As DataTable = New DataTable()
						dataTable.Load(sqlDataReader)
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text As String = dataRow("CompanyName").ToString()
								Dim text2 As String = dataRow("DBName").ToString()
								Dim text3 As String = dataRow("Online_DBName").ToString()
								Dim flag2 As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataRow("is_active")))
								Dim text4 As String = vbCrLf & "                INSERT INTO Branch_Relation " & vbCrLf & "                (CompanyName, DBName, Online_DBName, from_company_id, to_company_id, is_active)" & vbCrLf & "                VALUES " & vbCrLf & "                (@CompanyName, @DBName, @Online_DBName, @from_company_id, @to_company_id, @is_active)" & vbCrLf & "            "
								Using sqlCommand2 As SqlCommand = New SqlCommand(text4, sqlConnection2)
									sqlCommand2.Parameters.AddWithValue("@CompanyName", text)
									sqlCommand2.Parameters.AddWithValue("@DBName", text2)
									sqlCommand2.Parameters.AddWithValue("@Online_DBName", text3)
									sqlCommand2.Parameters.AddWithValue("@from_company_id", from_companyId)
									sqlCommand2.Parameters.AddWithValue("@to_company_id", to_companyId)
									sqlCommand2.Parameters.AddWithValue("@is_active", flag2)
									sqlCommand2.ExecuteNonQuery()
								End Using
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End If
				End Using
			End Using
		End Sub

		' Token: 0x06001533 RID: 5427 RVA: 0x000E38F4 File Offset: 0x000E1AF4
		Public Sub Getdata()
			Try
				ModCS.cs = ModCS.ReadCS()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Id,RTRIM(CompanyName),RTRIM(DBName),RTRIM(Online_DBName),is_active, RTRIM(to_company_id) FROM Branch_Relation where RTRIM(from_company_id)=@d1 ORDER BY Id", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.strCompany_id)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), Convert.ToBoolean(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(4))), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001534 RID: 5428 RVA: 0x000E3A60 File Offset: 0x000E1C60
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.dgw.Columns(e.ColumnIndex).Name, "btnDel", False) = 0 AndAlso e.RowIndex >= 0
			If flag Then
				Try
					Dim value As Object = Me.dgw.Rows(e.RowIndex).Cells(1).Value
					Dim text As String = If((value IsNot Nothing), value.ToString().Trim(), Nothing)
					Dim value2 As Object = Me.dgw.Rows(e.RowIndex).Cells(5).Value
					Dim text2 As String = If((value2 IsNot Nothing), value2.ToString().Trim(), Nothing)
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to delete '" + text + "'?", "Delete Branch", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					Dim flag2 As Boolean = dialogResult = DialogResult.Yes
					If flag2 Then
						Dim flag3 As Boolean = Not ModFunc.CheckForInternetConnection()
						If flag3 Then
							MessageBox.Show("Please Check your internet connection!")
						Else
							Me.DeleteBranchFromDB(text2)
							MessageBox.Show("🗑️ Branch deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Me.Getdata()
						End If
					End If
				Catch ex As Exception
					MessageBox.Show("❌ Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			End If
		End Sub

		' Token: 0x06001535 RID: 5429 RVA: 0x000E3BCC File Offset: 0x000E1DCC
		Public Sub DeleteBranchFromDB(selectedCompany As String)
			Try
				Dim text As String = ModCS.ReadCS()
				Dim text2 As String = ModCS.RaintechMaster_Online_connection()
				Using sqlConnection As SqlConnection = New SqlConnection(text)
					Using sqlConnection2 As SqlConnection = New SqlConnection(text2)
						sqlConnection.Open()
						sqlConnection2.Open()
						Dim text3 As String = "DELETE FROM Branch_Relation WHERE from_company_id = @d1 and to_company_id = @d2"
						Using sqlCommand As SqlCommand = New SqlCommand(text3, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@d1", Me.strCompany_id)
							sqlCommand.Parameters.AddWithValue("@d2", selectedCompany)
							sqlCommand.ExecuteNonQuery()
						End Using
						Using sqlCommand2 As SqlCommand = New SqlCommand(text3, sqlConnection2)
							sqlCommand2.Parameters.AddWithValue("@d1", Me.strCompany_id)
							sqlCommand2.Parameters.AddWithValue("@d2", selectedCompany)
							sqlCommand2.ExecuteNonQuery()
						End Using
						MessageBox.Show("✅ Company deleted from both local and remote databases.")
						Me.Getdata()
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("❌ Error Deleting: " + ex.Message)
			End Try
		End Sub

		' Token: 0x04000745 RID: 1861
		Private strCompany_id As String
	End Class
End Namespace
