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
	' Token: 0x02000468 RID: 1128
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class StockTableAdapter
		Inherits Component

		' Token: 0x17005899 RID: 22681
		' (get) Token: 0x0600E6BC RID: 59068 RVA: 0x00065C6F File Offset: 0x00063E6F
		' (set) Token: 0x0600E6BD RID: 59069 RVA: 0x00065C79 File Offset: 0x00063E79
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E6BE RID: 59070 RVA: 0x00065C82 File Offset: 0x00063E82
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x1700589A RID: 22682
		' (get) Token: 0x0600E6BF RID: 59071 RVA: 0x008B1DA4 File Offset: 0x008AFFA4
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

		' Token: 0x1700589B RID: 22683
		' (get) Token: 0x0600E6C0 RID: 59072 RVA: 0x008B1DD4 File Offset: 0x008AFFD4
		' (set) Token: 0x0600E6C1 RID: 59073 RVA: 0x008B1E04 File Offset: 0x008B0004
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

		' Token: 0x1700589C RID: 22684
		' (get) Token: 0x0600E6C2 RID: 59074 RVA: 0x008B1EC8 File Offset: 0x008B00C8
		' (set) Token: 0x0600E6C3 RID: 59075 RVA: 0x008B1EE0 File Offset: 0x008B00E0
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

		' Token: 0x1700589D RID: 22685
		' (get) Token: 0x0600E6C4 RID: 59076 RVA: 0x008B1FC8 File Offset: 0x008B01C8
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

		' Token: 0x1700589E RID: 22686
		' (get) Token: 0x0600E6C5 RID: 59077 RVA: 0x008B1FF8 File Offset: 0x008B01F8
		' (set) Token: 0x0600E6C6 RID: 59078 RVA: 0x00065C94 File Offset: 0x00063E94
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

		' Token: 0x0600E6C7 RID: 59079 RVA: 0x008B2010 File Offset: 0x008B0210
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Stock"
			dataTableMapping.ColumnMappings.Add("ST_ID", "ST_ID")
			dataTableMapping.ColumnMappings.Add("InvoiceNo", "InvoiceNo")
			dataTableMapping.ColumnMappings.Add("PurchaseType", "PurchaseType")
			dataTableMapping.ColumnMappings.Add("ReferenceNo1", "ReferenceNo1")
			dataTableMapping.ColumnMappings.Add("ReferenceNo2", "ReferenceNo2")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("SupplierID", "SupplierID")
			dataTableMapping.ColumnMappings.Add("SupplierInvoiceNo", "SupplierInvoiceNo")
			dataTableMapping.ColumnMappings.Add("SupplierInvoiceDate", "SupplierInvoiceDate")
			dataTableMapping.ColumnMappings.Add("TaxType", "TaxType")
			dataTableMapping.ColumnMappings.Add("SGST", "SGST")
			dataTableMapping.ColumnMappings.Add("CGST", "CGST")
			dataTableMapping.ColumnMappings.Add("IGST", "IGST")
			dataTableMapping.ColumnMappings.Add("CESS", "CESS")
			dataTableMapping.ColumnMappings.Add("SubTotal", "SubTotal")
			dataTableMapping.ColumnMappings.Add("PreviousDue", "PreviousDue")
			dataTableMapping.ColumnMappings.Add("FreightCharges", "FreightCharges")
			dataTableMapping.ColumnMappings.Add("OtherCharges", "OtherCharges")
			dataTableMapping.ColumnMappings.Add("Total", "Total")
			dataTableMapping.ColumnMappings.Add("RoundOff", "RoundOff")
			dataTableMapping.ColumnMappings.Add("GrandTotal", "GrandTotal")
			dataTableMapping.ColumnMappings.Add("TotalPayment", "TotalPayment")
			dataTableMapping.ColumnMappings.Add("PaymentDue", "PaymentDue")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Stock] WHERE (([ST_ID] = @Original_ST_ID) AND ([InvoiceNo] = @Original_InvoiceNo) AND ((@IsNull_PurchaseType = 1 AND [PurchaseType] IS NULL) OR ([PurchaseType] = @Original_PurchaseType)) AND ((@IsNull_ReferenceNo1 = 1 AND [ReferenceNo1] IS NULL) OR ([ReferenceNo1] = @Original_ReferenceNo1)) AND ((@IsNull_ReferenceNo2 = 1 AND [ReferenceNo2] IS NULL) OR ([ReferenceNo2] = @Original_ReferenceNo2)) AND ([Date] = @Original_Date) AND ([SupplierID] = @Original_SupplierID) AND ((@IsNull_SupplierInvoiceNo = 1 AND [SupplierInvoiceNo] IS NULL) OR ([SupplierInvoiceNo] = @Original_SupplierInvoiceNo)) AND ((@IsNull_SupplierInvoiceDate = 1 AND [SupplierInvoiceDate] IS NULL) OR ([SupplierInvoiceDate] = @Original_SupplierInvoiceDate)) AND ((@IsNull_TaxType = 1 AND [TaxType] IS NULL) OR ([TaxType] = @Original_TaxType)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ([SubTotal] = @Original_SubTotal) AND ((@IsNull_PreviousDue = 1 AND [PreviousDue] IS NULL) OR ([PreviousDue] = @Original_PreviousDue)) AND ((@IsNull_FreightCharges = 1 AND [FreightCharges] IS NULL) OR ([FreightCharges] = @Original_FreightCharges)) AND ((@IsNull_OtherCharges = 1 AND [OtherCharges] IS NULL) OR ([OtherCharges] = @Original_OtherCharges)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ([GrandTotal] = @Original_GrandTotal) AND ([TotalPayment] = @Original_TotalPayment) AND ([PaymentDue] = @Original_PaymentDue))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ST_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ST_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PurchaseType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PurchaseType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ReferenceNo1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReferenceNo1", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ReferenceNo1", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReferenceNo1", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ReferenceNo2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReferenceNo2", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ReferenceNo2", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReferenceNo2", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SupplierInvoiceNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SupplierInvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SupplierInvoiceDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceDate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SupplierInvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_TaxType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_IGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CESS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESS", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PreviousDue", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PreviousDue", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PreviousDue", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PreviousDue", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_FreightCharges", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FreightCharges", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_FreightCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "FreightCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_OtherCharges", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OtherCharges", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_OtherCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OtherCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Total", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Total", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_RoundOff", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RoundOff", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TotalPayment", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPayment", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PaymentDue", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PaymentDue", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Stock] ([ST_ID], [InvoiceNo], [PurchaseType], [ReferenceNo1], [ReferenceNo2], [Date], [SupplierID], [SupplierInvoiceNo], [SupplierInvoiceDate], [TaxType], [SGST], [CGST], [IGST], [CESS], [SubTotal], [PreviousDue], [FreightCharges], [OtherCharges], [Total], [RoundOff], [GrandTotal], [TotalPayment], [PaymentDue], [Remarks]) VALUES (@ST_ID, @InvoiceNo, @PurchaseType, @ReferenceNo1, @ReferenceNo2, @Date, @SupplierID, @SupplierInvoiceNo, @SupplierInvoiceDate, @TaxType, @SGST, @CGST, @IGST, @CESS, @SubTotal, @PreviousDue, @FreightCharges, @OtherCharges, @Total, @RoundOff, @GrandTotal, @TotalPayment, @PaymentDue, @Remarks);" & vbCrLf & "SELECT ST_ID, InvoiceNo, PurchaseType, ReferenceNo1, ReferenceNo2, Date, SupplierID, SupplierInvoiceNo, SupplierInvoiceDate, TaxType, SGST, CGST, IGST, CESS, SubTotal, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks FROM Stock WHERE (ST_ID = @ST_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ST_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ST_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PurchaseType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ReferenceNo1", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReferenceNo1", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ReferenceNo2", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReferenceNo2", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SupplierInvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SupplierInvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PreviousDue", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PreviousDue", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@FreightCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "FreightCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OtherCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OtherCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalPayment", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPayment", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaymentDue", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PaymentDue", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Stock] SET [ST_ID] = @ST_ID, [InvoiceNo] = @InvoiceNo, [PurchaseType] = @PurchaseType, [ReferenceNo1] = @ReferenceNo1, [ReferenceNo2] = @ReferenceNo2, [Date] = @Date, [SupplierID] = @SupplierID, [SupplierInvoiceNo] = @SupplierInvoiceNo, [SupplierInvoiceDate] = @SupplierInvoiceDate, [TaxType] = @TaxType, [SGST] = @SGST, [CGST] = @CGST, [IGST] = @IGST, [CESS] = @CESS, [SubTotal] = @SubTotal, [PreviousDue] = @PreviousDue, [FreightCharges] = @FreightCharges, [OtherCharges] = @OtherCharges, [Total] = @Total, [RoundOff] = @RoundOff, [GrandTotal] = @GrandTotal, [TotalPayment] = @TotalPayment, [PaymentDue] = @PaymentDue, [Remarks] = @Remarks WHERE (([ST_ID] = @Original_ST_ID) AND ([InvoiceNo] = @Original_InvoiceNo) AND ((@IsNull_PurchaseType = 1 AND [PurchaseType] IS NULL) OR ([PurchaseType] = @Original_PurchaseType)) AND ((@IsNull_ReferenceNo1 = 1 AND [ReferenceNo1] IS NULL) OR ([ReferenceNo1] = @Original_ReferenceNo1)) AND ((@IsNull_ReferenceNo2 = 1 AND [ReferenceNo2] IS NULL) OR ([ReferenceNo2] = @Original_ReferenceNo2)) AND ([Date] = @Original_Date) AND ([SupplierID] = @Original_SupplierID) AND ((@IsNull_SupplierInvoiceNo = 1 AND [SupplierInvoiceNo] IS NULL) OR ([SupplierInvoiceNo] = @Original_SupplierInvoiceNo)) AND ((@IsNull_SupplierInvoiceDate = 1 AND [SupplierInvoiceDate] IS NULL) OR ([SupplierInvoiceDate] = @Original_SupplierInvoiceDate)) AND ((@IsNull_TaxType = 1 AND [TaxType] IS NULL) OR ([TaxType] = @Original_TaxType)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ([SubTotal] = @Original_SubTotal) AND ((@IsNull_PreviousDue = 1 AND [PreviousDue] IS NULL) OR ([PreviousDue] = @Original_PreviousDue)) AND ((@IsNull_FreightCharges = 1 AND [FreightCharges] IS NULL) OR ([FreightCharges] = @Original_FreightCharges)) AND ((@IsNull_OtherCharges = 1 AND [OtherCharges] IS NULL) OR ([OtherCharges] = @Original_OtherCharges)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ([GrandTotal] = @Original_GrandTotal) AND ([TotalPayment] = @Original_TotalPayment) AND ([PaymentDue] = @Original_PaymentDue));" & vbCrLf & "SELECT ST_ID, InvoiceNo, PurchaseType, ReferenceNo1, ReferenceNo2, Date, SupplierID, SupplierInvoiceNo, SupplierInvoiceDate, TaxType, SGST, CGST, IGST, CESS, SubTotal, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks FROM Stock WHERE (ST_ID = @ST_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ST_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ST_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PurchaseType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ReferenceNo1", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReferenceNo1", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ReferenceNo2", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReferenceNo2", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SupplierInvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SupplierInvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PreviousDue", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PreviousDue", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@FreightCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "FreightCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OtherCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OtherCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalPayment", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPayment", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaymentDue", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PaymentDue", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ST_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ST_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PurchaseType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PurchaseType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ReferenceNo1", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReferenceNo1", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ReferenceNo1", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReferenceNo1", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ReferenceNo2", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReferenceNo2", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ReferenceNo2", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReferenceNo2", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SupplierInvoiceNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SupplierInvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SupplierInvoiceDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceDate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SupplierInvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "SupplierInvoiceDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_TaxType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_IGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CESS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESS", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PreviousDue", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PreviousDue", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PreviousDue", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PreviousDue", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_FreightCharges", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FreightCharges", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_FreightCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "FreightCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_OtherCharges", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OtherCharges", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_OtherCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OtherCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Total", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Total", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_RoundOff", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RoundOff", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TotalPayment", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPayment", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PaymentDue", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "PaymentDue", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E6C8 RID: 59080 RVA: 0x00065C9E File Offset: 0x00063E9E
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E6C9 RID: 59081 RVA: 0x008B42A8 File Offset: 0x008B24A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT ST_ID, InvoiceNo, PurchaseType, ReferenceNo1, ReferenceNo2, Date, SupplierID, SupplierInvoiceNo, SupplierInvoiceDate, TaxType, SGST, CGST, IGST, CESS, SubTotal, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks FROM dbo.Stock"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E6CA RID: 59082 RVA: 0x008B4308 File Offset: 0x008B2508
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.StockDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E6CB RID: 59083 RVA: 0x008B4350 File Offset: 0x008B2550
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.StockDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim stockDataTable As Inventory_DBDataSet.StockDataTable = New Inventory_DBDataSet.StockDataTable()
			Me.Adapter.Fill(stockDataTable)
			Return stockDataTable
		End Function

		' Token: 0x0600E6CC RID: 59084 RVA: 0x008B438C File Offset: 0x008B258C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.StockDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E6CD RID: 59085 RVA: 0x008B43AC File Offset: 0x008B25AC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Stock")
		End Function

		' Token: 0x0600E6CE RID: 59086 RVA: 0x008B43D0 File Offset: 0x008B25D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E6CF RID: 59087 RVA: 0x008B43F8 File Offset: 0x008B25F8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E6D0 RID: 59088 RVA: 0x008B4418 File Offset: 0x008B2618
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_ST_ID As Integer, Original_InvoiceNo As String, Original_PurchaseType As String, Original_ReferenceNo1 As String, Original_ReferenceNo2 As String, Original_Date As DateTime, Original_SupplierID As Integer, Original_SupplierInvoiceNo As String, Original_SupplierInvoiceDate As DateTime?, Original_TaxType As String, Original_SGST As Decimal?, Original_CGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_SubTotal As Decimal, Original_PreviousDue As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal, Original_TotalPayment As Decimal, Original_PaymentDue As Decimal) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_ST_ID
			Dim flag As Boolean = Original_InvoiceNo = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_InvoiceNo")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_InvoiceNo
			Dim flag2 As Boolean = Original_PurchaseType = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(2).Value = 1
				Me.Adapter.DeleteCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(2).Value = 0
				Me.Adapter.DeleteCommand.Parameters(3).Value = Original_PurchaseType
			End If
			Dim flag3 As Boolean = Original_ReferenceNo1 = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(4).Value = 1
				Me.Adapter.DeleteCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(4).Value = 0
				Me.Adapter.DeleteCommand.Parameters(5).Value = Original_ReferenceNo1
			End If
			Dim flag4 As Boolean = Original_ReferenceNo2 = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(6).Value = 1
				Me.Adapter.DeleteCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(6).Value = 0
				Me.Adapter.DeleteCommand.Parameters(7).Value = Original_ReferenceNo2
			End If
			Me.Adapter.DeleteCommand.Parameters(8).Value = Original_Date
			Me.Adapter.DeleteCommand.Parameters(9).Value = Original_SupplierID
			Dim flag5 As Boolean = Original_SupplierInvoiceNo = Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(10).Value = 1
				Me.Adapter.DeleteCommand.Parameters(11).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(10).Value = 0
				Me.Adapter.DeleteCommand.Parameters(11).Value = Original_SupplierInvoiceNo
			End If
			Dim flag6 As Boolean = Original_SupplierInvoiceDate IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(12).Value = 0
				Me.Adapter.DeleteCommand.Parameters(13).Value = Original_SupplierInvoiceDate.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(12).Value = 1
				Me.Adapter.DeleteCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_TaxType = Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(14).Value = 1
				Me.Adapter.DeleteCommand.Parameters(15).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(14).Value = 0
				Me.Adapter.DeleteCommand.Parameters(15).Value = Original_TaxType
			End If
			Dim flag8 As Boolean = Original_SGST IsNot Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(16).Value = 0
				Me.Adapter.DeleteCommand.Parameters(17).Value = Original_SGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(16).Value = 1
				Me.Adapter.DeleteCommand.Parameters(17).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Original_CGST IsNot Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(18).Value = 0
				Me.Adapter.DeleteCommand.Parameters(19).Value = Original_CGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(18).Value = 1
				Me.Adapter.DeleteCommand.Parameters(19).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_IGST IsNot Nothing
			If flag10 Then
				Me.Adapter.DeleteCommand.Parameters(20).Value = 0
				Me.Adapter.DeleteCommand.Parameters(21).Value = Original_IGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(20).Value = 1
				Me.Adapter.DeleteCommand.Parameters(21).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_CESS IsNot Nothing
			If flag11 Then
				Me.Adapter.DeleteCommand.Parameters(22).Value = 0
				Me.Adapter.DeleteCommand.Parameters(23).Value = Original_CESS.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(22).Value = 1
				Me.Adapter.DeleteCommand.Parameters(23).Value = DBNull.Value
			End If
			Me.Adapter.DeleteCommand.Parameters(24).Value = Original_SubTotal
			Dim flag12 As Boolean = Original_PreviousDue IsNot Nothing
			If flag12 Then
				Me.Adapter.DeleteCommand.Parameters(25).Value = 0
				Me.Adapter.DeleteCommand.Parameters(26).Value = Original_PreviousDue.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(25).Value = 1
				Me.Adapter.DeleteCommand.Parameters(26).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_FreightCharges IsNot Nothing
			If flag13 Then
				Me.Adapter.DeleteCommand.Parameters(27).Value = 0
				Me.Adapter.DeleteCommand.Parameters(28).Value = Original_FreightCharges.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(27).Value = 1
				Me.Adapter.DeleteCommand.Parameters(28).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = Original_OtherCharges IsNot Nothing
			If flag14 Then
				Me.Adapter.DeleteCommand.Parameters(29).Value = 0
				Me.Adapter.DeleteCommand.Parameters(30).Value = Original_OtherCharges.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(29).Value = 1
				Me.Adapter.DeleteCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = Original_Total IsNot Nothing
			If flag15 Then
				Me.Adapter.DeleteCommand.Parameters(31).Value = 0
				Me.Adapter.DeleteCommand.Parameters(32).Value = Original_Total.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(31).Value = 1
				Me.Adapter.DeleteCommand.Parameters(32).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = Original_RoundOff IsNot Nothing
			If flag16 Then
				Me.Adapter.DeleteCommand.Parameters(33).Value = 0
				Me.Adapter.DeleteCommand.Parameters(34).Value = Original_RoundOff.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(33).Value = 1
				Me.Adapter.DeleteCommand.Parameters(34).Value = DBNull.Value
			End If
			Me.Adapter.DeleteCommand.Parameters(35).Value = Original_GrandTotal
			Me.Adapter.DeleteCommand.Parameters(36).Value = Original_TotalPayment
			Me.Adapter.DeleteCommand.Parameters(37).Value = Original_PaymentDue
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag17 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag17 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag18 As Boolean = state = ConnectionState.Closed
				If flag18 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6D1 RID: 59089 RVA: 0x008B4F30 File Offset: 0x008B3130
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(ST_ID As Integer, InvoiceNo As String, PurchaseType As String, ReferenceNo1 As String, ReferenceNo2 As String, _Date As DateTime, SupplierID As Integer, SupplierInvoiceNo As String, SupplierInvoiceDate As DateTime?, TaxType As String, SGST As Decimal?, CGST As Decimal?, IGST As Decimal?, CESS As Decimal?, SubTotal As Decimal, PreviousDue As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal, TotalPayment As Decimal, PaymentDue As Decimal, Remarks As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = ST_ID
			Dim flag As Boolean = InvoiceNo = Nothing
			If flag Then
				Throw New ArgumentNullException("InvoiceNo")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = InvoiceNo
			Dim flag2 As Boolean = PurchaseType = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = PurchaseType
			End If
			Dim flag3 As Boolean = ReferenceNo1 = Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = ReferenceNo1
			End If
			Dim flag4 As Boolean = ReferenceNo2 = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = ReferenceNo2
			End If
			Me.Adapter.InsertCommand.Parameters(5).Value = _Date
			Me.Adapter.InsertCommand.Parameters(6).Value = SupplierID
			Dim flag5 As Boolean = SupplierInvoiceNo = Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = SupplierInvoiceNo
			End If
			Dim flag6 As Boolean = SupplierInvoiceDate IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = SupplierInvoiceDate.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = TaxType = Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = TaxType
			End If
			Dim flag8 As Boolean = SGST IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = SGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = CGST IsNot Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = CGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = IGST IsNot Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = IGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = CESS IsNot Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = CESS.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			End If
			Me.Adapter.InsertCommand.Parameters(14).Value = SubTotal
			Dim flag12 As Boolean = PreviousDue IsNot Nothing
			If flag12 Then
				Me.Adapter.InsertCommand.Parameters(15).Value = PreviousDue.Value
			Else
				Me.Adapter.InsertCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = FreightCharges IsNot Nothing
			If flag13 Then
				Me.Adapter.InsertCommand.Parameters(16).Value = FreightCharges.Value
			Else
				Me.Adapter.InsertCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = OtherCharges IsNot Nothing
			If flag14 Then
				Me.Adapter.InsertCommand.Parameters(17).Value = OtherCharges.Value
			Else
				Me.Adapter.InsertCommand.Parameters(17).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = Total IsNot Nothing
			If flag15 Then
				Me.Adapter.InsertCommand.Parameters(18).Value = Total.Value
			Else
				Me.Adapter.InsertCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = RoundOff IsNot Nothing
			If flag16 Then
				Me.Adapter.InsertCommand.Parameters(19).Value = RoundOff.Value
			Else
				Me.Adapter.InsertCommand.Parameters(19).Value = DBNull.Value
			End If
			Me.Adapter.InsertCommand.Parameters(20).Value = GrandTotal
			Me.Adapter.InsertCommand.Parameters(21).Value = TotalPayment
			Me.Adapter.InsertCommand.Parameters(22).Value = PaymentDue
			Dim flag17 As Boolean = Remarks = Nothing
			If flag17 Then
				Throw New ArgumentNullException("Remarks")
			End If
			Me.Adapter.InsertCommand.Parameters(23).Value = Remarks
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

		' Token: 0x0600E6D2 RID: 59090 RVA: 0x008B5668 File Offset: 0x008B3868
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ST_ID As Integer, InvoiceNo As String, PurchaseType As String, ReferenceNo1 As String, ReferenceNo2 As String, _Date As DateTime, SupplierID As Integer, SupplierInvoiceNo As String, SupplierInvoiceDate As DateTime?, TaxType As String, SGST As Decimal?, CGST As Decimal?, IGST As Decimal?, CESS As Decimal?, SubTotal As Decimal, PreviousDue As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal, TotalPayment As Decimal, PaymentDue As Decimal, Remarks As String, Original_ST_ID As Integer, Original_InvoiceNo As String, Original_PurchaseType As String, Original_ReferenceNo1 As String, Original_ReferenceNo2 As String, Original_Date As DateTime, Original_SupplierID As Integer, Original_SupplierInvoiceNo As String, Original_SupplierInvoiceDate As DateTime?, Original_TaxType As String, Original_SGST As Decimal?, Original_CGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_SubTotal As Decimal, Original_PreviousDue As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal, Original_TotalPayment As Decimal, Original_PaymentDue As Decimal) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = ST_ID
			Dim flag As Boolean = InvoiceNo = Nothing
			If flag Then
				Throw New ArgumentNullException("InvoiceNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = InvoiceNo
			Dim flag2 As Boolean = PurchaseType = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = PurchaseType
			End If
			Dim flag3 As Boolean = ReferenceNo1 = Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = ReferenceNo1
			End If
			Dim flag4 As Boolean = ReferenceNo2 = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = ReferenceNo2
			End If
			Me.Adapter.UpdateCommand.Parameters(5).Value = _Date
			Me.Adapter.UpdateCommand.Parameters(6).Value = SupplierID
			Dim flag5 As Boolean = SupplierInvoiceNo = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = SupplierInvoiceNo
			End If
			Dim flag6 As Boolean = SupplierInvoiceDate IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = SupplierInvoiceDate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = TaxType = Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = TaxType
			End If
			Dim flag8 As Boolean = SGST IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = CGST IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = IGST IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = CESS IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(14).Value = SubTotal
			Dim flag12 As Boolean = PreviousDue IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = PreviousDue.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = FreightCharges IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = FreightCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = OtherCharges IsNot Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = OtherCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = Total IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(18).Value = Total.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = RoundOff IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = RoundOff.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(19).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(20).Value = GrandTotal
			Me.Adapter.UpdateCommand.Parameters(21).Value = TotalPayment
			Me.Adapter.UpdateCommand.Parameters(22).Value = PaymentDue
			Dim flag17 As Boolean = Remarks = Nothing
			If flag17 Then
				Throw New ArgumentNullException("Remarks")
			End If
			Me.Adapter.UpdateCommand.Parameters(23).Value = Remarks
			Me.Adapter.UpdateCommand.Parameters(24).Value = Original_ST_ID
			Dim flag18 As Boolean = Original_InvoiceNo = Nothing
			If flag18 Then
				Throw New ArgumentNullException("Original_InvoiceNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(25).Value = Original_InvoiceNo
			Dim flag19 As Boolean = Original_PurchaseType = Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(26).Value = 1
				Me.Adapter.UpdateCommand.Parameters(27).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(26).Value = 0
				Me.Adapter.UpdateCommand.Parameters(27).Value = Original_PurchaseType
			End If
			Dim flag20 As Boolean = Original_ReferenceNo1 = Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(28).Value = 1
				Me.Adapter.UpdateCommand.Parameters(29).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(28).Value = 0
				Me.Adapter.UpdateCommand.Parameters(29).Value = Original_ReferenceNo1
			End If
			Dim flag21 As Boolean = Original_ReferenceNo2 = Nothing
			If flag21 Then
				Me.Adapter.UpdateCommand.Parameters(30).Value = 1
				Me.Adapter.UpdateCommand.Parameters(31).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(30).Value = 0
				Me.Adapter.UpdateCommand.Parameters(31).Value = Original_ReferenceNo2
			End If
			Me.Adapter.UpdateCommand.Parameters(32).Value = Original_Date
			Me.Adapter.UpdateCommand.Parameters(33).Value = Original_SupplierID
			Dim flag22 As Boolean = Original_SupplierInvoiceNo = Nothing
			If flag22 Then
				Me.Adapter.UpdateCommand.Parameters(34).Value = 1
				Me.Adapter.UpdateCommand.Parameters(35).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(34).Value = 0
				Me.Adapter.UpdateCommand.Parameters(35).Value = Original_SupplierInvoiceNo
			End If
			Dim flag23 As Boolean = Original_SupplierInvoiceDate IsNot Nothing
			If flag23 Then
				Me.Adapter.UpdateCommand.Parameters(36).Value = 0
				Me.Adapter.UpdateCommand.Parameters(37).Value = Original_SupplierInvoiceDate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(36).Value = 1
				Me.Adapter.UpdateCommand.Parameters(37).Value = DBNull.Value
			End If
			Dim flag24 As Boolean = Original_TaxType = Nothing
			If flag24 Then
				Me.Adapter.UpdateCommand.Parameters(38).Value = 1
				Me.Adapter.UpdateCommand.Parameters(39).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(38).Value = 0
				Me.Adapter.UpdateCommand.Parameters(39).Value = Original_TaxType
			End If
			Dim flag25 As Boolean = Original_SGST IsNot Nothing
			If flag25 Then
				Me.Adapter.UpdateCommand.Parameters(40).Value = 0
				Me.Adapter.UpdateCommand.Parameters(41).Value = Original_SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(40).Value = 1
				Me.Adapter.UpdateCommand.Parameters(41).Value = DBNull.Value
			End If
			Dim flag26 As Boolean = Original_CGST IsNot Nothing
			If flag26 Then
				Me.Adapter.UpdateCommand.Parameters(42).Value = 0
				Me.Adapter.UpdateCommand.Parameters(43).Value = Original_CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(42).Value = 1
				Me.Adapter.UpdateCommand.Parameters(43).Value = DBNull.Value
			End If
			Dim flag27 As Boolean = Original_IGST IsNot Nothing
			If flag27 Then
				Me.Adapter.UpdateCommand.Parameters(44).Value = 0
				Me.Adapter.UpdateCommand.Parameters(45).Value = Original_IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(44).Value = 1
				Me.Adapter.UpdateCommand.Parameters(45).Value = DBNull.Value
			End If
			Dim flag28 As Boolean = Original_CESS IsNot Nothing
			If flag28 Then
				Me.Adapter.UpdateCommand.Parameters(46).Value = 0
				Me.Adapter.UpdateCommand.Parameters(47).Value = Original_CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(46).Value = 1
				Me.Adapter.UpdateCommand.Parameters(47).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(48).Value = Original_SubTotal
			Dim flag29 As Boolean = Original_PreviousDue IsNot Nothing
			If flag29 Then
				Me.Adapter.UpdateCommand.Parameters(49).Value = 0
				Me.Adapter.UpdateCommand.Parameters(50).Value = Original_PreviousDue.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(49).Value = 1
				Me.Adapter.UpdateCommand.Parameters(50).Value = DBNull.Value
			End If
			Dim flag30 As Boolean = Original_FreightCharges IsNot Nothing
			If flag30 Then
				Me.Adapter.UpdateCommand.Parameters(51).Value = 0
				Me.Adapter.UpdateCommand.Parameters(52).Value = Original_FreightCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(51).Value = 1
				Me.Adapter.UpdateCommand.Parameters(52).Value = DBNull.Value
			End If
			Dim flag31 As Boolean = Original_OtherCharges IsNot Nothing
			If flag31 Then
				Me.Adapter.UpdateCommand.Parameters(53).Value = 0
				Me.Adapter.UpdateCommand.Parameters(54).Value = Original_OtherCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(53).Value = 1
				Me.Adapter.UpdateCommand.Parameters(54).Value = DBNull.Value
			End If
			Dim flag32 As Boolean = Original_Total IsNot Nothing
			If flag32 Then
				Me.Adapter.UpdateCommand.Parameters(55).Value = 0
				Me.Adapter.UpdateCommand.Parameters(56).Value = Original_Total.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(55).Value = 1
				Me.Adapter.UpdateCommand.Parameters(56).Value = DBNull.Value
			End If
			Dim flag33 As Boolean = Original_RoundOff IsNot Nothing
			If flag33 Then
				Me.Adapter.UpdateCommand.Parameters(57).Value = 0
				Me.Adapter.UpdateCommand.Parameters(58).Value = Original_RoundOff.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(57).Value = 1
				Me.Adapter.UpdateCommand.Parameters(58).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(59).Value = Original_GrandTotal
			Me.Adapter.UpdateCommand.Parameters(60).Value = Original_TotalPayment
			Me.Adapter.UpdateCommand.Parameters(61).Value = Original_PaymentDue
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag34 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag34 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag35 As Boolean = state = ConnectionState.Closed
				If flag35 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E6D3 RID: 59091 RVA: 0x008B6824 File Offset: 0x008B4A24
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(InvoiceNo As String, PurchaseType As String, ReferenceNo1 As String, ReferenceNo2 As String, _Date As DateTime, SupplierID As Integer, SupplierInvoiceNo As String, SupplierInvoiceDate As DateTime?, TaxType As String, SGST As Decimal?, CGST As Decimal?, IGST As Decimal?, CESS As Decimal?, SubTotal As Decimal, PreviousDue As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal, TotalPayment As Decimal, PaymentDue As Decimal, Remarks As String, Original_ST_ID As Integer, Original_InvoiceNo As String, Original_PurchaseType As String, Original_ReferenceNo1 As String, Original_ReferenceNo2 As String, Original_Date As DateTime, Original_SupplierID As Integer, Original_SupplierInvoiceNo As String, Original_SupplierInvoiceDate As DateTime?, Original_TaxType As String, Original_SGST As Decimal?, Original_CGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_SubTotal As Decimal, Original_PreviousDue As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal, Original_TotalPayment As Decimal, Original_PaymentDue As Decimal) As Integer
			Return Me.Update(Original_ST_ID, InvoiceNo, PurchaseType, ReferenceNo1, ReferenceNo2, _Date, SupplierID, SupplierInvoiceNo, SupplierInvoiceDate, TaxType, SGST, CGST, IGST, CESS, SubTotal, PreviousDue, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks, Original_ST_ID, Original_InvoiceNo, Original_PurchaseType, Original_ReferenceNo1, Original_ReferenceNo2, Original_Date, Original_SupplierID, Original_SupplierInvoiceNo, Original_SupplierInvoiceDate, Original_TaxType, Original_SGST, Original_CGST, Original_IGST, Original_CESS, Original_SubTotal, Original_PreviousDue, Original_FreightCharges, Original_OtherCharges, Original_Total, Original_RoundOff, Original_GrandTotal, Original_TotalPayment, Original_PaymentDue)
		End Function

		' Token: 0x040058D5 RID: 22741
		Private _connection As SqlConnection

		' Token: 0x040058D6 RID: 22742
		Private _transaction As SqlTransaction

		' Token: 0x040058D7 RID: 22743
		Private _commandCollection As SqlCommand()

		' Token: 0x040058D8 RID: 22744
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
