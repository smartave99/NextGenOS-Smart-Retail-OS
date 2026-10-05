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
	' Token: 0x0200044C RID: 1100
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class EmailSettingTableAdapter
		Inherits Component

		' Token: 0x170057F1 RID: 22513
		' (get) Token: 0x0600E41C RID: 58396 RVA: 0x0006535B File Offset: 0x0006355B
		' (set) Token: 0x0600E41D RID: 58397 RVA: 0x00065365 File Offset: 0x00063565
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E41E RID: 58398 RVA: 0x0006536E File Offset: 0x0006356E
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057F2 RID: 22514
		' (get) Token: 0x0600E41F RID: 58399 RVA: 0x008749A4 File Offset: 0x00872BA4
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

		' Token: 0x170057F3 RID: 22515
		' (get) Token: 0x0600E420 RID: 58400 RVA: 0x008749D4 File Offset: 0x00872BD4
		' (set) Token: 0x0600E421 RID: 58401 RVA: 0x00874A04 File Offset: 0x00872C04
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

		' Token: 0x170057F4 RID: 22516
		' (get) Token: 0x0600E422 RID: 58402 RVA: 0x00874AC8 File Offset: 0x00872CC8
		' (set) Token: 0x0600E423 RID: 58403 RVA: 0x00874AE0 File Offset: 0x00872CE0
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

		' Token: 0x170057F5 RID: 22517
		' (get) Token: 0x0600E424 RID: 58404 RVA: 0x00874BC8 File Offset: 0x00872DC8
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

		' Token: 0x170057F6 RID: 22518
		' (get) Token: 0x0600E425 RID: 58405 RVA: 0x00874BF8 File Offset: 0x00872DF8
		' (set) Token: 0x0600E426 RID: 58406 RVA: 0x00065380 File Offset: 0x00063580
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

		' Token: 0x0600E427 RID: 58407 RVA: 0x00874C10 File Offset: 0x00872E10
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "EmailSetting"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("ServerName", "ServerName")
			dataTableMapping.ColumnMappings.Add("SMTPAddress", "SMTPAddress")
			dataTableMapping.ColumnMappings.Add("Username", "Username")
			dataTableMapping.ColumnMappings.Add("Password", "Password")
			dataTableMapping.ColumnMappings.Add("Port", "Port")
			dataTableMapping.ColumnMappings.Add("TLS_SSL_Required", "TLS_SSL_Required")
			dataTableMapping.ColumnMappings.Add("IsDefault", "IsDefault")
			dataTableMapping.ColumnMappings.Add("IsActive", "IsActive")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[EmailSetting] WHERE (([Id] = @Original_Id) AND ([ServerName] = @Original_ServerName) AND ([SMTPAddress] = @Original_SMTPAddress) AND ([Username] = @Original_Username) AND ([Password] = @Original_Password) AND ([Port] = @Original_Port) AND ([TLS_SSL_Required] = @Original_TLS_SSL_Required) AND ([IsDefault] = @Original_IsDefault) AND ([IsActive] = @Original_IsActive))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ServerName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServerName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SMTPAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SMTPAddress", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Username", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Username", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Password", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Password", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Port", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Port", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TLS_SSL_Required", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TLS_SSL_Required", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IsDefault", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsDefault", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IsActive", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsActive", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[EmailSetting] ([ServerName], [SMTPAddress], [Username], [Password], [Port], [TLS_SSL_Required], [IsDefault], [IsActive]) VALUES (@ServerName, @SMTPAddress, @Username, @Password, @Port, @TLS_SSL_Required, @IsDefault, @IsActive);" & vbCrLf & "SELECT Id, ServerName, SMTPAddress, Username, Password, Port, TLS_SSL_Required, IsDefault, IsActive FROM EmailSetting WHERE (Id = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ServerName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServerName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SMTPAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SMTPAddress", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Username", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Username", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Password", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Password", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Port", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Port", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TLS_SSL_Required", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TLS_SSL_Required", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IsDefault", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsDefault", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IsActive", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsActive", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[EmailSetting] SET [ServerName] = @ServerName, [SMTPAddress] = @SMTPAddress, [Username] = @Username, [Password] = @Password, [Port] = @Port, [TLS_SSL_Required] = @TLS_SSL_Required, [IsDefault] = @IsDefault, [IsActive] = @IsActive WHERE (([Id] = @Original_Id) AND ([ServerName] = @Original_ServerName) AND ([SMTPAddress] = @Original_SMTPAddress) AND ([Username] = @Original_Username) AND ([Password] = @Original_Password) AND ([Port] = @Original_Port) AND ([TLS_SSL_Required] = @Original_TLS_SSL_Required) AND ([IsDefault] = @Original_IsDefault) AND ([IsActive] = @Original_IsActive));" & vbCrLf & "SELECT Id, ServerName, SMTPAddress, Username, Password, Port, TLS_SSL_Required, IsDefault, IsActive FROM EmailSetting WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ServerName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServerName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SMTPAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SMTPAddress", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Username", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Username", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Password", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Password", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Port", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Port", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TLS_SSL_Required", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TLS_SSL_Required", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsDefault", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsDefault", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsActive", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsActive", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ServerName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServerName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SMTPAddress", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "SMTPAddress", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Username", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Username", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Password", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Password", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Port", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Port", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TLS_SSL_Required", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TLS_SSL_Required", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IsDefault", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsDefault", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IsActive", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsActive", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E428 RID: 58408 RVA: 0x0006538A File Offset: 0x0006358A
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E429 RID: 58409 RVA: 0x008756EC File Offset: 0x008738EC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, ServerName, SMTPAddress, Username, Password, Port, TLS_SSL_Required, IsDefault, IsActive FROM dbo.EmailSetting"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E42A RID: 58410 RVA: 0x0087574C File Offset: 0x0087394C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.EmailSettingDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E42B RID: 58411 RVA: 0x00875794 File Offset: 0x00873994
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.EmailSettingDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim emailSettingDataTable As Inventory_DBDataSet.EmailSettingDataTable = New Inventory_DBDataSet.EmailSettingDataTable()
			Me.Adapter.Fill(emailSettingDataTable)
			Return emailSettingDataTable
		End Function

		' Token: 0x0600E42C RID: 58412 RVA: 0x008757D0 File Offset: 0x008739D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.EmailSettingDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E42D RID: 58413 RVA: 0x008757F0 File Offset: 0x008739F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "EmailSetting")
		End Function

		' Token: 0x0600E42E RID: 58414 RVA: 0x00875814 File Offset: 0x00873A14
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E42F RID: 58415 RVA: 0x0087583C File Offset: 0x00873A3C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E430 RID: 58416 RVA: 0x0087585C File Offset: 0x00873A5C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_ServerName As String, Original_SMTPAddress As String, Original_Username As String, Original_Password As String, Original_Port As Integer, Original_TLS_SSL_Required As String, Original_IsDefault As String, Original_IsActive As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Dim flag As Boolean = Original_ServerName = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_ServerName")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_ServerName
			Dim flag2 As Boolean = Original_SMTPAddress = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_SMTPAddress")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_SMTPAddress
			Dim flag3 As Boolean = Original_Username = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_Username")
			End If
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_Username
			Dim flag4 As Boolean = Original_Password = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Original_Password")
			End If
			Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Password
			Me.Adapter.DeleteCommand.Parameters(5).Value = Original_Port
			Dim flag5 As Boolean = Original_TLS_SSL_Required = Nothing
			If flag5 Then
				Throw New ArgumentNullException("Original_TLS_SSL_Required")
			End If
			Me.Adapter.DeleteCommand.Parameters(6).Value = Original_TLS_SSL_Required
			Dim flag6 As Boolean = Original_IsDefault = Nothing
			If flag6 Then
				Throw New ArgumentNullException("Original_IsDefault")
			End If
			Me.Adapter.DeleteCommand.Parameters(7).Value = Original_IsDefault
			Dim flag7 As Boolean = Original_IsActive = Nothing
			If flag7 Then
				Throw New ArgumentNullException("Original_IsActive")
			End If
			Me.Adapter.DeleteCommand.Parameters(8).Value = Original_IsActive
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag8 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag8 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag9 As Boolean = state = ConnectionState.Closed
				If flag9 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E431 RID: 58417 RVA: 0x00875AC0 File Offset: 0x00873CC0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(ServerName As String, SMTPAddress As String, Username As String, Password As String, Port As Integer, TLS_SSL_Required As String, IsDefault As String, IsActive As String) As Integer
			Dim flag As Boolean = ServerName = Nothing
			If flag Then
				Throw New ArgumentNullException("ServerName")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = ServerName
			Dim flag2 As Boolean = SMTPAddress = Nothing
			If flag2 Then
				Throw New ArgumentNullException("SMTPAddress")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = SMTPAddress
			Dim flag3 As Boolean = Username = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Username")
			End If
			Me.Adapter.InsertCommand.Parameters(2).Value = Username
			Dim flag4 As Boolean = Password = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Password")
			End If
			Me.Adapter.InsertCommand.Parameters(3).Value = Password
			Me.Adapter.InsertCommand.Parameters(4).Value = Port
			Dim flag5 As Boolean = TLS_SSL_Required = Nothing
			If flag5 Then
				Throw New ArgumentNullException("TLS_SSL_Required")
			End If
			Me.Adapter.InsertCommand.Parameters(5).Value = TLS_SSL_Required
			Dim flag6 As Boolean = IsDefault = Nothing
			If flag6 Then
				Throw New ArgumentNullException("IsDefault")
			End If
			Me.Adapter.InsertCommand.Parameters(6).Value = IsDefault
			Dim flag7 As Boolean = IsActive = Nothing
			If flag7 Then
				Throw New ArgumentNullException("IsActive")
			End If
			Me.Adapter.InsertCommand.Parameters(7).Value = IsActive
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag8 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag8 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag9 As Boolean = state = ConnectionState.Closed
				If flag9 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E432 RID: 58418 RVA: 0x00875D00 File Offset: 0x00873F00
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ServerName As String, SMTPAddress As String, Username As String, Password As String, Port As Integer, TLS_SSL_Required As String, IsDefault As String, IsActive As String, Original_Id As Integer, Original_ServerName As String, Original_SMTPAddress As String, Original_Username As String, Original_Password As String, Original_Port As Integer, Original_TLS_SSL_Required As String, Original_IsDefault As String, Original_IsActive As String, Id As Integer) As Integer
			Dim flag As Boolean = ServerName = Nothing
			If flag Then
				Throw New ArgumentNullException("ServerName")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = ServerName
			Dim flag2 As Boolean = SMTPAddress = Nothing
			If flag2 Then
				Throw New ArgumentNullException("SMTPAddress")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = SMTPAddress
			Dim flag3 As Boolean = Username = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Username")
			End If
			Me.Adapter.UpdateCommand.Parameters(2).Value = Username
			Dim flag4 As Boolean = Password = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Password")
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = Password
			Me.Adapter.UpdateCommand.Parameters(4).Value = Port
			Dim flag5 As Boolean = TLS_SSL_Required = Nothing
			If flag5 Then
				Throw New ArgumentNullException("TLS_SSL_Required")
			End If
			Me.Adapter.UpdateCommand.Parameters(5).Value = TLS_SSL_Required
			Dim flag6 As Boolean = IsDefault = Nothing
			If flag6 Then
				Throw New ArgumentNullException("IsDefault")
			End If
			Me.Adapter.UpdateCommand.Parameters(6).Value = IsDefault
			Dim flag7 As Boolean = IsActive = Nothing
			If flag7 Then
				Throw New ArgumentNullException("IsActive")
			End If
			Me.Adapter.UpdateCommand.Parameters(7).Value = IsActive
			Me.Adapter.UpdateCommand.Parameters(8).Value = Original_Id
			Dim flag8 As Boolean = Original_ServerName = Nothing
			If flag8 Then
				Throw New ArgumentNullException("Original_ServerName")
			End If
			Me.Adapter.UpdateCommand.Parameters(9).Value = Original_ServerName
			Dim flag9 As Boolean = Original_SMTPAddress = Nothing
			If flag9 Then
				Throw New ArgumentNullException("Original_SMTPAddress")
			End If
			Me.Adapter.UpdateCommand.Parameters(10).Value = Original_SMTPAddress
			Dim flag10 As Boolean = Original_Username = Nothing
			If flag10 Then
				Throw New ArgumentNullException("Original_Username")
			End If
			Me.Adapter.UpdateCommand.Parameters(11).Value = Original_Username
			Dim flag11 As Boolean = Original_Password = Nothing
			If flag11 Then
				Throw New ArgumentNullException("Original_Password")
			End If
			Me.Adapter.UpdateCommand.Parameters(12).Value = Original_Password
			Me.Adapter.UpdateCommand.Parameters(13).Value = Original_Port
			Dim flag12 As Boolean = Original_TLS_SSL_Required = Nothing
			If flag12 Then
				Throw New ArgumentNullException("Original_TLS_SSL_Required")
			End If
			Me.Adapter.UpdateCommand.Parameters(14).Value = Original_TLS_SSL_Required
			Dim flag13 As Boolean = Original_IsDefault = Nothing
			If flag13 Then
				Throw New ArgumentNullException("Original_IsDefault")
			End If
			Me.Adapter.UpdateCommand.Parameters(15).Value = Original_IsDefault
			Dim flag14 As Boolean = Original_IsActive = Nothing
			If flag14 Then
				Throw New ArgumentNullException("Original_IsActive")
			End If
			Me.Adapter.UpdateCommand.Parameters(16).Value = Original_IsActive
			Me.Adapter.UpdateCommand.Parameters(17).Value = Id
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag15 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag15 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag16 As Boolean = state = ConnectionState.Closed
				If flag16 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E433 RID: 58419 RVA: 0x0087612C File Offset: 0x0087432C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ServerName As String, SMTPAddress As String, Username As String, Password As String, Port As Integer, TLS_SSL_Required As String, IsDefault As String, IsActive As String, Original_Id As Integer, Original_ServerName As String, Original_SMTPAddress As String, Original_Username As String, Original_Password As String, Original_Port As Integer, Original_TLS_SSL_Required As String, Original_IsDefault As String, Original_IsActive As String) As Integer
			Return Me.Update(ServerName, SMTPAddress, Username, Password, Port, TLS_SSL_Required, IsDefault, IsActive, Original_Id, Original_ServerName, Original_SMTPAddress, Original_Username, Original_Password, Original_Port, Original_TLS_SSL_Required, Original_IsDefault, Original_IsActive, Original_Id)
		End Function

		' Token: 0x04005849 RID: 22601
		Private _connection As SqlConnection

		' Token: 0x0400584A RID: 22602
		Private _transaction As SqlTransaction

		' Token: 0x0400584B RID: 22603
		Private _commandCollection As SqlCommand()

		' Token: 0x0400584C RID: 22604
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
