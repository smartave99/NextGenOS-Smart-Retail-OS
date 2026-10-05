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
	' Token: 0x02000451 RID: 1105
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class InvoiceInfoTableAdapter
		Inherits Component

		' Token: 0x1700580F RID: 22543
		' (get) Token: 0x0600E494 RID: 58516 RVA: 0x000654FA File Offset: 0x000636FA
		' (set) Token: 0x0600E495 RID: 58517 RVA: 0x00065504 File Offset: 0x00063704
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E496 RID: 58518 RVA: 0x0006550D File Offset: 0x0006370D
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005810 RID: 22544
		' (get) Token: 0x0600E497 RID: 58519 RVA: 0x0087DC3C File Offset: 0x0087BE3C
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

		' Token: 0x17005811 RID: 22545
		' (get) Token: 0x0600E498 RID: 58520 RVA: 0x0087DC6C File Offset: 0x0087BE6C
		' (set) Token: 0x0600E499 RID: 58521 RVA: 0x0087DC9C File Offset: 0x0087BE9C
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

		' Token: 0x17005812 RID: 22546
		' (get) Token: 0x0600E49A RID: 58522 RVA: 0x0087DD60 File Offset: 0x0087BF60
		' (set) Token: 0x0600E49B RID: 58523 RVA: 0x0087DD78 File Offset: 0x0087BF78
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

		' Token: 0x17005813 RID: 22547
		' (get) Token: 0x0600E49C RID: 58524 RVA: 0x0087DE60 File Offset: 0x0087C060
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

		' Token: 0x17005814 RID: 22548
		' (get) Token: 0x0600E49D RID: 58525 RVA: 0x0087DE90 File Offset: 0x0087C090
		' (set) Token: 0x0600E49E RID: 58526 RVA: 0x0006551F File Offset: 0x0006371F
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

		' Token: 0x0600E49F RID: 58527 RVA: 0x0087DEA8 File Offset: 0x0087C0A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "InvoiceInfo"
			dataTableMapping.ColumnMappings.Add("Inv_ID", "Inv_ID")
			dataTableMapping.ColumnMappings.Add("InvoiceNo", "InvoiceNo")
			dataTableMapping.ColumnMappings.Add("InvoiceDate", "InvoiceDate")
			dataTableMapping.ColumnMappings.Add("TaxType", "TaxType")
			dataTableMapping.ColumnMappings.Add("Customer_ID", "Customer_ID")
			dataTableMapping.ColumnMappings.Add("SalesmanID", "SalesmanID")
			dataTableMapping.ColumnMappings.Add("SubTotal", "SubTotal")
			dataTableMapping.ColumnMappings.Add("CGST", "CGST")
			dataTableMapping.ColumnMappings.Add("SGST", "SGST")
			dataTableMapping.ColumnMappings.Add("IGST", "IGST")
			dataTableMapping.ColumnMappings.Add("CESS", "CESS")
			dataTableMapping.ColumnMappings.Add("FreightCharges", "FreightCharges")
			dataTableMapping.ColumnMappings.Add("OtherCharges", "OtherCharges")
			dataTableMapping.ColumnMappings.Add("Total", "Total")
			dataTableMapping.ColumnMappings.Add("RoundOff", "RoundOff")
			dataTableMapping.ColumnMappings.Add("GrandTotal", "GrandTotal")
			dataTableMapping.ColumnMappings.Add("TotalPaid", "TotalPaid")
			dataTableMapping.ColumnMappings.Add("Balance", "Balance")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[InvoiceInfo] WHERE (([Inv_ID] = @Original_Inv_ID) AND ([InvoiceNo] = @Original_InvoiceNo) AND ([InvoiceDate] = @Original_InvoiceDate) AND ((@IsNull_TaxType = 1 AND [TaxType] IS NULL) OR ([TaxType] = @Original_TaxType)) AND ([Customer_ID] = @Original_Customer_ID) AND ((@IsNull_SalesmanID = 1 AND [SalesmanID] IS NULL) OR ([SalesmanID] = @Original_SalesmanID)) AND ((@IsNull_SubTotal = 1 AND [SubTotal] IS NULL) OR ([SubTotal] = @Original_SubTotal)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_FreightCharges = 1 AND [FreightCharges] IS NULL) OR ([FreightCharges] = @Original_FreightCharges)) AND ((@IsNull_OtherCharges = 1 AND [OtherCharges] IS NULL) OR ([OtherCharges] = @Original_OtherCharges)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ([GrandTotal] = @Original_GrandTotal) AND ([TotalPaid] = @Original_TotalPaid) AND ([Balance] = @Original_Balance))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Inv_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Inv_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_InvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "InvoiceDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_TaxType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Customer_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Customer_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SalesmanID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesmanID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SalesmanID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesmanID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SubTotal", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubTotal", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_IGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CESS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESS", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_FreightCharges", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FreightCharges", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_FreightCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "FreightCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_OtherCharges", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OtherCharges", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_OtherCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OtherCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Total", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Total", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_RoundOff", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RoundOff", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Balance", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Balance", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[InvoiceInfo] ([Inv_ID], [InvoiceNo], [InvoiceDate], [TaxType], [Customer_ID], [SalesmanID], [SubTotal], [CGST], [SGST], [IGST], [CESS], [FreightCharges], [OtherCharges], [Total], [RoundOff], [GrandTotal], [TotalPaid], [Balance], [Remarks]) VALUES (@Inv_ID, @InvoiceNo, @InvoiceDate, @TaxType, @Customer_ID, @SalesmanID, @SubTotal, @CGST, @SGST, @IGST, @CESS, @FreightCharges, @OtherCharges, @Total, @RoundOff, @GrandTotal, @TotalPaid, @Balance, @Remarks);" & vbCrLf & "SELECT Inv_ID, InvoiceNo, InvoiceDate, TaxType, Customer_ID, SalesmanID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPaid, Balance, Remarks FROM InvoiceInfo WHERE (Inv_ID = @Inv_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Inv_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Inv_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@InvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "InvoiceDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Customer_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Customer_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SalesmanID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesmanID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@FreightCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "FreightCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OtherCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OtherCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Balance", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Balance", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[InvoiceInfo] SET [Inv_ID] = @Inv_ID, [InvoiceNo] = @InvoiceNo, [InvoiceDate] = @InvoiceDate, [TaxType] = @TaxType, [Customer_ID] = @Customer_ID, [SalesmanID] = @SalesmanID, [SubTotal] = @SubTotal, [CGST] = @CGST, [SGST] = @SGST, [IGST] = @IGST, [CESS] = @CESS, [FreightCharges] = @FreightCharges, [OtherCharges] = @OtherCharges, [Total] = @Total, [RoundOff] = @RoundOff, [GrandTotal] = @GrandTotal, [TotalPaid] = @TotalPaid, [Balance] = @Balance, [Remarks] = @Remarks WHERE (([Inv_ID] = @Original_Inv_ID) AND ([InvoiceNo] = @Original_InvoiceNo) AND ([InvoiceDate] = @Original_InvoiceDate) AND ((@IsNull_TaxType = 1 AND [TaxType] IS NULL) OR ([TaxType] = @Original_TaxType)) AND ([Customer_ID] = @Original_Customer_ID) AND ((@IsNull_SalesmanID = 1 AND [SalesmanID] IS NULL) OR ([SalesmanID] = @Original_SalesmanID)) AND ((@IsNull_SubTotal = 1 AND [SubTotal] IS NULL) OR ([SubTotal] = @Original_SubTotal)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_FreightCharges = 1 AND [FreightCharges] IS NULL) OR ([FreightCharges] = @Original_FreightCharges)) AND ((@IsNull_OtherCharges = 1 AND [OtherCharges] IS NULL) OR ([OtherCharges] = @Original_OtherCharges)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ([GrandTotal] = @Original_GrandTotal) AND ([TotalPaid] = @Original_TotalPaid) AND ([Balance] = @Original_Balance));" & vbCrLf & "SELECT Inv_ID, InvoiceNo, InvoiceDate, TaxType, Customer_ID, SalesmanID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPaid, Balance, Remarks FROM InvoiceInfo WHERE (Inv_ID = @Inv_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Inv_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Inv_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@InvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "InvoiceDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Customer_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Customer_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SalesmanID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesmanID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@FreightCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "FreightCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OtherCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OtherCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Balance", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Balance", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Inv_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Inv_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_InvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "InvoiceDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_TaxType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Customer_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Customer_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SalesmanID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesmanID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SalesmanID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesmanID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SubTotal", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SubTotal", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_IGST", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IGST", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CESS", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CESS", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_FreightCharges", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "FreightCharges", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_FreightCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "FreightCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_OtherCharges", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OtherCharges", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_OtherCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "OtherCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Total", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Total", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_RoundOff", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RoundOff", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Balance", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Balance", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E4A0 RID: 58528 RVA: 0x00065529 File Offset: 0x00063729
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E4A1 RID: 58529 RVA: 0x0087F9C0 File Offset: 0x0087DBC0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Inv_ID, InvoiceNo, InvoiceDate, TaxType, Customer_ID, SalesmanID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPaid, Balance, Remarks FROM dbo.InvoiceInfo"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E4A2 RID: 58530 RVA: 0x0087FA20 File Offset: 0x0087DC20
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.InvoiceInfoDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E4A3 RID: 58531 RVA: 0x0087FA68 File Offset: 0x0087DC68
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.InvoiceInfoDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim invoiceInfoDataTable As Inventory_DBDataSet.InvoiceInfoDataTable = New Inventory_DBDataSet.InvoiceInfoDataTable()
			Me.Adapter.Fill(invoiceInfoDataTable)
			Return invoiceInfoDataTable
		End Function

		' Token: 0x0600E4A4 RID: 58532 RVA: 0x0087FAA4 File Offset: 0x0087DCA4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.InvoiceInfoDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E4A5 RID: 58533 RVA: 0x0087FAC4 File Offset: 0x0087DCC4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "InvoiceInfo")
		End Function

		' Token: 0x0600E4A6 RID: 58534 RVA: 0x0087FAE8 File Offset: 0x0087DCE8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E4A7 RID: 58535 RVA: 0x0087FB10 File Offset: 0x0087DD10
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E4A8 RID: 58536 RVA: 0x0087FB30 File Offset: 0x0087DD30
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Inv_ID As Integer, Original_InvoiceNo As String, Original_InvoiceDate As DateTime, Original_TaxType As String, Original_Customer_ID As Integer, Original_SalesmanID As Integer?, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal, Original_TotalPaid As Decimal, Original_Balance As Decimal) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Inv_ID
			Dim flag As Boolean = Original_InvoiceNo = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_InvoiceNo")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_InvoiceNo
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_InvoiceDate
			Dim flag2 As Boolean = Original_TaxType = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_TaxType
			End If
			Me.Adapter.DeleteCommand.Parameters(5).Value = Original_Customer_ID
			Dim flag3 As Boolean = Original_SalesmanID IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(6).Value = 0
				Me.Adapter.DeleteCommand.Parameters(7).Value = Original_SalesmanID.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(6).Value = 1
				Me.Adapter.DeleteCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Original_SubTotal IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(8).Value = 0
				Me.Adapter.DeleteCommand.Parameters(9).Value = Original_SubTotal.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(8).Value = 1
				Me.Adapter.DeleteCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_CGST IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(10).Value = 0
				Me.Adapter.DeleteCommand.Parameters(11).Value = Original_CGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(10).Value = 1
				Me.Adapter.DeleteCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_SGST IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(12).Value = 0
				Me.Adapter.DeleteCommand.Parameters(13).Value = Original_SGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(12).Value = 1
				Me.Adapter.DeleteCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_IGST IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(14).Value = 0
				Me.Adapter.DeleteCommand.Parameters(15).Value = Original_IGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(14).Value = 1
				Me.Adapter.DeleteCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_CESS IsNot Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(16).Value = 0
				Me.Adapter.DeleteCommand.Parameters(17).Value = Original_CESS.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(16).Value = 1
				Me.Adapter.DeleteCommand.Parameters(17).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Original_FreightCharges IsNot Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(18).Value = 0
				Me.Adapter.DeleteCommand.Parameters(19).Value = Original_FreightCharges.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(18).Value = 1
				Me.Adapter.DeleteCommand.Parameters(19).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_OtherCharges IsNot Nothing
			If flag10 Then
				Me.Adapter.DeleteCommand.Parameters(20).Value = 0
				Me.Adapter.DeleteCommand.Parameters(21).Value = Original_OtherCharges.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(20).Value = 1
				Me.Adapter.DeleteCommand.Parameters(21).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_Total IsNot Nothing
			If flag11 Then
				Me.Adapter.DeleteCommand.Parameters(22).Value = 0
				Me.Adapter.DeleteCommand.Parameters(23).Value = Original_Total.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(22).Value = 1
				Me.Adapter.DeleteCommand.Parameters(23).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_RoundOff IsNot Nothing
			If flag12 Then
				Me.Adapter.DeleteCommand.Parameters(24).Value = 0
				Me.Adapter.DeleteCommand.Parameters(25).Value = Original_RoundOff.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(24).Value = 1
				Me.Adapter.DeleteCommand.Parameters(25).Value = DBNull.Value
			End If
			Me.Adapter.DeleteCommand.Parameters(26).Value = Original_GrandTotal
			Me.Adapter.DeleteCommand.Parameters(27).Value = Original_TotalPaid
			Me.Adapter.DeleteCommand.Parameters(28).Value = Original_Balance
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag13 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag13 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag14 As Boolean = state = ConnectionState.Closed
				If flag14 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E4A9 RID: 58537 RVA: 0x008803CC File Offset: 0x0087E5CC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(Inv_ID As Integer, InvoiceNo As String, InvoiceDate As DateTime, TaxType As String, Customer_ID As Integer, SalesmanID As Integer?, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal, TotalPaid As Decimal, Balance As Decimal, Remarks As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = Inv_ID
			Dim flag As Boolean = InvoiceNo = Nothing
			If flag Then
				Throw New ArgumentNullException("InvoiceNo")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = InvoiceNo
			Me.Adapter.InsertCommand.Parameters(2).Value = InvoiceDate
			Dim flag2 As Boolean = TaxType = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = TaxType
			End If
			Me.Adapter.InsertCommand.Parameters(4).Value = Customer_ID
			Dim flag3 As Boolean = SalesmanID IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = SalesmanID.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = SubTotal IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = SubTotal.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = CGST IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = CGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = SGST IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = SGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = IGST IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = IGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CESS IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = CESS.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = FreightCharges IsNot Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = FreightCharges.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = OtherCharges IsNot Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = OtherCharges.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Total IsNot Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = Total.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = RoundOff IsNot Nothing
			If flag12 Then
				Me.Adapter.InsertCommand.Parameters(14).Value = RoundOff.Value
			Else
				Me.Adapter.InsertCommand.Parameters(14).Value = DBNull.Value
			End If
			Me.Adapter.InsertCommand.Parameters(15).Value = GrandTotal
			Me.Adapter.InsertCommand.Parameters(16).Value = TotalPaid
			Me.Adapter.InsertCommand.Parameters(17).Value = Balance
			Dim flag13 As Boolean = Remarks = Nothing
			If flag13 Then
				Me.Adapter.InsertCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(18).Value = Remarks
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

		' Token: 0x0600E4AA RID: 58538 RVA: 0x008809B8 File Offset: 0x0087EBB8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Inv_ID As Integer, InvoiceNo As String, InvoiceDate As DateTime, TaxType As String, Customer_ID As Integer, SalesmanID As Integer?, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal, TotalPaid As Decimal, Balance As Decimal, Remarks As String, Original_Inv_ID As Integer, Original_InvoiceNo As String, Original_InvoiceDate As DateTime, Original_TaxType As String, Original_Customer_ID As Integer, Original_SalesmanID As Integer?, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal, Original_TotalPaid As Decimal, Original_Balance As Decimal) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = Inv_ID
			Dim flag As Boolean = InvoiceNo = Nothing
			If flag Then
				Throw New ArgumentNullException("InvoiceNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = InvoiceNo
			Me.Adapter.UpdateCommand.Parameters(2).Value = InvoiceDate
			Dim flag2 As Boolean = TaxType = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = TaxType
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = Customer_ID
			Dim flag3 As Boolean = SalesmanID IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = SalesmanID.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = SubTotal IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = SubTotal.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = CGST IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = SGST IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = IGST IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CESS IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = FreightCharges IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = FreightCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = OtherCharges IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = OtherCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Total IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = Total.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = RoundOff IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = RoundOff.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(15).Value = GrandTotal
			Me.Adapter.UpdateCommand.Parameters(16).Value = TotalPaid
			Me.Adapter.UpdateCommand.Parameters(17).Value = Balance
			Dim flag13 As Boolean = Remarks = Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(18).Value = Remarks
			End If
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_Inv_ID
			Dim flag14 As Boolean = Original_InvoiceNo = Nothing
			If flag14 Then
				Throw New ArgumentNullException("Original_InvoiceNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(20).Value = Original_InvoiceNo
			Me.Adapter.UpdateCommand.Parameters(21).Value = Original_InvoiceDate
			Dim flag15 As Boolean = Original_TaxType = Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(22).Value = 1
				Me.Adapter.UpdateCommand.Parameters(23).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(22).Value = 0
				Me.Adapter.UpdateCommand.Parameters(23).Value = Original_TaxType
			End If
			Me.Adapter.UpdateCommand.Parameters(24).Value = Original_Customer_ID
			Dim flag16 As Boolean = Original_SalesmanID IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(25).Value = 0
				Me.Adapter.UpdateCommand.Parameters(26).Value = Original_SalesmanID.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(25).Value = 1
				Me.Adapter.UpdateCommand.Parameters(26).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Original_SubTotal IsNot Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(27).Value = 0
				Me.Adapter.UpdateCommand.Parameters(28).Value = Original_SubTotal.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(27).Value = 1
				Me.Adapter.UpdateCommand.Parameters(28).Value = DBNull.Value
			End If
			Dim flag18 As Boolean = Original_CGST IsNot Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(29).Value = 0
				Me.Adapter.UpdateCommand.Parameters(30).Value = Original_CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(29).Value = 1
				Me.Adapter.UpdateCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim flag19 As Boolean = Original_SGST IsNot Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(31).Value = 0
				Me.Adapter.UpdateCommand.Parameters(32).Value = Original_SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(31).Value = 1
				Me.Adapter.UpdateCommand.Parameters(32).Value = DBNull.Value
			End If
			Dim flag20 As Boolean = Original_IGST IsNot Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(33).Value = 0
				Me.Adapter.UpdateCommand.Parameters(34).Value = Original_IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(33).Value = 1
				Me.Adapter.UpdateCommand.Parameters(34).Value = DBNull.Value
			End If
			Dim flag21 As Boolean = Original_CESS IsNot Nothing
			If flag21 Then
				Me.Adapter.UpdateCommand.Parameters(35).Value = 0
				Me.Adapter.UpdateCommand.Parameters(36).Value = Original_CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(35).Value = 1
				Me.Adapter.UpdateCommand.Parameters(36).Value = DBNull.Value
			End If
			Dim flag22 As Boolean = Original_FreightCharges IsNot Nothing
			If flag22 Then
				Me.Adapter.UpdateCommand.Parameters(37).Value = 0
				Me.Adapter.UpdateCommand.Parameters(38).Value = Original_FreightCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(37).Value = 1
				Me.Adapter.UpdateCommand.Parameters(38).Value = DBNull.Value
			End If
			Dim flag23 As Boolean = Original_OtherCharges IsNot Nothing
			If flag23 Then
				Me.Adapter.UpdateCommand.Parameters(39).Value = 0
				Me.Adapter.UpdateCommand.Parameters(40).Value = Original_OtherCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(39).Value = 1
				Me.Adapter.UpdateCommand.Parameters(40).Value = DBNull.Value
			End If
			Dim flag24 As Boolean = Original_Total IsNot Nothing
			If flag24 Then
				Me.Adapter.UpdateCommand.Parameters(41).Value = 0
				Me.Adapter.UpdateCommand.Parameters(42).Value = Original_Total.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(41).Value = 1
				Me.Adapter.UpdateCommand.Parameters(42).Value = DBNull.Value
			End If
			Dim flag25 As Boolean = Original_RoundOff IsNot Nothing
			If flag25 Then
				Me.Adapter.UpdateCommand.Parameters(43).Value = 0
				Me.Adapter.UpdateCommand.Parameters(44).Value = Original_RoundOff.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(43).Value = 1
				Me.Adapter.UpdateCommand.Parameters(44).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(45).Value = Original_GrandTotal
			Me.Adapter.UpdateCommand.Parameters(46).Value = Original_TotalPaid
			Me.Adapter.UpdateCommand.Parameters(47).Value = Original_Balance
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag26 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag26 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag27 As Boolean = state = ConnectionState.Closed
				If flag27 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E4AB RID: 58539 RVA: 0x008817A8 File Offset: 0x0087F9A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(InvoiceNo As String, InvoiceDate As DateTime, TaxType As String, Customer_ID As Integer, SalesmanID As Integer?, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal, TotalPaid As Decimal, Balance As Decimal, Remarks As String, Original_Inv_ID As Integer, Original_InvoiceNo As String, Original_InvoiceDate As DateTime, Original_TaxType As String, Original_Customer_ID As Integer, Original_SalesmanID As Integer?, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal, Original_TotalPaid As Decimal, Original_Balance As Decimal) As Integer
			Return Me.Update(Original_Inv_ID, InvoiceNo, InvoiceDate, TaxType, Customer_ID, SalesmanID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPaid, Balance, Remarks, Original_Inv_ID, Original_InvoiceNo, Original_InvoiceDate, Original_TaxType, Original_Customer_ID, Original_SalesmanID, Original_SubTotal, Original_CGST, Original_SGST, Original_IGST, Original_CESS, Original_FreightCharges, Original_OtherCharges, Original_Total, Original_RoundOff, Original_GrandTotal, Original_TotalPaid, Original_Balance)
		End Function

		' Token: 0x04005862 RID: 22626
		Private _connection As SqlConnection

		' Token: 0x04005863 RID: 22627
		Private _transaction As SqlTransaction

		' Token: 0x04005864 RID: 22628
		Private _commandCollection As SqlCommand()

		' Token: 0x04005865 RID: 22629
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
