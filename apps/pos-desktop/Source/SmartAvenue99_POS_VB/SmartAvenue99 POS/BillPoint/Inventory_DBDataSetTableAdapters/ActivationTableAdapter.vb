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
	' Token: 0x02000441 RID: 1089
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class ActivationTableAdapter
		Inherits Component

		' Token: 0x170057AF RID: 22447
		' (get) Token: 0x0600E314 RID: 58132 RVA: 0x00064FCA File Offset: 0x000631CA
		' (set) Token: 0x0600E315 RID: 58133 RVA: 0x00064FD4 File Offset: 0x000631D4
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E316 RID: 58134 RVA: 0x00064FDD File Offset: 0x000631DD
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057B0 RID: 22448
		' (get) Token: 0x0600E317 RID: 58135 RVA: 0x00863024 File Offset: 0x00861224
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

		' Token: 0x170057B1 RID: 22449
		' (get) Token: 0x0600E318 RID: 58136 RVA: 0x00863054 File Offset: 0x00861254
		' (set) Token: 0x0600E319 RID: 58137 RVA: 0x00863084 File Offset: 0x00861284
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

		' Token: 0x170057B2 RID: 22450
		' (get) Token: 0x0600E31A RID: 58138 RVA: 0x00863148 File Offset: 0x00861348
		' (set) Token: 0x0600E31B RID: 58139 RVA: 0x00863160 File Offset: 0x00861360
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

		' Token: 0x170057B3 RID: 22451
		' (get) Token: 0x0600E31C RID: 58140 RVA: 0x00863248 File Offset: 0x00861448
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

		' Token: 0x170057B4 RID: 22452
		' (get) Token: 0x0600E31D RID: 58141 RVA: 0x00863278 File Offset: 0x00861478
		' (set) Token: 0x0600E31E RID: 58142 RVA: 0x00064FEF File Offset: 0x000631EF
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

		' Token: 0x0600E31F RID: 58143 RVA: 0x00863290 File Offset: 0x00861490
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Activation"
			dataTableMapping.ColumnMappings.Add("ID", "ID")
			dataTableMapping.ColumnMappings.Add("HardwareID", "HardwareID")
			dataTableMapping.ColumnMappings.Add("ActivationID", "ActivationID")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Activation] WHERE (([ID] = @Original_ID) AND ([HardwareID] = @Original_HardwareID) AND ([ActivationID] = @Original_ActivationID))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_HardwareID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "HardwareID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ActivationID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ActivationID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Activation] ([HardwareID], [ActivationID]) VALUES (@HardwareID, @ActivationID);" & vbCrLf & "SELECT ID, HardwareID, ActivationID FROM Activation WHERE (ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@HardwareID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "HardwareID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ActivationID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ActivationID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Activation] SET [HardwareID] = @HardwareID, [ActivationID] = @ActivationID WHERE (([ID] = @Original_ID) AND ([HardwareID] = @Original_HardwareID) AND ([ActivationID] = @Original_ActivationID));" & vbCrLf & "SELECT ID, HardwareID, ActivationID FROM Activation WHERE (ID = @ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@HardwareID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "HardwareID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ActivationID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ActivationID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_HardwareID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "HardwareID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ActivationID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ActivationID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E320 RID: 58144 RVA: 0x00064FF9 File Offset: 0x000631F9
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E321 RID: 58145 RVA: 0x008636D4 File Offset: 0x008618D4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT ID, HardwareID, ActivationID FROM dbo.Activation"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E322 RID: 58146 RVA: 0x00863734 File Offset: 0x00861934
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.ActivationDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E323 RID: 58147 RVA: 0x0086377C File Offset: 0x0086197C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.ActivationDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim activationDataTable As Inventory_DBDataSet.ActivationDataTable = New Inventory_DBDataSet.ActivationDataTable()
			Me.Adapter.Fill(activationDataTable)
			Return activationDataTable
		End Function

		' Token: 0x0600E324 RID: 58148 RVA: 0x008637B8 File Offset: 0x008619B8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.ActivationDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E325 RID: 58149 RVA: 0x008637D8 File Offset: 0x008619D8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Activation")
		End Function

		' Token: 0x0600E326 RID: 58150 RVA: 0x008637FC File Offset: 0x008619FC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E327 RID: 58151 RVA: 0x00863824 File Offset: 0x00861A24
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E328 RID: 58152 RVA: 0x00863844 File Offset: 0x00861A44
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_ID As Integer, Original_HardwareID As String, Original_ActivationID As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_ID
			Dim flag As Boolean = Original_HardwareID = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_HardwareID")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_HardwareID
			Dim flag2 As Boolean = Original_ActivationID = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_ActivationID")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_ActivationID
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

		' Token: 0x0600E329 RID: 58153 RVA: 0x00863978 File Offset: 0x00861B78
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(HardwareID As String, ActivationID As String) As Integer
			Dim flag As Boolean = HardwareID = Nothing
			If flag Then
				Throw New ArgumentNullException("HardwareID")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = HardwareID
			Dim flag2 As Boolean = ActivationID = Nothing
			If flag2 Then
				Throw New ArgumentNullException("ActivationID")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = ActivationID
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

		' Token: 0x0600E32A RID: 58154 RVA: 0x00863A88 File Offset: 0x00861C88
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(HardwareID As String, ActivationID As String, Original_ID As Integer, Original_HardwareID As String, Original_ActivationID As String, ID As Integer) As Integer
			Dim flag As Boolean = HardwareID = Nothing
			If flag Then
				Throw New ArgumentNullException("HardwareID")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = HardwareID
			Dim flag2 As Boolean = ActivationID = Nothing
			If flag2 Then
				Throw New ArgumentNullException("ActivationID")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = ActivationID
			Me.Adapter.UpdateCommand.Parameters(2).Value = Original_ID
			Dim flag3 As Boolean = Original_HardwareID = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_HardwareID")
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_HardwareID
			Dim flag4 As Boolean = Original_ActivationID = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Original_ActivationID")
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_ActivationID
			Me.Adapter.UpdateCommand.Parameters(5).Value = ID
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag5 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag5 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag6 As Boolean = state = ConnectionState.Closed
				If flag6 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E32B RID: 58155 RVA: 0x00863C4C File Offset: 0x00861E4C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(HardwareID As String, ActivationID As String, Original_ID As Integer, Original_HardwareID As String, Original_ActivationID As String) As Integer
			Return Me.Update(HardwareID, ActivationID, Original_ID, Original_HardwareID, Original_ActivationID, Original_ID)
		End Function

		' Token: 0x04005812 RID: 22546
		Private _connection As SqlConnection

		' Token: 0x04005813 RID: 22547
		Private _transaction As SqlTransaction

		' Token: 0x04005814 RID: 22548
		Private _commandCollection As SqlCommand()

		' Token: 0x04005815 RID: 22549
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
