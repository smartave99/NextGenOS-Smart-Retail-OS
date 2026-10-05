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
	' Token: 0x02000459 RID: 1113
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class PurchaseOrderTableAdapter
		Inherits Component

		' Token: 0x1700583F RID: 22591
		' (get) Token: 0x0600E554 RID: 58708 RVA: 0x00065792 File Offset: 0x00063992
		' (set) Token: 0x0600E555 RID: 58709 RVA: 0x0006579C File Offset: 0x0006399C
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E556 RID: 58710 RVA: 0x000657A5 File Offset: 0x000639A5
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005840 RID: 22592
		' (get) Token: 0x0600E557 RID: 58711 RVA: 0x0088CF00 File Offset: 0x0088B100
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

		' Token: 0x17005841 RID: 22593
		' (get) Token: 0x0600E558 RID: 58712 RVA: 0x0088CF30 File Offset: 0x0088B130
		' (set) Token: 0x0600E559 RID: 58713 RVA: 0x0088CF60 File Offset: 0x0088B160
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

		' Token: 0x17005842 RID: 22594
		' (get) Token: 0x0600E55A RID: 58714 RVA: 0x0088D024 File Offset: 0x0088B224
		' (set) Token: 0x0600E55B RID: 58715 RVA: 0x0088D03C File Offset: 0x0088B23C
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

		' Token: 0x17005843 RID: 22595
		' (get) Token: 0x0600E55C RID: 58716 RVA: 0x0088D124 File Offset: 0x0088B324
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

		' Token: 0x17005844 RID: 22596
		' (get) Token: 0x0600E55D RID: 58717 RVA: 0x0088D154 File Offset: 0x0088B354
		' (set) Token: 0x0600E55E RID: 58718 RVA: 0x000657B7 File Offset: 0x000639B7
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

		' Token: 0x0600E55F RID: 58719 RVA: 0x0088D16C File Offset: 0x0088B36C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "PurchaseOrder"
			dataTableMapping.ColumnMappings.Add("PO_ID", "PO_ID")
			dataTableMapping.ColumnMappings.Add("PONo", "PONo")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("SupplierID", "SupplierID")
			dataTableMapping.ColumnMappings.Add("TaxType", "TaxType")
			dataTableMapping.ColumnMappings.Add("SGST", "SGST")
			dataTableMapping.ColumnMappings.Add("CGST", "CGST")
			dataTableMapping.ColumnMappings.Add("IGST", "IGST")
			dataTableMapping.ColumnMappings.Add("CESS", "CESS")
			dataTableMapping.ColumnMappings.Add("SubTotal", "SubTotal")
			dataTableMapping.ColumnMappings.Add("GrandTotal", "GrandTotal")
			dataTableMapping.ColumnMappings.Add("TermsAndConditions", "TermsAndConditions")
			dataTableMapping.ColumnMappings.Add("Terms", "Terms")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[PurchaseOrder] WHERE (([PO_ID] = @Original_PO_ID) AND ([PONo] = @Original_PONo) AND ([Date] = @Original_Date) AND ([SupplierID] = @Original_SupplierID) AND ((@IsNull_TaxType = 1 AND [TaxType] IS NULL) OR ([TaxType] = @Original_TaxType)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ([SubTotal] = @Original_SubTotal) AND ([GrandTotal] = @Original_GrandTotal) AND ((@IsNull_Terms = 1 AND [Terms] IS NULL) OR ([Terms] = @Original_Terms)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PO_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PO_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PONo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PONo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Terms", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Terms", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Terms", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Terms", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[PurchaseOrder] ([PO_ID], [PONo], [Date], [SupplierID], [TaxType], [SGST], [CGST], [IGST], [CESS], [SubTotal], [GrandTotal], [TermsAndConditions], [Terms]) VALUES (@PO_ID, @PONo, @Date, @SupplierID, @TaxType, @SGST, @CGST, @IGST, @CESS, @SubTotal, @GrandTotal, @TermsAndConditions, @Terms);" & vbCrLf & "SELECT PO_ID, PONo, Date, SupplierID, TaxType, SGST, CGST, IGST, CESS, SubTotal, GrandTotal, TermsAndConditions, Terms FROM PurchaseOrder WHERE (PO_ID = @PO_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PO_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PO_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PONo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PONo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TermsAndConditions", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TermsAndConditions", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Terms", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Terms", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[PurchaseOrder] SET [PO_ID] = @PO_ID, [PONo] = @PONo, [Date] = @Date, [SupplierID] = @SupplierID, [TaxType] = @TaxType, [SGST] = @SGST, [CGST] = @CGST, [IGST] = @IGST, [CESS] = @CESS, [SubTotal] = @SubTotal, [GrandTotal] = @GrandTotal, [TermsAndConditions] = @TermsAndConditions, [Terms] = @Terms WHERE (([PO_ID] = @Original_PO_ID) AND ([PONo] = @Original_PONo) AND ([Date] = @Original_Date) AND ([SupplierID] = @Original_SupplierID) AND ((@IsNull_TaxType = 1 AND [TaxType] IS NULL) OR ([TaxType] = @Original_TaxType)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ([SubTotal] = @Original_SubTotal) AND ([GrandTotal] = @Original_GrandTotal) AND ((@IsNull_Terms = 1 AND [Terms] IS NULL) OR ([Terms] = @Original_Terms)));" & vbCrLf & "SELECT PO_ID, PONo, Date, SupplierID, TaxType, SGST, CGST, IGST, CESS, SubTotal, GrandTotal, TermsAndConditions, Terms FROM PurchaseOrder WHERE (PO_ID = @PO_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PO_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PO_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PONo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PONo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TermsAndConditions", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "TermsAndConditions", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Terms", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Terms", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PO_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PO_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PONo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PONo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Terms", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Terms", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Terms", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Terms", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E560 RID: 58720 RVA: 0x000657C1 File Offset: 0x000639C1
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E561 RID: 58721 RVA: 0x0088E36C File Offset: 0x0088C56C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT PO_ID, PONo, Date, SupplierID, TaxType, SGST, CGST, IGST, CESS, SubTotal, GrandTotal, TermsAndConditions, Terms FROM dbo.PurchaseOrder"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E562 RID: 58722 RVA: 0x0088E3CC File Offset: 0x0088C5CC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.PurchaseOrderDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E563 RID: 58723 RVA: 0x0088E414 File Offset: 0x0088C614
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.PurchaseOrderDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim purchaseOrderDataTable As Inventory_DBDataSet.PurchaseOrderDataTable = New Inventory_DBDataSet.PurchaseOrderDataTable()
			Me.Adapter.Fill(purchaseOrderDataTable)
			Return purchaseOrderDataTable
		End Function

		' Token: 0x0600E564 RID: 58724 RVA: 0x0088E450 File Offset: 0x0088C650
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.PurchaseOrderDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E565 RID: 58725 RVA: 0x0088E470 File Offset: 0x0088C670
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "PurchaseOrder")
		End Function

		' Token: 0x0600E566 RID: 58726 RVA: 0x0088E494 File Offset: 0x0088C694
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E567 RID: 58727 RVA: 0x0088E4BC File Offset: 0x0088C6BC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E568 RID: 58728 RVA: 0x0088E4DC File Offset: 0x0088C6DC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_PO_ID As Integer, Original_PONo As String, Original_Date As DateTime, Original_SupplierID As Integer, Original_TaxType As String, Original_SGST As Decimal?, Original_CGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_SubTotal As Decimal, Original_GrandTotal As Decimal, Original_Terms As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_PO_ID
			Dim flag As Boolean = Original_PONo = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_PONo")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_PONo
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Date
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_SupplierID
			Dim flag2 As Boolean = Original_TaxType = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(4).Value = 1
				Me.Adapter.DeleteCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(4).Value = 0
				Me.Adapter.DeleteCommand.Parameters(5).Value = Original_TaxType
			End If
			Dim flag3 As Boolean = Original_SGST IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(6).Value = 0
				Me.Adapter.DeleteCommand.Parameters(7).Value = Original_SGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(6).Value = 1
				Me.Adapter.DeleteCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Original_CGST IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(8).Value = 0
				Me.Adapter.DeleteCommand.Parameters(9).Value = Original_CGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(8).Value = 1
				Me.Adapter.DeleteCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_IGST IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(10).Value = 0
				Me.Adapter.DeleteCommand.Parameters(11).Value = Original_IGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(10).Value = 1
				Me.Adapter.DeleteCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_CESS IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(12).Value = 0
				Me.Adapter.DeleteCommand.Parameters(13).Value = Original_CESS.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(12).Value = 1
				Me.Adapter.DeleteCommand.Parameters(13).Value = DBNull.Value
			End If
			Me.Adapter.DeleteCommand.Parameters(14).Value = Original_SubTotal
			Me.Adapter.DeleteCommand.Parameters(15).Value = Original_GrandTotal
			Dim flag7 As Boolean = Original_Terms = Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(16).Value = 1
				Me.Adapter.DeleteCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(16).Value = 0
				Me.Adapter.DeleteCommand.Parameters(17).Value = Original_Terms
			End If
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

		' Token: 0x0600E569 RID: 58729 RVA: 0x0088EA18 File Offset: 0x0088CC18
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(PO_ID As Integer, PONo As String, _Date As DateTime, SupplierID As Integer, TaxType As String, SGST As Decimal?, CGST As Decimal?, IGST As Decimal?, CESS As Decimal?, SubTotal As Decimal, GrandTotal As Decimal, TermsAndConditions As String, Terms As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = PO_ID
			Dim flag As Boolean = PONo = Nothing
			If flag Then
				Throw New ArgumentNullException("PONo")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = PONo
			Me.Adapter.InsertCommand.Parameters(2).Value = _Date
			Me.Adapter.InsertCommand.Parameters(3).Value = SupplierID
			Dim flag2 As Boolean = TaxType = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = TaxType
			End If
			Dim flag3 As Boolean = SGST IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = SGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = CGST IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = CGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = IGST IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = IGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = CESS IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = CESS.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			End If
			Me.Adapter.InsertCommand.Parameters(9).Value = SubTotal
			Me.Adapter.InsertCommand.Parameters(10).Value = GrandTotal
			Dim flag7 As Boolean = TermsAndConditions = Nothing
			If flag7 Then
				Throw New ArgumentNullException("TermsAndConditions")
			End If
			Me.Adapter.InsertCommand.Parameters(11).Value = TermsAndConditions
			Dim flag8 As Boolean = Terms = Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = Terms
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag9 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag9 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag10 As Boolean = state = ConnectionState.Closed
				If flag10 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E56A RID: 58730 RVA: 0x0088EDE8 File Offset: 0x0088CFE8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PO_ID As Integer, PONo As String, _Date As DateTime, SupplierID As Integer, TaxType As String, SGST As Decimal?, CGST As Decimal?, IGST As Decimal?, CESS As Decimal?, SubTotal As Decimal, GrandTotal As Decimal, TermsAndConditions As String, Terms As String, Original_PO_ID As Integer, Original_PONo As String, Original_Date As DateTime, Original_SupplierID As Integer, Original_TaxType As String, Original_SGST As Decimal?, Original_CGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_SubTotal As Decimal, Original_GrandTotal As Decimal, Original_Terms As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = PO_ID
			Dim flag As Boolean = PONo = Nothing
			If flag Then
				Throw New ArgumentNullException("PONo")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = PONo
			Me.Adapter.UpdateCommand.Parameters(2).Value = _Date
			Me.Adapter.UpdateCommand.Parameters(3).Value = SupplierID
			Dim flag2 As Boolean = TaxType = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = TaxType
			End If
			Dim flag3 As Boolean = SGST IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = CGST IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = IGST IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = CESS IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(9).Value = SubTotal
			Me.Adapter.UpdateCommand.Parameters(10).Value = GrandTotal
			Dim flag7 As Boolean = TermsAndConditions = Nothing
			If flag7 Then
				Throw New ArgumentNullException("TermsAndConditions")
			End If
			Me.Adapter.UpdateCommand.Parameters(11).Value = TermsAndConditions
			Dim flag8 As Boolean = Terms = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = Terms
			End If
			Me.Adapter.UpdateCommand.Parameters(13).Value = Original_PO_ID
			Dim flag9 As Boolean = Original_PONo = Nothing
			If flag9 Then
				Throw New ArgumentNullException("Original_PONo")
			End If
			Me.Adapter.UpdateCommand.Parameters(14).Value = Original_PONo
			Me.Adapter.UpdateCommand.Parameters(15).Value = Original_Date
			Me.Adapter.UpdateCommand.Parameters(16).Value = Original_SupplierID
			Dim flag10 As Boolean = Original_TaxType = Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_TaxType
			End If
			Dim flag11 As Boolean = Original_SGST IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = 0
				Me.Adapter.UpdateCommand.Parameters(20).Value = Original_SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(19).Value = 1
				Me.Adapter.UpdateCommand.Parameters(20).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_CGST IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(21).Value = 0
				Me.Adapter.UpdateCommand.Parameters(22).Value = Original_CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(21).Value = 1
				Me.Adapter.UpdateCommand.Parameters(22).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_IGST IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(23).Value = 0
				Me.Adapter.UpdateCommand.Parameters(24).Value = Original_IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(23).Value = 1
				Me.Adapter.UpdateCommand.Parameters(24).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = Original_CESS IsNot Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(25).Value = 0
				Me.Adapter.UpdateCommand.Parameters(26).Value = Original_CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(25).Value = 1
				Me.Adapter.UpdateCommand.Parameters(26).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(27).Value = Original_SubTotal
			Me.Adapter.UpdateCommand.Parameters(28).Value = Original_GrandTotal
			Dim flag15 As Boolean = Original_Terms = Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(29).Value = 1
				Me.Adapter.UpdateCommand.Parameters(30).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(29).Value = 0
				Me.Adapter.UpdateCommand.Parameters(30).Value = Original_Terms
			End If
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag16 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag16 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag17 As Boolean = state = ConnectionState.Closed
				If flag17 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E56B RID: 58731 RVA: 0x0088F65C File Offset: 0x0088D85C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PONo As String, _Date As DateTime, SupplierID As Integer, TaxType As String, SGST As Decimal?, CGST As Decimal?, IGST As Decimal?, CESS As Decimal?, SubTotal As Decimal, GrandTotal As Decimal, TermsAndConditions As String, Terms As String, Original_PO_ID As Integer, Original_PONo As String, Original_Date As DateTime, Original_SupplierID As Integer, Original_TaxType As String, Original_SGST As Decimal?, Original_CGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_SubTotal As Decimal, Original_GrandTotal As Decimal, Original_Terms As String) As Integer
			Return Me.Update(Original_PO_ID, PONo, _Date, SupplierID, TaxType, SGST, CGST, IGST, CESS, SubTotal, GrandTotal, TermsAndConditions, Terms, Original_PO_ID, Original_PONo, Original_Date, Original_SupplierID, Original_TaxType, Original_SGST, Original_CGST, Original_IGST, Original_CESS, Original_SubTotal, Original_GrandTotal, Original_Terms)
		End Function

		' Token: 0x0400588A RID: 22666
		Private _connection As SqlConnection

		' Token: 0x0400588B RID: 22667
		Private _transaction As SqlTransaction

		' Token: 0x0400588C RID: 22668
		Private _commandCollection As SqlCommand()

		' Token: 0x0400588D RID: 22669
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
