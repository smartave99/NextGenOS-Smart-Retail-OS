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
	' Token: 0x02000462 RID: 1122
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class SalesReturnTableAdapter
		Inherits Component

		' Token: 0x17005875 RID: 22645
		' (get) Token: 0x0600E62C RID: 58924 RVA: 0x00065A7D File Offset: 0x00063C7D
		' (set) Token: 0x0600E62D RID: 58925 RVA: 0x00065A87 File Offset: 0x00063C87
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E62E RID: 58926 RVA: 0x00065A90 File Offset: 0x00063C90
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005876 RID: 22646
		' (get) Token: 0x0600E62F RID: 58927 RVA: 0x008A5CD8 File Offset: 0x008A3ED8
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

		' Token: 0x17005877 RID: 22647
		' (get) Token: 0x0600E630 RID: 58928 RVA: 0x008A5D08 File Offset: 0x008A3F08
		' (set) Token: 0x0600E631 RID: 58929 RVA: 0x008A5D38 File Offset: 0x008A3F38
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

		' Token: 0x17005878 RID: 22648
		' (get) Token: 0x0600E632 RID: 58930 RVA: 0x008A5DFC File Offset: 0x008A3FFC
		' (set) Token: 0x0600E633 RID: 58931 RVA: 0x008A5E14 File Offset: 0x008A4014
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

		' Token: 0x17005879 RID: 22649
		' (get) Token: 0x0600E634 RID: 58932 RVA: 0x008A5EFC File Offset: 0x008A40FC
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

		' Token: 0x1700587A RID: 22650
		' (get) Token: 0x0600E635 RID: 58933 RVA: 0x008A5F2C File Offset: 0x008A412C
		' (set) Token: 0x0600E636 RID: 58934 RVA: 0x00065AA2 File Offset: 0x00063CA2
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

		' Token: 0x0600E637 RID: 58935 RVA: 0x008A5F44 File Offset: 0x008A4144
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "SalesReturn"
			dataTableMapping.ColumnMappings.Add("SR_ID", "SR_ID")
			dataTableMapping.ColumnMappings.Add("SRNo", "SRNo")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("SalesID", "SalesID")
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
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[SalesReturn] WHERE (([SR_ID] = @Original_SR_ID) AND ((@IsNull_SRNo = 1 AND [SRNo] IS NULL) OR ([SRNo] = @Original_SRNo)) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_SalesID = 1 AND [SalesID] IS NULL) OR ([SalesID] = @Original_SalesID)) AND ((@IsNull_SubTotal = 1 AND [SubTotal] IS NULL) OR ([SubTotal] = @Original_SubTotal)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_FreightCharges = 1 AND [FreightCharges] IS NULL) OR ([FreightCharges] = @Original_FreightCharges)) AND ((@IsNull_OtherCharges = 1 AND [OtherCharges] IS NULL) OR ([OtherCharges] = @Original_OtherCharges)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ((@IsNull_GrandTotal = 1 AND [GrandTotal] IS NULL) OR ([GrandTotal] = @Original_GrandTotal)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SR_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SR_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SRNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SRNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SRNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SRNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SalesID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SalesID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesID", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_GrandTotal", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GrandTotal", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[SalesReturn] ([SR_ID], [SRNo], [Date], [SalesID], [SubTotal], [CGST], [SGST], [IGST], [CESS], [FreightCharges], [OtherCharges], [Total], [RoundOff], [GrandTotal]) VALUES (@SR_ID, @SRNo, @Date, @SalesID, @SubTotal, @CGST, @SGST, @IGST, @CESS, @FreightCharges, @OtherCharges, @Total, @RoundOff, @GrandTotal);" & vbCrLf & "SELECT SR_ID, SRNo, Date, SalesID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal FROM SalesReturn WHERE (SR_ID = @SR_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SR_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SR_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SRNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SRNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SalesID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesID", DataRowVersion.Current, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[SalesReturn] SET [SR_ID] = @SR_ID, [SRNo] = @SRNo, [Date] = @Date, [SalesID] = @SalesID, [SubTotal] = @SubTotal, [CGST] = @CGST, [SGST] = @SGST, [IGST] = @IGST, [CESS] = @CESS, [FreightCharges] = @FreightCharges, [OtherCharges] = @OtherCharges, [Total] = @Total, [RoundOff] = @RoundOff, [GrandTotal] = @GrandTotal WHERE (([SR_ID] = @Original_SR_ID) AND ((@IsNull_SRNo = 1 AND [SRNo] IS NULL) OR ([SRNo] = @Original_SRNo)) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_SalesID = 1 AND [SalesID] IS NULL) OR ([SalesID] = @Original_SalesID)) AND ((@IsNull_SubTotal = 1 AND [SubTotal] IS NULL) OR ([SubTotal] = @Original_SubTotal)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_FreightCharges = 1 AND [FreightCharges] IS NULL) OR ([FreightCharges] = @Original_FreightCharges)) AND ((@IsNull_OtherCharges = 1 AND [OtherCharges] IS NULL) OR ([OtherCharges] = @Original_OtherCharges)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ((@IsNull_GrandTotal = 1 AND [GrandTotal] IS NULL) OR ([GrandTotal] = @Original_GrandTotal)));" & vbCrLf & "SELECT SR_ID, SRNo, Date, SalesID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal FROM SalesReturn WHERE (SR_ID = @SR_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SR_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SR_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SRNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SRNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SalesID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesID", DataRowVersion.Current, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SR_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SR_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SRNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SRNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SRNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SRNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SalesID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SalesID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesID", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_GrandTotal", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GrandTotal", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E638 RID: 58936 RVA: 0x00065AAC File Offset: 0x00063CAC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E639 RID: 58937 RVA: 0x008A7660 File Offset: 0x008A5860
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT SR_ID, SRNo, Date, SalesID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal FROM dbo.SalesReturn"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E63A RID: 58938 RVA: 0x008A76C0 File Offset: 0x008A58C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.SalesReturnDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E63B RID: 58939 RVA: 0x008A7708 File Offset: 0x008A5908
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.SalesReturnDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim salesReturnDataTable As Inventory_DBDataSet.SalesReturnDataTable = New Inventory_DBDataSet.SalesReturnDataTable()
			Me.Adapter.Fill(salesReturnDataTable)
			Return salesReturnDataTable
		End Function

		' Token: 0x0600E63C RID: 58940 RVA: 0x008A7744 File Offset: 0x008A5944
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.SalesReturnDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E63D RID: 58941 RVA: 0x008A7764 File Offset: 0x008A5964
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "SalesReturn")
		End Function

		' Token: 0x0600E63E RID: 58942 RVA: 0x008A7788 File Offset: 0x008A5988
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E63F RID: 58943 RVA: 0x008A77B0 File Offset: 0x008A59B0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E640 RID: 58944 RVA: 0x008A77D0 File Offset: 0x008A59D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_SR_ID As Integer, Original_SRNo As String, Original_Date As DateTime?, Original_SalesID As Integer?, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal?) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_SR_ID
			Dim flag As Boolean = Original_SRNo = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_SRNo
			End If
			Dim flag2 As Boolean = Original_Date IsNot Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Date.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = Original_SalesID IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_SalesID.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Original_SubTotal IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_SubTotal.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_CGST IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_CGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_SGST IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_SGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = Original_IGST IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(13).Value = 0
				Me.Adapter.DeleteCommand.Parameters(14).Value = Original_IGST.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(13).Value = 1
				Me.Adapter.DeleteCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_CESS IsNot Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(15).Value = 0
				Me.Adapter.DeleteCommand.Parameters(16).Value = Original_CESS.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(15).Value = 1
				Me.Adapter.DeleteCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Original_FreightCharges IsNot Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(17).Value = 0
				Me.Adapter.DeleteCommand.Parameters(18).Value = Original_FreightCharges.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(17).Value = 1
				Me.Adapter.DeleteCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_OtherCharges IsNot Nothing
			If flag10 Then
				Me.Adapter.DeleteCommand.Parameters(19).Value = 0
				Me.Adapter.DeleteCommand.Parameters(20).Value = Original_OtherCharges.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(19).Value = 1
				Me.Adapter.DeleteCommand.Parameters(20).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_Total IsNot Nothing
			If flag11 Then
				Me.Adapter.DeleteCommand.Parameters(21).Value = 0
				Me.Adapter.DeleteCommand.Parameters(22).Value = Original_Total.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(21).Value = 1
				Me.Adapter.DeleteCommand.Parameters(22).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_RoundOff IsNot Nothing
			If flag12 Then
				Me.Adapter.DeleteCommand.Parameters(23).Value = 0
				Me.Adapter.DeleteCommand.Parameters(24).Value = Original_RoundOff.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(23).Value = 1
				Me.Adapter.DeleteCommand.Parameters(24).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_GrandTotal IsNot Nothing
			If flag13 Then
				Me.Adapter.DeleteCommand.Parameters(25).Value = 0
				Me.Adapter.DeleteCommand.Parameters(26).Value = Original_GrandTotal.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(25).Value = 1
				Me.Adapter.DeleteCommand.Parameters(26).Value = DBNull.Value
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

		' Token: 0x0600E641 RID: 58945 RVA: 0x008A80C4 File Offset: 0x008A62C4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(SR_ID As Integer, SRNo As String, _Date As DateTime?, SalesID As Integer?, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal?) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = SR_ID
			Dim flag As Boolean = SRNo = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = SRNo
			End If
			Dim flag2 As Boolean = _Date IsNot Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = _Date.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = SalesID IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = SalesID.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = SubTotal IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = SubTotal.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = CGST IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = CGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = SGST IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = SGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = IGST IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = IGST.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CESS IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = CESS.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = FreightCharges IsNot Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = FreightCharges.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = OtherCharges IsNot Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = OtherCharges.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Total IsNot Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = Total.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = RoundOff IsNot Nothing
			If flag12 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = RoundOff.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = GrandTotal IsNot Nothing
			If flag13 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = GrandTotal.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
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

		' Token: 0x0600E642 RID: 58946 RVA: 0x008A862C File Offset: 0x008A682C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(SR_ID As Integer, SRNo As String, _Date As DateTime?, SalesID As Integer?, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal?, Original_SR_ID As Integer, Original_SRNo As String, Original_Date As DateTime?, Original_SalesID As Integer?, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal?) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = SR_ID
			Dim flag As Boolean = SRNo = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = SRNo
			End If
			Dim flag2 As Boolean = _Date IsNot Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = _Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = SalesID IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = SalesID.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = SubTotal IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = SubTotal.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = CGST IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = SGST IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag7 As Boolean = IGST IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = CESS IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = FreightCharges IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = FreightCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = OtherCharges IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = OtherCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Total IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = Total.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = RoundOff IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = RoundOff.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = GrandTotal IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = GrandTotal.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(14).Value = Original_SR_ID
			Dim flag14 As Boolean = Original_SRNo = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = 1
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = 0
				Me.Adapter.UpdateCommand.Parameters(16).Value = Original_SRNo
			End If
			Dim flag15 As Boolean = Original_Date IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = Original_SalesID IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = 0
				Me.Adapter.UpdateCommand.Parameters(20).Value = Original_SalesID.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(19).Value = 1
				Me.Adapter.UpdateCommand.Parameters(20).Value = DBNull.Value
			End If
			Dim flag17 As Boolean = Original_SubTotal IsNot Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(21).Value = 0
				Me.Adapter.UpdateCommand.Parameters(22).Value = Original_SubTotal.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(21).Value = 1
				Me.Adapter.UpdateCommand.Parameters(22).Value = DBNull.Value
			End If
			Dim flag18 As Boolean = Original_CGST IsNot Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(23).Value = 0
				Me.Adapter.UpdateCommand.Parameters(24).Value = Original_CGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(23).Value = 1
				Me.Adapter.UpdateCommand.Parameters(24).Value = DBNull.Value
			End If
			Dim flag19 As Boolean = Original_SGST IsNot Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(25).Value = 0
				Me.Adapter.UpdateCommand.Parameters(26).Value = Original_SGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(25).Value = 1
				Me.Adapter.UpdateCommand.Parameters(26).Value = DBNull.Value
			End If
			Dim flag20 As Boolean = Original_IGST IsNot Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(27).Value = 0
				Me.Adapter.UpdateCommand.Parameters(28).Value = Original_IGST.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(27).Value = 1
				Me.Adapter.UpdateCommand.Parameters(28).Value = DBNull.Value
			End If
			Dim flag21 As Boolean = Original_CESS IsNot Nothing
			If flag21 Then
				Me.Adapter.UpdateCommand.Parameters(29).Value = 0
				Me.Adapter.UpdateCommand.Parameters(30).Value = Original_CESS.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(29).Value = 1
				Me.Adapter.UpdateCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim flag22 As Boolean = Original_FreightCharges IsNot Nothing
			If flag22 Then
				Me.Adapter.UpdateCommand.Parameters(31).Value = 0
				Me.Adapter.UpdateCommand.Parameters(32).Value = Original_FreightCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(31).Value = 1
				Me.Adapter.UpdateCommand.Parameters(32).Value = DBNull.Value
			End If
			Dim flag23 As Boolean = Original_OtherCharges IsNot Nothing
			If flag23 Then
				Me.Adapter.UpdateCommand.Parameters(33).Value = 0
				Me.Adapter.UpdateCommand.Parameters(34).Value = Original_OtherCharges.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(33).Value = 1
				Me.Adapter.UpdateCommand.Parameters(34).Value = DBNull.Value
			End If
			Dim flag24 As Boolean = Original_Total IsNot Nothing
			If flag24 Then
				Me.Adapter.UpdateCommand.Parameters(35).Value = 0
				Me.Adapter.UpdateCommand.Parameters(36).Value = Original_Total.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(35).Value = 1
				Me.Adapter.UpdateCommand.Parameters(36).Value = DBNull.Value
			End If
			Dim flag25 As Boolean = Original_RoundOff IsNot Nothing
			If flag25 Then
				Me.Adapter.UpdateCommand.Parameters(37).Value = 0
				Me.Adapter.UpdateCommand.Parameters(38).Value = Original_RoundOff.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(37).Value = 1
				Me.Adapter.UpdateCommand.Parameters(38).Value = DBNull.Value
			End If
			Dim flag26 As Boolean = Original_GrandTotal IsNot Nothing
			If flag26 Then
				Me.Adapter.UpdateCommand.Parameters(39).Value = 0
				Me.Adapter.UpdateCommand.Parameters(40).Value = Original_GrandTotal.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(39).Value = 1
				Me.Adapter.UpdateCommand.Parameters(40).Value = DBNull.Value
			End If
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

		' Token: 0x0600E643 RID: 58947 RVA: 0x008A93F0 File Offset: 0x008A75F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(SRNo As String, _Date As DateTime?, SalesID As Integer?, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal?, Original_SR_ID As Integer, Original_SRNo As String, Original_Date As DateTime?, Original_SalesID As Integer?, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal?) As Integer
			Return Me.Update(Original_SR_ID, SRNo, _Date, SalesID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, Original_SR_ID, Original_SRNo, Original_Date, Original_SalesID, Original_SubTotal, Original_CGST, Original_SGST, Original_IGST, Original_CESS, Original_FreightCharges, Original_OtherCharges, Original_Total, Original_RoundOff, Original_GrandTotal)
		End Function

		' Token: 0x040058B7 RID: 22711
		Private _connection As SqlConnection

		' Token: 0x040058B8 RID: 22712
		Private _transaction As SqlTransaction

		' Token: 0x040058B9 RID: 22713
		Private _commandCollection As SqlCommand()

		' Token: 0x040058BA RID: 22714
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
