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
	' Token: 0x0200045E RID: 1118
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Quotation_JoinTableAdapter
		Inherits Component

		' Token: 0x1700585D RID: 22621
		' (get) Token: 0x0600E5CC RID: 58828 RVA: 0x00065931 File Offset: 0x00063B31
		' (set) Token: 0x0600E5CD RID: 58829 RVA: 0x0006593B File Offset: 0x00063B3B
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E5CE RID: 58830 RVA: 0x00065944 File Offset: 0x00063B44
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x1700585E RID: 22622
		' (get) Token: 0x0600E5CF RID: 58831 RVA: 0x0089D98C File Offset: 0x0089BB8C
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

		' Token: 0x1700585F RID: 22623
		' (get) Token: 0x0600E5D0 RID: 58832 RVA: 0x0089D9BC File Offset: 0x0089BBBC
		' (set) Token: 0x0600E5D1 RID: 58833 RVA: 0x0089D9EC File Offset: 0x0089BBEC
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

		' Token: 0x17005860 RID: 22624
		' (get) Token: 0x0600E5D2 RID: 58834 RVA: 0x0089DAB0 File Offset: 0x0089BCB0
		' (set) Token: 0x0600E5D3 RID: 58835 RVA: 0x0089DAC8 File Offset: 0x0089BCC8
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

		' Token: 0x17005861 RID: 22625
		' (get) Token: 0x0600E5D4 RID: 58836 RVA: 0x0089DBB0 File Offset: 0x0089BDB0
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

		' Token: 0x17005862 RID: 22626
		' (get) Token: 0x0600E5D5 RID: 58837 RVA: 0x0089DBE0 File Offset: 0x0089BDE0
		' (set) Token: 0x0600E5D6 RID: 58838 RVA: 0x00065956 File Offset: 0x00063B56
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

		' Token: 0x0600E5D7 RID: 58839 RVA: 0x0089DBF8 File Offset: 0x0089BDF8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Quotation_Join"
			dataTableMapping.ColumnMappings.Add("QJ_ID", "QJ_ID")
			dataTableMapping.ColumnMappings.Add("QuotationID", "QuotationID")
			dataTableMapping.ColumnMappings.Add("ProductID", "ProductID")
			dataTableMapping.ColumnMappings.Add("Barcode", "Barcode")
			dataTableMapping.ColumnMappings.Add("Qty", "Qty")
			dataTableMapping.ColumnMappings.Add("Price", "Price")
			dataTableMapping.ColumnMappings.Add("DiscountPer", "DiscountPer")
			dataTableMapping.ColumnMappings.Add("DiscountAmt", "DiscountAmt")
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
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Quotation_Join] WHERE (([QJ_ID] = @Original_QJ_ID) AND ([QuotationID] = @Original_QuotationID) AND ([ProductID] = @Original_ProductID) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ([Qty] = @Original_Qty) AND ([Price] = @Original_Price) AND ([DiscountPer] = @Original_DiscountPer) AND ([DiscountAmt] = @Original_DiscountAmt) AND ([CGSTPer] = @Original_CGSTPer) AND ([CGSTAmt] = @Original_CGSTAmt) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ([TotalAmount] = @Original_TotalAmount))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_QJ_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "QJ_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_QuotationID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "QuotationID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_DiscountAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Quotation_Join] ([QuotationID], [ProductID], [Barcode], [Qty], [Price], [DiscountPer], [DiscountAmt], [CGSTPer], [CGSTAmt], [SGSTPer], [SGSTAmt], [IGSTPer], [IGSTAmt], [CESSPer], [CESSAmt], [TotalAmount]) VALUES (@QuotationID, @ProductID, @Barcode, @Qty, @Price, @DiscountPer, @DiscountAmt, @CGSTPer, @CGSTAmt, @SGSTPer, @SGSTAmt, @IGSTPer, @IGSTAmt, @CESSPer, @CESSAmt, @TotalAmount);" & vbCrLf & "SELECT QJ_ID, QuotationID, ProductID, Barcode, Qty, Price, DiscountPer, DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount FROM Quotation_Join WHERE (QJ_ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@QuotationID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "QuotationID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@DiscountAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Quotation_Join] SET [QuotationID] = @QuotationID, [ProductID] = @ProductID, [Barcode] = @Barcode, [Qty] = @Qty, [Price] = @Price, [DiscountPer] = @DiscountPer, [DiscountAmt] = @DiscountAmt, [CGSTPer] = @CGSTPer, [CGSTAmt] = @CGSTAmt, [SGSTPer] = @SGSTPer, [SGSTAmt] = @SGSTAmt, [IGSTPer] = @IGSTPer, [IGSTAmt] = @IGSTAmt, [CESSPer] = @CESSPer, [CESSAmt] = @CESSAmt, [TotalAmount] = @TotalAmount WHERE (([QJ_ID] = @Original_QJ_ID) AND ([QuotationID] = @Original_QuotationID) AND ([ProductID] = @Original_ProductID) AND ((@IsNull_Barcode = 1 AND [Barcode] IS NULL) OR ([Barcode] = @Original_Barcode)) AND ([Qty] = @Original_Qty) AND ([Price] = @Original_Price) AND ([DiscountPer] = @Original_DiscountPer) AND ([DiscountAmt] = @Original_DiscountAmt) AND ([CGSTPer] = @Original_CGSTPer) AND ([CGSTAmt] = @Original_CGSTAmt) AND ((@IsNull_SGSTPer = 1 AND [SGSTPer] IS NULL) OR ([SGSTPer] = @Original_SGSTPer)) AND ((@IsNull_SGSTAmt = 1 AND [SGSTAmt] IS NULL) OR ([SGSTAmt] = @Original_SGSTAmt)) AND ((@IsNull_IGSTPer = 1 AND [IGSTPer] IS NULL) OR ([IGSTPer] = @Original_IGSTPer)) AND ((@IsNull_IGSTAmt = 1 AND [IGSTAmt] IS NULL) OR ([IGSTAmt] = @Original_IGSTAmt)) AND ((@IsNull_CESSPer = 1 AND [CESSPer] IS NULL) OR ([CESSPer] = @Original_CESSPer)) AND ((@IsNull_CESSAmt = 1 AND [CESSAmt] IS NULL) OR ([CESSAmt] = @Original_CESSAmt)) AND ([TotalAmount] = @Original_TotalAmount));" & vbCrLf & "SELECT QJ_ID, QuotationID, ProductID, Barcode, Qty, Price, DiscountPer, DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount FROM Quotation_Join WHERE (QJ_ID = @QJ_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@QuotationID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "QuotationID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@DiscountAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGSTPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGSTAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGSTAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESSPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESSAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESSAmt", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_QJ_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "QJ_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_QuotationID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "QuotationID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ProductID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ProductID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Barcode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Barcode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Barcode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Qty", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Qty", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Price", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Price", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_DiscountPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_DiscountAmt", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "DiscountAmt", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@QJ_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "QJ_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E5D8 RID: 58840 RVA: 0x00065960 File Offset: 0x00063B60
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E5D9 RID: 58841 RVA: 0x0089F320 File Offset: 0x0089D520
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT QJ_ID, QuotationID, ProductID, Barcode, Qty, Price, DiscountPer, DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount FROM dbo.Quotation_Join"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E5DA RID: 58842 RVA: 0x0089F380 File Offset: 0x0089D580
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Quotation_JoinDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E5DB RID: 58843 RVA: 0x0089F3C8 File Offset: 0x0089D5C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Quotation_JoinDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim quotation_JoinDataTable As Inventory_DBDataSet.Quotation_JoinDataTable = New Inventory_DBDataSet.Quotation_JoinDataTable()
			Me.Adapter.Fill(quotation_JoinDataTable)
			Return quotation_JoinDataTable
		End Function

		' Token: 0x0600E5DC RID: 58844 RVA: 0x0089F404 File Offset: 0x0089D604
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Quotation_JoinDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E5DD RID: 58845 RVA: 0x0089F424 File Offset: 0x0089D624
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Quotation_Join")
		End Function

		' Token: 0x0600E5DE RID: 58846 RVA: 0x0089F448 File Offset: 0x0089D648
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E5DF RID: 58847 RVA: 0x0089F470 File Offset: 0x0089D670
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E5E0 RID: 58848 RVA: 0x0089F490 File Offset: 0x0089D690
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_QJ_ID As Integer, Original_QuotationID As Integer, Original_ProductID As Integer, Original_Barcode As String, Original_Qty As Decimal, Original_Price As Decimal, Original_DiscountPer As Decimal, Original_DiscountAmt As Decimal, Original_CGSTPer As Decimal, Original_CGSTAmt As Decimal, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_TotalAmount As Decimal) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_QJ_ID
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_QuotationID
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
			Me.Adapter.DeleteCommand.Parameters(6).Value = Original_Price
			Me.Adapter.DeleteCommand.Parameters(7).Value = Original_DiscountPer
			Me.Adapter.DeleteCommand.Parameters(8).Value = Original_DiscountAmt
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

		' Token: 0x0600E5E1 RID: 58849 RVA: 0x0089FAFC File Offset: 0x0089DCFC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(QuotationID As Integer, ProductID As Integer, Barcode As String, Qty As Decimal, Price As Decimal, DiscountPer As Decimal, DiscountAmt As Decimal, CGSTPer As Decimal, CGSTAmt As Decimal, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, TotalAmount As Decimal) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = QuotationID
			Me.Adapter.InsertCommand.Parameters(1).Value = ProductID
			Dim flag As Boolean = Barcode = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = Barcode
			End If
			Me.Adapter.InsertCommand.Parameters(3).Value = Qty
			Me.Adapter.InsertCommand.Parameters(4).Value = Price
			Me.Adapter.InsertCommand.Parameters(5).Value = DiscountPer
			Me.Adapter.InsertCommand.Parameters(6).Value = DiscountAmt
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

		' Token: 0x0600E5E2 RID: 58850 RVA: 0x0089FF5C File Offset: 0x0089E15C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(QuotationID As Integer, ProductID As Integer, Barcode As String, Qty As Decimal, Price As Decimal, DiscountPer As Decimal, DiscountAmt As Decimal, CGSTPer As Decimal, CGSTAmt As Decimal, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, TotalAmount As Decimal, Original_QJ_ID As Integer, Original_QuotationID As Integer, Original_ProductID As Integer, Original_Barcode As String, Original_Qty As Decimal, Original_Price As Decimal, Original_DiscountPer As Decimal, Original_DiscountAmt As Decimal, Original_CGSTPer As Decimal, Original_CGSTAmt As Decimal, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_TotalAmount As Decimal, QJ_ID As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = QuotationID
			Me.Adapter.UpdateCommand.Parameters(1).Value = ProductID
			Dim flag As Boolean = Barcode = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = Qty
			Me.Adapter.UpdateCommand.Parameters(4).Value = Price
			Me.Adapter.UpdateCommand.Parameters(5).Value = DiscountPer
			Me.Adapter.UpdateCommand.Parameters(6).Value = DiscountAmt
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
			Me.Adapter.UpdateCommand.Parameters(16).Value = Original_QJ_ID
			Me.Adapter.UpdateCommand.Parameters(17).Value = Original_QuotationID
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_ProductID
			Dim flag8 As Boolean = Original_Barcode = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = 1
				Me.Adapter.UpdateCommand.Parameters(20).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(19).Value = 0
				Me.Adapter.UpdateCommand.Parameters(20).Value = Original_Barcode
			End If
			Me.Adapter.UpdateCommand.Parameters(21).Value = Original_Qty
			Me.Adapter.UpdateCommand.Parameters(22).Value = Original_Price
			Me.Adapter.UpdateCommand.Parameters(23).Value = Original_DiscountPer
			Me.Adapter.UpdateCommand.Parameters(24).Value = Original_DiscountAmt
			Me.Adapter.UpdateCommand.Parameters(25).Value = Original_CGSTPer
			Me.Adapter.UpdateCommand.Parameters(26).Value = Original_CGSTAmt
			Dim flag9 As Boolean = Original_SGSTPer IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(27).Value = 0
				Me.Adapter.UpdateCommand.Parameters(28).Value = Original_SGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(27).Value = 1
				Me.Adapter.UpdateCommand.Parameters(28).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_SGSTAmt IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(29).Value = 0
				Me.Adapter.UpdateCommand.Parameters(30).Value = Original_SGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(29).Value = 1
				Me.Adapter.UpdateCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_IGSTPer IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(31).Value = 0
				Me.Adapter.UpdateCommand.Parameters(32).Value = Original_IGSTPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(31).Value = 1
				Me.Adapter.UpdateCommand.Parameters(32).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_IGSTAmt IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(33).Value = 0
				Me.Adapter.UpdateCommand.Parameters(34).Value = Original_IGSTAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(33).Value = 1
				Me.Adapter.UpdateCommand.Parameters(34).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_CESSPer IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(35).Value = 0
				Me.Adapter.UpdateCommand.Parameters(36).Value = Original_CESSPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(35).Value = 1
				Me.Adapter.UpdateCommand.Parameters(36).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = Original_CESSAmt IsNot Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(37).Value = 0
				Me.Adapter.UpdateCommand.Parameters(38).Value = Original_CESSAmt.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(37).Value = 1
				Me.Adapter.UpdateCommand.Parameters(38).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(39).Value = Original_TotalAmount
			Me.Adapter.UpdateCommand.Parameters(40).Value = QJ_ID
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

		' Token: 0x0600E5E3 RID: 58851 RVA: 0x008A09B0 File Offset: 0x0089EBB0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(QuotationID As Integer, ProductID As Integer, Barcode As String, Qty As Decimal, Price As Decimal, DiscountPer As Decimal, DiscountAmt As Decimal, CGSTPer As Decimal, CGSTAmt As Decimal, SGSTPer As Decimal?, SGSTAmt As Decimal?, IGSTPer As Decimal?, IGSTAmt As Decimal?, CESSPer As Decimal?, CESSAmt As Decimal?, TotalAmount As Decimal, Original_QJ_ID As Integer, Original_QuotationID As Integer, Original_ProductID As Integer, Original_Barcode As String, Original_Qty As Decimal, Original_Price As Decimal, Original_DiscountPer As Decimal, Original_DiscountAmt As Decimal, Original_CGSTPer As Decimal, Original_CGSTAmt As Decimal, Original_SGSTPer As Decimal?, Original_SGSTAmt As Decimal?, Original_IGSTPer As Decimal?, Original_IGSTAmt As Decimal?, Original_CESSPer As Decimal?, Original_CESSAmt As Decimal?, Original_TotalAmount As Decimal) As Integer
			Return Me.Update(QuotationID, ProductID, Barcode, Qty, Price, DiscountPer, DiscountAmt, CGSTPer, CGSTAmt, SGSTPer, SGSTAmt, IGSTPer, IGSTAmt, CESSPer, CESSAmt, TotalAmount, Original_QJ_ID, Original_QuotationID, Original_ProductID, Original_Barcode, Original_Qty, Original_Price, Original_DiscountPer, Original_DiscountAmt, Original_CGSTPer, Original_CGSTAmt, Original_SGSTPer, Original_SGSTAmt, Original_IGSTPer, Original_IGSTAmt, Original_CESSPer, Original_CESSAmt, Original_TotalAmount, Original_QJ_ID)
		End Function

		' Token: 0x040058A3 RID: 22691
		Private _connection As SqlConnection

		' Token: 0x040058A4 RID: 22692
		Private _transaction As SqlTransaction

		' Token: 0x040058A5 RID: 22693
		Private _commandCollection As SqlCommand()

		' Token: 0x040058A6 RID: 22694
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
