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
	' Token: 0x02000457 RID: 1111
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class ProductTableAdapter
		Inherits Component

		' Token: 0x17005833 RID: 22579
		' (get) Token: 0x0600E524 RID: 58660 RVA: 0x000656EC File Offset: 0x000638EC
		' (set) Token: 0x0600E525 RID: 58661 RVA: 0x000656F6 File Offset: 0x000638F6
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E526 RID: 58662 RVA: 0x000656FF File Offset: 0x000638FF
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005834 RID: 22580
		' (get) Token: 0x0600E527 RID: 58663 RVA: 0x0088901C File Offset: 0x0088721C
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

		' Token: 0x17005835 RID: 22581
		' (get) Token: 0x0600E528 RID: 58664 RVA: 0x0088904C File Offset: 0x0088724C
		' (set) Token: 0x0600E529 RID: 58665 RVA: 0x0088907C File Offset: 0x0088727C
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

		' Token: 0x17005836 RID: 22582
		' (get) Token: 0x0600E52A RID: 58666 RVA: 0x00889140 File Offset: 0x00887340
		' (set) Token: 0x0600E52B RID: 58667 RVA: 0x00889158 File Offset: 0x00887358
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

		' Token: 0x17005837 RID: 22583
		' (get) Token: 0x0600E52C RID: 58668 RVA: 0x00889240 File Offset: 0x00887440
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

		' Token: 0x17005838 RID: 22584
		' (get) Token: 0x0600E52D RID: 58669 RVA: 0x00889270 File Offset: 0x00887470
		' (set) Token: 0x0600E52E RID: 58670 RVA: 0x00065711 File Offset: 0x00063911
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

		' Token: 0x0600E52F RID: 58671 RVA: 0x00889288 File Offset: 0x00887488
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Product"
			dataTableMapping.ColumnMappings.Add("PID", "PID")
			dataTableMapping.ColumnMappings.Add("ProductCode", "ProductCode")
			dataTableMapping.ColumnMappings.Add("ProductName", "ProductName")
			dataTableMapping.ColumnMappings.Add("SubCategoryID", "SubCategoryID")
			dataTableMapping.ColumnMappings.Add("HSNCode", "HSNCode")
			dataTableMapping.ColumnMappings.Add("PartNo", "PartNo")
			dataTableMapping.ColumnMappings.Add("Description", "Description")
			dataTableMapping.ColumnMappings.Add("CostPrice", "CostPrice")
			dataTableMapping.ColumnMappings.Add("SellingPrice", "SellingPrice")
			dataTableMapping.ColumnMappings.Add("Discount", "Discount")
			dataTableMapping.ColumnMappings.Add("CGST", "CGST")
			dataTableMapping.ColumnMappings.Add("SGST", "SGST")
			dataTableMapping.ColumnMappings.Add("CESS", "CESS")
			dataTableMapping.ColumnMappings.Add("Barcode", "Barcode")
			dataTableMapping.ColumnMappings.Add("ReorderPoint", "ReorderPoint")
			dataTableMapping.ColumnMappings.Add("OpeningStock", "OpeningStock")
			dataTableMapping.ColumnMappings.Add("PurchaseUnit", "PurchaseUnit")
			dataTableMapping.ColumnMappings.Add("SalesUnit", "SalesUnit")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Product] WHERE (([PID] = @Original_PID) AND ([ProductCode] = @Original_ProductCode) AND ([ProductName] = @Original_ProductName) AND ([SubCategoryID] = @Original_SubCategoryID) AND ((@IsNull_HSNCode = 1 AND [HSNCode] IS NULL) OR ([HSNCode] = @Original_HSNCode)) AND ((@IsNull_PartNo = 1 AND [PartNo] IS NULL) OR ([PartNo] = @Original_PartNo)) AND ([CostPrice] = @Original_CostPrice) AND ([SellingPrice] = @Original_SellingPrice) AND ([Discount] = @Original_Discount) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ([ReorderPoint] = @Original_ReorderPoint) AND ([OpeningStock] = @Original_OpeningStock) AND ((@IsNull_PurchaseUnit = 1 AND [PurchaseUnit] IS NULL) OR ([PurchaseUnit] = @Original_PurchaseUnit)) AND ((@IsNull_SalesUnit = 1 AND [SalesUnit] IS NULL) OR ([SalesUnit] = @Original_SalesUnit)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ProductCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ProductName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SubCategoryID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubCategoryID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_HSNCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HSNCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_HSNCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "HSNCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PartNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PartNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PartNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PartNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CostPrice", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CostPrice", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SellingPrice", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SellingPrice", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Discount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Discount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CESS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESS", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ReorderPoint", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReorderPoint", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_OpeningStock", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OpeningStock", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PurchaseUnit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseUnit", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PurchaseUnit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseUnit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SalesUnit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesUnit", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SalesUnit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesUnit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Product] ([PID], [ProductCode], [ProductName], [SubCategoryID], [HSNCode], [PartNo], [Description], [CostPrice], [SellingPrice], [Discount], [CGST], [SGST], [CESS], [Barcode], [ReorderPoint], [OpeningStock], [PurchaseUnit], [SalesUnit]) VALUES (@PID, @ProductCode, @ProductName, @SubCategoryID, @HSNCode, @PartNo, @Description, @CostPrice, @SellingPrice, @Discount, @CGST, @SGST, @CESS, @Barcode, @ReorderPoint, @OpeningStock, @PurchaseUnit, @SalesUnit);" & vbCrLf & "SELECT PID, ProductCode, ProductName, SubCategoryID, HSNCode, PartNo, Description, CostPrice, SellingPrice, Discount, CGST, SGST, CESS, Barcode, ReorderPoint, OpeningStock, PurchaseUnit, SalesUnit FROM Product WHERE (PID = @PID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ProductCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ProductName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SubCategoryID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubCategoryID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@HSNCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "HSNCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PartNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PartNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Description", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CostPrice", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CostPrice", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SellingPrice", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SellingPrice", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Discount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Discount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ReorderPoint", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReorderPoint", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OpeningStock", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OpeningStock", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PurchaseUnit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseUnit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SalesUnit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesUnit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Product] SET [PID] = @PID, [ProductCode] = @ProductCode, [ProductName] = @ProductName, [SubCategoryID] = @SubCategoryID, [HSNCode] = @HSNCode, [PartNo] = @PartNo, [Description] = @Description, [CostPrice] = @CostPrice, [SellingPrice] = @SellingPrice, [Discount] = @Discount, [CGST] = @CGST, [SGST] = @SGST, [CESS] = @CESS, [Barcode] = @Barcode, [ReorderPoint] = @ReorderPoint, [OpeningStock] = @OpeningStock, [PurchaseUnit] = @PurchaseUnit, [SalesUnit] = @SalesUnit WHERE (([PID] = @Original_PID) AND ([ProductCode] = @Original_ProductCode) AND ([ProductName] = @Original_ProductName) AND ([SubCategoryID] = @Original_SubCategoryID) AND ((@IsNull_HSNCode = 1 AND [HSNCode] IS NULL) OR ([HSNCode] = @Original_HSNCode)) AND ((@IsNull_PartNo = 1 AND [PartNo] IS NULL) OR ([PartNo] = @Original_PartNo)) AND ([CostPrice] = @Original_CostPrice) AND ([SellingPrice] = @Original_SellingPrice) AND ([Discount] = @Original_Discount) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ([ReorderPoint] = @Original_ReorderPoint) AND ([OpeningStock] = @Original_OpeningStock) AND ((@IsNull_PurchaseUnit = 1 AND [PurchaseUnit] IS NULL) OR ([PurchaseUnit] = @Original_PurchaseUnit)) AND ((@IsNull_SalesUnit = 1 AND [SalesUnit] IS NULL) OR ([SalesUnit] = @Original_SalesUnit)));" & vbCrLf & "SELECT PID, ProductCode, ProductName, SubCategoryID, HSNCode, PartNo, Description, CostPrice, SellingPrice, Discount, CGST, SGST, CESS, Barcode, ReorderPoint, OpeningStock, PurchaseUnit, SalesUnit FROM Product WHERE (PID = @PID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ProductCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ProductName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SubCategoryID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubCategoryID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@HSNCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "HSNCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PartNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PartNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Description", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Description", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CostPrice", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CostPrice", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SellingPrice", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SellingPrice", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Discount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Discount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ReorderPoint", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReorderPoint", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OpeningStock", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OpeningStock", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PurchaseUnit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseUnit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SalesUnit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesUnit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ProductCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ProductName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SubCategoryID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubCategoryID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_HSNCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "HSNCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_HSNCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "HSNCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PartNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PartNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PartNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PartNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CostPrice", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CostPrice", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SellingPrice", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SellingPrice", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Discount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Discount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CESS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESS", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ReorderPoint", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReorderPoint", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_OpeningStock", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OpeningStock", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PurchaseUnit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseUnit", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PurchaseUnit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseUnit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SalesUnit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesUnit", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SalesUnit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesUnit", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E530 RID: 58672 RVA: 0x0006571B File Offset: 0x0006391B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E531 RID: 58673 RVA: 0x0088AB08 File Offset: 0x00888D08
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT PID, ProductCode, ProductName, SubCategoryID, HSNCode, PartNo, Description, CostPrice, SellingPrice, Discount, CGST, SGST, CESS, Barcode, ReorderPoint, OpeningStock, PurchaseUnit, SalesUnit FROM dbo.Product"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E532 RID: 58674 RVA: 0x0088AB68 File Offset: 0x00888D68
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.ProductDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E533 RID: 58675 RVA: 0x0088ABB0 File Offset: 0x00888DB0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.ProductDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim productDataTable As Inventory_DBDataSet.ProductDataTable = New Inventory_DBDataSet.ProductDataTable()
			Me.Adapter.Fill(productDataTable)
			Return productDataTable
		End Function

		' Token: 0x0600E534 RID: 58676 RVA: 0x0088ABEC File Offset: 0x00888DEC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.ProductDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E535 RID: 58677 RVA: 0x0088AC0C File Offset: 0x00888E0C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Product")
		End Function

		' Token: 0x0600E536 RID: 58678 RVA: 0x0088AC30 File Offset: 0x00888E30
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E537 RID: 58679 RVA: 0x0088AC58 File Offset: 0x00888E58
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E538 RID: 58680 RVA: 0x0088AC78 File Offset: 0x00888E78
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_PID As Integer, Original_ProductCode As String, Original_ProductName As String, Original_SubCategoryID As Integer, Original_HSNCode As String, Original_PartNo As String, Original_CostPrice As Decimal, Original_SellingPrice As Decimal, Original_Discount As Decimal, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_CESS As Decimal?, Original_Barcode As String, Original_ReorderPoint As Integer, Original_OpeningStock As Decimal, Original_PurchaseUnit As String, Original_SalesUnit As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_PID
			Dim flag As Boolean = Original_ProductCode = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_ProductCode")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_ProductCode
			Dim flag2 As Boolean = Original_ProductName = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_ProductName")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_ProductName
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_SubCategoryID
			Dim flag3 As Boolean = Original_HSNCode = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(4).Value = 1
				Me.Adapter.DeleteCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(4).Value = 0
				Me.Adapter.DeleteCommand.Parameters(5).Value = Original_HSNCode
			End If
			Dim flag4 As Boolean = Original_PartNo = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(6).Value = 1
				Me.Adapter.DeleteCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(6).Value = 0
				Me.Adapter.DeleteCommand.Parameters(7).Value = Original_PartNo
			End If
			Me.Adapter.DeleteCommand.Parameters(8).Value = Original_CostPrice
			Me.Adapter.DeleteCommand.Parameters(9).Value = Original_SellingPrice
			Me.Adapter.DeleteCommand.Parameters(10).Value = Original_Discount
			Dim flag5 As Boolean = Original_CGST IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_CGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_SGST IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(13).Value = 0
				Me.Adapter.DeleteCommand.Parameters(14).Value = Original_SGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(13).Value = 1
				Me.Adapter.DeleteCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_CESS IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(15).Value = 0
				Me.Adapter.DeleteCommand.Parameters(16).Value = Original_CESS.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(15).Value = 1
				Me.Adapter.DeleteCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_Barcode = Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(17).Value = 1
				Me.Adapter.DeleteCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(17).Value = 0
				Me.Adapter.DeleteCommand.Parameters(18).Value = Original_Barcode
			End If
			Me.Adapter.DeleteCommand.Parameters(19).Value = Original_ReorderPoint
			Me.Adapter.DeleteCommand.Parameters(20).Value = Original_OpeningStock
			Dim flag9 As Boolean = Original_PurchaseUnit = Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(21).Value = 1
				Me.Adapter.DeleteCommand.Parameters(22).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(21).Value = 0
				Me.Adapter.DeleteCommand.Parameters(22).Value = Original_PurchaseUnit
			End If
			Dim flag10 As Boolean = Original_SalesUnit = Nothing
			If flag10 Then
				Me.Adapter.DeleteCommand.Parameters(23).Value = 1
				Me.Adapter.DeleteCommand.Parameters(24).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(23).Value = 0
				Me.Adapter.DeleteCommand.Parameters(24).Value = Original_SalesUnit
			End If
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag11 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag11 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag12 As Boolean = state = ConnectionState.Closed
				If flag12 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E539 RID: 58681 RVA: 0x0088B354 File Offset: 0x00889554
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(PID As Integer, ProductCode As String, ProductName As String, SubCategoryID As Integer, HSNCode As String, PartNo As String, Description As String, CostPrice As Decimal, SellingPrice As Decimal, Discount As Decimal, CGST As Decimal?, SGST As Decimal?, CESS As Decimal?, Barcode As String, ReorderPoint As Integer, OpeningStock As Decimal, PurchaseUnit As String, SalesUnit As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = PID
			Dim flag As Boolean = ProductCode = Nothing
			If flag Then
				Throw New ArgumentNullException("ProductCode")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = ProductCode
			Dim flag2 As Boolean = ProductName = Nothing
			If flag2 Then
				Throw New ArgumentNullException("ProductName")
			End If
			Me.Adapter.InsertCommand.Parameters(2).Value = ProductName
			Me.Adapter.InsertCommand.Parameters(3).Value = SubCategoryID
			Dim flag3 As Boolean = HSNCode = Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = HSNCode
			End If
			Dim flag4 As Boolean = PartNo = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = PartNo
			End If
			Dim flag5 As Boolean = Description = Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = Description
			End If
			Me.Adapter.InsertCommand.Parameters(7).Value = CostPrice
			Me.Adapter.InsertCommand.Parameters(8).Value = SellingPrice
			Me.Adapter.InsertCommand.Parameters(9).Value = Discount
			Dim flag6 As Boolean = CGST IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = CGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = SGST IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = SGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CESS IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = CESS.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Barcode = Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = Barcode
			End If
			Me.Adapter.InsertCommand.Parameters(14).Value = ReorderPoint
			Me.Adapter.InsertCommand.Parameters(15).Value = OpeningStock
			Dim flag10 As Boolean = PurchaseUnit = Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(16).Value = PurchaseUnit
			End If
			Dim flag11 As Boolean = SalesUnit = Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(17).Value = SalesUnit
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

		' Token: 0x0600E53A RID: 58682 RVA: 0x0088B854 File Offset: 0x00889A54
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PID As Integer, ProductCode As String, ProductName As String, SubCategoryID As Integer, HSNCode As String, PartNo As String, Description As String, CostPrice As Decimal, SellingPrice As Decimal, Discount As Decimal, CGST As Decimal?, SGST As Decimal?, CESS As Decimal?, Barcode As String, ReorderPoint As Integer, OpeningStock As Decimal, PurchaseUnit As String, SalesUnit As String, Original_PID As Integer, Original_ProductCode As String, Original_ProductName As String, Original_SubCategoryID As Integer, Original_HSNCode As String, Original_PartNo As String, Original_CostPrice As Decimal, Original_SellingPrice As Decimal, Original_Discount As Decimal, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_CESS As Decimal?, Original_Barcode As String, Original_ReorderPoint As Integer, Original_OpeningStock As Decimal, Original_PurchaseUnit As String, Original_SalesUnit As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = PID
			Dim flag As Boolean = ProductCode = Nothing
			If flag Then
				Throw New ArgumentNullException("ProductCode")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = ProductCode
			Dim flag2 As Boolean = ProductName = Nothing
			If flag2 Then
				Throw New ArgumentNullException("ProductName")
			End If
			Me.Adapter.UpdateCommand.Parameters(2).Value = ProductName
			Me.Adapter.UpdateCommand.Parameters(3).Value = SubCategoryID
			Dim flag3 As Boolean = HSNCode = Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = HSNCode
			End If
			Dim flag4 As Boolean = PartNo = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = PartNo
			End If
			Dim flag5 As Boolean = Description = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = Description
			End If
			Me.Adapter.UpdateCommand.Parameters(7).Value = CostPrice
			Me.Adapter.UpdateCommand.Parameters(8).Value = SellingPrice
			Me.Adapter.UpdateCommand.Parameters(9).Value = Discount
			Dim flag6 As Boolean = CGST IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = SGST IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CESS IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Barcode = Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(14).Value = ReorderPoint
			Me.Adapter.UpdateCommand.Parameters(15).Value = OpeningStock
			Dim flag10 As Boolean = PurchaseUnit = Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = PurchaseUnit
			End If
			Dim flag11 As Boolean = SalesUnit = Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = SalesUnit
			End If
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_PID
			Dim flag12 As Boolean = Original_ProductCode = Nothing
			If flag12 Then
				Throw New ArgumentNullException("Original_ProductCode")
			End If
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_ProductCode
			Dim flag13 As Boolean = Original_ProductName = Nothing
			If flag13 Then
				Throw New ArgumentNullException("Original_ProductName")
			End If
			Me.Adapter.UpdateCommand.Parameters(20).Value = Original_ProductName
			Me.Adapter.UpdateCommand.Parameters(21).Value = Original_SubCategoryID
			Dim flag14 As Boolean = Original_HSNCode = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(22).Value = 1
				Me.Adapter.UpdateCommand.Parameters(23).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(22).Value = 0
				Me.Adapter.UpdateCommand.Parameters(23).Value = Original_HSNCode
			End If
			Dim flag15 As Boolean = Original_PartNo = Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(24).Value = 1
				Me.Adapter.UpdateCommand.Parameters(25).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(24).Value = 0
				Me.Adapter.UpdateCommand.Parameters(25).Value = Original_PartNo
			End If
			Me.Adapter.UpdateCommand.Parameters(26).Value = Original_CostPrice
			Me.Adapter.UpdateCommand.Parameters(27).Value = Original_SellingPrice
			Me.Adapter.UpdateCommand.Parameters(28).Value = Original_Discount
			Dim flag16 As Boolean = Original_CGST IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(29).Value = 0
				Me.Adapter.UpdateCommand.Parameters(30).Value = Original_CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(29).Value = 1
				Me.Adapter.UpdateCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Original_SGST IsNot Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(31).Value = 0
				Me.Adapter.UpdateCommand.Parameters(32).Value = Original_SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(31).Value = 1
				Me.Adapter.UpdateCommand.Parameters(32).Value = DBNull.Value
			End If
			Dim flag18 As Boolean = Original_CESS IsNot Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(33).Value = 0
				Me.Adapter.UpdateCommand.Parameters(34).Value = Original_CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(33).Value = 1
				Me.Adapter.UpdateCommand.Parameters(34).Value = DBNull.Value
			End If
			Dim flag19 As Boolean = Original_Barcode = Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(35).Value = 1
				Me.Adapter.UpdateCommand.Parameters(36).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(35).Value = 0
				Me.Adapter.UpdateCommand.Parameters(36).Value = Original_Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(37).Value = Original_ReorderPoint
			Me.Adapter.UpdateCommand.Parameters(38).Value = Original_OpeningStock
			Dim flag20 As Boolean = Original_PurchaseUnit = Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(39).Value = 1
				Me.Adapter.UpdateCommand.Parameters(40).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(39).Value = 0
				Me.Adapter.UpdateCommand.Parameters(40).Value = Original_PurchaseUnit
			End If
			Dim flag21 As Boolean = Original_SalesUnit = Nothing
			If flag21 Then
				Me.Adapter.UpdateCommand.Parameters(41).Value = 1
				Me.Adapter.UpdateCommand.Parameters(42).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(41).Value = 0
				Me.Adapter.UpdateCommand.Parameters(42).Value = Original_SalesUnit
			End If
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag22 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag22 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag23 As Boolean = state = ConnectionState.Closed
				If flag23 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E53B RID: 58683 RVA: 0x0088C398 File Offset: 0x0088A598
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ProductCode As String, ProductName As String, SubCategoryID As Integer, HSNCode As String, PartNo As String, Description As String, CostPrice As Decimal, SellingPrice As Decimal, Discount As Decimal, CGST As Decimal?, SGST As Decimal?, CESS As Decimal?, Barcode As String, ReorderPoint As Integer, OpeningStock As Decimal, PurchaseUnit As String, SalesUnit As String, Original_PID As Integer, Original_ProductCode As String, Original_ProductName As String, Original_SubCategoryID As Integer, Original_HSNCode As String, Original_PartNo As String, Original_CostPrice As Decimal, Original_SellingPrice As Decimal, Original_Discount As Decimal, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_CESS As Decimal?, Original_Barcode As String, Original_ReorderPoint As Integer, Original_OpeningStock As Decimal, Original_PurchaseUnit As String, Original_SalesUnit As String) As Integer
			Return Me.Update(Original_PID, ProductCode, ProductName, SubCategoryID, HSNCode, PartNo, Description, CostPrice, SellingPrice, Discount, CGST, SGST, CESS, Barcode, ReorderPoint, OpeningStock, PurchaseUnit, SalesUnit, Original_PID, Original_ProductCode, Original_ProductName, Original_SubCategoryID, Original_HSNCode, Original_PartNo, Original_CostPrice, Original_SellingPrice, Original_Discount, Original_CGST, Original_SGST, Original_CESS, Original_Barcode, Original_ReorderPoint, Original_OpeningStock, Original_PurchaseUnit, Original_SalesUnit)
		End Function

		' Token: 0x04005880 RID: 22656
		Private _connection As SqlConnection

		' Token: 0x04005881 RID: 22657
		Private _transaction As SqlTransaction

		' Token: 0x04005882 RID: 22658
		Private _commandCollection As SqlCommand()

		' Token: 0x04005883 RID: 22659
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
