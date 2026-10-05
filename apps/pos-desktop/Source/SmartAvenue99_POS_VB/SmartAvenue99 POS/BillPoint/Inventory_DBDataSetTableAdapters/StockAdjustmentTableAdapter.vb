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
	' Token: 0x0200046A RID: 1130
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class StockAdjustmentTableAdapter
		Inherits Component

		' Token: 0x170058A5 RID: 22693
		' (get) Token: 0x0600E6EC RID: 59116 RVA: 0x00065D15 File Offset: 0x00063F15
		' (set) Token: 0x0600E6ED RID: 59117 RVA: 0x00065D1F File Offset: 0x00063F1F
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E6EE RID: 59118 RVA: 0x00065D28 File Offset: 0x00063F28
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170058A6 RID: 22694
		' (get) Token: 0x0600E6EF RID: 59119 RVA: 0x008BA65C File Offset: 0x008B885C
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

		' Token: 0x170058A7 RID: 22695
		' (get) Token: 0x0600E6F0 RID: 59120 RVA: 0x008BA68C File Offset: 0x008B888C
		' (set) Token: 0x0600E6F1 RID: 59121 RVA: 0x008BA6BC File Offset: 0x008B88BC
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

		' Token: 0x170058A8 RID: 22696
		' (get) Token: 0x0600E6F2 RID: 59122 RVA: 0x008BA780 File Offset: 0x008B8980
		' (set) Token: 0x0600E6F3 RID: 59123 RVA: 0x008BA798 File Offset: 0x008B8998
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

		' Token: 0x170058A9 RID: 22697
		' (get) Token: 0x0600E6F4 RID: 59124 RVA: 0x008BA880 File Offset: 0x008B8A80
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

		' Token: 0x170058AA RID: 22698
		' (get) Token: 0x0600E6F5 RID: 59125 RVA: 0x008BA8B0 File Offset: 0x008B8AB0
		' (set) Token: 0x0600E6F6 RID: 59126 RVA: 0x00065D3A File Offset: 0x00063F3A
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

		' Token: 0x0600E6F7 RID: 59127 RVA: 0x008BA8C8 File Offset: 0x008B8AC8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "StockAdjustment"
			dataTableMapping.ColumnMappings.Add("SA_ID", "SA_ID")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("ProductID", "ProductID")
			dataTableMapping.ColumnMappings.Add("Barcode", "Barcode")
			dataTableMapping.ColumnMappings.Add("Qty", "Qty")
			dataTableMapping.ColumnMappings.Add("Add_Subtract", "Add_Subtract")
			dataTableMapping.ColumnMappings.Add("ReasonForAdjustment", "ReasonForAdjustment")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[StockAdjustment] WHERE (([SA_ID] = @Original_SA_ID) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ([ProductID] = @Original_ProductID) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ((@IsNull_Qty = 1 AND [Qty] IS NULL) OR ([Qty] = @Original_Qty)) AND ((@IsNull_Add_Subtract = 1 AND [Add_Subtract] IS NULL) OR ([Add_Subtract] = @Original_Add_Subtract)) AND ((@IsNull_ReasonForAdjustment = 1 AND [ReasonForAdjustment] IS NULL) OR ([ReasonForAdjustment] = @Original_ReasonForAdjustment)) AND ((@IsNull_Remarks = 1 AND [Remarks] IS NULL) OR ([Remarks] = @Original_Remarks)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SA_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SA_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Qty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Add_Subtract", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Add_Subtract", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Add_Subtract", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Add_Subtract", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ReasonForAdjustment", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReasonForAdjustment", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ReasonForAdjustment", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReasonForAdjustment", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Remarks", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[StockAdjustment] ([SA_ID], [Date], [ProductID], [Barcode], [Qty], [Add_Subtract], [ReasonForAdjustment], [Remarks]) VALUES (@SA_ID, @Date, @ProductID, @Barcode, @Qty, @Add_Subtract, @ReasonForAdjustment, @Remarks);" & vbCrLf & "SELECT SA_ID, Date, ProductID, Barcode, Qty, Add_Subtract, ReasonForAdjustment, Remarks FROM StockAdjustment WHERE (SA_ID = @SA_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SA_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SA_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Add_Subtract", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Add_Subtract", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ReasonForAdjustment", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReasonForAdjustment", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[StockAdjustment] SET [SA_ID] = @SA_ID, [Date] = @Date, [ProductID] = @ProductID, [Barcode] = @Barcode, [Qty] = @Qty, [Add_Subtract] = @Add_Subtract, [ReasonForAdjustment] = @ReasonForAdjustment, [Remarks] = @Remarks WHERE (([SA_ID] = @Original_SA_ID) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ([ProductID] = @Original_ProductID) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ((@IsNull_Qty = 1 AND [Qty] IS NULL) OR ([Qty] = @Original_Qty)) AND ((@IsNull_Add_Subtract = 1 AND [Add_Subtract] IS NULL) OR ([Add_Subtract] = @Original_Add_Subtract)) AND ((@IsNull_ReasonForAdjustment = 1 AND [ReasonForAdjustment] IS NULL) OR ([ReasonForAdjustment] = @Original_ReasonForAdjustment)) AND ((@IsNull_Remarks = 1 AND [Remarks] IS NULL) OR ([Remarks] = @Original_Remarks)));" & vbCrLf & "SELECT SA_ID, Date, ProductID, Barcode, Qty, Add_Subtract, ReasonForAdjustment, Remarks FROM StockAdjustment WHERE (SA_ID = @SA_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SA_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SA_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Add_Subtract", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Add_Subtract", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ReasonForAdjustment", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReasonForAdjustment", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SA_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SA_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Qty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Add_Subtract", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Add_Subtract", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Add_Subtract", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Add_Subtract", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ReasonForAdjustment", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReasonForAdjustment", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ReasonForAdjustment", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReasonForAdjustment", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Remarks", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E6F8 RID: 59128 RVA: 0x00065D44 File Offset: 0x00063F44
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E6F9 RID: 59129 RVA: 0x008BB5C8 File Offset: 0x008B97C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT SA_ID, Date, ProductID, Barcode, Qty, Add_Subtract, ReasonForAdjustment, Remarks FROM dbo.StockAdjustment"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E6FA RID: 59130 RVA: 0x008BB628 File Offset: 0x008B9828
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.StockAdjustmentDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E6FB RID: 59131 RVA: 0x008BB670 File Offset: 0x008B9870
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.StockAdjustmentDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim stockAdjustmentDataTable As Inventory_DBDataSet.StockAdjustmentDataTable = New Inventory_DBDataSet.StockAdjustmentDataTable()
			Me.Adapter.Fill(stockAdjustmentDataTable)
			Return stockAdjustmentDataTable
		End Function

		' Token: 0x0600E6FC RID: 59132 RVA: 0x008BB6AC File Offset: 0x008B98AC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.StockAdjustmentDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E6FD RID: 59133 RVA: 0x008BB6CC File Offset: 0x008B98CC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "StockAdjustment")
		End Function

		' Token: 0x0600E6FE RID: 59134 RVA: 0x008BB6F0 File Offset: 0x008B98F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E6FF RID: 59135 RVA: 0x008BB718 File Offset: 0x008B9918
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E700 RID: 59136 RVA: 0x008BB738 File Offset: 0x008B9938
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_SA_ID As Integer, Original_Date As DateTime?, Original_ProductID As Integer, Original_Barcode As String, Original_Qty As Decimal?, Original_Add_Subtract As String, Original_ReasonForAdjustment As String, Original_Remarks As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_SA_ID
			Dim flag As Boolean = Original_Date IsNot Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Date.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			End If
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_ProductID
			Dim flag2 As Boolean = Original_Barcode = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(4).Value = 1
				Me.Adapter.DeleteCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(4).Value = 0
				Me.Adapter.DeleteCommand.Parameters(5).Value = Original_Barcode
			End If
			Dim flag3 As Boolean = Original_Qty IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(6).Value = 0
				Me.Adapter.DeleteCommand.Parameters(7).Value = Original_Qty.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(6).Value = 1
				Me.Adapter.DeleteCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Original_Add_Subtract = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(8).Value = 1
				Me.Adapter.DeleteCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(8).Value = 0
				Me.Adapter.DeleteCommand.Parameters(9).Value = Original_Add_Subtract
			End If
			Dim flag5 As Boolean = Original_ReasonForAdjustment = Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(10).Value = 1
				Me.Adapter.DeleteCommand.Parameters(11).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(10).Value = 0
				Me.Adapter.DeleteCommand.Parameters(11).Value = Original_ReasonForAdjustment
			End If
			Dim flag6 As Boolean = Original_Remarks = Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(12).Value = 1
				Me.Adapter.DeleteCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(12).Value = 0
				Me.Adapter.DeleteCommand.Parameters(13).Value = Original_Remarks
			End If
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag7 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag7 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag8 As Boolean = state = ConnectionState.Closed
				If flag8 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E701 RID: 59137 RVA: 0x008BBBB8 File Offset: 0x008B9DB8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(SA_ID As Integer, _Date As DateTime?, ProductID As Integer, Barcode As String, Qty As Decimal?, Add_Subtract As String, ReasonForAdjustment As String, Remarks As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = SA_ID
			Dim flag As Boolean = _Date IsNot Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = _Date.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			End If
			Me.Adapter.InsertCommand.Parameters(2).Value = ProductID
			Dim flag2 As Boolean = Barcode = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = Barcode
			End If
			Dim flag3 As Boolean = Qty IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = Qty.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Add_Subtract = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = Add_Subtract
			End If
			Dim flag5 As Boolean = ReasonForAdjustment = Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = ReasonForAdjustment
			End If
			Dim flag6 As Boolean = Remarks = Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = Remarks
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag7 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag7 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag8 As Boolean = state = ConnectionState.Closed
				If flag8 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E702 RID: 59138 RVA: 0x008BBE98 File Offset: 0x008BA098
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(SA_ID As Integer, _Date As DateTime?, ProductID As Integer, Barcode As String, Qty As Decimal?, Add_Subtract As String, ReasonForAdjustment As String, Remarks As String, Original_SA_ID As Integer, Original_Date As DateTime?, Original_ProductID As Integer, Original_Barcode As String, Original_Qty As Decimal?, Original_Add_Subtract As String, Original_ReasonForAdjustment As String, Original_Remarks As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = SA_ID
			Dim flag As Boolean = _Date IsNot Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = _Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(2).Value = ProductID
			Dim flag2 As Boolean = Barcode = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = Barcode
			End If
			Dim flag3 As Boolean = Qty IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = Qty.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Add_Subtract = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = Add_Subtract
			End If
			Dim flag5 As Boolean = ReasonForAdjustment = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = ReasonForAdjustment
			End If
			Dim flag6 As Boolean = Remarks = Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = Remarks
			End If
			Me.Adapter.UpdateCommand.Parameters(8).Value = Original_SA_ID
			Dim flag7 As Boolean = Original_Date IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = 0
				Me.Adapter.UpdateCommand.Parameters(10).Value = Original_Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = 1
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(11).Value = Original_ProductID
			Dim flag8 As Boolean = Original_Barcode = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = 1
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = 0
				Me.Adapter.UpdateCommand.Parameters(13).Value = Original_Barcode
			End If
			Dim flag9 As Boolean = Original_Qty IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = 0
				Me.Adapter.UpdateCommand.Parameters(15).Value = Original_Qty.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = 1
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_Add_Subtract = Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = 1
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = 0
				Me.Adapter.UpdateCommand.Parameters(17).Value = Original_Add_Subtract
			End If
			Dim flag11 As Boolean = Original_ReasonForAdjustment = Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(18).Value = 1
				Me.Adapter.UpdateCommand.Parameters(19).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(18).Value = 0
				Me.Adapter.UpdateCommand.Parameters(19).Value = Original_ReasonForAdjustment
			End If
			Dim flag12 As Boolean = Original_Remarks = Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(20).Value = 1
				Me.Adapter.UpdateCommand.Parameters(21).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(20).Value = 0
				Me.Adapter.UpdateCommand.Parameters(21).Value = Original_Remarks
			End If
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag13 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag13 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag14 As Boolean = state = ConnectionState.Closed
				If flag14 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E703 RID: 59139 RVA: 0x008BC560 File Offset: 0x008BA760
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(_Date As DateTime?, ProductID As Integer, Barcode As String, Qty As Decimal?, Add_Subtract As String, ReasonForAdjustment As String, Remarks As String, Original_SA_ID As Integer, Original_Date As DateTime?, Original_ProductID As Integer, Original_Barcode As String, Original_Qty As Decimal?, Original_Add_Subtract As String, Original_ReasonForAdjustment As String, Original_Remarks As String) As Integer
			Return Me.Update(Original_SA_ID, _Date, ProductID, Barcode, Qty, Add_Subtract, ReasonForAdjustment, Remarks, Original_SA_ID, Original_Date, Original_ProductID, Original_Barcode, Original_Qty, Original_Add_Subtract, Original_ReasonForAdjustment, Original_Remarks)
		End Function

		' Token: 0x040058DF RID: 22751
		Private _connection As SqlConnection

		' Token: 0x040058E0 RID: 22752
		Private _transaction As SqlTransaction

		' Token: 0x040058E1 RID: 22753
		Private _commandCollection As SqlCommand()

		' Token: 0x040058E2 RID: 22754
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
