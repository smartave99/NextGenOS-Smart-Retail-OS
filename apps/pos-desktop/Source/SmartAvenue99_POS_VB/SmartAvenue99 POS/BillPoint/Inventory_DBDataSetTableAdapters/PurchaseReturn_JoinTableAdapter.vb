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
	' Token: 0x0200045C RID: 1116
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class PurchaseReturn_JoinTableAdapter
		Inherits Component

		' Token: 0x17005851 RID: 22609
		' (get) Token: 0x0600E59C RID: 58780 RVA: 0x0006588B File Offset: 0x00063A8B
		' (set) Token: 0x0600E59D RID: 58781 RVA: 0x00065895 File Offset: 0x00063A95
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E59E RID: 58782 RVA: 0x0006589E File Offset: 0x00063A9E
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005852 RID: 22610
		' (get) Token: 0x0600E59F RID: 58783 RVA: 0x008964C8 File Offset: 0x008946C8
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

		' Token: 0x17005853 RID: 22611
		' (get) Token: 0x0600E5A0 RID: 58784 RVA: 0x008964F8 File Offset: 0x008946F8
		' (set) Token: 0x0600E5A1 RID: 58785 RVA: 0x00896528 File Offset: 0x00894728
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

		' Token: 0x17005854 RID: 22612
		' (get) Token: 0x0600E5A2 RID: 58786 RVA: 0x008965EC File Offset: 0x008947EC
		' (set) Token: 0x0600E5A3 RID: 58787 RVA: 0x00896604 File Offset: 0x00894804
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

		' Token: 0x17005855 RID: 22613
		' (get) Token: 0x0600E5A4 RID: 58788 RVA: 0x008966EC File Offset: 0x008948EC
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

		' Token: 0x17005856 RID: 22614
		' (get) Token: 0x0600E5A5 RID: 58789 RVA: 0x0089671C File Offset: 0x0089491C
		' (set) Token: 0x0600E5A6 RID: 58790 RVA: 0x000658B0 File Offset: 0x00063AB0
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

		' Token: 0x0600E5A7 RID: 58791 RVA: 0x00896734 File Offset: 0x00894934
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "PurchaseReturn_Join"
			dataTableMapping.ColumnMappings.Add("PRJ_ID", "PRJ_ID")
			dataTableMapping.ColumnMappings.Add("PurchaseReturnID", "PurchaseReturnID")
			dataTableMapping.ColumnMappings.Add("ProductID", "ProductID")
			dataTableMapping.ColumnMappings.Add("Barcode", "Barcode")
			dataTableMapping.ColumnMappings.Add("Qty", "Qty")
			dataTableMapping.ColumnMappings.Add("MRP", "MRP")
			dataTableMapping.ColumnMappings.Add("Price", "Price")
			dataTableMapping.ColumnMappings.Add("ReturnQty", "ReturnQty")
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
			dataTableMapping.ColumnMappings.Add("TotalAmount", "TotalAmount")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[PurchaseReturn_Join] WHERE (([PRJ_ID] = @Original_PRJ_ID) AND ([PurchaseReturnID] = @Original_PurchaseReturnID) AND ((@IsNull_ProductID = 1 AND [ProductID] IS NULL) OR ([ProductID] = @Original_ProductID)) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ((@IsNull_Qty = 1 AND [Qty] IS NULL) OR ([Qty] = @Original_Qty)) AND ((@IsNull_MRP = 1 AND [MRP] IS NULL) OR ([MRP] = @Original_MRP)) AND ((@IsNull_Price = 1 AND [Price] IS NULL) OR ([Price] = @Original_Price)) AND ((@IsNull_ReturnQty = 1 AND [ReturnQty] IS NULL) OR ([ReturnQty] = @Original_ReturnQty)) AND ((@IsNull_DiscPer = 1 AND [DiscPer] IS NULL) OR ([DiscPer] = @Original_DiscPer)) AND ((@IsNull_DiscAmt = 1 AND [DiscAmt] IS NULL) OR ([DiscAmt] = @Original_DiscAmt)) AND ((@IsNull_CGSTPer = 1 AND [CGSTPer] IS NULL) OR ([CGSTPer] = @Original_CGSTPer)) AND ((@IsNull_CGSTAmt = 1 AND [CGSTAmt] IS NULL) OR ([CGSTAmt] = @Original_CGSTAmt)) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ((@IsNull_TotalAmount = 1 AND [TotalAmount] IS NULL) OR ([TotalAmount] = @Original_TotalAmount)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PRJ_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PRJ_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PurchaseReturnID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseReturnID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Qty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_MRP", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "MRP", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_MRP", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "MRP", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Price", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Price", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ReturnQty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReturnQty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ReturnQty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ReturnQty", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SGSTAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGSTAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_IGSTPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGSTPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_IGSTAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGSTAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CESSPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESSPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CESSAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESSAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_TotalAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalAmount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[PurchaseReturn_Join] ([PurchaseReturnID], [ProductID], [Barcode], [Qty], [MRP], [Price], [ReturnQty], [DiscPer], [DiscAmt], [CGSTPer], [CGSTAmt], [SGSTPer], [SGSTAmt], [IGSTPer], [IGSTAmt], [CESSPer], [CESSAmt], [TotalAmount]) VALUES (@PurchaseReturnID, @ProductID, @Barcode, @Qty, @MRP, @Price, @ReturnQty, @DiscPer, @DiscAmt, @CGSTPer, @CGSTAmt, @SGSTPer, @SGSTAmt, @IGSTPer, @IGSTAmt, @CESSPer, @CESSAmt, @TotalAmount);" & vbCrLf & "SELECT PRJ_ID, PurchaseReturnID, ProductID, Barcode, Qty, MRP, Price, ReturnQty, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount FROM PurchaseReturn_Join WHERE (PRJ_ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PurchaseReturnID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseReturnID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MRP", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "MRP", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ReturnQty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ReturnQty", DataRowVersion.Current, False, Nothing, "", "", ""))
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
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[PurchaseReturn_Join] SET [PurchaseReturnID] = @PurchaseReturnID, [ProductID] = @ProductID, [Barcode] = @Barcode, [Qty] = @Qty, [MRP] = @MRP, [Price] = @Price, [ReturnQty] = @ReturnQty, [DiscPer] = @DiscPer, [DiscAmt] = @DiscAmt, [CGSTPer] = @CGSTPer, [CGSTAmt] = @CGSTAmt, [SGSTPer] = @SGSTPer, [SGSTAmt] = @SGSTAmt, [IGSTPer] = @IGSTPer, [IGSTAmt] = @IGSTAmt, [CESSPer] = @CESSPer, [CESSAmt] = @CESSAmt, [TotalAmount] = @TotalAmount WHERE (([PRJ_ID] = @Original_PRJ_ID) AND ([PurchaseReturnID] = @Original_PurchaseReturnID) AND ((@IsNull_ProductID = 1 AND [ProductID] IS NULL) OR ([ProductID] = @Original_ProductID)) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ((@IsNull_Qty = 1 AND [Qty] IS NULL) OR ([Qty] = @Original_Qty)) AND ((@IsNull_MRP = 1 AND [MRP] IS NULL) OR ([MRP] = @Original_MRP)) AND ((@IsNull_Price = 1 AND [Price] IS NULL) OR ([Price] = @Original_Price)) AND ((@IsNull_ReturnQty = 1 AND [ReturnQty] IS NULL) OR ([ReturnQty] = @Original_ReturnQty)) AND ((@IsNull_DiscPer = 1 AND [DiscPer] IS NULL) OR ([DiscPer] = @Original_DiscPer)) AND ((@IsNull_DiscAmt = 1 AND [DiscAmt] IS NULL) OR ([DiscAmt] = @Original_DiscAmt)) AND ((@IsNull_CGSTPer = 1 AND [CGSTPer] IS NULL) OR ([CGSTPer] = @Original_CGSTPer)) AND ((@IsNull_CGSTAmt = 1 AND [CGSTAmt] IS NULL) OR ([CGSTAmt] = @Original_CGSTAmt)) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ((@IsNull_TotalAmount = 1 AND [TotalAmount] IS NULL) OR ([TotalAmount] = @Original_TotalAmount)));" & vbCrLf & "SELECT PRJ_ID, PurchaseReturnID, ProductID, Barcode, Qty, MRP, Price, ReturnQty, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount FROM PurchaseReturn_Join WHERE (PRJ_ID = @PRJ_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PurchaseReturnID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseReturnID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@MRP", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "MRP", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ReturnQty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ReturnQty", DataRowVersion.Current, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PRJ_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PRJ_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PurchaseReturnID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseReturnID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Qty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Qty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_MRP", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "MRP", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_MRP", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "MRP", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Price", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Price", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ReturnQty", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReturnQty", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ReturnQty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ReturnQty", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SGSTAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGSTAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_IGSTPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGSTPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_IGSTAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGSTAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CESSPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESSPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CESSAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESSAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_TotalAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalAmount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PRJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "PRJ_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E5A8 RID: 58792 RVA: 0x000658BA File Offset: 0x00063ABA
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E5A9 RID: 58793 RVA: 0x00898590 File Offset: 0x00896790
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT PRJ_ID, PurchaseReturnID, ProductID, Barcode, Qty, MRP, Price, ReturnQty, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount FROM dbo.PurchaseReturn_Join"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E5AA RID: 58794 RVA: 0x008985F0 File Offset: 0x008967F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.PurchaseReturn_JoinDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E5AB RID: 58795 RVA: 0x00898638 File Offset: 0x00896838
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.PurchaseReturn_JoinDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim purchaseReturn_JoinDataTable As Inventory_DBDataSet.PurchaseReturn_JoinDataTable = New Inventory_DBDataSet.PurchaseReturn_JoinDataTable()
			Me.Adapter.Fill(purchaseReturn_JoinDataTable)
			Return purchaseReturn_JoinDataTable
		End Function

		' Token: 0x0600E5AC RID: 58796 RVA: 0x00898674 File Offset: 0x00896874
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.PurchaseReturn_JoinDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E5AD RID: 58797 RVA: 0x00898694 File Offset: 0x00896894
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "PurchaseReturn_Join")
		End Function

		' Token: 0x0600E5AE RID: 58798 RVA: 0x008986B8 File Offset: 0x008968B8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E5AF RID: 58799 RVA: 0x008986E0 File Offset: 0x008968E0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E5B0 RID: 58800 RVA: 0x00898700 File Offset: 0x00896900
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_PRJ_ID As Integer, Original_PurchaseReturnID As Integer, Original_ProductID As Integer?, Original_Barcode As String, Original_Qty As Decimal?, Original_MRP As Decimal?, Original_Price As Decimal?, Original_ReturnQty As Decimal?, Original_DiscPer As Decimal?, Original_DiscAmt As Decimal?, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_TotalAmount As Decimal?) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_PRJ_ID
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_PurchaseReturnID
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
			Dim flag4 As Boolean = Original_MRP IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(8).Value = 0
				Me.Adapter.DeleteCommand.Parameters(9).Value = Original_MRP.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(8).Value = 1
				Me.Adapter.DeleteCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_Price IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(10).Value = 0
				Me.Adapter.DeleteCommand.Parameters(11).Value = Original_Price.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(10).Value = 1
				Me.Adapter.DeleteCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_ReturnQty IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(12).Value = 0
				Me.Adapter.DeleteCommand.Parameters(13).Value = Original_ReturnQty.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(12).Value = 1
				Me.Adapter.DeleteCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_DiscPer IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(14).Value = 0
				Me.Adapter.DeleteCommand.Parameters(15).Value = Original_DiscPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(14).Value = 1
				Me.Adapter.DeleteCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_DiscAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(16).Value = 0
				Me.Adapter.DeleteCommand.Parameters(17).Value = Original_DiscAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(16).Value = 1
				Me.Adapter.DeleteCommand.Parameters(17).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Original_CGSTPer IsNot Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(18).Value = 0
				Me.Adapter.DeleteCommand.Parameters(19).Value = Original_CGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(18).Value = 1
				Me.Adapter.DeleteCommand.Parameters(19).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_CGSTAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.DeleteCommand.Parameters(20).Value = 0
				Me.Adapter.DeleteCommand.Parameters(21).Value = Original_CGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(20).Value = 1
				Me.Adapter.DeleteCommand.Parameters(21).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_SGSTPer IsNot Nothing
			If flag11 Then
				Me.Adapter.DeleteCommand.Parameters(22).Value = 0
				Me.Adapter.DeleteCommand.Parameters(23).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(22).Value = 1
				Me.Adapter.DeleteCommand.Parameters(23).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_SGSTAmt IsNot Nothing
			If flag12 Then
				Me.Adapter.DeleteCommand.Parameters(24).Value = 0
				Me.Adapter.DeleteCommand.Parameters(25).Value = Original_SGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(24).Value = 1
				Me.Adapter.DeleteCommand.Parameters(25).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_IGSTPer IsNot Nothing
			If flag13 Then
				Me.Adapter.DeleteCommand.Parameters(26).Value = 0
				Me.Adapter.DeleteCommand.Parameters(27).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(26).Value = 1
				Me.Adapter.DeleteCommand.Parameters(27).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag14 Then
				Me.Adapter.DeleteCommand.Parameters(28).Value = 0
				Me.Adapter.DeleteCommand.Parameters(29).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(28).Value = 1
				Me.Adapter.DeleteCommand.Parameters(29).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = Original_CESSPer IsNot Nothing
			If flag15 Then
				Me.Adapter.DeleteCommand.Parameters(30).Value = 0
				Me.Adapter.DeleteCommand.Parameters(31).Value = Original_CESSPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(30).Value = 1
				Me.Adapter.DeleteCommand.Parameters(31).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = Original_CESSAmt IsNot Nothing
			If flag16 Then
				Me.Adapter.DeleteCommand.Parameters(32).Value = 0
				Me.Adapter.DeleteCommand.Parameters(33).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(32).Value = 1
				Me.Adapter.DeleteCommand.Parameters(33).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Original_TotalAmount IsNot Nothing
			If flag17 Then
				Me.Adapter.DeleteCommand.Parameters(34).Value = 0
				Me.Adapter.DeleteCommand.Parameters(35).Value = Original_TotalAmount.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(34).Value = 1
				Me.Adapter.DeleteCommand.Parameters(35).Value = DBNull.Value
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

		' Token: 0x0600E5B1 RID: 58801 RVA: 0x008992A8 File Offset: 0x008974A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(PurchaseReturnID As Integer, ProductID As Integer?, Barcode As String, Qty As Decimal?, MRP As Decimal?, Price As Decimal?, ReturnQty As Decimal?, DiscPer As Decimal?, DiscAmt As Decimal?, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, TotalAmount As Decimal?) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = PurchaseReturnID
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
			Dim flag4 As Boolean = MRP IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = MRP.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Price IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = Price.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = ReturnQty IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = ReturnQty.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = DiscPer IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = DiscPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = DiscAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = DiscAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = CGSTPer IsNot Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = CGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = CGSTAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = CGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = SGSTPer IsNot Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = SGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = SGSTAmt IsNot Nothing
			If flag12 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = SGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = IGSTPer IsNot Nothing
			If flag13 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = IGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = IGSTAmt IsNot Nothing
			If flag14 Then
				Me.Adapter.InsertCommand.Parameters(14).Value = IGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = CESSPer IsNot Nothing
			If flag15 Then
				Me.Adapter.InsertCommand.Parameters(15).Value = CESSPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = CESSAmt IsNot Nothing
			If flag16 Then
				Me.Adapter.InsertCommand.Parameters(16).Value = CESSAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = TotalAmount IsNot Nothing
			If flag17 Then
				Me.Adapter.InsertCommand.Parameters(17).Value = TotalAmount.Value
			Else
				Me.Adapter.InsertCommand.Parameters(17).Value = DBNull.Value
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

		' Token: 0x0600E5B2 RID: 58802 RVA: 0x00899984 File Offset: 0x00897B84
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PurchaseReturnID As Integer, ProductID As Integer?, Barcode As String, Qty As Decimal?, MRP As Decimal?, Price As Decimal?, ReturnQty As Decimal?, DiscPer As Decimal?, DiscAmt As Decimal?, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, TotalAmount As Decimal?, Original_PRJ_ID As Integer, Original_PurchaseReturnID As Integer, Original_ProductID As Integer?, Original_Barcode As String, Original_Qty As Decimal?, Original_MRP As Decimal?, Original_Price As Decimal?, Original_ReturnQty As Decimal?, Original_DiscPer As Decimal?, Original_DiscAmt As Decimal?, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_TotalAmount As Decimal?, PRJ_ID As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = PurchaseReturnID
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
			Dim flag4 As Boolean = MRP IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = MRP.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Price IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = Price.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = ReturnQty IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = ReturnQty.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = DiscPer IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = DiscPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = DiscAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = DiscAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = CGSTPer IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = CGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = CGSTAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = CGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = SGSTPer IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = SGSTAmt IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = SGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = IGSTPer IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = IGSTAmt IsNot Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = CESSPer IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = CESSAmt IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = TotalAmount IsNot Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = TotalAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_PRJ_ID
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_PurchaseReturnID
			Dim flag18 As Boolean = Original_ProductID IsNot Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(20).Value = 0
				Me.Adapter.UpdateCommand.Parameters(21).Value = Original_ProductID.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(20).Value = 1
				Me.Adapter.UpdateCommand.Parameters(21).Value = DBNull.Value
			End If
			Dim flag19 As Boolean = Original_Barcode = Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(22).Value = 1
				Me.Adapter.UpdateCommand.Parameters(23).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(22).Value = 0
				Me.Adapter.UpdateCommand.Parameters(23).Value = Original_Barcode
			End If
			Dim flag20 As Boolean = Original_Qty IsNot Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(24).Value = 0
				Me.Adapter.UpdateCommand.Parameters(25).Value = Original_Qty.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(24).Value = 1
				Me.Adapter.UpdateCommand.Parameters(25).Value = DBNull.Value
			End If
			Dim flag21 As Boolean = Original_MRP IsNot Nothing
			If flag21 Then
				Me.Adapter.UpdateCommand.Parameters(26).Value = 0
				Me.Adapter.UpdateCommand.Parameters(27).Value = Original_MRP.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(26).Value = 1
				Me.Adapter.UpdateCommand.Parameters(27).Value = DBNull.Value
			End If
			Dim flag22 As Boolean = Original_Price IsNot Nothing
			If flag22 Then
				Me.Adapter.UpdateCommand.Parameters(28).Value = 0
				Me.Adapter.UpdateCommand.Parameters(29).Value = Original_Price.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(28).Value = 1
				Me.Adapter.UpdateCommand.Parameters(29).Value = DBNull.Value
			End If
			Dim flag23 As Boolean = Original_ReturnQty IsNot Nothing
			If flag23 Then
				Me.Adapter.UpdateCommand.Parameters(30).Value = 0
				Me.Adapter.UpdateCommand.Parameters(31).Value = Original_ReturnQty.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(30).Value = 1
				Me.Adapter.UpdateCommand.Parameters(31).Value = DBNull.Value
			End If
			Dim flag24 As Boolean = Original_DiscPer IsNot Nothing
			If flag24 Then
				Me.Adapter.UpdateCommand.Parameters(32).Value = 0
				Me.Adapter.UpdateCommand.Parameters(33).Value = Original_DiscPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(32).Value = 1
				Me.Adapter.UpdateCommand.Parameters(33).Value = DBNull.Value
			End If
			Dim flag25 As Boolean = Original_DiscAmt IsNot Nothing
			If flag25 Then
				Me.Adapter.UpdateCommand.Parameters(34).Value = 0
				Me.Adapter.UpdateCommand.Parameters(35).Value = Original_DiscAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(34).Value = 1
				Me.Adapter.UpdateCommand.Parameters(35).Value = DBNull.Value
			End If
			Dim flag26 As Boolean = Original_CGSTPer IsNot Nothing
			If flag26 Then
				Me.Adapter.UpdateCommand.Parameters(36).Value = 0
				Me.Adapter.UpdateCommand.Parameters(37).Value = Original_CGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(36).Value = 1
				Me.Adapter.UpdateCommand.Parameters(37).Value = DBNull.Value
			End If
			Dim flag27 As Boolean = Original_CGSTAmt IsNot Nothing
			If flag27 Then
				Me.Adapter.UpdateCommand.Parameters(38).Value = 0
				Me.Adapter.UpdateCommand.Parameters(39).Value = Original_CGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(38).Value = 1
				Me.Adapter.UpdateCommand.Parameters(39).Value = DBNull.Value
			End If
			Dim flag28 As Boolean = Original_SGSTPer IsNot Nothing
			If flag28 Then
				Me.Adapter.UpdateCommand.Parameters(40).Value = 0
				Me.Adapter.UpdateCommand.Parameters(41).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(40).Value = 1
				Me.Adapter.UpdateCommand.Parameters(41).Value = DBNull.Value
			End If
			Dim flag29 As Boolean = Original_SGSTAmt IsNot Nothing
			If flag29 Then
				Me.Adapter.UpdateCommand.Parameters(42).Value = 0
				Me.Adapter.UpdateCommand.Parameters(43).Value = Original_SGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(42).Value = 1
				Me.Adapter.UpdateCommand.Parameters(43).Value = DBNull.Value
			End If
			Dim flag30 As Boolean = Original_IGSTPer IsNot Nothing
			If flag30 Then
				Me.Adapter.UpdateCommand.Parameters(44).Value = 0
				Me.Adapter.UpdateCommand.Parameters(45).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(44).Value = 1
				Me.Adapter.UpdateCommand.Parameters(45).Value = DBNull.Value
			End If
			Dim flag31 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag31 Then
				Me.Adapter.UpdateCommand.Parameters(46).Value = 0
				Me.Adapter.UpdateCommand.Parameters(47).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(46).Value = 1
				Me.Adapter.UpdateCommand.Parameters(47).Value = DBNull.Value
			End If
			Dim flag32 As Boolean = Original_CESSPer IsNot Nothing
			If flag32 Then
				Me.Adapter.UpdateCommand.Parameters(48).Value = 0
				Me.Adapter.UpdateCommand.Parameters(49).Value = Original_CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(48).Value = 1
				Me.Adapter.UpdateCommand.Parameters(49).Value = DBNull.Value
			End If
			Dim flag33 As Boolean = Original_CESSAmt IsNot Nothing
			If flag33 Then
				Me.Adapter.UpdateCommand.Parameters(50).Value = 0
				Me.Adapter.UpdateCommand.Parameters(51).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(50).Value = 1
				Me.Adapter.UpdateCommand.Parameters(51).Value = DBNull.Value
			End If
			Dim flag34 As Boolean = Original_TotalAmount IsNot Nothing
			If flag34 Then
				Me.Adapter.UpdateCommand.Parameters(52).Value = 0
				Me.Adapter.UpdateCommand.Parameters(53).Value = Original_TotalAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(52).Value = 1
				Me.Adapter.UpdateCommand.Parameters(53).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(54).Value = PRJ_ID
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

		' Token: 0x0600E5B3 RID: 58803 RVA: 0x0089AB90 File Offset: 0x00898D90
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PurchaseReturnID As Integer, ProductID As Integer?, Barcode As String, Qty As Decimal?, MRP As Decimal?, Price As Decimal?, ReturnQty As Decimal?, DiscPer As Decimal?, DiscAmt As Decimal?, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, TotalAmount As Decimal?, Original_PRJ_ID As Integer, Original_PurchaseReturnID As Integer, Original_ProductID As Integer?, Original_Barcode As String, Original_Qty As Decimal?, Original_MRP As Decimal?, Original_Price As Decimal?, Original_ReturnQty As Decimal?, Original_DiscPer As Decimal?, Original_DiscAmt As Decimal?, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_TotalAmount As Decimal?) As Integer
			Return Me.Update(PurchaseReturnID, ProductID, Barcode, Qty, MRP, Price, ReturnQty, DiscPer, DiscAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount, Original_PRJ_ID, Original_PurchaseReturnID, Original_ProductID, Original_Barcode, Original_Qty, Original_MRP, Original_Price, Original_ReturnQty, Original_DiscPer, Original_DiscAmt, Original_CGSTPer, Original_CGSTAmt, Original_SGSTPer, Original_SGSTAmt, Original_IGSTPer, Original_IGSTAmt, Original_CESSPer, Original_CESSAmt, Original_TotalAmount, Original_PRJ_ID)
		End Function

		' Token: 0x04005899 RID: 22681
		Private _connection As SqlConnection

		' Token: 0x0400589A RID: 22682
		Private _transaction As SqlTransaction

		' Token: 0x0400589B RID: 22683
		Private _commandCollection As SqlCommand()

		' Token: 0x0400589C RID: 22684
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
