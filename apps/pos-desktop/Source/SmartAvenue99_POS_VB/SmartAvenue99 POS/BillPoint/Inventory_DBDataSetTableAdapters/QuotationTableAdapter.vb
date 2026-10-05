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
	' Token: 0x0200045D RID: 1117
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class QuotationTableAdapter
		Inherits Component

		' Token: 0x17005857 RID: 22615
		' (get) Token: 0x0600E5B4 RID: 58804 RVA: 0x000658DE File Offset: 0x00063ADE
		' (set) Token: 0x0600E5B5 RID: 58805 RVA: 0x000658E8 File Offset: 0x00063AE8
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E5B6 RID: 58806 RVA: 0x000658F1 File Offset: 0x00063AF1
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005858 RID: 22616
		' (get) Token: 0x0600E5B7 RID: 58807 RVA: 0x0089ABF4 File Offset: 0x00898DF4
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

		' Token: 0x17005859 RID: 22617
		' (get) Token: 0x0600E5B8 RID: 58808 RVA: 0x0089AC24 File Offset: 0x00898E24
		' (set) Token: 0x0600E5B9 RID: 58809 RVA: 0x0089AC54 File Offset: 0x00898E54
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

		' Token: 0x1700585A RID: 22618
		' (get) Token: 0x0600E5BA RID: 58810 RVA: 0x0089AD18 File Offset: 0x00898F18
		' (set) Token: 0x0600E5BB RID: 58811 RVA: 0x0089AD30 File Offset: 0x00898F30
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

		' Token: 0x1700585B RID: 22619
		' (get) Token: 0x0600E5BC RID: 58812 RVA: 0x0089AE18 File Offset: 0x00899018
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

		' Token: 0x1700585C RID: 22620
		' (get) Token: 0x0600E5BD RID: 58813 RVA: 0x0089AE48 File Offset: 0x00899048
		' (set) Token: 0x0600E5BE RID: 58814 RVA: 0x00065903 File Offset: 0x00063B03
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

		' Token: 0x0600E5BF RID: 58815 RVA: 0x0089AE60 File Offset: 0x00899060
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Quotation"
			dataTableMapping.ColumnMappings.Add("Q_ID", "Q_ID")
			dataTableMapping.ColumnMappings.Add("QuotationNo", "QuotationNo")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("TaxType", "TaxType")
			dataTableMapping.ColumnMappings.Add("CustomerID", "CustomerID")
			dataTableMapping.ColumnMappings.Add("SubTotal", "SubTotal")
			dataTableMapping.ColumnMappings.Add("CGST", "CGST")
			dataTableMapping.ColumnMappings.Add("SGST", "SGST")
			dataTableMapping.ColumnMappings.Add("IGST", "IGST")
			dataTableMapping.ColumnMappings.Add("CESS", "CESS")
			dataTableMapping.ColumnMappings.Add("Total", "Total")
			dataTableMapping.ColumnMappings.Add("RoundOff", "RoundOff")
			dataTableMapping.ColumnMappings.Add("GrandTotal", "GrandTotal")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Quotation] WHERE (([Q_ID] = @Original_Q_ID) AND ([QuotationNo] = @Original_QuotationNo) AND ([Date] = @Original_Date) AND ((@IsNull_TaxType = 1 AND [TaxType] IS NULL) OR ([TaxType] = @Original_TaxType)) AND ([CustomerID] = @Original_CustomerID) AND ((@IsNull_SubTotal = 1 AND [SubTotal] IS NULL) OR ([SubTotal] = @Original_SubTotal)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ([GrandTotal] = @Original_GrandTotal))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Q_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Q_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_QuotationNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "QuotationNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_TaxType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Total", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Total", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_RoundOff", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RoundOff", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Quotation] ([Q_ID], [QuotationNo], [Date], [TaxType], [CustomerID], [SubTotal], [CGST], [SGST], [IGST], [CESS], [Total], [RoundOff], [GrandTotal], [Remarks]) VALUES (@Q_ID, @QuotationNo, @Date, @TaxType, @CustomerID, @SubTotal, @CGST, @SGST, @IGST, @CESS, @Total, @RoundOff, @GrandTotal, @Remarks);" & vbCrLf & "SELECT Q_ID, QuotationNo, Date, TaxType, CustomerID, SubTotal, CGST, SGST, IGST, CESS, Total, RoundOff, GrandTotal, Remarks FROM Quotation WHERE (Q_ID = @Q_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Q_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Q_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@QuotationNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "QuotationNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Quotation] SET [Q_ID] = @Q_ID, [QuotationNo] = @QuotationNo, [Date] = @Date, [TaxType] = @TaxType, [CustomerID] = @CustomerID, [SubTotal] = @SubTotal, [CGST] = @CGST, [SGST] = @SGST, [IGST] = @IGST, [CESS] = @CESS, [Total] = @Total, [RoundOff] = @RoundOff, [GrandTotal] = @GrandTotal, [Remarks] = @Remarks WHERE (([Q_ID] = @Original_Q_ID) AND ([QuotationNo] = @Original_QuotationNo) AND ([Date] = @Original_Date) AND ((@IsNull_TaxType = 1 AND [TaxType] IS NULL) OR ([TaxType] = @Original_TaxType)) AND ([CustomerID] = @Original_CustomerID) AND ((@IsNull_SubTotal = 1 AND [SubTotal] IS NULL) OR ([SubTotal] = @Original_SubTotal)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ([GrandTotal] = @Original_GrandTotal));" & vbCrLf & "SELECT Q_ID, QuotationNo, Date, TaxType, CustomerID, SubTotal, CGST, SGST, IGST, CESS, Total, RoundOff, GrandTotal, Remarks FROM Quotation WHERE (Q_ID = @Q_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Q_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Q_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@QuotationNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "QuotationNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SubTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SubTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "SGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IGST", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "IGST", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CESS", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CESS", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Q_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Q_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_QuotationNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "QuotationNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_TaxType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TaxType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TaxType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Total", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Total", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Total", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Total", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_RoundOff", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "RoundOff", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_RoundOff", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RoundOff", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E5C0 RID: 58816 RVA: 0x0006590D File Offset: 0x00063B0D
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E5C1 RID: 58817 RVA: 0x0089C278 File Offset: 0x0089A478
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Q_ID, QuotationNo, Date, TaxType, CustomerID, SubTotal, CGST, SGST, IGST, CESS, Total, RoundOff, GrandTotal, Remarks FROM dbo.Quotation"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E5C2 RID: 58818 RVA: 0x0089C2D8 File Offset: 0x0089A4D8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.QuotationDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E5C3 RID: 58819 RVA: 0x0089C320 File Offset: 0x0089A520
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.QuotationDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim quotationDataTable As Inventory_DBDataSet.QuotationDataTable = New Inventory_DBDataSet.QuotationDataTable()
			Me.Adapter.Fill(quotationDataTable)
			Return quotationDataTable
		End Function

		' Token: 0x0600E5C4 RID: 58820 RVA: 0x0089C35C File Offset: 0x0089A55C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.QuotationDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E5C5 RID: 58821 RVA: 0x0089C37C File Offset: 0x0089A57C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Quotation")
		End Function

		' Token: 0x0600E5C6 RID: 58822 RVA: 0x0089C3A0 File Offset: 0x0089A5A0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E5C7 RID: 58823 RVA: 0x0089C3C8 File Offset: 0x0089A5C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E5C8 RID: 58824 RVA: 0x0089C3E8 File Offset: 0x0089A5E8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Q_ID As Integer, Original_QuotationNo As String, Original_Date As DateTime, Original_TaxType As String, Original_CustomerID As Integer, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Q_ID
			Dim flag As Boolean = Original_QuotationNo = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_QuotationNo")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_QuotationNo
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Date
			Dim flag2 As Boolean = Original_TaxType = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_TaxType
			End If
			Me.Adapter.DeleteCommand.Parameters(5).Value = Original_CustomerID
			Dim flag3 As Boolean = Original_SubTotal IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(6).Value = 0
				Me.Adapter.DeleteCommand.Parameters(7).Value = Original_SubTotal.Value
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
			Dim flag5 As Boolean = Original_SGST IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(10).Value = 0
				Me.Adapter.DeleteCommand.Parameters(11).Value = Original_SGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(10).Value = 1
				Me.Adapter.DeleteCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_IGST IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(12).Value = 0
				Me.Adapter.DeleteCommand.Parameters(13).Value = Original_IGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(12).Value = 1
				Me.Adapter.DeleteCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_CESS IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(14).Value = 0
				Me.Adapter.DeleteCommand.Parameters(15).Value = Original_CESS.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(14).Value = 1
				Me.Adapter.DeleteCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_Total IsNot Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(16).Value = 0
				Me.Adapter.DeleteCommand.Parameters(17).Value = Original_Total.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(16).Value = 1
				Me.Adapter.DeleteCommand.Parameters(17).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Original_RoundOff IsNot Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(18).Value = 0
				Me.Adapter.DeleteCommand.Parameters(19).Value = Original_RoundOff.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(18).Value = 1
				Me.Adapter.DeleteCommand.Parameters(19).Value = DBNull.Value
			End If
			Me.Adapter.DeleteCommand.Parameters(20).Value = Original_GrandTotal
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag10 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag10 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag11 As Boolean = state = ConnectionState.Closed
				If flag11 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E5C9 RID: 58825 RVA: 0x0089CA54 File Offset: 0x0089AC54
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(Q_ID As Integer, QuotationNo As String, _Date As DateTime, TaxType As String, CustomerID As Integer, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal, Remarks As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = Q_ID
			Dim flag As Boolean = QuotationNo = Nothing
			If flag Then
				Throw New ArgumentNullException("QuotationNo")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = QuotationNo
			Me.Adapter.InsertCommand.Parameters(2).Value = _Date
			Dim flag2 As Boolean = TaxType = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = TaxType
			End If
			Me.Adapter.InsertCommand.Parameters(4).Value = CustomerID
			Dim flag3 As Boolean = SubTotal IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = SubTotal.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = CGST IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = CGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = SGST IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = SGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = IGST IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = IGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = CESS IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = CESS.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Total IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = Total.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = RoundOff IsNot Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = RoundOff.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Me.Adapter.InsertCommand.Parameters(12).Value = GrandTotal
			Dim flag10 As Boolean = Remarks = Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = Remarks
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag11 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag11 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag12 As Boolean = state = ConnectionState.Closed
				If flag12 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E5CA RID: 58826 RVA: 0x0089CEE0 File Offset: 0x0089B0E0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Q_ID As Integer, QuotationNo As String, _Date As DateTime, TaxType As String, CustomerID As Integer, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal, Remarks As String, Original_Q_ID As Integer, Original_QuotationNo As String, Original_Date As DateTime, Original_TaxType As String, Original_CustomerID As Integer, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = Q_ID
			Dim flag As Boolean = QuotationNo = Nothing
			If flag Then
				Throw New ArgumentNullException("QuotationNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = QuotationNo
			Me.Adapter.UpdateCommand.Parameters(2).Value = _Date
			Dim flag2 As Boolean = TaxType = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = TaxType
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = CustomerID
			Dim flag3 As Boolean = SubTotal IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = SubTotal.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = CGST IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = SGST IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = IGST IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = CESS IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Total IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = Total.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = RoundOff IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = RoundOff.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(12).Value = GrandTotal
			Dim flag10 As Boolean = Remarks = Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = Remarks
			End If
			Me.Adapter.UpdateCommand.Parameters(14).Value = Original_Q_ID
			Dim flag11 As Boolean = Original_QuotationNo = Nothing
			If flag11 Then
				Throw New ArgumentNullException("Original_QuotationNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(15).Value = Original_QuotationNo
			Me.Adapter.UpdateCommand.Parameters(16).Value = Original_Date
			Dim flag12 As Boolean = Original_TaxType = Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_TaxType
			End If
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_CustomerID
			Dim flag13 As Boolean = Original_SubTotal IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(20).Value = 0
				Me.Adapter.UpdateCommand.Parameters(21).Value = Original_SubTotal.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(20).Value = 1
				Me.Adapter.UpdateCommand.Parameters(21).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = Original_CGST IsNot Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(22).Value = 0
				Me.Adapter.UpdateCommand.Parameters(23).Value = Original_CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(22).Value = 1
				Me.Adapter.UpdateCommand.Parameters(23).Value = DBNull.Value
			End If
			Dim flag15 As Boolean = Original_SGST IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(24).Value = 0
				Me.Adapter.UpdateCommand.Parameters(25).Value = Original_SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(24).Value = 1
				Me.Adapter.UpdateCommand.Parameters(25).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = Original_IGST IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(26).Value = 0
				Me.Adapter.UpdateCommand.Parameters(27).Value = Original_IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(26).Value = 1
				Me.Adapter.UpdateCommand.Parameters(27).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Original_CESS IsNot Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(28).Value = 0
				Me.Adapter.UpdateCommand.Parameters(29).Value = Original_CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(28).Value = 1
				Me.Adapter.UpdateCommand.Parameters(29).Value = DBNull.Value
			End If
			Dim flag18 As Boolean = Original_Total IsNot Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(30).Value = 0
				Me.Adapter.UpdateCommand.Parameters(31).Value = Original_Total.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(30).Value = 1
				Me.Adapter.UpdateCommand.Parameters(31).Value = DBNull.Value
			End If
			Dim flag19 As Boolean = Original_RoundOff IsNot Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(32).Value = 0
				Me.Adapter.UpdateCommand.Parameters(33).Value = Original_RoundOff.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(32).Value = 1
				Me.Adapter.UpdateCommand.Parameters(33).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(34).Value = Original_GrandTotal
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag20 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag20 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag21 As Boolean = state = ConnectionState.Closed
				If flag21 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E5CB RID: 58827 RVA: 0x0089D940 File Offset: 0x0089BB40
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(QuotationNo As String, _Date As DateTime, TaxType As String, CustomerID As Integer, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal, Remarks As String, Original_Q_ID As Integer, Original_QuotationNo As String, Original_Date As DateTime, Original_TaxType As String, Original_CustomerID As Integer, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal) As Integer
			Return Me.Update(Original_Q_ID, QuotationNo, _Date, TaxType, CustomerID, SubTotal, CGST, SGST, IGST, CESS, Total, RoundOff, GrandTotal, Remarks, Original_Q_ID, Original_QuotationNo, Original_Date, Original_TaxType, Original_CustomerID, Original_SubTotal, Original_CGST, Original_SGST, Original_IGST, Original_CESS, Original_Total, Original_RoundOff, Original_GrandTotal)
		End Function

		' Token: 0x0400589E RID: 22686
		Private _connection As SqlConnection

		' Token: 0x0400589F RID: 22687
		Private _transaction As SqlTransaction

		' Token: 0x040058A0 RID: 22688
		Private _commandCollection As SqlCommand()

		' Token: 0x040058A1 RID: 22689
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
