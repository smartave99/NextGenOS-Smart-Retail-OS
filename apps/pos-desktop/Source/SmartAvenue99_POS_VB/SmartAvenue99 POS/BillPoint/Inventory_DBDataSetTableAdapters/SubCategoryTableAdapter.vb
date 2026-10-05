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
	' Token: 0x0200046B RID: 1131
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class SubCategoryTableAdapter
		Inherits Component

		' Token: 0x170058AB RID: 22699
		' (get) Token: 0x0600E704 RID: 59140 RVA: 0x00065D68 File Offset: 0x00063F68
		' (set) Token: 0x0600E705 RID: 59141 RVA: 0x00065D72 File Offset: 0x00063F72
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E706 RID: 59142 RVA: 0x00065D7B File Offset: 0x00063F7B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170058AC RID: 22700
		' (get) Token: 0x0600E707 RID: 59143 RVA: 0x008BC598 File Offset: 0x008BA798
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

		' Token: 0x170058AD RID: 22701
		' (get) Token: 0x0600E708 RID: 59144 RVA: 0x008BC5C8 File Offset: 0x008BA7C8
		' (set) Token: 0x0600E709 RID: 59145 RVA: 0x008BC5F8 File Offset: 0x008BA7F8
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

		' Token: 0x170058AE RID: 22702
		' (get) Token: 0x0600E70A RID: 59146 RVA: 0x008BC6BC File Offset: 0x008BA8BC
		' (set) Token: 0x0600E70B RID: 59147 RVA: 0x008BC6D4 File Offset: 0x008BA8D4
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

		' Token: 0x170058AF RID: 22703
		' (get) Token: 0x0600E70C RID: 59148 RVA: 0x008BC7BC File Offset: 0x008BA9BC
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

		' Token: 0x170058B0 RID: 22704
		' (get) Token: 0x0600E70D RID: 59149 RVA: 0x008BC7EC File Offset: 0x008BA9EC
		' (set) Token: 0x0600E70E RID: 59150 RVA: 0x00065D8D File Offset: 0x00063F8D
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

		' Token: 0x0600E70F RID: 59151 RVA: 0x008BC804 File Offset: 0x008BAA04
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "SubCategory"
			dataTableMapping.ColumnMappings.Add("ID", "ID")
			dataTableMapping.ColumnMappings.Add("SubCategoryName", "SubCategoryName")
			dataTableMapping.ColumnMappings.Add("Category", "Category")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[SubCategory] WHERE (([ID] = @Original_ID) AND ([SubCategoryName] = @Original_SubCategoryName) AND ([Category] = @Original_Category))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SubCategoryName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SubCategoryName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Category", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[SubCategory] ([ID], [SubCategoryName], [Category]) VALUES (@ID, @SubCategoryName, @Category);" & vbCrLf & "SELECT ID, SubCategoryName, Category FROM SubCategory WHERE (ID = @ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SubCategoryName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SubCategoryName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Category", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[SubCategory] SET [ID] = @ID, [SubCategoryName] = @SubCategoryName, [Category] = @Category WHERE (([ID] = @Original_ID) AND ([SubCategoryName] = @Original_SubCategoryName) AND ([Category] = @Original_Category));" & vbCrLf & "SELECT ID, SubCategoryName, Category FROM SubCategory WHERE (ID = @ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SubCategoryName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SubCategoryName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Category", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SubCategoryName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SubCategoryName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Category", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Category", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E710 RID: 59152 RVA: 0x00065D97 File Offset: 0x00063F97
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E711 RID: 59153 RVA: 0x008BCC88 File Offset: 0x008BAE88
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT ID, SubCategoryName, Category FROM dbo.SubCategory"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E712 RID: 59154 RVA: 0x008BCCE8 File Offset: 0x008BAEE8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.SubCategoryDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E713 RID: 59155 RVA: 0x008BCD30 File Offset: 0x008BAF30
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.SubCategoryDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim subCategoryDataTable As Inventory_DBDataSet.SubCategoryDataTable = New Inventory_DBDataSet.SubCategoryDataTable()
			Me.Adapter.Fill(subCategoryDataTable)
			Return subCategoryDataTable
		End Function

		' Token: 0x0600E714 RID: 59156 RVA: 0x008BCD6C File Offset: 0x008BAF6C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.SubCategoryDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E715 RID: 59157 RVA: 0x008BCD8C File Offset: 0x008BAF8C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "SubCategory")
		End Function

		' Token: 0x0600E716 RID: 59158 RVA: 0x008BCDB0 File Offset: 0x008BAFB0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E717 RID: 59159 RVA: 0x008BCDD8 File Offset: 0x008BAFD8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E718 RID: 59160 RVA: 0x008BCDF8 File Offset: 0x008BAFF8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_ID As Integer, Original_SubCategoryName As String, Original_Category As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_ID
			Dim flag As Boolean = Original_SubCategoryName = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_SubCategoryName")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_SubCategoryName
			Dim flag2 As Boolean = Original_Category = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_Category")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Category
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

		' Token: 0x0600E719 RID: 59161 RVA: 0x008BCF2C File Offset: 0x008BB12C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(ID As Integer, SubCategoryName As String, Category As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = ID
			Dim flag As Boolean = SubCategoryName = Nothing
			If flag Then
				Throw New ArgumentNullException("SubCategoryName")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = SubCategoryName
			Dim flag2 As Boolean = Category = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Category")
			End If
			Me.Adapter.InsertCommand.Parameters(2).Value = Category
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

		' Token: 0x0600E71A RID: 59162 RVA: 0x008BD060 File Offset: 0x008BB260
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ID As Integer, SubCategoryName As String, Category As String, Original_ID As Integer, Original_SubCategoryName As String, Original_Category As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = ID
			Dim flag As Boolean = SubCategoryName = Nothing
			If flag Then
				Throw New ArgumentNullException("SubCategoryName")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = SubCategoryName
			Dim flag2 As Boolean = Category = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Category")
			End If
			Me.Adapter.UpdateCommand.Parameters(2).Value = Category
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_ID
			Dim flag3 As Boolean = Original_SubCategoryName = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_SubCategoryName")
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_SubCategoryName
			Dim flag4 As Boolean = Original_Category = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Original_Category")
			End If
			Me.Adapter.UpdateCommand.Parameters(5).Value = Original_Category
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

		' Token: 0x0600E71B RID: 59163 RVA: 0x008BD224 File Offset: 0x008BB424
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(SubCategoryName As String, Category As String, Original_ID As Integer, Original_SubCategoryName As String, Original_Category As String) As Integer
			Return Me.Update(Original_ID, SubCategoryName, Category, Original_ID, Original_SubCategoryName, Original_Category)
		End Function

		' Token: 0x040058E4 RID: 22756
		Private _connection As SqlConnection

		' Token: 0x040058E5 RID: 22757
		Private _transaction As SqlTransaction

		' Token: 0x040058E6 RID: 22758
		Private _commandCollection As SqlCommand()

		' Token: 0x040058E7 RID: 22759
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
