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
	' Token: 0x0200045A RID: 1114
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class PurchaseOrder_JoinTableAdapter
		Inherits Component

		' Token: 0x17005845 RID: 22597
		' (get) Token: 0x0600E56C RID: 58732 RVA: 0x000657E5 File Offset: 0x000639E5
		' (set) Token: 0x0600E56D RID: 58733 RVA: 0x000657EF File Offset: 0x000639EF
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E56E RID: 58734 RVA: 0x000657F8 File Offset: 0x000639F8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005846 RID: 22598
		' (get) Token: 0x0600E56F RID: 58735 RVA: 0x0088F6A4 File Offset: 0x0088D8A4
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

		' Token: 0x17005847 RID: 22599
		' (get) Token: 0x0600E570 RID: 58736 RVA: 0x0088F6D4 File Offset: 0x0088D8D4
		' (set) Token: 0x0600E571 RID: 58737 RVA: 0x0088F704 File Offset: 0x0088D904
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

		' Token: 0x17005848 RID: 22600
		' (get) Token: 0x0600E572 RID: 58738 RVA: 0x0088F7C8 File Offset: 0x0088D9C8
		' (set) Token: 0x0600E573 RID: 58739 RVA: 0x0088F7E0 File Offset: 0x0088D9E0
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

		' Token: 0x17005849 RID: 22601
		' (get) Token: 0x0600E574 RID: 58740 RVA: 0x0088F8C8 File Offset: 0x0088DAC8
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

		' Token: 0x1700584A RID: 22602
		' (get) Token: 0x0600E575 RID: 58741 RVA: 0x0088F8F8 File Offset: 0x0088DAF8
		' (set) Token: 0x0600E576 RID: 58742 RVA: 0x0006580A File Offset: 0x00063A0A
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

		' Token: 0x0600E577 RID: 58743 RVA: 0x0088F910 File Offset: 0x0088DB10
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "PurchaseOrder_Join"
			dataTableMapping.ColumnMappings.Add("POJ_ID", "POJ_ID")
			dataTableMapping.ColumnMappings.Add("PurchaseOrderID", "PurchaseOrderID")
			dataTableMapping.ColumnMappings.Add("ProductID", "ProductID")
			dataTableMapping.ColumnMappings.Add("Qty", "Qty")
			dataTableMapping.ColumnMappings.Add("Price", "Price")
			dataTableMapping.ColumnMappings.Add("CGSTPer", "CGSTPer")
			dataTableMapping.ColumnMappings.Add("CGSTAmt", "CGSTAmt")
			dataTableMapping.ColumnMappings.Add("SGSTPer", "SGSTPer")
			dataTableMapping.ColumnMappings.Add("SGSTAmt", "SGSTAmt")
			dataTableMapping.ColumnMappings.Add("IGSTPer", "IGSTPer")
			dataTableMapping.ColumnMappings.Add("IGSTAmt", "IGSTAmt")
			dataTableMapping.ColumnMappings.Add("CESSPer", "CESSPer")
			dataTableMapping.ColumnMappings.Add("CESSAmt", "CESSAmt")
			dataTableMapping.ColumnMappings.Add("DiscountPer", "DiscountPer")
			dataTableMapping.ColumnMappings.Add("DiscountAmt", "DiscountAmt")
			dataTableMapping.ColumnMappings.Add("TotalAmount", "TotalAmount")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[PurchaseOrder_Join] WHERE (([POJ_ID] = @Original_POJ_ID) AND ([PurchaseOrderID] = @Original_PurchaseOrderID) AND ([ProductID] = @Original_ProductID) AND ([Qty] = @Original_Qty) AND ([Price] = @Original_Price) AND ((@IsNull_CGSTPer = 1 AND [CGSTPer] IS NULL) OR ([CGSTPer] = @Original_CGSTPer)) AND ((@IsNull_CGSTAmt = 1 AND [CGSTAmt] IS NULL) OR ([CGSTAmt] = @Original_CGSTAmt)) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ((@IsNull_DiscountPer = 1 AND [DiscountPer] IS NULL) OR ([DiscountPer] = @Original_DiscountPer)) AND ((@IsNull_DiscountAmt = 1 AND [DiscountAmt] IS NULL) OR ([DiscountAmt] = @Original_DiscountAmt)) AND ((@IsNull_TotalAmount = 1 AND [TotalAmount] IS NULL) OR ([TotalAmount] = @Original_TotalAmount)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_POJ_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "POJ_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PurchaseOrderID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseOrderID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_DiscountPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DiscountPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_DiscountAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DiscountAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_DiscountAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_TotalAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalAmount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[PurchaseOrder_Join] ([PurchaseOrderID], [ProductID], [Qty], [Price], [CGSTPer], [CGSTAmt], [SGSTPer], [SGSTAmt], [IGSTPer], [IGSTAmt], [CESSPer], [CESSAmt], [DiscountPer], [DiscountAmt], [TotalAmount]) VALUES (@PurchaseOrderID, @ProductID, @Qty, @Price, @CGSTPer, @CGSTAmt, @SGSTPer, @SGSTAmt, @IGSTPer, @IGSTAmt, @CESSPer, @CESSAmt, @DiscountPer, @DiscountAmt, @TotalAmount);" & vbCrLf & "SELECT POJ_ID, PurchaseOrderID, ProductID, Qty, Price, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, DiscountPer, DiscountAmt, TotalAmount FROM PurchaseOrder_Join WHERE (POJ_ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PurchaseOrderID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseOrderID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DiscountAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[PurchaseOrder_Join] SET [PurchaseOrderID] = @PurchaseOrderID, [ProductID] = @ProductID, [Qty] = @Qty, [Price] = @Price, [CGSTPer] = @CGSTPer, [CGSTAmt] = @CGSTAmt, [SGSTPer] = @SGSTPer, [SGSTAmt] = @SGSTAmt, [IGSTPer] = @IGSTPer, [IGSTAmt] = @IGSTAmt, [CESSPer] = @CESSPer, [CESSAmt] = @CESSAmt, [DiscountPer] = @DiscountPer, [DiscountAmt] = @DiscountAmt, [TotalAmount] = @TotalAmount WHERE (([POJ_ID] = @Original_POJ_ID) AND ([PurchaseOrderID] = @Original_PurchaseOrderID) AND ([ProductID] = @Original_ProductID) AND ([Qty] = @Original_Qty) AND ([Price] = @Original_Price) AND ((@IsNull_CGSTPer = 1 AND [CGSTPer] IS NULL) OR ([CGSTPer] = @Original_CGSTPer)) AND ((@IsNull_CGSTAmt = 1 AND [CGSTAmt] IS NULL) OR ([CGSTAmt] = @Original_CGSTAmt)) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ((@IsNull_DiscountPer = 1 AND [DiscountPer] IS NULL) OR ([DiscountPer] = @Original_DiscountPer)) AND ((@IsNull_DiscountAmt = 1 AND [DiscountAmt] IS NULL) OR ([DiscountAmt] = @Original_DiscountAmt)) AND ((@IsNull_TotalAmount = 1 AND [TotalAmount] IS NULL) OR ([TotalAmount] = @Original_TotalAmount)));" & vbCrLf & "SELECT POJ_ID, PurchaseOrderID, ProductID, Qty, Price, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, DiscountPer, DiscountAmt, TotalAmount FROM PurchaseOrder_Join WHERE (POJ_ID = @POJ_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PurchaseOrderID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseOrderID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DiscountAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_POJ_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "POJ_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PurchaseOrderID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseOrderID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_DiscountPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DiscountPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_DiscountAmt", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "DiscountAmt", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_DiscountAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_TotalAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TotalAmount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@POJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "POJ_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E578 RID: 58744 RVA: 0x00065814 File Offset: 0x00063A14
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E579 RID: 58745 RVA: 0x00891120 File Offset: 0x0088F320
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT POJ_ID, PurchaseOrderID, ProductID, Qty, Price, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, DiscountPer, DiscountAmt, TotalAmount FROM dbo.PurchaseOrder_Join"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E57A RID: 58746 RVA: 0x00891180 File Offset: 0x0088F380
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.PurchaseOrder_JoinDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E57B RID: 58747 RVA: 0x008911C8 File Offset: 0x0088F3C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.PurchaseOrder_JoinDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim purchaseOrder_JoinDataTable As Inventory_DBDataSet.PurchaseOrder_JoinDataTable = New Inventory_DBDataSet.PurchaseOrder_JoinDataTable()
			Me.Adapter.Fill(purchaseOrder_JoinDataTable)
			Return purchaseOrder_JoinDataTable
		End Function

		' Token: 0x0600E57C RID: 58748 RVA: 0x00891204 File Offset: 0x0088F404
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.PurchaseOrder_JoinDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E57D RID: 58749 RVA: 0x00891224 File Offset: 0x0088F424
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "PurchaseOrder_Join")
		End Function

		' Token: 0x0600E57E RID: 58750 RVA: 0x00891248 File Offset: 0x0088F448
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E57F RID: 58751 RVA: 0x00891270 File Offset: 0x0088F470
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E580 RID: 58752 RVA: 0x00891290 File Offset: 0x0088F490
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_POJ_ID As Integer, Original_PurchaseOrderID As Integer, Original_ProductID As Integer, Original_Qty As Decimal, Original_Price As Decimal, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_DiscountPer As Decimal?, Original_DiscountAmt As Decimal?, Original_TotalAmount As Decimal?) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_POJ_ID
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_PurchaseOrderID
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_ProductID
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_Qty
			Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Price
			Dim flag As Boolean = Original_CGSTPer IsNot Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_CGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag2 As Boolean = Original_CGSTAmt IsNot Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_CGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = Original_SGSTPer IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Original_SGSTAmt IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_SGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_IGSTPer IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(13).Value = 0
				Me.Adapter.DeleteCommand.Parameters(14).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(13).Value = 1
				Me.Adapter.DeleteCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(15).Value = 0
				Me.Adapter.DeleteCommand.Parameters(16).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(15).Value = 1
				Me.Adapter.DeleteCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_CESSPer IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(17).Value = 0
				Me.Adapter.DeleteCommand.Parameters(18).Value = Original_CESSPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(17).Value = 1
				Me.Adapter.DeleteCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_CESSAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(19).Value = 0
				Me.Adapter.DeleteCommand.Parameters(20).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(19).Value = 1
				Me.Adapter.DeleteCommand.Parameters(20).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Original_DiscountPer IsNot Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(21).Value = 0
				Me.Adapter.DeleteCommand.Parameters(22).Value = Original_DiscountPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(21).Value = 1
				Me.Adapter.DeleteCommand.Parameters(22).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_DiscountAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.DeleteCommand.Parameters(23).Value = 0
				Me.Adapter.DeleteCommand.Parameters(24).Value = Original_DiscountAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(23).Value = 1
				Me.Adapter.DeleteCommand.Parameters(24).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_TotalAmount IsNot Nothing
			If flag11 Then
				Me.Adapter.DeleteCommand.Parameters(25).Value = 0
				Me.Adapter.DeleteCommand.Parameters(26).Value = Original_TotalAmount.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(25).Value = 1
				Me.Adapter.DeleteCommand.Parameters(26).Value = DBNull.Value
			End If
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag12 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag12 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag13 As Boolean = state = ConnectionState.Closed
				If flag13 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E581 RID: 58753 RVA: 0x00891AE0 File Offset: 0x0088FCE0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(PurchaseOrderID As Integer, ProductID As Integer, Qty As Decimal, Price As Decimal, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, DiscountPer As Decimal?, DiscountAmt As Decimal?, TotalAmount As Decimal?) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = PurchaseOrderID
			Me.Adapter.InsertCommand.Parameters(1).Value = ProductID
			Me.Adapter.InsertCommand.Parameters(2).Value = Qty
			Me.Adapter.InsertCommand.Parameters(3).Value = Price
			Dim flag As Boolean = CGSTPer IsNot Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(4).Value = CGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag2 As Boolean = CGSTAmt IsNot Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = CGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = SGSTPer IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = SGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = SGSTAmt IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = SGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = IGSTPer IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = IGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = IGSTAmt IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = IGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = CESSPer IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = CESSPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CESSAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = CESSAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = DiscountPer IsNot Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = DiscountPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = DiscountAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = DiscountAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = TotalAmount IsNot Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(14).Value = TotalAmount.Value
			Else
				Me.Adapter.InsertCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag12 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag12 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag13 As Boolean = state = ConnectionState.Closed
				If flag13 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E582 RID: 58754 RVA: 0x00892008 File Offset: 0x00890208
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PurchaseOrderID As Integer, ProductID As Integer, Qty As Decimal, Price As Decimal, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, DiscountPer As Decimal?, DiscountAmt As Decimal?, TotalAmount As Decimal?, Original_POJ_ID As Integer, Original_PurchaseOrderID As Integer, Original_ProductID As Integer, Original_Qty As Decimal, Original_Price As Decimal, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_DiscountPer As Decimal?, Original_DiscountAmt As Decimal?, Original_TotalAmount As Decimal?, POJ_ID As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = PurchaseOrderID
			Me.Adapter.UpdateCommand.Parameters(1).Value = ProductID
			Me.Adapter.UpdateCommand.Parameters(2).Value = Qty
			Me.Adapter.UpdateCommand.Parameters(3).Value = Price
			Dim flag As Boolean = CGSTPer IsNot Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = CGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag2 As Boolean = CGSTAmt IsNot Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = CGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = SGSTPer IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = SGSTAmt IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = SGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = IGSTPer IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = IGSTAmt IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = CESSPer IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CESSAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = DiscountPer IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = DiscountPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = DiscountAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = DiscountAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = TotalAmount IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = TotalAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(15).Value = Original_POJ_ID
			Me.Adapter.UpdateCommand.Parameters(16).Value = Original_PurchaseOrderID
			Me.Adapter.UpdateCommand.Parameters(17).Value = Original_ProductID
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_Qty
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_Price
			Dim flag12 As Boolean = Original_CGSTPer IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(20).Value = 0
				Me.Adapter.UpdateCommand.Parameters(21).Value = Original_CGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(20).Value = 1
				Me.Adapter.UpdateCommand.Parameters(21).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_CGSTAmt IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(22).Value = 0
				Me.Adapter.UpdateCommand.Parameters(23).Value = Original_CGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(22).Value = 1
				Me.Adapter.UpdateCommand.Parameters(23).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = Original_SGSTPer IsNot Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(24).Value = 0
				Me.Adapter.UpdateCommand.Parameters(25).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(24).Value = 1
				Me.Adapter.UpdateCommand.Parameters(25).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = Original_SGSTAmt IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(26).Value = 0
				Me.Adapter.UpdateCommand.Parameters(27).Value = Original_SGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(26).Value = 1
				Me.Adapter.UpdateCommand.Parameters(27).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = Original_IGSTPer IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(28).Value = 0
				Me.Adapter.UpdateCommand.Parameters(29).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(28).Value = 1
				Me.Adapter.UpdateCommand.Parameters(29).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(30).Value = 0
				Me.Adapter.UpdateCommand.Parameters(31).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(30).Value = 1
				Me.Adapter.UpdateCommand.Parameters(31).Value = DBNull.Value
			End If
			Dim flag18 As Boolean = Original_CESSPer IsNot Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(32).Value = 0
				Me.Adapter.UpdateCommand.Parameters(33).Value = Original_CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(32).Value = 1
				Me.Adapter.UpdateCommand.Parameters(33).Value = DBNull.Value
			End If
			Dim flag19 As Boolean = Original_CESSAmt IsNot Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(34).Value = 0
				Me.Adapter.UpdateCommand.Parameters(35).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(34).Value = 1
				Me.Adapter.UpdateCommand.Parameters(35).Value = DBNull.Value
			End If
			Dim flag20 As Boolean = Original_DiscountPer IsNot Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(36).Value = 0
				Me.Adapter.UpdateCommand.Parameters(37).Value = Original_DiscountPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(36).Value = 1
				Me.Adapter.UpdateCommand.Parameters(37).Value = DBNull.Value
			End If
			Dim flag21 As Boolean = Original_DiscountAmt IsNot Nothing
			If flag21 Then
				Me.Adapter.UpdateCommand.Parameters(38).Value = 0
				Me.Adapter.UpdateCommand.Parameters(39).Value = Original_DiscountAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(38).Value = 1
				Me.Adapter.UpdateCommand.Parameters(39).Value = DBNull.Value
			End If
			Dim flag22 As Boolean = Original_TotalAmount IsNot Nothing
			If flag22 Then
				Me.Adapter.UpdateCommand.Parameters(40).Value = 0
				Me.Adapter.UpdateCommand.Parameters(41).Value = Original_TotalAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(40).Value = 1
				Me.Adapter.UpdateCommand.Parameters(41).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(42).Value = POJ_ID
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag23 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag23 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag24 As Boolean = state = ConnectionState.Closed
				If flag24 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E583 RID: 58755 RVA: 0x00892D08 File Offset: 0x00890F08
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PurchaseOrderID As Integer, ProductID As Integer, Qty As Decimal, Price As Decimal, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, DiscountPer As Decimal?, DiscountAmt As Decimal?, TotalAmount As Decimal?, Original_POJ_ID As Integer, Original_PurchaseOrderID As Integer, Original_ProductID As Integer, Original_Qty As Decimal, Original_Price As Decimal, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_DiscountPer As Decimal?, Original_DiscountAmt As Decimal?, Original_TotalAmount As Decimal?) As Integer
			Return Me.Update(PurchaseOrderID, ProductID, Qty, Price, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, DiscountPer, DiscountAmt, TotalAmount, Original_POJ_ID, Original_PurchaseOrderID, Original_ProductID, Original_Qty, Original_Price, Original_CGSTPer, Original_CGSTAmt, Original_SGSTPer, Original_SGSTAmt, Original_IGSTPer, Original_IGSTAmt, Original_CESSPer, Original_CESSAmt, Original_DiscountPer, Original_DiscountAmt, Original_TotalAmount, Original_POJ_ID)
		End Function

		' Token: 0x0400588F RID: 22671
		Private _connection As SqlConnection

		' Token: 0x04005890 RID: 22672
		Private _transaction As SqlTransaction

		' Token: 0x04005891 RID: 22673
		Private _commandCollection As SqlCommand()

		' Token: 0x04005892 RID: 22674
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
