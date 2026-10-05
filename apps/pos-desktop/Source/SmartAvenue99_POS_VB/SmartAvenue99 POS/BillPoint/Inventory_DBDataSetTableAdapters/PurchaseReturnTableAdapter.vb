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
	' Token: 0x0200045B RID: 1115
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class PurchaseReturnTableAdapter
		Inherits Component

		' Token: 0x1700584B RID: 22603
		' (get) Token: 0x0600E584 RID: 58756 RVA: 0x00065838 File Offset: 0x00063A38
		' (set) Token: 0x0600E585 RID: 58757 RVA: 0x00065842 File Offset: 0x00063A42
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E586 RID: 58758 RVA: 0x0006584B File Offset: 0x00063A4B
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x1700584C RID: 22604
		' (get) Token: 0x0600E587 RID: 58759 RVA: 0x00892D60 File Offset: 0x00890F60
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

		' Token: 0x1700584D RID: 22605
		' (get) Token: 0x0600E588 RID: 58760 RVA: 0x00892D90 File Offset: 0x00890F90
		' (set) Token: 0x0600E589 RID: 58761 RVA: 0x00892DC0 File Offset: 0x00890FC0
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

		' Token: 0x1700584E RID: 22606
		' (get) Token: 0x0600E58A RID: 58762 RVA: 0x00892E84 File Offset: 0x00891084
		' (set) Token: 0x0600E58B RID: 58763 RVA: 0x00892E9C File Offset: 0x0089109C
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

		' Token: 0x1700584F RID: 22607
		' (get) Token: 0x0600E58C RID: 58764 RVA: 0x00892F84 File Offset: 0x00891184
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

		' Token: 0x17005850 RID: 22608
		' (get) Token: 0x0600E58D RID: 58765 RVA: 0x00892FB4 File Offset: 0x008911B4
		' (set) Token: 0x0600E58E RID: 58766 RVA: 0x0006585D File Offset: 0x00063A5D
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

		' Token: 0x0600E58F RID: 58767 RVA: 0x00892FCC File Offset: 0x008911CC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "PurchaseReturn"
			dataTableMapping.ColumnMappings.Add("PR_ID", "PR_ID")
			dataTableMapping.ColumnMappings.Add("PRNo", "PRNo")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("PurchaseID", "PurchaseID")
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
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[PurchaseReturn] WHERE (([PR_ID] = @Original_PR_ID) AND ((@IsNull_PRNo = 1 AND [PRNo] IS NULL) OR ([PRNo] = @Original_PRNo)) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_PurchaseID = 1 AND [PurchaseID] IS NULL) OR ([PurchaseID] = @Original_PurchaseID)) AND ((@IsNull_SubTotal = 1 AND [SubTotal] IS NULL) OR ([SubTotal] = @Original_SubTotal)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_FreightCharges = 1 AND [FreightCharges] IS NULL) OR ([FreightCharges] = @Original_FreightCharges)) AND ((@IsNull_OtherCharges = 1 AND [OtherCharges] IS NULL) OR ([OtherCharges] = @Original_OtherCharges)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ((@IsNull_GrandTotal = 1 AND [GrandTotal] IS NULL) OR ([GrandTotal] = @Original_GrandTotal)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PR_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PR_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PRNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PRNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PRNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PRNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PurchaseID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PurchaseID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseID", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[PurchaseReturn] ([PR_ID], [PRNo], [Date], [PurchaseID], [SubTotal], [CGST], [SGST], [IGST], [CESS], [FreightCharges], [OtherCharges], [Total], [RoundOff], [GrandTotal]) VALUES (@PR_ID, @PRNo, @Date, @PurchaseID, @SubTotal, @CGST, @SGST, @IGST, @CESS, @FreightCharges, @OtherCharges, @Total, @RoundOff, @GrandTotal);" & vbCrLf & "SELECT PR_ID, PRNo, Date, PurchaseID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal FROM PurchaseReturn WHERE (PR_ID = @PR_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PR_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PR_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PRNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PRNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PurchaseID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseID", DataRowVersion.Current, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[PurchaseReturn] SET [PR_ID] = @PR_ID, [PRNo] = @PRNo, [Date] = @Date, [PurchaseID] = @PurchaseID, [SubTotal] = @SubTotal, [CGST] = @CGST, [SGST] = @SGST, [IGST] = @IGST, [CESS] = @CESS, [FreightCharges] = @FreightCharges, [OtherCharges] = @OtherCharges, [Total] = @Total, [RoundOff] = @RoundOff, [GrandTotal] = @GrandTotal WHERE (([PR_ID] = @Original_PR_ID) AND ((@IsNull_PRNo = 1 AND [PRNo] IS NULL) OR ([PRNo] = @Original_PRNo)) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_PurchaseID = 1 AND [PurchaseID] IS NULL) OR ([PurchaseID] = @Original_PurchaseID)) AND ((@IsNull_SubTotal = 1 AND [SubTotal] IS NULL) OR ([SubTotal] = @Original_SubTotal)) AND ((@IsNull_CGST = 1 AND [CGST] IS NULL) OR ([CGST] = @Original_CGST)) AND ((@IsNull_SGST = 1 AND [SGST] IS NULL) OR ([SGST] = @Original_SGST)) AND ((@IsNull_IGST = 1 AND [IGST] IS NULL) OR ([IGST] = @Original_IGST)) AND ((@IsNull_CESS = 1 AND [CESS] IS NULL) OR ([CESS] = @Original_CESS)) AND ((@IsNull_FreightCharges = 1 AND [FreightCharges] IS NULL) OR ([FreightCharges] = @Original_FreightCharges)) AND ((@IsNull_OtherCharges = 1 AND [OtherCharges] IS NULL) OR ([OtherCharges] = @Original_OtherCharges)) AND ((@IsNull_Total = 1 AND [Total] IS NULL) OR ([Total] = @Original_Total)) AND ((@IsNull_RoundOff = 1 AND [RoundOff] IS NULL) OR ([RoundOff] = @Original_RoundOff)) AND ((@IsNull_GrandTotal = 1 AND [GrandTotal] IS NULL) OR ([GrandTotal] = @Original_GrandTotal)));" & vbCrLf & "SELECT PR_ID, PRNo, Date, PurchaseID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal FROM PurchaseReturn WHERE (PR_ID = @PR_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PR_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PR_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PRNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PRNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PurchaseID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseID", DataRowVersion.Current, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PR_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PR_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PRNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PRNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PRNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PRNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PurchaseID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PurchaseID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PurchaseID", DataRowVersion.Original, False, Nothing, "", "", ""))
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

		' Token: 0x0600E590 RID: 58768 RVA: 0x00065867 File Offset: 0x00063A67
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E591 RID: 58769 RVA: 0x008946E8 File Offset: 0x008928E8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT PR_ID, PRNo, Date, PurchaseID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal FROM dbo.PurchaseReturn"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E592 RID: 58770 RVA: 0x00894748 File Offset: 0x00892948
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.PurchaseReturnDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E593 RID: 58771 RVA: 0x00894790 File Offset: 0x00892990
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.PurchaseReturnDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim purchaseReturnDataTable As Inventory_DBDataSet.PurchaseReturnDataTable = New Inventory_DBDataSet.PurchaseReturnDataTable()
			Me.Adapter.Fill(purchaseReturnDataTable)
			Return purchaseReturnDataTable
		End Function

		' Token: 0x0600E594 RID: 58772 RVA: 0x008947CC File Offset: 0x008929CC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.PurchaseReturnDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E595 RID: 58773 RVA: 0x008947EC File Offset: 0x008929EC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "PurchaseReturn")
		End Function

		' Token: 0x0600E596 RID: 58774 RVA: 0x00894810 File Offset: 0x00892A10
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E597 RID: 58775 RVA: 0x00894838 File Offset: 0x00892A38
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E598 RID: 58776 RVA: 0x00894858 File Offset: 0x00892A58
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_PR_ID As Integer, Original_PRNo As String, Original_Date As DateTime?, Original_PurchaseID As Integer?, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal?) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_PR_ID
			Dim flag As Boolean = Original_PRNo = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_PRNo
			End If
			Dim flag2 As Boolean = Original_Date IsNot Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Date.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = Original_PurchaseID IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_PurchaseID.Value
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

		' Token: 0x0600E599 RID: 58777 RVA: 0x0089514C File Offset: 0x0089334C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(PR_ID As Integer, PRNo As String, _Date As DateTime?, PurchaseID As Integer?, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal?) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = PR_ID
			Dim flag As Boolean = PRNo = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = PRNo
			End If
			Dim flag2 As Boolean = _Date IsNot Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = _Date.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = PurchaseID IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = PurchaseID.Value
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

		' Token: 0x0600E59A RID: 58778 RVA: 0x008956B4 File Offset: 0x008938B4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PR_ID As Integer, PRNo As String, _Date As DateTime?, PurchaseID As Integer?, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal?, Original_PR_ID As Integer, Original_PRNo As String, Original_Date As DateTime?, Original_PurchaseID As Integer?, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal?) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = PR_ID
			Dim flag As Boolean = PRNo = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = PRNo
			End If
			Dim flag2 As Boolean = _Date IsNot Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = _Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			End If
			Dim flag3 As Boolean = PurchaseID IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = PurchaseID.Value
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
			Me.Adapter.UpdateCommand.Parameters(14).Value = Original_PR_ID
			Dim flag14 As Boolean = Original_PRNo = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = 1
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = 0
				Me.Adapter.UpdateCommand.Parameters(16).Value = Original_PRNo
			End If
			Dim flag15 As Boolean = Original_Date IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = Original_PurchaseID IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = 0
				Me.Adapter.UpdateCommand.Parameters(20).Value = Original_PurchaseID.Value
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

		' Token: 0x0600E59B RID: 58779 RVA: 0x00896478 File Offset: 0x00894678
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PRNo As String, _Date As DateTime?, PurchaseID As Integer?, SubTotal As Decimal?, CGST As Decimal?, SGST As Decimal?, IGST As Decimal?, CESS As Decimal?, FreightCharges As Decimal?, OtherCharges As Decimal?, Total As Decimal?, RoundOff As Decimal?, GrandTotal As Decimal?, Original_PR_ID As Integer, Original_PRNo As String, Original_Date As DateTime?, Original_PurchaseID As Integer?, Original_SubTotal As Decimal?, Original_CGST As Decimal?, Original_SGST As Decimal?, Original_IGST As Decimal?, Original_CESS As Decimal?, Original_FreightCharges As Decimal?, Original_OtherCharges As Decimal?, Original_Total As Decimal?, Original_RoundOff As Decimal?, Original_GrandTotal As Decimal?) As Integer
			Return Me.Update(Original_PR_ID, PRNo, _Date, PurchaseID, SubTotal, CGST, SGST, IGST, CESS, FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, Original_PR_ID, Original_PRNo, Original_Date, Original_PurchaseID, Original_SubTotal, Original_CGST, Original_SGST, Original_IGST, Original_CESS, Original_FreightCharges, Original_OtherCharges, Original_Total, Original_RoundOff, Original_GrandTotal)
		End Function

		' Token: 0x04005894 RID: 22676
		Private _connection As SqlConnection

		' Token: 0x04005895 RID: 22677
		Private _transaction As SqlTransaction

		' Token: 0x04005896 RID: 22678
		Private _commandCollection As SqlCommand()

		' Token: 0x04005897 RID: 22679
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
