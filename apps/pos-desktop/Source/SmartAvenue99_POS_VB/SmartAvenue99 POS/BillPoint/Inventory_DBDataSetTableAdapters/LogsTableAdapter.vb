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
	' Token: 0x02000454 RID: 1108
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class LogsTableAdapter
		Inherits Component

		' Token: 0x17005821 RID: 22561
		' (get) Token: 0x0600E4DC RID: 58588 RVA: 0x000655F3 File Offset: 0x000637F3
		' (set) Token: 0x0600E4DD RID: 58589 RVA: 0x000655FD File Offset: 0x000637FD
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E4DE RID: 58590 RVA: 0x00065606 File Offset: 0x00063806
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005822 RID: 22562
		' (get) Token: 0x0600E4DF RID: 58591 RVA: 0x008849AC File Offset: 0x00882BAC
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

		' Token: 0x17005823 RID: 22563
		' (get) Token: 0x0600E4E0 RID: 58592 RVA: 0x008849DC File Offset: 0x00882BDC
		' (set) Token: 0x0600E4E1 RID: 58593 RVA: 0x00884A0C File Offset: 0x00882C0C
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

		' Token: 0x17005824 RID: 22564
		' (get) Token: 0x0600E4E2 RID: 58594 RVA: 0x00884AD0 File Offset: 0x00882CD0
		' (set) Token: 0x0600E4E3 RID: 58595 RVA: 0x00884AE8 File Offset: 0x00882CE8
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

		' Token: 0x17005825 RID: 22565
		' (get) Token: 0x0600E4E4 RID: 58596 RVA: 0x00884BD0 File Offset: 0x00882DD0
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

		' Token: 0x17005826 RID: 22566
		' (get) Token: 0x0600E4E5 RID: 58597 RVA: 0x00884C00 File Offset: 0x00882E00
		' (set) Token: 0x0600E4E6 RID: 58598 RVA: 0x00065618 File Offset: 0x00063818
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

		' Token: 0x0600E4E7 RID: 58599 RVA: 0x00884C18 File Offset: 0x00882E18
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Logs"
			dataTableMapping.ColumnMappings.Add("ID", "ID")
			dataTableMapping.ColumnMappings.Add("UserID", "UserID")
			dataTableMapping.ColumnMappings.Add("Operation", "Operation")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Logs] WHERE (([ID] = @Original_ID) AND ([UserID] = @Original_UserID) AND ([Date] = @Original_Date))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_UserID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Logs] ([UserID], [Operation], [Date]) VALUES (@UserID, @Operation, @Date);" & vbCrLf & "SELECT ID, UserID, Operation, Date FROM Logs WHERE (ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Operation", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Operation", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Logs] SET [UserID] = @UserID, [Operation] = @Operation, [Date] = @Date WHERE (([ID] = @Original_ID) AND ([UserID] = @Original_UserID) AND ([Date] = @Original_Date));" & vbCrLf & "SELECT ID, UserID, Operation, Date FROM Logs WHERE (ID = @ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Operation", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Operation", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_UserID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "UserID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E4E8 RID: 58600 RVA: 0x00065622 File Offset: 0x00063822
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E4E9 RID: 58601 RVA: 0x008850F0 File Offset: 0x008832F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT ID, UserID, Operation, Date FROM dbo.Logs"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E4EA RID: 58602 RVA: 0x00885150 File Offset: 0x00883350
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.LogsDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E4EB RID: 58603 RVA: 0x00885198 File Offset: 0x00883398
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.LogsDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim logsDataTable As Inventory_DBDataSet.LogsDataTable = New Inventory_DBDataSet.LogsDataTable()
			Me.Adapter.Fill(logsDataTable)
			Return logsDataTable
		End Function

		' Token: 0x0600E4EC RID: 58604 RVA: 0x008851D4 File Offset: 0x008833D4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.LogsDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E4ED RID: 58605 RVA: 0x008851F4 File Offset: 0x008833F4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Logs")
		End Function

		' Token: 0x0600E4EE RID: 58606 RVA: 0x00885218 File Offset: 0x00883418
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E4EF RID: 58607 RVA: 0x00885240 File Offset: 0x00883440
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E4F0 RID: 58608 RVA: 0x00885260 File Offset: 0x00883460
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_ID As Integer, Original_UserID As String, Original_Date As DateTime) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_ID
			Dim flag As Boolean = Original_UserID = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_UserID")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_UserID
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Date
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag2 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag2 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag3 As Boolean = state = ConnectionState.Closed
				If flag3 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E4F1 RID: 58609 RVA: 0x00885380 File Offset: 0x00883580
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(UserID As String, Operation As String, _Date As DateTime) As Integer
			Dim flag As Boolean = UserID = Nothing
			If flag Then
				Throw New ArgumentNullException("UserID")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = UserID
			Dim flag2 As Boolean = Operation = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Operation")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = Operation
			Me.Adapter.InsertCommand.Parameters(2).Value = _Date
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag3 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag3 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag4 As Boolean = state = ConnectionState.Closed
				If flag4 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E4F2 RID: 58610 RVA: 0x008854B4 File Offset: 0x008836B4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(UserID As String, Operation As String, _Date As DateTime, Original_ID As Integer, Original_UserID As String, Original_Date As DateTime, ID As Integer) As Integer
			Dim flag As Boolean = UserID = Nothing
			If flag Then
				Throw New ArgumentNullException("UserID")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = UserID
			Dim flag2 As Boolean = Operation = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Operation")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = Operation
			Me.Adapter.UpdateCommand.Parameters(2).Value = _Date
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_ID
			Dim flag3 As Boolean = Original_UserID = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_UserID")
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_UserID
			Me.Adapter.UpdateCommand.Parameters(5).Value = Original_Date
			Me.Adapter.UpdateCommand.Parameters(6).Value = ID
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag4 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag4 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag5 As Boolean = state = ConnectionState.Closed
				If flag5 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E4F3 RID: 58611 RVA: 0x00885688 File Offset: 0x00883888
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(UserID As String, Operation As String, _Date As DateTime, Original_ID As Integer, Original_UserID As String, Original_Date As DateTime) As Integer
			Return Me.Update(UserID, Operation, _Date, Original_ID, Original_UserID, Original_Date, Original_ID)
		End Function

		' Token: 0x04005871 RID: 22641
		Private _connection As SqlConnection

		' Token: 0x04005872 RID: 22642
		Private _transaction As SqlTransaction

		' Token: 0x04005873 RID: 22643
		Private _commandCollection As SqlCommand()

		' Token: 0x04005874 RID: 22644
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
