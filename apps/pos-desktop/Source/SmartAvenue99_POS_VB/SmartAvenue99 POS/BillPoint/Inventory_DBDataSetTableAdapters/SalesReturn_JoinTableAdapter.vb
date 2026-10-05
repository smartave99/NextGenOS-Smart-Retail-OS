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
	' Token: 0x02000463 RID: 1123
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class SalesReturn_JoinTableAdapter
		Inherits Component

		' Token: 0x1700587B RID: 22651
		' (get) Token: 0x0600E644 RID: 58948 RVA: 0x00065AD0 File Offset: 0x00063CD0
		' (set) Token: 0x0600E645 RID: 58949 RVA: 0x00065ADA File Offset: 0x00063CDA
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E646 RID: 58950 RVA: 0x00065AE3 File Offset: 0x00063CE3
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x1700587C RID: 22652
		' (get) Token: 0x0600E647 RID: 58951 RVA: 0x008A9440 File Offset: 0x008A7640
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

		' Token: 0x1700587D RID: 22653
		' (get) Token: 0x0600E648 RID: 58952 RVA: 0x008A9470 File Offset: 0x008A7670
		' (set) Token: 0x0600E649 RID: 58953 RVA: 0x008A94A0 File Offset: 0x008A76A0
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

		' Token: 0x1700587E RID: 22654
		' (get) Token: 0x0600E64A RID: 58954 RVA: 0x008A9564 File Offset: 0x008A7764
		' (set) Token: 0x0600E64B RID: 58955 RVA: 0x008A957C File Offset: 0x008A777C
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

		' Token: 0x1700587F RID: 22655
		' (get) Token: 0x0600E64C RID: 58956 RVA: 0x008A9664 File Offset: 0x008A7864
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

		' Token: 0x17005880 RID: 22656
		' (get) Token: 0x0600E64D RID: 58957 RVA: 0x008A9694 File Offset: 0x008A7894
		' (set) Token: 0x0600E64E RID: 58958 RVA: 0x00065AF5 File Offset: 0x00063CF5
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

		' Token: 0x0600E64F RID: 58959 RVA: 0x008A96AC File Offset: 0x008A78AC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "SalesReturn_Join"
			dataTableMapping.ColumnMappings.Add("SRJ_ID", "SRJ_ID")
			dataTableMapping.ColumnMappings.Add("SalesReturnID", "SalesReturnID")
			dataTableMapping.ColumnMappings.Add("ProductID", "ProductID")
			dataTableMapping.ColumnMappings.Add("Barcode", "Barcode")
			dataTableMapping.ColumnMappings.Add("Qty", "Qty")
			dataTableMapping.ColumnMappings.Add("SalesRate", "SalesRate")
			dataTableMapping.ColumnMappings.Add("DiscPer", "DiscPer")
			dataTableMapping.ColumnMappings.Add("DiscAmt", "DiscAmt")
			dataTableMapping.ColumnMappings.Add("CGSTPer", "CGSTPer")
			dataTableMapping.ColumnMappings.Add("CGSTAmt", "CGSTAmt")
			dataTableMapping.ColumnMappings.Add("SGSTPer", "SGSTPer")
			dataTableMapping.ColumnMappings.Add("SGSTAmt", "SGSTAmt")
			dataTableMapping.ColumnMappings.Add("IGSTPer", "IGSTPer")
			dataTableMapping.ColumnMappings.Add("IGSTAmt", "IGSTAmt")
			dataTableMapping.ColumnMappings.Add("CESSPer", "CESSPer")
			dataTableMapping.ColumnMappings.Add("CESSAmt", "CESSAmt")
			dataTableMapping.ColumnMappings.Add("ReturnQty", "ReturnQty")
			dataTableMapping.ColumnMappings.Add("TotalAmount", "TotalAmount")
			dataTableMapping.ColumnMappings.Add("PurchaseRate", "PurchaseRate")
			dataTableMapping.ColumnMappings.Add("Margin", "Margin")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[SalesReturn_Join] WHERE (([SRJ_ID] = @Original_SRJ_ID) AND ([SalesReturnID] = @Original_SalesReturnID) AND ((@IsNull_ProductID = 1 AND [ProductID] IS NULL) OR ([ProductID] = @Original_ProductID)) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ((@IsNull_Qty = 1 AND [Qty] IS NULL) OR ([Qty] = @Original_Qty)) AND ((@IsNull_SalesRate = 1 AND [SalesRate] IS NULL) OR ([SalesRate] = @Original_SalesRate)) AND ((@IsNull_DiscPer = 1 AND [DiscPer] IS NULL) OR ([DiscPer] = @Original_DiscPer)) AND ((@IsNull_DiscAmt = 1 AND [DiscAmt] IS NULL) OR ([DiscAmt] = @Original_DiscAmt)) AND ((@IsNull_CGSTPer = 1 AND [CGSTPer] IS NULL) OR ([CGSTPer] = @Original_CGSTPer)) AND ((@IsNull_CGSTAmt = 1 AND [CGSTAmt] IS NULL) OR ([CGSTAmt] = @Original_CGSTAmt)) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ([SGSTAmt] = @Original_SGSTAmt) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ((@IsNull_ReturnQty = 1 AND [ReturnQty] IS NULL) OR ([ReturnQty] = @Original_ReturnQty)) AND ((@IsNull_TotalAmount = 1 AND [TotalAmount] IS NULL) OR ([TotalAmount] = @Original_TotalAmount)) AND ((@IsNull_PurchaseRate = 1 AND [PurchaseRate] IS NULL) OR ([PurchaseRate] = @Original_PurchaseRate)) AND ((@IsNull_Margin = 1 AND [Margin] IS NULL) OR ([Margin] = @Original_Margin)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SRJ_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SRJ_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SalesReturnID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesReturnID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Qty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SalesRate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesRate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SalesRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SalesRate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_DiscPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DiscPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_DiscPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_DiscAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DiscAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_DiscAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CGSTPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGSTPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CGSTAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGSTAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SGSTPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGSTPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_IGSTPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGSTPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_IGSTAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGSTAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CESSPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESSPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CESSAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESSAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ReturnQty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReturnQty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ReturnQty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ReturnQty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_TotalAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalAmount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PurchaseRate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseRate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PurchaseRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PurchaseRate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Margin", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Margin", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Margin", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Margin", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[SalesReturn_Join] ([SalesReturnID], [ProductID], [Barcode], [Qty], [SalesRate], [DiscPer], [DiscAmt], [CGSTPer], [CGSTAmt], [SGSTPer], [SGSTAmt], [IGSTPer], [IGSTAmt], [CESSPer], [CESSAmt], [ReturnQty], [TotalAmount], [PurchaseRate], [Margin]) VALUES (@SalesReturnID, @ProductID, @Barcode, @Qty, @SalesRate, @DiscPer, @DiscAmt, @CGSTPer, @CGSTAmt, @SGSTPer, @SGSTAmt, @IGSTPer, @IGSTAmt, @CESSPer, @CESSAmt, @ReturnQty, @TotalAmount, @PurchaseRate, @Margin);" & vbCrLf & "SELECT SRJ_ID, SalesReturnID, ProductID, Barcode, Qty, SalesRate, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, ReturnQty, TotalAmount, PurchaseRate, Margin FROM SalesReturn_Join WHERE (SRJ_ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SalesReturnID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesReturnID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SalesRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SalesRate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DiscPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DiscAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ReturnQty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ReturnQty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PurchaseRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PurchaseRate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Margin", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Margin", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[SalesReturn_Join] SET [SalesReturnID] = @SalesReturnID, [ProductID] = @ProductID, [Barcode] = @Barcode, [Qty] = @Qty, [SalesRate] = @SalesRate, [DiscPer] = @DiscPer, [DiscAmt] = @DiscAmt, [CGSTPer] = @CGSTPer, [CGSTAmt] = @CGSTAmt, [SGSTPer] = @SGSTPer, [SGSTAmt] = @SGSTAmt, [IGSTPer] = @IGSTPer, [IGSTAmt] = @IGSTAmt, [CESSPer] = @CESSPer, [CESSAmt] = @CESSAmt, [ReturnQty] = @ReturnQty, [TotalAmount] = @TotalAmount, [PurchaseRate] = @PurchaseRate, [Margin] = @Margin WHERE (([SRJ_ID] = @Original_SRJ_ID) AND ([SalesReturnID] = @Original_SalesReturnID) AND ((@IsNull_ProductID = 1 AND [ProductID] IS NULL) OR ([ProductID] = @Original_ProductID)) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ((@IsNull_Qty = 1 AND [Qty] IS NULL) OR ([Qty] = @Original_Qty)) AND ((@IsNull_SalesRate = 1 AND [SalesRate] IS NULL) OR ([SalesRate] = @Original_SalesRate)) AND ((@IsNull_DiscPer = 1 AND [DiscPer] IS NULL) OR ([DiscPer] = @Original_DiscPer)) AND ((@IsNull_DiscAmt = 1 AND [DiscAmt] IS NULL) OR ([DiscAmt] = @Original_DiscAmt)) AND ((@IsNull_CGSTPer = 1 AND [CGSTPer] IS NULL) OR ([CGSTPer] = @Original_CGSTPer)) AND ((@IsNull_CGSTAmt = 1 AND [CGSTAmt] IS NULL) OR ([CGSTAmt] = @Original_CGSTAmt)) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ([SGSTAmt] = @Original_SGSTAmt) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ((@IsNull_ReturnQty = 1 AND [ReturnQty] IS NULL) OR ([ReturnQty] = @Original_ReturnQty)) AND ((@IsNull_TotalAmount = 1 AND [TotalAmount] IS NULL) OR ([TotalAmount] = @Original_TotalAmount)) AND ((@IsNull_PurchaseRate = 1 AND [PurchaseRate] IS NULL) OR ([PurchaseRate] = @Original_PurchaseRate)) AND ((@IsNull_Margin = 1 AND [Margin] IS NULL) OR ([Margin] = @Original_Margin)));" & vbCrLf & "SELECT SRJ_ID, SalesReturnID, ProductID, Barcode, Qty, SalesRate, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, ReturnQty, TotalAmount, PurchaseRate, Margin FROM SalesReturn_Join WHERE (SRJ_ID = @SRJ_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SalesReturnID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesReturnID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SalesRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SalesRate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DiscPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DiscAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ReturnQty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ReturnQty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PurchaseRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PurchaseRate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Margin", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Margin", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SRJ_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SRJ_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SalesReturnID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesReturnID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Qty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SalesRate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesRate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SalesRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SalesRate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_DiscPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DiscPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_DiscPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_DiscAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DiscAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_DiscAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CGSTPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGSTPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CGSTAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGSTAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SGSTPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGSTPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_IGSTPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGSTPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_IGSTAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGSTAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CESSPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESSPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CESSAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESSAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ReturnQty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReturnQty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ReturnQty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ReturnQty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_TotalAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalAmount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PurchaseRate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseRate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PurchaseRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PurchaseRate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Margin", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Margin", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Margin", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Margin", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SRJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "SRJ_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E650 RID: 58960 RVA: 0x00065AFF File Offset: 0x00063CFF
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E651 RID: 58961 RVA: 0x008AB624 File Offset: 0x008A9824
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT SRJ_ID, SalesReturnID, ProductID, Barcode, Qty, SalesRate, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, ReturnQty, TotalAmount, PurchaseRate, Margin FROM dbo.SalesReturn_Join"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E652 RID: 58962 RVA: 0x008AB684 File Offset: 0x008A9884
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.SalesReturn_JoinDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E653 RID: 58963 RVA: 0x008AB6CC File Offset: 0x008A98CC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.SalesReturn_JoinDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim salesReturn_JoinDataTable As Inventory_DBDataSet.SalesReturn_JoinDataTable = New Inventory_DBDataSet.SalesReturn_JoinDataTable()
			Me.Adapter.Fill(salesReturn_JoinDataTable)
			Return salesReturn_JoinDataTable
		End Function

		' Token: 0x0600E654 RID: 58964 RVA: 0x008AB708 File Offset: 0x008A9908
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.SalesReturn_JoinDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E655 RID: 58965 RVA: 0x008AB728 File Offset: 0x008A9928
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "SalesReturn_Join")
		End Function

		' Token: 0x0600E656 RID: 58966 RVA: 0x008AB74C File Offset: 0x008A994C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E657 RID: 58967 RVA: 0x008AB774 File Offset: 0x008A9974
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E658 RID: 58968 RVA: 0x008AB794 File Offset: 0x008A9994
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_SRJ_ID As Integer, Original_SalesReturnID As Integer, Original_ProductID As Integer?, Original_Barcode As String, Original_Qty As Decimal?, Original_SalesRate As Decimal?, Original_DiscPer As Decimal?, Original_DiscAmt As Decimal?, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_ReturnQty As Decimal?, Original_TotalAmount As Decimal?, Original_PurchaseRate As Decimal?, Original_Margin As Decimal?) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_SRJ_ID
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_SalesReturnID
			Dim flag As Boolean = Original_ProductID IsNot Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(2).Value = 0
				Me.Adapter.DeleteCommand.Parameters(3).Value = Original_ProductID.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(2).Value = 1
				Me.Adapter.DeleteCommand.Parameters(3).Value = DBNull.Value
			End If
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
			Dim flag4 As Boolean = Original_SalesRate IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(8).Value = 0
				Me.Adapter.DeleteCommand.Parameters(9).Value = Original_SalesRate.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(8).Value = 1
				Me.Adapter.DeleteCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_DiscPer IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(10).Value = 0
				Me.Adapter.DeleteCommand.Parameters(11).Value = Original_DiscPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(10).Value = 1
				Me.Adapter.DeleteCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_DiscAmt IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(12).Value = 0
				Me.Adapter.DeleteCommand.Parameters(13).Value = Original_DiscAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(12).Value = 1
				Me.Adapter.DeleteCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_CGSTPer IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(14).Value = 0
				Me.Adapter.DeleteCommand.Parameters(15).Value = Original_CGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(14).Value = 1
				Me.Adapter.DeleteCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_CGSTAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(16).Value = 0
				Me.Adapter.DeleteCommand.Parameters(17).Value = Original_CGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(16).Value = 1
				Me.Adapter.DeleteCommand.Parameters(17).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Original_SGSTPer IsNot Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(18).Value = 0
				Me.Adapter.DeleteCommand.Parameters(19).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(18).Value = 1
				Me.Adapter.DeleteCommand.Parameters(19).Value = DBNull.Value
			End If
			Me.Adapter.DeleteCommand.Parameters(20).Value = Original_SGSTAmt
			Dim flag10 As Boolean = Original_IGSTPer IsNot Nothing
			If flag10 Then
				Me.Adapter.DeleteCommand.Parameters(21).Value = 0
				Me.Adapter.DeleteCommand.Parameters(22).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(21).Value = 1
				Me.Adapter.DeleteCommand.Parameters(22).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag11 Then
				Me.Adapter.DeleteCommand.Parameters(23).Value = 0
				Me.Adapter.DeleteCommand.Parameters(24).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(23).Value = 1
				Me.Adapter.DeleteCommand.Parameters(24).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_CESSPer IsNot Nothing
			If flag12 Then
				Me.Adapter.DeleteCommand.Parameters(25).Value = 0
				Me.Adapter.DeleteCommand.Parameters(26).Value = Original_CESSPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(25).Value = 1
				Me.Adapter.DeleteCommand.Parameters(26).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_CESSAmt IsNot Nothing
			If flag13 Then
				Me.Adapter.DeleteCommand.Parameters(27).Value = 0
				Me.Adapter.DeleteCommand.Parameters(28).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(27).Value = 1
				Me.Adapter.DeleteCommand.Parameters(28).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = Original_ReturnQty IsNot Nothing
			If flag14 Then
				Me.Adapter.DeleteCommand.Parameters(29).Value = 0
				Me.Adapter.DeleteCommand.Parameters(30).Value = Original_ReturnQty.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(29).Value = 1
				Me.Adapter.DeleteCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = Original_TotalAmount IsNot Nothing
			If flag15 Then
				Me.Adapter.DeleteCommand.Parameters(31).Value = 0
				Me.Adapter.DeleteCommand.Parameters(32).Value = Original_TotalAmount.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(31).Value = 1
				Me.Adapter.DeleteCommand.Parameters(32).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = Original_PurchaseRate IsNot Nothing
			If flag16 Then
				Me.Adapter.DeleteCommand.Parameters(33).Value = 0
				Me.Adapter.DeleteCommand.Parameters(34).Value = Original_PurchaseRate.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(33).Value = 1
				Me.Adapter.DeleteCommand.Parameters(34).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Original_Margin IsNot Nothing
			If flag17 Then
				Me.Adapter.DeleteCommand.Parameters(35).Value = 0
				Me.Adapter.DeleteCommand.Parameters(36).Value = Original_Margin.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(35).Value = 1
				Me.Adapter.DeleteCommand.Parameters(36).Value = DBNull.Value
			End If
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag18 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag18 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag19 As Boolean = state = ConnectionState.Closed
				If flag19 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E659 RID: 58969 RVA: 0x008AC360 File Offset: 0x008AA560
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(SalesReturnID As Integer, ProductID As Integer?, Barcode As String, Qty As Decimal?, SalesRate As Decimal?, DiscPer As Decimal?, DiscAmt As Decimal?, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, ReturnQty As Decimal?, TotalAmount As Decimal?, PurchaseRate As Decimal?, Margin As Decimal?) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = SalesReturnID
			Dim flag As Boolean = ProductID IsNot Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = ProductID.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			End If
			Dim flag2 As Boolean = Barcode = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = Barcode
			End If
			Dim flag3 As Boolean = Qty IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = Qty.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = SalesRate IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = SalesRate.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = DiscPer IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DiscPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = DiscAmt IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DiscAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = CGSTPer IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = CGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CGSTAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = CGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = SGSTPer IsNot Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = SGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			End If
			Me.Adapter.InsertCommand.Parameters(10).Value = SGSTAmt
			Dim flag10 As Boolean = IGSTPer IsNot Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = IGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = IGSTAmt IsNot Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = IGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = CESSPer IsNot Nothing
			If flag12 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = CESSPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = CESSAmt IsNot Nothing
			If flag13 Then
				Me.Adapter.InsertCommand.Parameters(14).Value = CESSAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = ReturnQty IsNot Nothing
			If flag14 Then
				Me.Adapter.InsertCommand.Parameters(15).Value = ReturnQty.Value
			Else
				Me.Adapter.InsertCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = TotalAmount IsNot Nothing
			If flag15 Then
				Me.Adapter.InsertCommand.Parameters(16).Value = TotalAmount.Value
			Else
				Me.Adapter.InsertCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = PurchaseRate IsNot Nothing
			If flag16 Then
				Me.Adapter.InsertCommand.Parameters(17).Value = PurchaseRate.Value
			Else
				Me.Adapter.InsertCommand.Parameters(17).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Margin IsNot Nothing
			If flag17 Then
				Me.Adapter.InsertCommand.Parameters(18).Value = Margin.Value
			Else
				Me.Adapter.InsertCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag18 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag18 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag19 As Boolean = state = ConnectionState.Closed
				If flag19 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E65A RID: 58970 RVA: 0x008ACA60 File Offset: 0x008AAC60
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(SalesReturnID As Integer, ProductID As Integer?, Barcode As String, Qty As Decimal?, SalesRate As Decimal?, DiscPer As Decimal?, DiscAmt As Decimal?, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, ReturnQty As Decimal?, TotalAmount As Decimal?, PurchaseRate As Decimal?, Margin As Decimal?, Original_SRJ_ID As Integer, Original_SalesReturnID As Integer, Original_ProductID As Integer?, Original_Barcode As String, Original_Qty As Decimal?, Original_SalesRate As Decimal?, Original_DiscPer As Decimal?, Original_DiscAmt As Decimal?, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_ReturnQty As Decimal?, Original_TotalAmount As Decimal?, Original_PurchaseRate As Decimal?, Original_Margin As Decimal?, SRJ_ID As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = SalesReturnID
			Dim flag As Boolean = ProductID IsNot Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = ProductID.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			End If
			Dim flag2 As Boolean = Barcode = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = Barcode
			End If
			Dim flag3 As Boolean = Qty IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = Qty.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = SalesRate IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = SalesRate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = DiscPer IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DiscPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = DiscAmt IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DiscAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = CGSTPer IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = CGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CGSTAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = CGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = SGSTPer IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(10).Value = SGSTAmt
			Dim flag10 As Boolean = IGSTPer IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = IGSTAmt IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = CESSPer IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = CESSAmt IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = ReturnQty IsNot Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = ReturnQty.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = TotalAmount IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = TotalAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = PurchaseRate IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = PurchaseRate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Margin IsNot Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(18).Value = Margin.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_SRJ_ID
			Me.Adapter.UpdateCommand.Parameters(20).Value = Original_SalesReturnID
			Dim flag18 As Boolean = Original_ProductID IsNot Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(21).Value = 0
				Me.Adapter.UpdateCommand.Parameters(22).Value = Original_ProductID.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(21).Value = 1
				Me.Adapter.UpdateCommand.Parameters(22).Value = DBNull.Value
			End If
			Dim flag19 As Boolean = Original_Barcode = Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(23).Value = 1
				Me.Adapter.UpdateCommand.Parameters(24).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(23).Value = 0
				Me.Adapter.UpdateCommand.Parameters(24).Value = Original_Barcode
			End If
			Dim flag20 As Boolean = Original_Qty IsNot Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(25).Value = 0
				Me.Adapter.UpdateCommand.Parameters(26).Value = Original_Qty.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(25).Value = 1
				Me.Adapter.UpdateCommand.Parameters(26).Value = DBNull.Value
			End If
			Dim flag21 As Boolean = Original_SalesRate IsNot Nothing
			If flag21 Then
				Me.Adapter.UpdateCommand.Parameters(27).Value = 0
				Me.Adapter.UpdateCommand.Parameters(28).Value = Original_SalesRate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(27).Value = 1
				Me.Adapter.UpdateCommand.Parameters(28).Value = DBNull.Value
			End If
			Dim flag22 As Boolean = Original_DiscPer IsNot Nothing
			If flag22 Then
				Me.Adapter.UpdateCommand.Parameters(29).Value = 0
				Me.Adapter.UpdateCommand.Parameters(30).Value = Original_DiscPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(29).Value = 1
				Me.Adapter.UpdateCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim flag23 As Boolean = Original_DiscAmt IsNot Nothing
			If flag23 Then
				Me.Adapter.UpdateCommand.Parameters(31).Value = 0
				Me.Adapter.UpdateCommand.Parameters(32).Value = Original_DiscAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(31).Value = 1
				Me.Adapter.UpdateCommand.Parameters(32).Value = DBNull.Value
			End If
			Dim flag24 As Boolean = Original_CGSTPer IsNot Nothing
			If flag24 Then
				Me.Adapter.UpdateCommand.Parameters(33).Value = 0
				Me.Adapter.UpdateCommand.Parameters(34).Value = Original_CGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(33).Value = 1
				Me.Adapter.UpdateCommand.Parameters(34).Value = DBNull.Value
			End If
			Dim flag25 As Boolean = Original_CGSTAmt IsNot Nothing
			If flag25 Then
				Me.Adapter.UpdateCommand.Parameters(35).Value = 0
				Me.Adapter.UpdateCommand.Parameters(36).Value = Original_CGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(35).Value = 1
				Me.Adapter.UpdateCommand.Parameters(36).Value = DBNull.Value
			End If
			Dim flag26 As Boolean = Original_SGSTPer IsNot Nothing
			If flag26 Then
				Me.Adapter.UpdateCommand.Parameters(37).Value = 0
				Me.Adapter.UpdateCommand.Parameters(38).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(37).Value = 1
				Me.Adapter.UpdateCommand.Parameters(38).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(39).Value = Original_SGSTAmt
			Dim flag27 As Boolean = Original_IGSTPer IsNot Nothing
			If flag27 Then
				Me.Adapter.UpdateCommand.Parameters(40).Value = 0
				Me.Adapter.UpdateCommand.Parameters(41).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(40).Value = 1
				Me.Adapter.UpdateCommand.Parameters(41).Value = DBNull.Value
			End If
			Dim flag28 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag28 Then
				Me.Adapter.UpdateCommand.Parameters(42).Value = 0
				Me.Adapter.UpdateCommand.Parameters(43).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(42).Value = 1
				Me.Adapter.UpdateCommand.Parameters(43).Value = DBNull.Value
			End If
			Dim flag29 As Boolean = Original_CESSPer IsNot Nothing
			If flag29 Then
				Me.Adapter.UpdateCommand.Parameters(44).Value = 0
				Me.Adapter.UpdateCommand.Parameters(45).Value = Original_CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(44).Value = 1
				Me.Adapter.UpdateCommand.Parameters(45).Value = DBNull.Value
			End If
			Dim flag30 As Boolean = Original_CESSAmt IsNot Nothing
			If flag30 Then
				Me.Adapter.UpdateCommand.Parameters(46).Value = 0
				Me.Adapter.UpdateCommand.Parameters(47).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(46).Value = 1
				Me.Adapter.UpdateCommand.Parameters(47).Value = DBNull.Value
			End If
			Dim flag31 As Boolean = Original_ReturnQty IsNot Nothing
			If flag31 Then
				Me.Adapter.UpdateCommand.Parameters(48).Value = 0
				Me.Adapter.UpdateCommand.Parameters(49).Value = Original_ReturnQty.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(48).Value = 1
				Me.Adapter.UpdateCommand.Parameters(49).Value = DBNull.Value
			End If
			Dim flag32 As Boolean = Original_TotalAmount IsNot Nothing
			If flag32 Then
				Me.Adapter.UpdateCommand.Parameters(50).Value = 0
				Me.Adapter.UpdateCommand.Parameters(51).Value = Original_TotalAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(50).Value = 1
				Me.Adapter.UpdateCommand.Parameters(51).Value = DBNull.Value
			End If
			Dim flag33 As Boolean = Original_PurchaseRate IsNot Nothing
			If flag33 Then
				Me.Adapter.UpdateCommand.Parameters(52).Value = 0
				Me.Adapter.UpdateCommand.Parameters(53).Value = Original_PurchaseRate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(52).Value = 1
				Me.Adapter.UpdateCommand.Parameters(53).Value = DBNull.Value
			End If
			Dim flag34 As Boolean = Original_Margin IsNot Nothing
			If flag34 Then
				Me.Adapter.UpdateCommand.Parameters(54).Value = 0
				Me.Adapter.UpdateCommand.Parameters(55).Value = Original_Margin.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(54).Value = 1
				Me.Adapter.UpdateCommand.Parameters(55).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(56).Value = SRJ_ID
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag35 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag35 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag36 As Boolean = state = ConnectionState.Closed
				If flag36 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E65B RID: 58971 RVA: 0x008ADCB4 File Offset: 0x008ABEB4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(SalesReturnID As Integer, ProductID As Integer?, Barcode As String, Qty As Decimal?, SalesRate As Decimal?, DiscPer As Decimal?, DiscAmt As Decimal?, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, ReturnQty As Decimal?, TotalAmount As Decimal?, PurchaseRate As Decimal?, Margin As Decimal?, Original_SRJ_ID As Integer, Original_SalesReturnID As Integer, Original_ProductID As Integer?, Original_Barcode As String, Original_Qty As Decimal?, Original_SalesRate As Decimal?, Original_DiscPer As Decimal?, Original_DiscAmt As Decimal?, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_ReturnQty As Decimal?, Original_TotalAmount As Decimal?, Original_PurchaseRate As Decimal?, Original_Margin As Decimal?) As Integer
			Return Me.Update(SalesReturnID, ProductID, Barcode, Qty, SalesRate, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, ReturnQty, TotalAmount, PurchaseRate, Margin, Original_SRJ_ID, Original_SalesReturnID, Original_ProductID, Original_Barcode, Original_Qty, Original_SalesRate, Original_DiscPer, Original_DiscAmt, Original_CGSTPer, Original_CGSTAmt, Original_SGSTPer, Original_SGSTAmt, Original_IGSTPer, Original_IGSTAmt, Original_CESSPer, Original_CESSAmt, Original_ReturnQty, Original_TotalAmount, Original_PurchaseRate, Original_Margin, Original_SRJ_ID)
		End Function

		' Token: 0x040058BC RID: 22716
		Private _connection As SqlConnection

		' Token: 0x040058BD RID: 22717
		Private _transaction As SqlTransaction

		' Token: 0x040058BE RID: 22718
		Private _commandCollection As SqlCommand()

		' Token: 0x040058BF RID: 22719
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
