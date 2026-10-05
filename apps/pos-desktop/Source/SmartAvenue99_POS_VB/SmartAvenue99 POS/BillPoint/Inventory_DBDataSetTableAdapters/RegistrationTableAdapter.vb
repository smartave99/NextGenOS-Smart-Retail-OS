Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports BillPoint.My

Namespace BillPoint.Inventory_DBDataSetTableAdapters
	' Token: 0x0200045F RID: 1119
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class RegistrationTableAdapter
		Inherits Component

		' Token: 0x17005863 RID: 22627
		' (get) Token: 0x0600E5E4 RID: 58852 RVA: 0x00065984 File Offset: 0x00063B84
		' (set) Token: 0x0600E5E5 RID: 58853 RVA: 0x0006598E File Offset: 0x00063B8E
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E5E6 RID: 58854 RVA: 0x00065997 File Offset: 0x00063B97
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005864 RID: 22628
		' (get) Token: 0x0600E5E7 RID: 58855 RVA: 0x008A0A0C File Offset: 0x0089EC0C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected Friend ReadOnly Property Adapter As SqlDataAdapter
			Get
				Dim flag As Boolean = Me._adapter Is Nothing
				If flag Then
					Me.InitAdapter()
				End If
				Return Me._adapter
			End Get
		End Property

		' Token: 0x17005865 RID: 22629
		' (get) Token: 0x0600E5E8 RID: 58856 RVA: 0x008A0A3C File Offset: 0x0089EC3C
		' (set) Token: 0x0600E5E9 RID: 58857 RVA: 0x008A0A6C File Offset: 0x0089EC6C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Property Connection As SqlConnection
			Get
				Dim flag As Boolean = Me._connection Is Nothing
				If flag Then
					Me.InitConnection()
				End If
				Return Me._connection
			End Get
			Set(value As SqlConnection)
				Me._connection = value
				Dim flag As Boolean = Me.Adapter.InsertCommand IsNot Nothing
				If flag Then
					Me.Adapter.InsertCommand.Connection = value
				End If
				Dim flag2 As Boolean = Me.Adapter.DeleteCommand IsNot Nothing
				If flag2 Then
					Me.Adapter.DeleteCommand.Connection = value
				End If
				Dim flag3 As Boolean = Me.Adapter.UpdateCommand IsNot Nothing
				If flag3 Then
					Me.Adapter.UpdateCommand.Connection = value
				End If
				For i As Integer = 0 To Me.CommandCollection.Length - 1
					Dim flag4 As Boolean = Me.CommandCollection(i) IsNot Nothing
					If flag4 Then
						Me.CommandCollection(i).Connection = value
					End If
				Next
			End Set
		End Property

		' Token: 0x17005866 RID: 22630
		' (get) Token: 0x0600E5EA RID: 58858 RVA: 0x008A0B30 File Offset: 0x0089ED30
		' (set) Token: 0x0600E5EB RID: 58859 RVA: 0x008A0B48 File Offset: 0x0089ED48
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Friend Property Transaction As SqlTransaction
			Get
				Return Me._transaction
			End Get
			Set(value As SqlTransaction)
				Me._transaction = value
				For i As Integer = 0 To Me.CommandCollection.Length - 1
					Me.CommandCollection(i).Transaction = Me._transaction
				Next
				Dim flag As Boolean = Me.Adapter IsNot Nothing AndAlso Me.Adapter.DeleteCommand IsNot Nothing
				If flag Then
					Me.Adapter.DeleteCommand.Transaction = Me._transaction
				End If
				Dim flag2 As Boolean = Me.Adapter IsNot Nothing AndAlso Me.Adapter.InsertCommand IsNot Nothing
				If flag2 Then
					Me.Adapter.InsertCommand.Transaction = Me._transaction
				End If
				Dim flag3 As Boolean = Me.Adapter IsNot Nothing AndAlso Me.Adapter.UpdateCommand IsNot Nothing
				If flag3 Then
					Me.Adapter.UpdateCommand.Transaction = Me._transaction
				End If
			End Set
		End Property

		' Token: 0x17005867 RID: 22631
		' (get) Token: 0x0600E5EC RID: 58860 RVA: 0x008A0C30 File Offset: 0x0089EE30
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Protected ReadOnly Property CommandCollection As SqlCommand()
			Get
				Dim flag As Boolean = Me._commandCollection Is Nothing
				If flag Then
					Me.InitCommandCollection()
				End If
				Return Me._commandCollection
			End Get
		End Property

		' Token: 0x17005868 RID: 22632
		' (get) Token: 0x0600E5ED RID: 58861 RVA: 0x008A0C60 File Offset: 0x0089EE60
		' (set) Token: 0x0600E5EE RID: 58862 RVA: 0x000659A9 File Offset: 0x00063BA9
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Property ClearBeforeFill As Boolean
			Get
				Return Me._clearBeforeFill
			End Get
			Set(value As Boolean)
				Me._clearBeforeFill = value
			End Set
		End Property

		' Token: 0x0600E5EF RID: 58863 RVA: 0x008A0C78 File Offset: 0x0089EE78
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Registration"
			dataTableMapping.ColumnMappings.Add("UserID", "UserID")
			dataTableMapping.ColumnMappings.Add("UserType", "UserType")
			dataTableMapping.ColumnMappings.Add("Password", "Password")
			dataTableMapping.ColumnMappings.Add("Name", "Name")
			dataTableMapping.ColumnMappings.Add("ContactNo", "ContactNo")
			dataTableMapping.ColumnMappings.Add("EmailID", "EmailID")
			dataTableMapping.ColumnMappings.Add("JoiningDate", "JoiningDate")
			dataTableMapping.ColumnMappings.Add("Active", "Active")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Registration] WHERE (([UserID] = @Original_UserID) AND ([UserType] = @Original_UserType) AND ([Password] = @Original_Password) AND ([Name] = @Original_Name) AND ([ContactNo] = @Original_ContactNo) AND ((@IsNull_EmailID = 1 AND [EmailID] IS NULL) OR ([EmailID] = @Original_EmailID)) AND ((@IsNull_JoiningDate = 1 AND [JoiningDate] IS NULL) OR ([JoiningDate] = @Original_JoiningDate)) AND ((@IsNull_Active = 1 AND [Active] IS NULL) OR ([Active] = @Original_Active)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_UserID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_UserType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Password", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Password", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_EmailID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_JoiningDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "JoiningDate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_JoiningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "JoiningDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Active", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Active", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Registration] ([UserID], [UserType], [Password], [Name], [ContactNo], [EmailID], [JoiningDate], [Active]) VALUES (@UserID, @UserType, @Password, @Name, @ContactNo, @EmailID, @JoiningDate, @Active);" & vbCrLf & "SELECT UserID, UserType, Password, Name, ContactNo, EmailID, JoiningDate, Active FROM Registration WHERE (UserID = @UserID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Password", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Password", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@JoiningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "JoiningDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Active", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Registration] SET [UserID] = @UserID, [UserType] = @UserType, [Password] = @Password, [Name] = @Name, [ContactNo] = @ContactNo, [EmailID] = @EmailID, [JoiningDate] = @JoiningDate, [Active] = @Active WHERE (([UserID] = @Original_UserID) AND ([UserType] = @Original_UserType) AND ([Password] = @Original_Password) AND ([Name] = @Original_Name) AND ([ContactNo] = @Original_ContactNo) AND ((@IsNull_EmailID = 1 AND [EmailID] IS NULL) OR ([EmailID] = @Original_EmailID)) AND ((@IsNull_JoiningDate = 1 AND [JoiningDate] IS NULL) OR ([JoiningDate] = @Original_JoiningDate)) AND ((@IsNull_Active = 1 AND [Active] IS NULL) OR ([Active] = @Original_Active)));" & vbCrLf & "SELECT UserID, UserType, Password, Name, ContactNo, EmailID, JoiningDate, Active FROM Registration WHERE (UserID = @UserID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UserType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Password", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Password", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@JoiningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "JoiningDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Active", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_UserID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_UserType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Password", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Password", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_EmailID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_JoiningDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "JoiningDate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_JoiningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "JoiningDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Active", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Active", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E5F0 RID: 58864 RVA: 0x000659B3 File Offset: 0x00063BB3
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E5F1 RID: 58865 RVA: 0x008A1800 File Offset: 0x0089FA00
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT UserID, UserType, Password, Name, ContactNo, EmailID, JoiningDate, Active FROM dbo.Registration"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E5F2 RID: 58866 RVA: 0x008A1860 File Offset: 0x0089FA60
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.RegistrationDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E5F3 RID: 58867 RVA: 0x008A18A8 File Offset: 0x0089FAA8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.RegistrationDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim registrationDataTable As Inventory_DBDataSet.RegistrationDataTable = New Inventory_DBDataSet.RegistrationDataTable()
			Me.Adapter.Fill(registrationDataTable)
			Return registrationDataTable
		End Function

		' Token: 0x0600E5F4 RID: 58868 RVA: 0x008A18E4 File Offset: 0x0089FAE4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.RegistrationDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E5F5 RID: 58869 RVA: 0x008A1904 File Offset: 0x0089FB04
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Registration")
		End Function

		' Token: 0x0600E5F6 RID: 58870 RVA: 0x008A1928 File Offset: 0x0089FB28
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E5F7 RID: 58871 RVA: 0x008A1950 File Offset: 0x0089FB50
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E5F8 RID: 58872 RVA: 0x008A1970 File Offset: 0x0089FB70
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_UserID As String, Original_UserType As String, Original_Password As String, Original_Name As String, Original_ContactNo As String, Original_EmailID As String, Original_JoiningDate As DateTime?, Original_Active As String) As Integer
			Dim flag As Boolean = Original_UserID = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_UserID")
			End If
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_UserID
			Dim flag2 As Boolean = Original_UserType = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_UserType")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_UserType
			Dim flag3 As Boolean = Original_Password = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_Password")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Password
			Dim flag4 As Boolean = Original_Name = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Original_Name")
			End If
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_Name
			Dim flag5 As Boolean = Original_ContactNo = Nothing
			If flag5 Then
				Throw New ArgumentNullException("Original_ContactNo")
			End If
			Me.Adapter.DeleteCommand.Parameters(4).Value = Original_ContactNo
			Dim flag6 As Boolean = Original_EmailID = Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_EmailID
			End If
			Dim flag7 As Boolean = Original_JoiningDate IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_JoiningDate.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_Active = Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_Active
			End If
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag9 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag9 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag10 As Boolean = state = ConnectionState.Closed
				If flag10 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E5F9 RID: 58873 RVA: 0x008A1CEC File Offset: 0x0089FEEC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(UserID As String, UserType As String, Password As String, Name As String, ContactNo As String, EmailID As String, JoiningDate As DateTime?, Active As String) As Integer
			Dim flag As Boolean = UserID = Nothing
			If flag Then
				Throw New ArgumentNullException("UserID")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = UserID
			Dim flag2 As Boolean = UserType = Nothing
			If flag2 Then
				Throw New ArgumentNullException("UserType")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = UserType
			Dim flag3 As Boolean = Password = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Password")
			End If
			Me.Adapter.InsertCommand.Parameters(2).Value = Password
			Dim flag4 As Boolean = Name = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Name")
			End If
			Me.Adapter.InsertCommand.Parameters(3).Value = Name
			Dim flag5 As Boolean = ContactNo = Nothing
			If flag5 Then
				Throw New ArgumentNullException("ContactNo")
			End If
			Me.Adapter.InsertCommand.Parameters(4).Value = ContactNo
			Dim flag6 As Boolean = EmailID = Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = EmailID
			End If
			Dim flag7 As Boolean = JoiningDate IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = JoiningDate.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Active = Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = Active
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag9 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag9 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag10 As Boolean = state = ConnectionState.Closed
				If flag10 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E5FA RID: 58874 RVA: 0x008A1F98 File Offset: 0x008A0198
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(UserID As String, UserType As String, Password As String, Name As String, ContactNo As String, EmailID As String, JoiningDate As DateTime?, Active As String, Original_UserID As String, Original_UserType As String, Original_Password As String, Original_Name As String, Original_ContactNo As String, Original_EmailID As String, Original_JoiningDate As DateTime?, Original_Active As String) As Integer
			Dim flag As Boolean = UserID = Nothing
			If flag Then
				Throw New ArgumentNullException("UserID")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = UserID
			Dim flag2 As Boolean = UserType = Nothing
			If flag2 Then
				Throw New ArgumentNullException("UserType")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = UserType
			Dim flag3 As Boolean = Password = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Password")
			End If
			Me.Adapter.UpdateCommand.Parameters(2).Value = Password
			Dim flag4 As Boolean = Name = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Name")
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = Name
			Dim flag5 As Boolean = ContactNo = Nothing
			If flag5 Then
				Throw New ArgumentNullException("ContactNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = ContactNo
			Dim flag6 As Boolean = EmailID = Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = EmailID
			End If
			Dim flag7 As Boolean = JoiningDate IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = JoiningDate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Active = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = Active
			End If
			Dim flag9 As Boolean = Original_UserID = Nothing
			If flag9 Then
				Throw New ArgumentNullException("Original_UserID")
			End If
			Me.Adapter.UpdateCommand.Parameters(8).Value = Original_UserID
			Dim flag10 As Boolean = Original_UserType = Nothing
			If flag10 Then
				Throw New ArgumentNullException("Original_UserType")
			End If
			Me.Adapter.UpdateCommand.Parameters(9).Value = Original_UserType
			Dim flag11 As Boolean = Original_Password = Nothing
			If flag11 Then
				Throw New ArgumentNullException("Original_Password")
			End If
			Me.Adapter.UpdateCommand.Parameters(10).Value = Original_Password
			Dim flag12 As Boolean = Original_Name = Nothing
			If flag12 Then
				Throw New ArgumentNullException("Original_Name")
			End If
			Me.Adapter.UpdateCommand.Parameters(11).Value = Original_Name
			Dim flag13 As Boolean = Original_ContactNo = Nothing
			If flag13 Then
				Throw New ArgumentNullException("Original_ContactNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(12).Value = Original_ContactNo
			Dim flag14 As Boolean = Original_EmailID = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = 1
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = 0
				Me.Adapter.UpdateCommand.Parameters(14).Value = Original_EmailID
			End If
			Dim flag15 As Boolean = Original_JoiningDate IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = 0
				Me.Adapter.UpdateCommand.Parameters(16).Value = Original_JoiningDate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = 1
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = Original_Active = Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_Active
			End If
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag17 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag17 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag18 As Boolean = state = ConnectionState.Closed
				If flag18 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E5FB RID: 58875 RVA: 0x008A2524 File Offset: 0x008A0724
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(UserType As String, Password As String, Name As String, ContactNo As String, EmailID As String, JoiningDate As DateTime?, Active As String, Original_UserID As String, Original_UserType As String, Original_Password As String, Original_Name As String, Original_ContactNo As String, Original_EmailID As String, Original_JoiningDate As DateTime?, Original_Active As String) As Integer
			Return Me.Update(Original_UserID, UserType, Password, Name, ContactNo, EmailID, JoiningDate, Active, Original_UserID, Original_UserType, Original_Password, Original_Name, Original_ContactNo, Original_EmailID, Original_JoiningDate, Original_Active)
		End Function

		' Token: 0x040058A8 RID: 22696
		Private _connection As SqlConnection

		' Token: 0x040058A9 RID: 22697
		Private _transaction As SqlTransaction

		' Token: 0x040058AA RID: 22698
		Private _commandCollection As SqlCommand()

		' Token: 0x040058AB RID: 22699
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
