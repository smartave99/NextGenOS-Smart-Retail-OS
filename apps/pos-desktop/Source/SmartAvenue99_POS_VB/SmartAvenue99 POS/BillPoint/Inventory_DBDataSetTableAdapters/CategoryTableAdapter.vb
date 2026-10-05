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
	' Token: 0x02000446 RID: 1094
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class CategoryTableAdapter
		Inherits Component

		' Token: 0x170057CD RID: 22477
		' (get) Token: 0x0600E38C RID: 58252 RVA: 0x00065169 File Offset: 0x00063369
		' (set) Token: 0x0600E38D RID: 58253 RVA: 0x00065173 File Offset: 0x00063373
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E38E RID: 58254 RVA: 0x0006517C File Offset: 0x0006337C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057CE RID: 22478
		' (get) Token: 0x0600E38F RID: 58255 RVA: 0x0086A02C File Offset: 0x0086822C
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

		' Token: 0x170057CF RID: 22479
		' (get) Token: 0x0600E390 RID: 58256 RVA: 0x0086A05C File Offset: 0x0086825C
		' (set) Token: 0x0600E391 RID: 58257 RVA: 0x0086A08C File Offset: 0x0086828C
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

		' Token: 0x170057D0 RID: 22480
		' (get) Token: 0x0600E392 RID: 58258 RVA: 0x0086A150 File Offset: 0x00868350
		' (set) Token: 0x0600E393 RID: 58259 RVA: 0x0086A168 File Offset: 0x00868368
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

		' Token: 0x170057D1 RID: 22481
		' (get) Token: 0x0600E394 RID: 58260 RVA: 0x0086A250 File Offset: 0x00868450
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

		' Token: 0x170057D2 RID: 22482
		' (get) Token: 0x0600E395 RID: 58261 RVA: 0x0086A280 File Offset: 0x00868480
		' (set) Token: 0x0600E396 RID: 58262 RVA: 0x0006518E File Offset: 0x0006338E
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

		' Token: 0x0600E397 RID: 58263 RVA: 0x0086A298 File Offset: 0x00868498
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Category"
			dataTableMapping.ColumnMappings.Add("CategoryName", "CategoryName")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Category] WHERE (([CategoryName] = @Original_CategoryName))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CategoryName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CategoryName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Category] ([CategoryName]) VALUES (@CategoryName);" & vbCrLf & "SELECT CategoryName FROM Category WHERE (CategoryName = @CategoryName)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CategoryName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CategoryName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Category] SET [CategoryName] = @CategoryName WHERE (([CategoryName] = @Original_CategoryName));" & vbCrLf & "SELECT CategoryName FROM Category WHERE (CategoryName = @CategoryName)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CategoryName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CategoryName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CategoryName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CategoryName", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E398 RID: 58264 RVA: 0x00065198 File Offset: 0x00063398
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E399 RID: 58265 RVA: 0x0086A4EC File Offset: 0x008686EC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT CategoryName FROM dbo.Category"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E39A RID: 58266 RVA: 0x0086A54C File Offset: 0x0086874C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.CategoryDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E39B RID: 58267 RVA: 0x0086A594 File Offset: 0x00868794
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.CategoryDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim categoryDataTable As Inventory_DBDataSet.CategoryDataTable = New Inventory_DBDataSet.CategoryDataTable()
			Me.Adapter.Fill(categoryDataTable)
			Return categoryDataTable
		End Function

		' Token: 0x0600E39C RID: 58268 RVA: 0x0086A5D0 File Offset: 0x008687D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.CategoryDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E39D RID: 58269 RVA: 0x0086A5F0 File Offset: 0x008687F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Category")
		End Function

		' Token: 0x0600E39E RID: 58270 RVA: 0x0086A614 File Offset: 0x00868814
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E39F RID: 58271 RVA: 0x0086A63C File Offset: 0x0086883C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E3A0 RID: 58272 RVA: 0x0086A65C File Offset: 0x0086885C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_CategoryName As String) As Integer
			Dim flag As Boolean = Original_CategoryName = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_CategoryName")
			End If
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_CategoryName
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

		' Token: 0x0600E3A1 RID: 58273 RVA: 0x0086A738 File Offset: 0x00868938
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(CategoryName As String) As Integer
			Dim flag As Boolean = CategoryName = Nothing
			If flag Then
				Throw New ArgumentNullException("CategoryName")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = CategoryName
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

		' Token: 0x0600E3A2 RID: 58274 RVA: 0x0086A814 File Offset: 0x00868A14
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(CategoryName As String, Original_CategoryName As String) As Integer
			Dim flag As Boolean = CategoryName = Nothing
			If flag Then
				Throw New ArgumentNullException("CategoryName")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = CategoryName
			Dim flag2 As Boolean = Original_CategoryName = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_CategoryName")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = Original_CategoryName
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag3 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag3 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag4 As Boolean = state = ConnectionState.Closed
				If flag4 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E3A3 RID: 58275 RVA: 0x0086A924 File Offset: 0x00868B24
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Original_CategoryName As String) As Integer
			Return Me.Update(Original_CategoryName, Original_CategoryName)
		End Function

		' Token: 0x0400582B RID: 22571
		Private _connection As SqlConnection

		' Token: 0x0400582C RID: 22572
		Private _transaction As SqlTransaction

		' Token: 0x0400582D RID: 22573
		Private _commandCollection As SqlCommand()

		' Token: 0x0400582E RID: 22574
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
