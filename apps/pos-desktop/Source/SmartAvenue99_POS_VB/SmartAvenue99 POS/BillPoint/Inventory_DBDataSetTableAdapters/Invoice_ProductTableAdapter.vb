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
	' Token: 0x02000450 RID: 1104
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Invoice_ProductTableAdapter
		Inherits Component

		' Token: 0x17005809 RID: 22537
		' (get) Token: 0x0600E47C RID: 58492 RVA: 0x000654A7 File Offset: 0x000636A7
		' (set) Token: 0x0600E47D RID: 58493 RVA: 0x000654B1 File Offset: 0x000636B1
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E47E RID: 58494 RVA: 0x000654BA File Offset: 0x000636BA
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x1700580A RID: 22538
		' (get) Token: 0x0600E47F RID: 58495 RVA: 0x0087A860 File Offset: 0x00878A60
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

		' Token: 0x1700580B RID: 22539
		' (get) Token: 0x0600E480 RID: 58496 RVA: 0x0087A890 File Offset: 0x00878A90
		' (set) Token: 0x0600E481 RID: 58497 RVA: 0x0087A8C0 File Offset: 0x00878AC0
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

		' Token: 0x1700580C RID: 22540
		' (get) Token: 0x0600E482 RID: 58498 RVA: 0x0087A984 File Offset: 0x00878B84
		' (set) Token: 0x0600E483 RID: 58499 RVA: 0x0087A99C File Offset: 0x00878B9C
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

		' Token: 0x1700580D RID: 22541
		' (get) Token: 0x0600E484 RID: 58500 RVA: 0x0087AA84 File Offset: 0x00878C84
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

		' Token: 0x1700580E RID: 22542
		' (get) Token: 0x0600E485 RID: 58501 RVA: 0x0087AAB4 File Offset: 0x00878CB4
		' (set) Token: 0x0600E486 RID: 58502 RVA: 0x000654CC File Offset: 0x000636CC
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

		' Token: 0x0600E487 RID: 58503 RVA: 0x0087AACC File Offset: 0x00878CCC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Invoice_Product"
			dataTableMapping.ColumnMappings.Add("IPo_ID", "IPo_ID")
			dataTableMapping.ColumnMappings.Add("InvoiceID", "InvoiceID")
			dataTableMapping.ColumnMappings.Add("ProductID", "ProductID")
			dataTableMapping.ColumnMappings.Add("Barcode", "Barcode")
			dataTableMapping.ColumnMappings.Add("SalesRate", "SalesRate")
			dataTableMapping.ColumnMappings.Add("Qty", "Qty")
			dataTableMapping.ColumnMappings.Add("DiscountPer", "DiscountPer")
			dataTableMapping.ColumnMappings.Add("Discount", "Discount")
			dataTableMapping.ColumnMappings.Add("CGSTPer", "CGSTPer")
			dataTableMapping.ColumnMappings.Add("CGSTAmt", "CGSTAmt")
			dataTableMapping.ColumnMappings.Add("SGSTPer", "SGSTPer")
			dataTableMapping.ColumnMappings.Add("SGSTAmt", "SGSTAmt")
			dataTableMapping.ColumnMappings.Add("IGSTPer", "IGSTPer")
			dataTableMapping.ColumnMappings.Add("IGSTAmt", "IGSTAmt")
			dataTableMapping.ColumnMappings.Add("CESSPer", "CESSPer")
			dataTableMapping.ColumnMappings.Add("CESSAmt", "CESSAmt")
			dataTableMapping.ColumnMappings.Add("TotalAmount", "TotalAmount")
			dataTableMapping.ColumnMappings.Add("PurchaseRate", "PurchaseRate")
			dataTableMapping.ColumnMappings.Add("Margin", "Margin")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Invoice_Product] WHERE (([IPo_ID] = @Original_IPo_ID) AND ([InvoiceID] = @Original_InvoiceID) AND ([ProductID] = @Original_ProductID) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ([SalesRate] = @Original_SalesRate) AND ([Qty] = @Original_Qty) AND ([DiscountPer] = @Original_DiscountPer) AND ([Discount] = @Original_Discount) AND ([CGSTPer] = @Original_CGSTPer) AND ([CGSTAmt] = @Original_CGSTAmt) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ([TotalAmount] = @Original_TotalAmount) AND ([PurchaseRate] = @Original_PurchaseRate) AND ([Margin] = @Original_Margin))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IPo_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IPo_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SalesRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SalesRate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Discount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Discount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PurchaseRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PurchaseRate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Margin", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Margin", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Invoice_Product] ([InvoiceID], [ProductID], [Barcode], [SalesRate], [Qty], [DiscountPer], [Discount], [CGSTPer], [CGSTAmt], [SGSTPer], [SGSTAmt], [IGSTPer], [IGSTAmt], [CESSPer], [CESSAmt], [TotalAmount], [PurchaseRate], [Margin]) VALUES (@InvoiceID, @ProductID, @Barcode, @SalesRate, @Qty, @DiscountPer, @Discount, @CGSTPer, @CGSTAmt, @SGSTPer, @SGSTAmt, @IGSTPer, @IGSTAmt, @CESSPer, @CESSAmt, @TotalAmount, @PurchaseRate, @Margin);" & vbCrLf & "SELECT IPo_ID, InvoiceID, ProductID, Barcode, SalesRate, Qty, DiscountPer, Discount, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount, PurchaseRate, Margin FROM Invoice_Product WHERE (IPo_ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SalesRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SalesRate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Discount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Discount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PurchaseRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PurchaseRate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Margin", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Margin", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Invoice_Product] SET [InvoiceID] = @InvoiceID, [ProductID] = @ProductID, [Barcode] = @Barcode, [SalesRate] = @SalesRate, [Qty] = @Qty, [DiscountPer] = @DiscountPer, [Discount] = @Discount, [CGSTPer] = @CGSTPer, [CGSTAmt] = @CGSTAmt, [SGSTPer] = @SGSTPer, [SGSTAmt] = @SGSTAmt, [IGSTPer] = @IGSTPer, [IGSTAmt] = @IGSTAmt, [CESSPer] = @CESSPer, [CESSAmt] = @CESSAmt, [TotalAmount] = @TotalAmount, [PurchaseRate] = @PurchaseRate, [Margin] = @Margin WHERE (([IPo_ID] = @Original_IPo_ID) AND ([InvoiceID] = @Original_InvoiceID) AND ([ProductID] = @Original_ProductID) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ([SalesRate] = @Original_SalesRate) AND ([Qty] = @Original_Qty) AND ([DiscountPer] = @Original_DiscountPer) AND ([Discount] = @Original_Discount) AND ([CGSTPer] = @Original_CGSTPer) AND ([CGSTAmt] = @Original_CGSTAmt) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ([TotalAmount] = @Original_TotalAmount) AND ([PurchaseRate] = @Original_PurchaseRate) AND ([Margin] = @Original_Margin));" & vbCrLf & "SELECT IPo_ID, InvoiceID, ProductID, Barcode, SalesRate, Qty, DiscountPer, Discount, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount, PurchaseRate, Margin FROM Invoice_Product WHERE (IPo_ID = @IPo_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SalesRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SalesRate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Discount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Discount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PurchaseRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PurchaseRate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Margin", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Margin", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IPo_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IPo_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SalesRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SalesRate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Discount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Discount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PurchaseRate", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PurchaseRate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Margin", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Margin", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IPo_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IPo_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E488 RID: 58504 RVA: 0x000654D6 File Offset: 0x000636D6
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E489 RID: 58505 RVA: 0x0087C428 File Offset: 0x0087A628
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT IPo_ID, InvoiceID, ProductID, Barcode, SalesRate, Qty, DiscountPer, Discount, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount, PurchaseRate, Margin FROM dbo.Invoice_Product"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E48A RID: 58506 RVA: 0x0087C488 File Offset: 0x0087A688
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Invoice_ProductDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E48B RID: 58507 RVA: 0x0087C4D0 File Offset: 0x0087A6D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Invoice_ProductDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim invoice_ProductDataTable As Inventory_DBDataSet.Invoice_ProductDataTable = New Inventory_DBDataSet.Invoice_ProductDataTable()
			Me.Adapter.Fill(invoice_ProductDataTable)
			Return invoice_ProductDataTable
		End Function

		' Token: 0x0600E48C RID: 58508 RVA: 0x0087C50C File Offset: 0x0087A70C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Invoice_ProductDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E48D RID: 58509 RVA: 0x0087C52C File Offset: 0x0087A72C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Invoice_Product")
		End Function

		' Token: 0x0600E48E RID: 58510 RVA: 0x0087C550 File Offset: 0x0087A750
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E48F RID: 58511 RVA: 0x0087C578 File Offset: 0x0087A778
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E490 RID: 58512 RVA: 0x0087C598 File Offset: 0x0087A798
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_IPo_ID As Integer, Original_InvoiceID As Integer, Original_ProductID As Integer, Original_Barcode As String, Original_SalesRate As Decimal, Original_Qty As Decimal, Original_DiscountPer As Decimal, Original_Discount As Decimal, Original_CGSTPer As Decimal, Original_CGSTAmt As Decimal, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_TotalAmount As Decimal, Original_PurchaseRate As Decimal, Original_Margin As Decimal) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_IPo_ID
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_InvoiceID
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_ProductID
			Dim flag As Boolean = Original_Barcode = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Barcode
			End If
			Me.Adapter.DeleteCommand.Parameters(5).Value = Original_SalesRate
			Me.Adapter.DeleteCommand.Parameters(6).Value = Original_Qty
			Me.Adapter.DeleteCommand.Parameters(7).Value = Original_DiscountPer
			Me.Adapter.DeleteCommand.Parameters(8).Value = Original_Discount
			Me.Adapter.DeleteCommand.Parameters(9).Value = Original_CGSTPer
			Me.Adapter.DeleteCommand.Parameters(10).Value = Original_CGSTAmt
			Dim flag2 As Boolean = Original_SGSTPer IsNot Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = Original_SGSTAmt IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(13).Value = 0
				Me.Adapter.DeleteCommand.Parameters(14).Value = Original_SGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(13).Value = 1
				Me.Adapter.DeleteCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Original_IGSTPer IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(15).Value = 0
				Me.Adapter.DeleteCommand.Parameters(16).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(15).Value = 1
				Me.Adapter.DeleteCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(17).Value = 0
				Me.Adapter.DeleteCommand.Parameters(18).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(17).Value = 1
				Me.Adapter.DeleteCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_CESSPer IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(19).Value = 0
				Me.Adapter.DeleteCommand.Parameters(20).Value = Original_CESSPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(19).Value = 1
				Me.Adapter.DeleteCommand.Parameters(20).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_CESSAmt IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(21).Value = 0
				Me.Adapter.DeleteCommand.Parameters(22).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(21).Value = 1
				Me.Adapter.DeleteCommand.Parameters(22).Value = DBNull.Value
			End If
			Me.Adapter.DeleteCommand.Parameters(23).Value = Original_TotalAmount
			Me.Adapter.DeleteCommand.Parameters(24).Value = Original_PurchaseRate
			Me.Adapter.DeleteCommand.Parameters(25).Value = Original_Margin
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag8 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag8 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag9 As Boolean = state = ConnectionState.Closed
				If flag9 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E491 RID: 58513 RVA: 0x0087CC4C File Offset: 0x0087AE4C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(InvoiceID As Integer, ProductID As Integer, Barcode As String, SalesRate As Decimal, Qty As Decimal, DiscountPer As Decimal, Discount As Decimal, CGSTPer As Decimal, CGSTAmt As Decimal, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, TotalAmount As Decimal, PurchaseRate As Decimal, Margin As Decimal) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = InvoiceID
			Me.Adapter.InsertCommand.Parameters(1).Value = ProductID
			Dim flag As Boolean = Barcode = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = Barcode
			End If
			Me.Adapter.InsertCommand.Parameters(3).Value = SalesRate
			Me.Adapter.InsertCommand.Parameters(4).Value = Qty
			Me.Adapter.InsertCommand.Parameters(5).Value = DiscountPer
			Me.Adapter.InsertCommand.Parameters(6).Value = Discount
			Me.Adapter.InsertCommand.Parameters(7).Value = CGSTPer
			Me.Adapter.InsertCommand.Parameters(8).Value = CGSTAmt
			Dim flag2 As Boolean = SGSTPer IsNot Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = SGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = SGSTAmt IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = SGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = IGSTPer IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = IGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = IGSTAmt IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = IGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = CESSPer IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = CESSPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = CESSAmt IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(14).Value = CESSAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(14).Value = DBNull.Value
			End If
			Me.Adapter.InsertCommand.Parameters(15).Value = TotalAmount
			Me.Adapter.InsertCommand.Parameters(16).Value = PurchaseRate
			Me.Adapter.InsertCommand.Parameters(17).Value = Margin
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag8 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag8 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag9 As Boolean = state = ConnectionState.Closed
				If flag9 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E492 RID: 58514 RVA: 0x0087D0F4 File Offset: 0x0087B2F4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(InvoiceID As Integer, ProductID As Integer, Barcode As String, SalesRate As Decimal, Qty As Decimal, DiscountPer As Decimal, Discount As Decimal, CGSTPer As Decimal, CGSTAmt As Decimal, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, TotalAmount As Decimal, PurchaseRate As Decimal, Margin As Decimal, Original_IPo_ID As Integer, Original_InvoiceID As Integer, Original_ProductID As Integer, Original_Barcode As String, Original_SalesRate As Decimal, Original_Qty As Decimal, Original_DiscountPer As Decimal, Original_Discount As Decimal, Original_CGSTPer As Decimal, Original_CGSTAmt As Decimal, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_TotalAmount As Decimal, Original_PurchaseRate As Decimal, Original_Margin As Decimal, IPo_ID As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = InvoiceID
			Me.Adapter.UpdateCommand.Parameters(1).Value = ProductID
			Dim flag As Boolean = Barcode = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = SalesRate
			Me.Adapter.UpdateCommand.Parameters(4).Value = Qty
			Me.Adapter.UpdateCommand.Parameters(5).Value = DiscountPer
			Me.Adapter.UpdateCommand.Parameters(6).Value = Discount
			Me.Adapter.UpdateCommand.Parameters(7).Value = CGSTPer
			Me.Adapter.UpdateCommand.Parameters(8).Value = CGSTAmt
			Dim flag2 As Boolean = SGSTPer IsNot Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = SGSTAmt IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = SGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = IGSTPer IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = IGSTAmt IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = CESSPer IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = CESSAmt IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(15).Value = TotalAmount
			Me.Adapter.UpdateCommand.Parameters(16).Value = PurchaseRate
			Me.Adapter.UpdateCommand.Parameters(17).Value = Margin
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_IPo_ID
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_InvoiceID
			Me.Adapter.UpdateCommand.Parameters(20).Value = Original_ProductID
			Dim flag8 As Boolean = Original_Barcode = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(21).Value = 1
				Me.Adapter.UpdateCommand.Parameters(22).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(21).Value = 0
				Me.Adapter.UpdateCommand.Parameters(22).Value = Original_Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(23).Value = Original_SalesRate
			Me.Adapter.UpdateCommand.Parameters(24).Value = Original_Qty
			Me.Adapter.UpdateCommand.Parameters(25).Value = Original_DiscountPer
			Me.Adapter.UpdateCommand.Parameters(26).Value = Original_Discount
			Me.Adapter.UpdateCommand.Parameters(27).Value = Original_CGSTPer
			Me.Adapter.UpdateCommand.Parameters(28).Value = Original_CGSTAmt
			Dim flag9 As Boolean = Original_SGSTPer IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(29).Value = 0
				Me.Adapter.UpdateCommand.Parameters(30).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(29).Value = 1
				Me.Adapter.UpdateCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_SGSTAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(31).Value = 0
				Me.Adapter.UpdateCommand.Parameters(32).Value = Original_SGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(31).Value = 1
				Me.Adapter.UpdateCommand.Parameters(32).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_IGSTPer IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(33).Value = 0
				Me.Adapter.UpdateCommand.Parameters(34).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(33).Value = 1
				Me.Adapter.UpdateCommand.Parameters(34).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(35).Value = 0
				Me.Adapter.UpdateCommand.Parameters(36).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(35).Value = 1
				Me.Adapter.UpdateCommand.Parameters(36).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_CESSPer IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(37).Value = 0
				Me.Adapter.UpdateCommand.Parameters(38).Value = Original_CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(37).Value = 1
				Me.Adapter.UpdateCommand.Parameters(38).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = Original_CESSAmt IsNot Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(39).Value = 0
				Me.Adapter.UpdateCommand.Parameters(40).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(39).Value = 1
				Me.Adapter.UpdateCommand.Parameters(40).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(41).Value = Original_TotalAmount
			Me.Adapter.UpdateCommand.Parameters(42).Value = Original_PurchaseRate
			Me.Adapter.UpdateCommand.Parameters(43).Value = Original_Margin
			Me.Adapter.UpdateCommand.Parameters(44).Value = IPo_ID
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag15 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag15 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag16 As Boolean = state = ConnectionState.Closed
				If flag16 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E493 RID: 58515 RVA: 0x0087DBD8 File Offset: 0x0087BDD8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(InvoiceID As Integer, ProductID As Integer, Barcode As String, SalesRate As Decimal, Qty As Decimal, DiscountPer As Decimal, Discount As Decimal, CGSTPer As Decimal, CGSTAmt As Decimal, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, TotalAmount As Decimal, PurchaseRate As Decimal, Margin As Decimal, Original_IPo_ID As Integer, Original_InvoiceID As Integer, Original_ProductID As Integer, Original_Barcode As String, Original_SalesRate As Decimal, Original_Qty As Decimal, Original_DiscountPer As Decimal, Original_Discount As Decimal, Original_CGSTPer As Decimal, Original_CGSTAmt As Decimal, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_TotalAmount As Decimal, Original_PurchaseRate As Decimal, Original_Margin As Decimal) As Integer
			Return Me.Update(InvoiceID, ProductID, Barcode, SalesRate, Qty, DiscountPer, Discount, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount, PurchaseRate, Margin, Original_IPo_ID, Original_InvoiceID, Original_ProductID, Original_Barcode, Original_SalesRate, Original_Qty, Original_DiscountPer, Original_Discount, Original_CGSTPer, Original_CGSTAmt, Original_SGSTPer, Original_SGSTAmt, Original_IGSTPer, Original_IGSTAmt, Original_CESSPer, Original_CESSAmt, Original_TotalAmount, Original_PurchaseRate, Original_Margin, Original_IPo_ID)
		End Function

		' Token: 0x0400585D RID: 22621
		Private _connection As SqlConnection

		' Token: 0x0400585E RID: 22622
		Private _transaction As SqlTransaction

		' Token: 0x0400585F RID: 22623
		Private _commandCollection As SqlCommand()

		' Token: 0x04005860 RID: 22624
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
