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
	' Token: 0x02000466 RID: 1126
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class SMSTableAdapter
		Inherits Component

		' Token: 0x1700588D RID: 22669
		' (get) Token: 0x0600E68C RID: 59020 RVA: 0x00065BC9 File Offset: 0x00063DC9
		' (set) Token: 0x0600E68D RID: 59021 RVA: 0x00065BD3 File Offset: 0x00063DD3
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E68E RID: 59022 RVA: 0x00065BDC File Offset: 0x00063DDC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x1700588E RID: 22670
		' (get) Token: 0x0600E68F RID: 59023 RVA: 0x008B0548 File Offset: 0x008AE748
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

		' Token: 0x1700588F RID: 22671
		' (get) Token: 0x0600E690 RID: 59024 RVA: 0x008B0578 File Offset: 0x008AE778
		' (set) Token: 0x0600E691 RID: 59025 RVA: 0x008B05A8 File Offset: 0x008AE7A8
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

		' Token: 0x17005890 RID: 22672
		' (get) Token: 0x0600E692 RID: 59026 RVA: 0x008B066C File Offset: 0x008AE86C
		' (set) Token: 0x0600E693 RID: 59027 RVA: 0x008B0684 File Offset: 0x008AE884
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

		' Token: 0x17005891 RID: 22673
		' (get) Token: 0x0600E694 RID: 59028 RVA: 0x008B076C File Offset: 0x008AE96C
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

		' Token: 0x17005892 RID: 22674
		' (get) Token: 0x0600E695 RID: 59029 RVA: 0x008B079C File Offset: 0x008AE99C
		' (set) Token: 0x0600E696 RID: 59030 RVA: 0x00065BEE File Offset: 0x00063DEE
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

		' Token: 0x0600E697 RID: 59031 RVA: 0x008B07B4 File Offset: 0x008AE9B4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "SMS"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("Message", "Message")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[SMS] WHERE (([Id] = @Original_Id) AND ([Date] = @Original_Date))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[SMS] ([Message], [Date]) VALUES (@Message, @Date);" & vbCrLf & "SELECT Id, Message, Date FROM SMS WHERE (Id = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Message", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Message", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[SMS] SET [Message] = @Message, [Date] = @Date WHERE (([Id] = @Original_Id) AND ([Date] = @Original_Date));" & vbCrLf & "SELECT Id, Message, Date FROM SMS WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Message", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Message", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E698 RID: 59032 RVA: 0x00065BF8 File Offset: 0x00063DF8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E699 RID: 59033 RVA: 0x008B0B74 File Offset: 0x008AED74
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, Message, Date FROM dbo.SMS"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E69A RID: 59034 RVA: 0x008B0BD4 File Offset: 0x008AEDD4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.SMSDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E69B RID: 59035 RVA: 0x008B0C1C File Offset: 0x008AEE1C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.SMSDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim smsdataTable As Inventory_DBDataSet.SMSDataTable = New Inventory_DBDataSet.SMSDataTable()
			Me.Adapter.Fill(smsdataTable)
			Return smsdataTable
		End Function

		' Token: 0x0600E69C RID: 59036 RVA: 0x008B0C58 File Offset: 0x008AEE58
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.SMSDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E69D RID: 59037 RVA: 0x008B0C78 File Offset: 0x008AEE78
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "SMS")
		End Function

		' Token: 0x0600E69E RID: 59038 RVA: 0x008B0C9C File Offset: 0x008AEE9C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E69F RID: 59039 RVA: 0x008B0CC4 File Offset: 0x008AEEC4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E6A0 RID: 59040 RVA: 0x008B0CE4 File Offset: 0x008AEEE4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_Date As DateTime) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_Date
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag2 As Boolean = state = ConnectionState.Closed
				If flag2 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6A1 RID: 59041 RVA: 0x008B0DD0 File Offset: 0x008AEFD0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(Message As String, _Date As DateTime) As Integer
			Dim flag As Boolean = Message = Nothing
			If flag Then
				Throw New ArgumentNullException("Message")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = Message
			Me.Adapter.InsertCommand.Parameters(1).Value = _Date
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag2 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag2 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag3 As Boolean = state = ConnectionState.Closed
				If flag3 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6A2 RID: 59042 RVA: 0x008B0ED0 File Offset: 0x008AF0D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Message As String, _Date As DateTime, Original_Id As Integer, Original_Date As DateTime, Id As Integer) As Integer
			Dim flag As Boolean = Message = Nothing
			If flag Then
				Throw New ArgumentNullException("Message")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = Message
			Me.Adapter.UpdateCommand.Parameters(1).Value = _Date
			Me.Adapter.UpdateCommand.Parameters(2).Value = Original_Id
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_Date
			Me.Adapter.UpdateCommand.Parameters(4).Value = Id
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag2 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag2 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag3 As Boolean = state = ConnectionState.Closed
				If flag3 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6A3 RID: 59043 RVA: 0x008B1038 File Offset: 0x008AF238
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Message As String, _Date As DateTime, Original_Id As Integer, Original_Date As DateTime) As Integer
			Return Me.Update(Message, _Date, Original_Id, Original_Date, Original_Id)
		End Function

		' Token: 0x040058CB RID: 22731
		Private _connection As SqlConnection

		' Token: 0x040058CC RID: 22732
		Private _transaction As SqlTransaction

		' Token: 0x040058CD RID: 22733
		Private _commandCollection As SqlCommand()

		' Token: 0x040058CE RID: 22734
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
