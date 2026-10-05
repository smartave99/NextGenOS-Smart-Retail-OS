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
	' Token: 0x02000469 RID: 1129
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Stock_ProductTableAdapter
		Inherits Component

		' Token: 0x1700589F RID: 22687
		' (get) Token: 0x0600E6D4 RID: 59092 RVA: 0x00065CC2 File Offset: 0x00063EC2
		' (set) Token: 0x0600E6D5 RID: 59093 RVA: 0x00065CCC File Offset: 0x00063ECC
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E6D6 RID: 59094 RVA: 0x00065CD5 File Offset: 0x00063ED5
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170058A0 RID: 22688
		' (get) Token: 0x0600E6D7 RID: 59095 RVA: 0x008B6898 File Offset: 0x008B4A98
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

		' Token: 0x170058A1 RID: 22689
		' (get) Token: 0x0600E6D8 RID: 59096 RVA: 0x008B68C8 File Offset: 0x008B4AC8
		' (set) Token: 0x0600E6D9 RID: 59097 RVA: 0x008B68F8 File Offset: 0x008B4AF8
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

		' Token: 0x170058A2 RID: 22690
		' (get) Token: 0x0600E6DA RID: 59098 RVA: 0x008B69BC File Offset: 0x008B4BBC
		' (set) Token: 0x0600E6DB RID: 59099 RVA: 0x008B69D4 File Offset: 0x008B4BD4
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

		' Token: 0x170058A3 RID: 22691
		' (get) Token: 0x0600E6DC RID: 59100 RVA: 0x008B6ABC File Offset: 0x008B4CBC
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

		' Token: 0x170058A4 RID: 22692
		' (get) Token: 0x0600E6DD RID: 59101 RVA: 0x008B6AEC File Offset: 0x008B4CEC
		' (set) Token: 0x0600E6DE RID: 59102 RVA: 0x00065CE7 File Offset: 0x00063EE7
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

		' Token: 0x0600E6DF RID: 59103 RVA: 0x008B6B04 File Offset: 0x008B4D04
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Stock_Product"
			dataTableMapping.ColumnMappings.Add("SP_ID", "SP_ID")
			dataTableMapping.ColumnMappings.Add("StockID", "StockID")
			dataTableMapping.ColumnMappings.Add("ProductID", "ProductID")
			dataTableMapping.ColumnMappings.Add("Barcode", "Barcode")
			dataTableMapping.ColumnMappings.Add("Qty", "Qty")
			dataTableMapping.ColumnMappings.Add("MRP", "MRP")
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
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Stock_Product] WHERE (([SP_ID] = @Original_SP_ID) AND ([StockID] = @Original_StockID) AND ([ProductID] = @Original_ProductID) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ([Qty] = @Original_Qty) AND ((@IsNull_MRP = 1 AND [MRP] IS NULL) OR ([MRP] = @Original_MRP)) AND ([Price] = @Original_Price) AND ((@IsNull_CGSTPer = 1 AND [CGSTPer] IS NULL) OR ([CGSTPer] = @Original_CGSTPer)) AND ((@IsNull_CGSTAmt = 1 AND [CGSTAmt] IS NULL) OR ([CGSTAmt] = @Original_CGSTAmt)) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ((@IsNull_DiscountPer = 1 AND [DiscountPer] IS NULL) OR ([DiscountPer] = @Original_DiscountPer)) AND ((@IsNull_DiscountAmt = 1 AND [DiscountAmt] IS NULL) OR ([DiscountAmt] = @Original_DiscountAmt)) AND ((@IsNull_TotalAmount = 1 AND [TotalAmount] IS NULL) OR ([TotalAmount] = @Original_TotalAmount)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SP_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SP_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_StockID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StockID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_MRP", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "MRP", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_MRP", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "MRP", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Stock_Product] ([StockID], [ProductID], [Barcode], [Qty], [MRP], [Price], [CGSTPer], [CGSTAmt], [SGSTPer], [SGSTAmt], [IGSTPer], [IGSTAmt], [CESSPer], [CESSAmt], [DiscountPer], [DiscountAmt], [TotalAmount]) VALUES (@StockID, @ProductID, @Barcode, @Qty, @MRP, @Price, @CGSTPer, @CGSTAmt, @SGSTPer, @SGSTAmt, @IGSTPer, @IGSTAmt, @CESSPer, @CESSAmt, @DiscountPer, @DiscountAmt, @TotalAmount);" & vbCrLf & "SELECT SP_ID, StockID, ProductID, Barcode, Qty, MRP, Price, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, DiscountPer, DiscountAmt, TotalAmount FROM Stock_Product WHERE (SP_ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@StockID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StockID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@MRP", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "MRP", DataRowVersion.Current, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Stock_Product] SET [StockID] = @StockID, [ProductID] = @ProductID, [Barcode] = @Barcode, [Qty] = @Qty, [MRP] = @MRP, [Price] = @Price, [CGSTPer] = @CGSTPer, [CGSTAmt] = @CGSTAmt, [SGSTPer] = @SGSTPer, [SGSTAmt] = @SGSTAmt, [IGSTPer] = @IGSTPer, [IGSTAmt] = @IGSTAmt, [CESSPer] = @CESSPer, [CESSAmt] = @CESSAmt, [DiscountPer] = @DiscountPer, [DiscountAmt] = @DiscountAmt, [TotalAmount] = @TotalAmount WHERE (([SP_ID] = @Original_SP_ID) AND ([StockID] = @Original_StockID) AND ([ProductID] = @Original_ProductID) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ([Qty] = @Original_Qty) AND ((@IsNull_MRP = 1 AND [MRP] IS NULL) OR ([MRP] = @Original_MRP)) AND ([Price] = @Original_Price) AND ((@IsNull_CGSTPer = 1 AND [CGSTPer] IS NULL) OR ([CGSTPer] = @Original_CGSTPer)) AND ((@IsNull_CGSTAmt = 1 AND [CGSTAmt] IS NULL) OR ([CGSTAmt] = @Original_CGSTAmt)) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ((@IsNull_DiscountPer = 1 AND [DiscountPer] IS NULL) OR ([DiscountPer] = @Original_DiscountPer)) AND ((@IsNull_DiscountAmt = 1 AND [DiscountAmt] IS NULL) OR ([DiscountAmt] = @Original_DiscountAmt)) AND ((@IsNull_TotalAmount = 1 AND [TotalAmount] IS NULL) OR ([TotalAmount] = @Original_TotalAmount)));" & vbCrLf & "SELECT SP_ID, StockID, ProductID, Barcode, Qty, MRP, Price, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, DiscountPer, DiscountAmt, TotalAmount FROM Stock_Product WHERE (SP_ID = @SP_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@StockID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StockID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@MRP", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "MRP", DataRowVersion.Current, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SP_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SP_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_StockID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "StockID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_MRP", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "MRP", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_MRP", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "MRP", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SP_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "SP_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E6E0 RID: 59104 RVA: 0x00065CF1 File Offset: 0x00063EF1
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E6E1 RID: 59105 RVA: 0x008B8648 File Offset: 0x008B6848
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT SP_ID, StockID, ProductID, Barcode, Qty, MRP, Price, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, DiscountPer, DiscountAmt, TotalAmount FROM dbo.Stock_Product"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E6E2 RID: 59106 RVA: 0x008B86A8 File Offset: 0x008B68A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Stock_ProductDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E6E3 RID: 59107 RVA: 0x008B86F0 File Offset: 0x008B68F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Stock_ProductDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim stock_ProductDataTable As Inventory_DBDataSet.Stock_ProductDataTable = New Inventory_DBDataSet.Stock_ProductDataTable()
			Me.Adapter.Fill(stock_ProductDataTable)
			Return stock_ProductDataTable
		End Function

		' Token: 0x0600E6E4 RID: 59108 RVA: 0x008B872C File Offset: 0x008B692C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Stock_ProductDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E6E5 RID: 59109 RVA: 0x008B874C File Offset: 0x008B694C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Stock_Product")
		End Function

		' Token: 0x0600E6E6 RID: 59110 RVA: 0x008B8770 File Offset: 0x008B6970
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E6E7 RID: 59111 RVA: 0x008B8798 File Offset: 0x008B6998
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E6E8 RID: 59112 RVA: 0x008B87B8 File Offset: 0x008B69B8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_SP_ID As Integer, Original_StockID As Integer, Original_ProductID As Integer, Original_Barcode As String, Original_Qty As Decimal, Original_MRP As Decimal?, Original_Price As Decimal, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_DiscountPer As Decimal?, Original_DiscountAmt As Decimal?, Original_TotalAmount As Decimal?) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_SP_ID
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_StockID
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_ProductID
			Dim flag As Boolean = Original_Barcode = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Barcode
			End If
			Me.Adapter.DeleteCommand.Parameters(5).Value = Original_Qty
			Dim flag2 As Boolean = Original_MRP IsNot Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(6).Value = 0
				Me.Adapter.DeleteCommand.Parameters(7).Value = Original_MRP.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(6).Value = 1
				Me.Adapter.DeleteCommand.Parameters(7).Value = DBNull.Value
			End If
			Me.Adapter.DeleteCommand.Parameters(8).Value = Original_Price
			Dim flag3 As Boolean = Original_CGSTPer IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_CGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Original_CGSTAmt IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_CGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_SGSTPer IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(13).Value = 0
				Me.Adapter.DeleteCommand.Parameters(14).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(13).Value = 1
				Me.Adapter.DeleteCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_SGSTAmt IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(15).Value = 0
				Me.Adapter.DeleteCommand.Parameters(16).Value = Original_SGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(15).Value = 1
				Me.Adapter.DeleteCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_IGSTPer IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(17).Value = 0
				Me.Adapter.DeleteCommand.Parameters(18).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(17).Value = 1
				Me.Adapter.DeleteCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(19).Value = 0
				Me.Adapter.DeleteCommand.Parameters(20).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(19).Value = 1
				Me.Adapter.DeleteCommand.Parameters(20).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Original_CESSPer IsNot Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(21).Value = 0
				Me.Adapter.DeleteCommand.Parameters(22).Value = Original_CESSPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(21).Value = 1
				Me.Adapter.DeleteCommand.Parameters(22).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_CESSAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.DeleteCommand.Parameters(23).Value = 0
				Me.Adapter.DeleteCommand.Parameters(24).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(23).Value = 1
				Me.Adapter.DeleteCommand.Parameters(24).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_DiscountPer IsNot Nothing
			If flag11 Then
				Me.Adapter.DeleteCommand.Parameters(25).Value = 0
				Me.Adapter.DeleteCommand.Parameters(26).Value = Original_DiscountPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(25).Value = 1
				Me.Adapter.DeleteCommand.Parameters(26).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_DiscountAmt IsNot Nothing
			If flag12 Then
				Me.Adapter.DeleteCommand.Parameters(27).Value = 0
				Me.Adapter.DeleteCommand.Parameters(28).Value = Original_DiscountAmt.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(27).Value = 1
				Me.Adapter.DeleteCommand.Parameters(28).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_TotalAmount IsNot Nothing
			If flag13 Then
				Me.Adapter.DeleteCommand.Parameters(29).Value = 0
				Me.Adapter.DeleteCommand.Parameters(30).Value = Original_TotalAmount.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(29).Value = 1
				Me.Adapter.DeleteCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag14 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag14 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag15 As Boolean = state = ConnectionState.Closed
				If flag15 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6E9 RID: 59113 RVA: 0x008B9140 File Offset: 0x008B7340
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(StockID As Integer, ProductID As Integer, Barcode As String, Qty As Decimal, MRP As Decimal?, Price As Decimal, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, DiscountPer As Decimal?, DiscountAmt As Decimal?, TotalAmount As Decimal?) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = StockID
			Me.Adapter.InsertCommand.Parameters(1).Value = ProductID
			Dim flag As Boolean = Barcode = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = Barcode
			End If
			Me.Adapter.InsertCommand.Parameters(3).Value = Qty
			Dim flag2 As Boolean = MRP IsNot Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = MRP.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Me.Adapter.InsertCommand.Parameters(5).Value = Price
			Dim flag3 As Boolean = CGSTPer IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = CGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = CGSTAmt IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = CGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = SGSTPer IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = SGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = SGSTAmt IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = SGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = IGSTPer IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = IGSTPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = IGSTAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = IGSTAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = CESSPer IsNot Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = CESSPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = CESSAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = CESSAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = DiscountPer IsNot Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(14).Value = DiscountPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = DiscountAmt IsNot Nothing
			If flag12 Then
				Me.Adapter.InsertCommand.Parameters(15).Value = DiscountAmt.Value
			Else
				Me.Adapter.InsertCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = TotalAmount IsNot Nothing
			If flag13 Then
				Me.Adapter.InsertCommand.Parameters(16).Value = TotalAmount.Value
			Else
				Me.Adapter.InsertCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag14 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag14 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag15 As Boolean = state = ConnectionState.Closed
				If flag15 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6EA RID: 59114 RVA: 0x008B9714 File Offset: 0x008B7914
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(StockID As Integer, ProductID As Integer, Barcode As String, Qty As Decimal, MRP As Decimal?, Price As Decimal, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, DiscountPer As Decimal?, DiscountAmt As Decimal?, TotalAmount As Decimal?, Original_SP_ID As Integer, Original_StockID As Integer, Original_ProductID As Integer, Original_Barcode As String, Original_Qty As Decimal, Original_MRP As Decimal?, Original_Price As Decimal, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_DiscountPer As Decimal?, Original_DiscountAmt As Decimal?, Original_TotalAmount As Decimal?, SP_ID As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = StockID
			Me.Adapter.UpdateCommand.Parameters(1).Value = ProductID
			Dim flag As Boolean = Barcode = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = Qty
			Dim flag2 As Boolean = MRP IsNot Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = MRP.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(5).Value = Price
			Dim flag3 As Boolean = CGSTPer IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = CGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = CGSTAmt IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = CGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = SGSTPer IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = SGSTAmt IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = SGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = IGSTPer IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = IGSTAmt IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = CESSPer IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = CESSAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = DiscountPer IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = DiscountPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = DiscountAmt IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = DiscountAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = TotalAmount IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = TotalAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(17).Value = Original_SP_ID
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_StockID
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_ProductID
			Dim flag14 As Boolean = Original_Barcode = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(20).Value = 1
				Me.Adapter.UpdateCommand.Parameters(21).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(20).Value = 0
				Me.Adapter.UpdateCommand.Parameters(21).Value = Original_Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(22).Value = Original_Qty
			Dim flag15 As Boolean = Original_MRP IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(23).Value = 0
				Me.Adapter.UpdateCommand.Parameters(24).Value = Original_MRP.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(23).Value = 1
				Me.Adapter.UpdateCommand.Parameters(24).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(25).Value = Original_Price
			Dim flag16 As Boolean = Original_CGSTPer IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(26).Value = 0
				Me.Adapter.UpdateCommand.Parameters(27).Value = Original_CGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(26).Value = 1
				Me.Adapter.UpdateCommand.Parameters(27).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Original_CGSTAmt IsNot Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(28).Value = 0
				Me.Adapter.UpdateCommand.Parameters(29).Value = Original_CGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(28).Value = 1
				Me.Adapter.UpdateCommand.Parameters(29).Value = DBNull.Value
			End If
			Dim flag18 As Boolean = Original_SGSTPer IsNot Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(30).Value = 0
				Me.Adapter.UpdateCommand.Parameters(31).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(30).Value = 1
				Me.Adapter.UpdateCommand.Parameters(31).Value = DBNull.Value
			End If
			Dim flag19 As Boolean = Original_SGSTAmt IsNot Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(32).Value = 0
				Me.Adapter.UpdateCommand.Parameters(33).Value = Original_SGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(32).Value = 1
				Me.Adapter.UpdateCommand.Parameters(33).Value = DBNull.Value
			End If
			Dim flag20 As Boolean = Original_IGSTPer IsNot Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(34).Value = 0
				Me.Adapter.UpdateCommand.Parameters(35).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(34).Value = 1
				Me.Adapter.UpdateCommand.Parameters(35).Value = DBNull.Value
			End If
			Dim flag21 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag21 Then
				Me.Adapter.UpdateCommand.Parameters(36).Value = 0
				Me.Adapter.UpdateCommand.Parameters(37).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(36).Value = 1
				Me.Adapter.UpdateCommand.Parameters(37).Value = DBNull.Value
			End If
			Dim flag22 As Boolean = Original_CESSPer IsNot Nothing
			If flag22 Then
				Me.Adapter.UpdateCommand.Parameters(38).Value = 0
				Me.Adapter.UpdateCommand.Parameters(39).Value = Original_CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(38).Value = 1
				Me.Adapter.UpdateCommand.Parameters(39).Value = DBNull.Value
			End If
			Dim flag23 As Boolean = Original_CESSAmt IsNot Nothing
			If flag23 Then
				Me.Adapter.UpdateCommand.Parameters(40).Value = 0
				Me.Adapter.UpdateCommand.Parameters(41).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(40).Value = 1
				Me.Adapter.UpdateCommand.Parameters(41).Value = DBNull.Value
			End If
			Dim flag24 As Boolean = Original_DiscountPer IsNot Nothing
			If flag24 Then
				Me.Adapter.UpdateCommand.Parameters(42).Value = 0
				Me.Adapter.UpdateCommand.Parameters(43).Value = Original_DiscountPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(42).Value = 1
				Me.Adapter.UpdateCommand.Parameters(43).Value = DBNull.Value
			End If
			Dim flag25 As Boolean = Original_DiscountAmt IsNot Nothing
			If flag25 Then
				Me.Adapter.UpdateCommand.Parameters(44).Value = 0
				Me.Adapter.UpdateCommand.Parameters(45).Value = Original_DiscountAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(44).Value = 1
				Me.Adapter.UpdateCommand.Parameters(45).Value = DBNull.Value
			End If
			Dim flag26 As Boolean = Original_TotalAmount IsNot Nothing
			If flag26 Then
				Me.Adapter.UpdateCommand.Parameters(46).Value = 0
				Me.Adapter.UpdateCommand.Parameters(47).Value = Original_TotalAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(46).Value = 1
				Me.Adapter.UpdateCommand.Parameters(47).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(48).Value = SP_ID
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag27 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag27 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag28 As Boolean = state = ConnectionState.Closed
				If flag28 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6EB RID: 59115 RVA: 0x008BA5FC File Offset: 0x008B87FC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(StockID As Integer, ProductID As Integer, Barcode As String, Qty As Decimal, MRP As Decimal?, Price As Decimal, CGSTPer As Decimal?, CGSTAmt As Decimal?, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, DiscountPer As Decimal?, DiscountAmt As Decimal?, TotalAmount As Decimal?, Original_SP_ID As Integer, Original_StockID As Integer, Original_ProductID As Integer, Original_Barcode As String, Original_Qty As Decimal, Original_MRP As Decimal?, Original_Price As Decimal, Original_CGSTPer As Decimal?, Original_CGSTAmt As Decimal?, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_DiscountPer As Decimal?, Original_DiscountAmt As Decimal?, Original_TotalAmount As Decimal?) As Integer
			Return Me.Update(StockID, ProductID, Barcode, Qty, MRP, Price, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, DiscountPer, DiscountAmt, TotalAmount, Original_SP_ID, Original_StockID, Original_ProductID, Original_Barcode, Original_Qty, Original_MRP, Original_Price, Original_CGSTPer, Original_CGSTAmt, Original_SGSTPer, Original_SGSTAmt, Original_IGSTPer, Original_IGSTAmt, Original_CESSPer, Original_CESSAmt, Original_DiscountPer, Original_DiscountAmt, Original_TotalAmount, Original_SP_ID)
		End Function

		' Token: 0x040058DA RID: 22746
		Private _connection As SqlConnection

		' Token: 0x040058DB RID: 22747
		Private _transaction As SqlTransaction

		' Token: 0x040058DC RID: 22748
		Private _commandCollection As SqlCommand()

		' Token: 0x040058DD RID: 22749
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
