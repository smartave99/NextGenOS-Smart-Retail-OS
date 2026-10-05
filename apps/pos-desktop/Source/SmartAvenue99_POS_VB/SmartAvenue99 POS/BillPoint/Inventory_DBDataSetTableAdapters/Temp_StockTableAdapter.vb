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
	' Token: 0x0200046E RID: 1134
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Temp_StockTableAdapter
		Inherits Component

		' Token: 0x170058BD RID: 22717
		' (get) Token: 0x0600E74C RID: 59212 RVA: 0x00065E61 File Offset: 0x00064061
		' (set) Token: 0x0600E74D RID: 59213 RVA: 0x00065E6B File Offset: 0x0006406B
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E74E RID: 59214 RVA: 0x00065E74 File Offset: 0x00064074
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170058BE RID: 22718
		' (get) Token: 0x0600E74F RID: 59215 RVA: 0x008C2F38 File Offset: 0x008C1138
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

		' Token: 0x170058BF RID: 22719
		' (get) Token: 0x0600E750 RID: 59216 RVA: 0x008C2F68 File Offset: 0x008C1168
		' (set) Token: 0x0600E751 RID: 59217 RVA: 0x008C2F98 File Offset: 0x008C1198
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

		' Token: 0x170058C0 RID: 22720
		' (get) Token: 0x0600E752 RID: 59218 RVA: 0x008C305C File Offset: 0x008C125C
		' (set) Token: 0x0600E753 RID: 59219 RVA: 0x008C3074 File Offset: 0x008C1274
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

		' Token: 0x170058C1 RID: 22721
		' (get) Token: 0x0600E754 RID: 59220 RVA: 0x008C315C File Offset: 0x008C135C
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

		' Token: 0x170058C2 RID: 22722
		' (get) Token: 0x0600E755 RID: 59221 RVA: 0x008C318C File Offset: 0x008C138C
		' (set) Token: 0x0600E756 RID: 59222 RVA: 0x00065E86 File Offset: 0x00064086
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

		' Token: 0x0600E757 RID: 59223 RVA: 0x008C31A4 File Offset: 0x008C13A4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Temp_Stock"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("ProductID", "ProductID")
			dataTableMapping.ColumnMappings.Add("Qty", "Qty")
			dataTableMapping.ColumnMappings.Add("Barcode", "Barcode")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Temp_Stock] WHERE (([Id] = @Original_Id) AND ([ProductID] = @Original_ProductID) AND ([Qty] = @Original_Qty) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Temp_Stock] ([ProductID], [Qty], [Barcode]) VALUES (@ProductID, @Qty, @Barcode);" & vbCrLf & "SELECT Id, ProductID, Qty, Barcode FROM Temp_Stock WHERE (Id = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Temp_Stock] SET [ProductID] = @ProductID, [Qty] = @Qty, [Barcode] = @Barcode WHERE (([Id] = @Original_Id) AND ([ProductID] = @Original_ProductID) AND ([Qty] = @Original_Qty) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)));" & vbCrLf & "SELECT Id, ProductID, Qty, Barcode FROM Temp_Stock WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E758 RID: 59224 RVA: 0x00065E90 File Offset: 0x00064090
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E759 RID: 59225 RVA: 0x008C3780 File Offset: 0x008C1980
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, ProductID, Qty, Barcode FROM dbo.Temp_Stock"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E75A RID: 59226 RVA: 0x008C37E0 File Offset: 0x008C19E0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Temp_StockDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E75B RID: 59227 RVA: 0x008C3828 File Offset: 0x008C1A28
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Temp_StockDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim temp_StockDataTable As Inventory_DBDataSet.Temp_StockDataTable = New Inventory_DBDataSet.Temp_StockDataTable()
			Me.Adapter.Fill(temp_StockDataTable)
			Return temp_StockDataTable
		End Function

		' Token: 0x0600E75C RID: 59228 RVA: 0x008C3864 File Offset: 0x008C1A64
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Temp_StockDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E75D RID: 59229 RVA: 0x008C3884 File Offset: 0x008C1A84
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Temp_Stock")
		End Function

		' Token: 0x0600E75E RID: 59230 RVA: 0x008C38A8 File Offset: 0x008C1AA8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E75F RID: 59231 RVA: 0x008C38D0 File Offset: 0x008C1AD0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E760 RID: 59232 RVA: 0x008C38F0 File Offset: 0x008C1AF0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_ProductID As Integer, Original_Qty As Decimal, Original_Barcode As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_ProductID
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Qty
			Dim flag As Boolean = Original_Barcode = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Barcode
			End If
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

		' Token: 0x0600E761 RID: 59233 RVA: 0x008C3A94 File Offset: 0x008C1C94
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(ProductID As Integer, Qty As Decimal, Barcode As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = ProductID
			Me.Adapter.InsertCommand.Parameters(1).Value = Qty
			Dim flag As Boolean = Barcode = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = Barcode
			End If
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

		' Token: 0x0600E762 RID: 59234 RVA: 0x008C3BD0 File Offset: 0x008C1DD0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ProductID As Integer, Qty As Decimal, Barcode As String, Original_Id As Integer, Original_ProductID As Integer, Original_Qty As Decimal, Original_Barcode As String, Id As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = ProductID
			Me.Adapter.UpdateCommand.Parameters(1).Value = Qty
			Dim flag As Boolean = Barcode = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_Id
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_ProductID
			Me.Adapter.UpdateCommand.Parameters(5).Value = Original_Qty
			Dim flag2 As Boolean = Original_Barcode = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = 1
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = 0
				Me.Adapter.UpdateCommand.Parameters(7).Value = Original_Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(8).Value = Id
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

		' Token: 0x0600E763 RID: 59235 RVA: 0x008C3E28 File Offset: 0x008C2028
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ProductID As Integer, Qty As Decimal, Barcode As String, Original_Id As Integer, Original_ProductID As Integer, Original_Qty As Decimal, Original_Barcode As String) As Integer
			Return Me.Update(ProductID, Qty, Barcode, Original_Id, Original_ProductID, Original_Qty, Original_Barcode, Original_Id)
		End Function

		' Token: 0x040058F3 RID: 22771
		Private _connection As SqlConnection

		' Token: 0x040058F4 RID: 22772
		Private _transaction As SqlTransaction

		' Token: 0x040058F5 RID: 22773
		Private _commandCollection As SqlCommand()

		' Token: 0x040058F6 RID: 22774
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
