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
	' Token: 0x02000458 RID: 1112
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Product_JoinTableAdapter
		Inherits Component

		' Token: 0x17005839 RID: 22585
		' (get) Token: 0x0600E53C RID: 58684 RVA: 0x0006573F File Offset: 0x0006393F
		' (set) Token: 0x0600E53D RID: 58685 RVA: 0x00065749 File Offset: 0x00063949
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E53E RID: 58686 RVA: 0x00065752 File Offset: 0x00063952
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x1700583A RID: 22586
		' (get) Token: 0x0600E53F RID: 58687 RVA: 0x0088C3F4 File Offset: 0x0088A5F4
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

		' Token: 0x1700583B RID: 22587
		' (get) Token: 0x0600E540 RID: 58688 RVA: 0x0088C424 File Offset: 0x0088A624
		' (set) Token: 0x0600E541 RID: 58689 RVA: 0x0088C454 File Offset: 0x0088A654
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

		' Token: 0x1700583C RID: 22588
		' (get) Token: 0x0600E542 RID: 58690 RVA: 0x0088C518 File Offset: 0x0088A718
		' (set) Token: 0x0600E543 RID: 58691 RVA: 0x0088C530 File Offset: 0x0088A730
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

		' Token: 0x1700583D RID: 22589
		' (get) Token: 0x0600E544 RID: 58692 RVA: 0x0088C618 File Offset: 0x0088A818
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

		' Token: 0x1700583E RID: 22590
		' (get) Token: 0x0600E545 RID: 58693 RVA: 0x0088C648 File Offset: 0x0088A848
		' (set) Token: 0x0600E546 RID: 58694 RVA: 0x00065764 File Offset: 0x00063964
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

		' Token: 0x0600E547 RID: 58695 RVA: 0x0088C660 File Offset: 0x0088A860
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Product_Join"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("ProductID", "ProductID")
			dataTableMapping.ColumnMappings.Add("Photo", "Photo")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Product_Join] WHERE (([Id] = @Original_Id) AND ([ProductID] = @Original_ProductID))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Product_Join] ([ProductID], [Photo]) VALUES (@ProductID, @Photo);" & vbCrLf & "SELECT Id, ProductID, Photo FROM Product_Join WHERE (Id = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Photo", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Photo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Product_Join] SET [ProductID] = @ProductID, [Photo] = @Photo WHERE (([Id] = @Original_Id) AND ([ProductID] = @Original_ProductID));" & vbCrLf & "SELECT Id, ProductID, Photo FROM Product_Join WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Photo", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Photo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E548 RID: 58696 RVA: 0x0006576E File Offset: 0x0006396E
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E549 RID: 58697 RVA: 0x0088CA1C File Offset: 0x0088AC1C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, ProductID, Photo FROM dbo.Product_Join"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E54A RID: 58698 RVA: 0x0088CA7C File Offset: 0x0088AC7C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Product_JoinDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E54B RID: 58699 RVA: 0x0088CAC4 File Offset: 0x0088ACC4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Product_JoinDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim product_JoinDataTable As Inventory_DBDataSet.Product_JoinDataTable = New Inventory_DBDataSet.Product_JoinDataTable()
			Me.Adapter.Fill(product_JoinDataTable)
			Return product_JoinDataTable
		End Function

		' Token: 0x0600E54C RID: 58700 RVA: 0x0088CB00 File Offset: 0x0088AD00
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Product_JoinDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E54D RID: 58701 RVA: 0x0088CB20 File Offset: 0x0088AD20
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Product_Join")
		End Function

		' Token: 0x0600E54E RID: 58702 RVA: 0x0088CB44 File Offset: 0x0088AD44
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E54F RID: 58703 RVA: 0x0088CB6C File Offset: 0x0088AD6C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E550 RID: 58704 RVA: 0x0088CB8C File Offset: 0x0088AD8C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_ProductID As Integer) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_ProductID
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

		' Token: 0x0600E551 RID: 58705 RVA: 0x0088CC78 File Offset: 0x0088AE78
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(ProductID As Integer, Photo As Byte()) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = ProductID
			Dim flag As Boolean = Photo Is Nothing
			If flag Then
				Throw New ArgumentNullException("Photo")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = Photo
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

		' Token: 0x0600E552 RID: 58706 RVA: 0x0088CD78 File Offset: 0x0088AF78
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ProductID As Integer, Photo As Byte(), Original_Id As Integer, Original_ProductID As Integer, Id As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = ProductID
			Dim flag As Boolean = Photo Is Nothing
			If flag Then
				Throw New ArgumentNullException("Photo")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = Photo
			Me.Adapter.UpdateCommand.Parameters(2).Value = Original_Id
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_ProductID
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

		' Token: 0x0600E553 RID: 58707 RVA: 0x0088CEE0 File Offset: 0x0088B0E0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ProductID As Integer, Photo As Byte(), Original_Id As Integer, Original_ProductID As Integer) As Integer
			Return Me.Update(ProductID, Photo, Original_Id, Original_ProductID, Original_Id)
		End Function

		' Token: 0x04005885 RID: 22661
		Private _connection As SqlConnection

		' Token: 0x04005886 RID: 22662
		Private _transaction As SqlTransaction

		' Token: 0x04005887 RID: 22663
		Private _commandCollection As SqlCommand()

		' Token: 0x04005888 RID: 22664
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
