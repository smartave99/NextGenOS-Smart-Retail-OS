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
	' Token: 0x02000452 RID: 1106
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class InvoiceInfo1TableAdapter
		Inherits Component

		' Token: 0x17005815 RID: 22549
		' (get) Token: 0x0600E4AC RID: 58540 RVA: 0x0006554D File Offset: 0x0006374D
		' (set) Token: 0x0600E4AD RID: 58541 RVA: 0x00065557 File Offset: 0x00063757
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E4AE RID: 58542 RVA: 0x00065560 File Offset: 0x00063760
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005816 RID: 22550
		' (get) Token: 0x0600E4AF RID: 58543 RVA: 0x00881808 File Offset: 0x0087FA08
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

		' Token: 0x17005817 RID: 22551
		' (get) Token: 0x0600E4B0 RID: 58544 RVA: 0x00881838 File Offset: 0x0087FA38
		' (set) Token: 0x0600E4B1 RID: 58545 RVA: 0x00881868 File Offset: 0x0087FA68
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

		' Token: 0x17005818 RID: 22552
		' (get) Token: 0x0600E4B2 RID: 58546 RVA: 0x0088192C File Offset: 0x0087FB2C
		' (set) Token: 0x0600E4B3 RID: 58547 RVA: 0x00881944 File Offset: 0x0087FB44
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

		' Token: 0x17005819 RID: 22553
		' (get) Token: 0x0600E4B4 RID: 58548 RVA: 0x00881A2C File Offset: 0x0087FC2C
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

		' Token: 0x1700581A RID: 22554
		' (get) Token: 0x0600E4B5 RID: 58549 RVA: 0x00881A5C File Offset: 0x0087FC5C
		' (set) Token: 0x0600E4B6 RID: 58550 RVA: 0x00065572 File Offset: 0x00063772
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

		' Token: 0x0600E4B7 RID: 58551 RVA: 0x00881A74 File Offset: 0x0087FC74
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "InvoiceInfo1"
			dataTableMapping.ColumnMappings.Add("Inv_ID", "Inv_ID")
			dataTableMapping.ColumnMappings.Add("InvoiceNo", "InvoiceNo")
			dataTableMapping.ColumnMappings.Add("InvoiceDate", "InvoiceDate")
			dataTableMapping.ColumnMappings.Add("ServiceID", "ServiceID")
			dataTableMapping.ColumnMappings.Add("RepairCharges", "RepairCharges")
			dataTableMapping.ColumnMappings.Add("Upfront", "Upfront")
			dataTableMapping.ColumnMappings.Add("ServiceTaxPer", "ServiceTaxPer")
			dataTableMapping.ColumnMappings.Add("ServiceTax", "ServiceTax")
			dataTableMapping.ColumnMappings.Add("GrandTotal", "GrandTotal")
			dataTableMapping.ColumnMappings.Add("TotalPaid", "TotalPaid")
			dataTableMapping.ColumnMappings.Add("Balance", "Balance")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[InvoiceInfo1] WHERE (([Inv_ID] = @Original_Inv_ID) AND ([InvoiceNo] = @Original_InvoiceNo) AND ([InvoiceDate] = @Original_InvoiceDate) AND ([ServiceID] = @Original_ServiceID) AND ([RepairCharges] = @Original_RepairCharges) AND ([Upfront] = @Original_Upfront) AND ([ServiceTaxPer] = @Original_ServiceTaxPer) AND ([ServiceTax] = @Original_ServiceTax) AND ([GrandTotal] = @Original_GrandTotal) AND ([TotalPaid] = @Original_TotalPaid) AND ([Balance] = @Original_Balance))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Inv_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Inv_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_InvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "InvoiceDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ServiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ServiceID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_RepairCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RepairCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Upfront", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Upfront", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ServiceTaxPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ServiceTaxPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ServiceTax", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ServiceTax", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Balance", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Balance", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[InvoiceInfo1] ([Inv_ID], [InvoiceNo], [InvoiceDate], [ServiceID], [RepairCharges], [Upfront], [ServiceTaxPer], [ServiceTax], [GrandTotal], [TotalPaid], [Balance], [Remarks]) VALUES (@Inv_ID, @InvoiceNo, @InvoiceDate, @ServiceID, @RepairCharges, @Upfront, @ServiceTaxPer, @ServiceTax, @GrandTotal, @TotalPaid, @Balance, @Remarks);" & vbCrLf & "SELECT Inv_ID, InvoiceNo, InvoiceDate, ServiceID, RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, Remarks FROM InvoiceInfo1 WHERE (Inv_ID = @Inv_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Inv_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Inv_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@InvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "InvoiceDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ServiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ServiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@RepairCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RepairCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Upfront", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Upfront", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ServiceTaxPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ServiceTaxPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ServiceTax", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ServiceTax", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Balance", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Balance", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[InvoiceInfo1] SET [Inv_ID] = @Inv_ID, [InvoiceNo] = @InvoiceNo, [InvoiceDate] = @InvoiceDate, [ServiceID] = @ServiceID, [RepairCharges] = @RepairCharges, [Upfront] = @Upfront, [ServiceTaxPer] = @ServiceTaxPer, [ServiceTax] = @ServiceTax, [GrandTotal] = @GrandTotal, [TotalPaid] = @TotalPaid, [Balance] = @Balance, [Remarks] = @Remarks WHERE (([Inv_ID] = @Original_Inv_ID) AND ([InvoiceNo] = @Original_InvoiceNo) AND ([InvoiceDate] = @Original_InvoiceDate) AND ([ServiceID] = @Original_ServiceID) AND ([RepairCharges] = @Original_RepairCharges) AND ([Upfront] = @Original_Upfront) AND ([ServiceTaxPer] = @Original_ServiceTaxPer) AND ([ServiceTax] = @Original_ServiceTax) AND ([GrandTotal] = @Original_GrandTotal) AND ([TotalPaid] = @Original_TotalPaid) AND ([Balance] = @Original_Balance));" & vbCrLf & "SELECT Inv_ID, InvoiceNo, InvoiceDate, ServiceID, RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, Remarks FROM InvoiceInfo1 WHERE (Inv_ID = @Inv_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Inv_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Inv_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@InvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "InvoiceDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ServiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ServiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@RepairCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RepairCharges", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Upfront", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Upfront", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ServiceTaxPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ServiceTaxPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ServiceTax", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ServiceTax", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Balance", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Balance", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Inv_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Inv_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_InvoiceNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "InvoiceNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_InvoiceDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "InvoiceDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ServiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ServiceID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_RepairCharges", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "RepairCharges", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Upfront", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Upfront", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ServiceTaxPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ServiceTaxPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ServiceTax", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ServiceTax", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Balance", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Balance", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E4B8 RID: 58552 RVA: 0x0006557C File Offset: 0x0006377C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E4B9 RID: 58553 RVA: 0x00882858 File Offset: 0x00880A58
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Inv_ID, InvoiceNo, InvoiceDate, ServiceID, RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, Remarks FROM dbo.InvoiceInfo1"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E4BA RID: 58554 RVA: 0x008828B8 File Offset: 0x00880AB8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.InvoiceInfo1DataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E4BB RID: 58555 RVA: 0x00882900 File Offset: 0x00880B00
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.InvoiceInfo1DataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim invoiceInfo1DataTable As Inventory_DBDataSet.InvoiceInfo1DataTable = New Inventory_DBDataSet.InvoiceInfo1DataTable()
			Me.Adapter.Fill(invoiceInfo1DataTable)
			Return invoiceInfo1DataTable
		End Function

		' Token: 0x0600E4BC RID: 58556 RVA: 0x0088293C File Offset: 0x00880B3C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.InvoiceInfo1DataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E4BD RID: 58557 RVA: 0x0088295C File Offset: 0x00880B5C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "InvoiceInfo1")
		End Function

		' Token: 0x0600E4BE RID: 58558 RVA: 0x00882980 File Offset: 0x00880B80
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E4BF RID: 58559 RVA: 0x008829A8 File Offset: 0x00880BA8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E4C0 RID: 58560 RVA: 0x008829C8 File Offset: 0x00880BC8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Inv_ID As Integer, Original_InvoiceNo As String, Original_InvoiceDate As DateTime, Original_ServiceID As Integer, Original_RepairCharges As Decimal, Original_Upfront As Decimal, Original_ServiceTaxPer As Decimal, Original_ServiceTax As Decimal, Original_GrandTotal As Decimal, Original_TotalPaid As Decimal, Original_Balance As Decimal) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Inv_ID
			Dim flag As Boolean = Original_InvoiceNo = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_InvoiceNo")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_InvoiceNo
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_InvoiceDate
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_ServiceID
			Me.Adapter.DeleteCommand.Parameters(4).Value = Original_RepairCharges
			Me.Adapter.DeleteCommand.Parameters(5).Value = Original_Upfront
			Me.Adapter.DeleteCommand.Parameters(6).Value = Original_ServiceTaxPer
			Me.Adapter.DeleteCommand.Parameters(7).Value = Original_ServiceTax
			Me.Adapter.DeleteCommand.Parameters(8).Value = Original_GrandTotal
			Me.Adapter.DeleteCommand.Parameters(9).Value = Original_TotalPaid
			Me.Adapter.DeleteCommand.Parameters(10).Value = Original_Balance
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag2 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag2 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag3 As Boolean = state = ConnectionState.Closed
				If flag3 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E4C1 RID: 58561 RVA: 0x00882C04 File Offset: 0x00880E04
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(Inv_ID As Integer, InvoiceNo As String, InvoiceDate As DateTime, ServiceID As Integer, RepairCharges As Decimal, Upfront As Decimal, ServiceTaxPer As Decimal, ServiceTax As Decimal, GrandTotal As Decimal, TotalPaid As Decimal, Balance As Decimal, Remarks As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = Inv_ID
			Dim flag As Boolean = InvoiceNo = Nothing
			If flag Then
				Throw New ArgumentNullException("InvoiceNo")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = InvoiceNo
			Me.Adapter.InsertCommand.Parameters(2).Value = InvoiceDate
			Me.Adapter.InsertCommand.Parameters(3).Value = ServiceID
			Me.Adapter.InsertCommand.Parameters(4).Value = RepairCharges
			Me.Adapter.InsertCommand.Parameters(5).Value = Upfront
			Me.Adapter.InsertCommand.Parameters(6).Value = ServiceTaxPer
			Me.Adapter.InsertCommand.Parameters(7).Value = ServiceTax
			Me.Adapter.InsertCommand.Parameters(8).Value = GrandTotal
			Me.Adapter.InsertCommand.Parameters(9).Value = TotalPaid
			Me.Adapter.InsertCommand.Parameters(10).Value = Balance
			Dim flag2 As Boolean = Remarks = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = Remarks
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag3 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag3 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag4 As Boolean = state = ConnectionState.Closed
				If flag4 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E4C2 RID: 58562 RVA: 0x00882E90 File Offset: 0x00881090
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Inv_ID As Integer, InvoiceNo As String, InvoiceDate As DateTime, ServiceID As Integer, RepairCharges As Decimal, Upfront As Decimal, ServiceTaxPer As Decimal, ServiceTax As Decimal, GrandTotal As Decimal, TotalPaid As Decimal, Balance As Decimal, Remarks As String, Original_Inv_ID As Integer, Original_InvoiceNo As String, Original_InvoiceDate As DateTime, Original_ServiceID As Integer, Original_RepairCharges As Decimal, Original_Upfront As Decimal, Original_ServiceTaxPer As Decimal, Original_ServiceTax As Decimal, Original_GrandTotal As Decimal, Original_TotalPaid As Decimal, Original_Balance As Decimal) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = Inv_ID
			Dim flag As Boolean = InvoiceNo = Nothing
			If flag Then
				Throw New ArgumentNullException("InvoiceNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = InvoiceNo
			Me.Adapter.UpdateCommand.Parameters(2).Value = InvoiceDate
			Me.Adapter.UpdateCommand.Parameters(3).Value = ServiceID
			Me.Adapter.UpdateCommand.Parameters(4).Value = RepairCharges
			Me.Adapter.UpdateCommand.Parameters(5).Value = Upfront
			Me.Adapter.UpdateCommand.Parameters(6).Value = ServiceTaxPer
			Me.Adapter.UpdateCommand.Parameters(7).Value = ServiceTax
			Me.Adapter.UpdateCommand.Parameters(8).Value = GrandTotal
			Me.Adapter.UpdateCommand.Parameters(9).Value = TotalPaid
			Me.Adapter.UpdateCommand.Parameters(10).Value = Balance
			Dim flag2 As Boolean = Remarks = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = Remarks
			End If
			Me.Adapter.UpdateCommand.Parameters(12).Value = Original_Inv_ID
			Dim flag3 As Boolean = Original_InvoiceNo = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_InvoiceNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(13).Value = Original_InvoiceNo
			Me.Adapter.UpdateCommand.Parameters(14).Value = Original_InvoiceDate
			Me.Adapter.UpdateCommand.Parameters(15).Value = Original_ServiceID
			Me.Adapter.UpdateCommand.Parameters(16).Value = Original_RepairCharges
			Me.Adapter.UpdateCommand.Parameters(17).Value = Original_Upfront
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_ServiceTaxPer
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_ServiceTax
			Me.Adapter.UpdateCommand.Parameters(20).Value = Original_GrandTotal
			Me.Adapter.UpdateCommand.Parameters(21).Value = Original_TotalPaid
			Me.Adapter.UpdateCommand.Parameters(22).Value = Original_Balance
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag4 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag4 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag5 As Boolean = state = ConnectionState.Closed
				If flag5 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E4C3 RID: 58563 RVA: 0x008832BC File Offset: 0x008814BC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(InvoiceNo As String, InvoiceDate As DateTime, ServiceID As Integer, RepairCharges As Decimal, Upfront As Decimal, ServiceTaxPer As Decimal, ServiceTax As Decimal, GrandTotal As Decimal, TotalPaid As Decimal, Balance As Decimal, Remarks As String, Original_Inv_ID As Integer, Original_InvoiceNo As String, Original_InvoiceDate As DateTime, Original_ServiceID As Integer, Original_RepairCharges As Decimal, Original_Upfront As Decimal, Original_ServiceTaxPer As Decimal, Original_ServiceTax As Decimal, Original_GrandTotal As Decimal, Original_TotalPaid As Decimal, Original_Balance As Decimal) As Integer
			Return Me.Update(Original_Inv_ID, InvoiceNo, InvoiceDate, ServiceID, RepairCharges, Upfront, ServiceTaxPer, ServiceTax, GrandTotal, TotalPaid, Balance, Remarks, Original_Inv_ID, Original_InvoiceNo, Original_InvoiceDate, Original_ServiceID, Original_RepairCharges, Original_Upfront, Original_ServiceTaxPer, Original_ServiceTax, Original_GrandTotal, Original_TotalPaid, Original_Balance)
		End Function

		' Token: 0x04005867 RID: 22631
		Private _connection As SqlConnection

		' Token: 0x04005868 RID: 22632
		Private _transaction As SqlTransaction

		' Token: 0x04005869 RID: 22633
		Private _commandCollection As SqlCommand()

		' Token: 0x0400586A RID: 22634
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
