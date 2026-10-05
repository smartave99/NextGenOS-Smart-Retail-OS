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
	' Token: 0x02000467 RID: 1127
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class SMSSettingTableAdapter
		Inherits Component

		' Token: 0x17005893 RID: 22675
		' (get) Token: 0x0600E6A4 RID: 59044 RVA: 0x00065C1C File Offset: 0x00063E1C
		' (set) Token: 0x0600E6A5 RID: 59045 RVA: 0x00065C26 File Offset: 0x00063E26
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E6A6 RID: 59046 RVA: 0x00065C2F File Offset: 0x00063E2F
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005894 RID: 22676
		' (get) Token: 0x0600E6A7 RID: 59047 RVA: 0x008B1058 File Offset: 0x008AF258
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

		' Token: 0x17005895 RID: 22677
		' (get) Token: 0x0600E6A8 RID: 59048 RVA: 0x008B1088 File Offset: 0x008AF288
		' (set) Token: 0x0600E6A9 RID: 59049 RVA: 0x008B10B8 File Offset: 0x008AF2B8
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

		' Token: 0x17005896 RID: 22678
		' (get) Token: 0x0600E6AA RID: 59050 RVA: 0x008B117C File Offset: 0x008AF37C
		' (set) Token: 0x0600E6AB RID: 59051 RVA: 0x008B1194 File Offset: 0x008AF394
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

		' Token: 0x17005897 RID: 22679
		' (get) Token: 0x0600E6AC RID: 59052 RVA: 0x008B127C File Offset: 0x008AF47C
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

		' Token: 0x17005898 RID: 22680
		' (get) Token: 0x0600E6AD RID: 59053 RVA: 0x008B12AC File Offset: 0x008AF4AC
		' (set) Token: 0x0600E6AE RID: 59054 RVA: 0x00065C41 File Offset: 0x00063E41
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

		' Token: 0x0600E6AF RID: 59055 RVA: 0x008B12C4 File Offset: 0x008AF4C4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "SMSSetting"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("APIUrl", "APIUrl")
			dataTableMapping.ColumnMappings.Add("IsDefault", "IsDefault")
			dataTableMapping.ColumnMappings.Add("IsEnabled", "IsEnabled")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[SMSSetting] WHERE (([Id] = @Original_Id) AND ([IsDefault] = @Original_IsDefault) AND ([IsEnabled] = @Original_IsEnabled))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IsDefault", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsDefault", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IsEnabled", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsEnabled", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[SMSSetting] ([APIUrl], [IsDefault], [IsEnabled]) VALUES (@APIUrl, @IsDefault, @IsEnabled);" & vbCrLf & "SELECT Id, APIUrl, IsDefault, IsEnabled FROM SMSSetting WHERE (Id = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@APIUrl", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "APIUrl", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IsDefault", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsDefault", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IsEnabled", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsEnabled", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[SMSSetting] SET [APIUrl] = @APIUrl, [IsDefault] = @IsDefault, [IsEnabled] = @IsEnabled WHERE (([Id] = @Original_Id) AND ([IsDefault] = @Original_IsDefault) AND ([IsEnabled] = @Original_IsEnabled));" & vbCrLf & "SELECT Id, APIUrl, IsDefault, IsEnabled FROM SMSSetting WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@APIUrl", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "APIUrl", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsDefault", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsDefault", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsEnabled", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsEnabled", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IsDefault", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsDefault", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IsEnabled", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IsEnabled", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E6B0 RID: 59056 RVA: 0x00065C4B File Offset: 0x00063E4B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E6B1 RID: 59057 RVA: 0x008B17A0 File Offset: 0x008AF9A0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, APIUrl, IsDefault, IsEnabled FROM dbo.SMSSetting"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E6B2 RID: 59058 RVA: 0x008B1800 File Offset: 0x008AFA00
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.SMSSettingDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E6B3 RID: 59059 RVA: 0x008B1848 File Offset: 0x008AFA48
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.SMSSettingDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim smssettingDataTable As Inventory_DBDataSet.SMSSettingDataTable = New Inventory_DBDataSet.SMSSettingDataTable()
			Me.Adapter.Fill(smssettingDataTable)
			Return smssettingDataTable
		End Function

		' Token: 0x0600E6B4 RID: 59060 RVA: 0x008B1884 File Offset: 0x008AFA84
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.SMSSettingDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E6B5 RID: 59061 RVA: 0x008B18A4 File Offset: 0x008AFAA4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "SMSSetting")
		End Function

		' Token: 0x0600E6B6 RID: 59062 RVA: 0x008B18C8 File Offset: 0x008AFAC8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E6B7 RID: 59063 RVA: 0x008B18F0 File Offset: 0x008AFAF0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E6B8 RID: 59064 RVA: 0x008B1910 File Offset: 0x008AFB10
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_IsDefault As String, Original_IsEnabled As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Dim flag As Boolean = Original_IsDefault = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_IsDefault")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_IsDefault
			Dim flag2 As Boolean = Original_IsEnabled = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_IsEnabled")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_IsEnabled
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag3 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag3 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag4 As Boolean = state = ConnectionState.Closed
				If flag4 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6B9 RID: 59065 RVA: 0x008B1A44 File Offset: 0x008AFC44
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(APIUrl As String, IsDefault As String, IsEnabled As String) As Integer
			Dim flag As Boolean = APIUrl = Nothing
			If flag Then
				Throw New ArgumentNullException("APIUrl")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = APIUrl
			Dim flag2 As Boolean = IsDefault = Nothing
			If flag2 Then
				Throw New ArgumentNullException("IsDefault")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = IsDefault
			Dim flag3 As Boolean = IsEnabled = Nothing
			If flag3 Then
				Throw New ArgumentNullException("IsEnabled")
			End If
			Me.Adapter.InsertCommand.Parameters(2).Value = IsEnabled
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag4 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag4 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag5 As Boolean = state = ConnectionState.Closed
				If flag5 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6BA RID: 59066 RVA: 0x008B1B88 File Offset: 0x008AFD88
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(APIUrl As String, IsDefault As String, IsEnabled As String, Original_Id As Integer, Original_IsDefault As String, Original_IsEnabled As String, Id As Integer) As Integer
			Dim flag As Boolean = APIUrl = Nothing
			If flag Then
				Throw New ArgumentNullException("APIUrl")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = APIUrl
			Dim flag2 As Boolean = IsDefault = Nothing
			If flag2 Then
				Throw New ArgumentNullException("IsDefault")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = IsDefault
			Dim flag3 As Boolean = IsEnabled = Nothing
			If flag3 Then
				Throw New ArgumentNullException("IsEnabled")
			End If
			Me.Adapter.UpdateCommand.Parameters(2).Value = IsEnabled
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_Id
			Dim flag4 As Boolean = Original_IsDefault = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Original_IsDefault")
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_IsDefault
			Dim flag5 As Boolean = Original_IsEnabled = Nothing
			If flag5 Then
				Throw New ArgumentNullException("Original_IsEnabled")
			End If
			Me.Adapter.UpdateCommand.Parameters(5).Value = Original_IsEnabled
			Me.Adapter.UpdateCommand.Parameters(6).Value = Id
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag6 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag6 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag7 As Boolean = state = ConnectionState.Closed
				If flag7 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6BB RID: 59067 RVA: 0x008B1D80 File Offset: 0x008AFF80
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(APIUrl As String, IsDefault As String, IsEnabled As String, Original_Id As Integer, Original_IsDefault As String, Original_IsEnabled As String) As Integer
			Return Me.Update(APIUrl, IsDefault, IsEnabled, Original_Id, Original_IsDefault, Original_IsEnabled, Original_Id)
		End Function

		' Token: 0x040058D0 RID: 22736
		Private _connection As SqlConnection

		' Token: 0x040058D1 RID: 22737
		Private _transaction As SqlTransaction

		' Token: 0x040058D2 RID: 22738
		Private _commandCollection As SqlCommand()

		' Token: 0x040058D3 RID: 22739
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
