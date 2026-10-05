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
	' Token: 0x02000455 RID: 1109
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class PaymentTableAdapter
		Inherits Component

		' Token: 0x17005827 RID: 22567
		' (get) Token: 0x0600E4F4 RID: 58612 RVA: 0x00065646 File Offset: 0x00063846
		' (set) Token: 0x0600E4F5 RID: 58613 RVA: 0x00065650 File Offset: 0x00063850
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E4F6 RID: 58614 RVA: 0x00065659 File Offset: 0x00063859
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005828 RID: 22568
		' (get) Token: 0x0600E4F7 RID: 58615 RVA: 0x008856AC File Offset: 0x008838AC
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

		' Token: 0x17005829 RID: 22569
		' (get) Token: 0x0600E4F8 RID: 58616 RVA: 0x008856DC File Offset: 0x008838DC
		' (set) Token: 0x0600E4F9 RID: 58617 RVA: 0x0088570C File Offset: 0x0088390C
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

		' Token: 0x1700582A RID: 22570
		' (get) Token: 0x0600E4FA RID: 58618 RVA: 0x008857D0 File Offset: 0x008839D0
		' (set) Token: 0x0600E4FB RID: 58619 RVA: 0x008857E8 File Offset: 0x008839E8
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

		' Token: 0x1700582B RID: 22571
		' (get) Token: 0x0600E4FC RID: 58620 RVA: 0x008858D0 File Offset: 0x00883AD0
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

		' Token: 0x1700582C RID: 22572
		' (get) Token: 0x0600E4FD RID: 58621 RVA: 0x00885900 File Offset: 0x00883B00
		' (set) Token: 0x0600E4FE RID: 58622 RVA: 0x0006566B File Offset: 0x0006386B
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

		' Token: 0x0600E4FF RID: 58623 RVA: 0x00885918 File Offset: 0x00883B18
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Payment"
			dataTableMapping.ColumnMappings.Add("T_ID", "T_ID")
			dataTableMapping.ColumnMappings.Add("TransactionID", "TransactionID")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("PaymentMode", "PaymentMode")
			dataTableMapping.ColumnMappings.Add("SupplierID", "SupplierID")
			dataTableMapping.ColumnMappings.Add("Amount", "Amount")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			dataTableMapping.ColumnMappings.Add("PaymentModeDetails", "PaymentModeDetails")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Payment] WHERE (([T_ID] = @Original_T_ID) AND ([TransactionID] = @Original_TransactionID) AND ([Date] = @Original_Date) AND ([PaymentMode] = @Original_PaymentMode) AND ([SupplierID] = @Original_SupplierID) AND ([Amount] = @Original_Amount) AND ((@IsNull_Remarks = 1 AND [Remarks] IS NULL) OR ([Remarks] = @Original_Remarks)) AND ((@IsNull_PaymentModeDetails = 1 AND [PaymentModeDetails] IS NULL) OR ([PaymentModeDetails] = @Original_PaymentModeDetails)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_T_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TransactionID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Remarks", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PaymentModeDetails", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PaymentModeDetails", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Payment] ([T_ID], [TransactionID], [Date], [PaymentMode], [SupplierID], [Amount], [Remarks], [PaymentModeDetails]) VALUES (@T_ID, @TransactionID, @Date, @PaymentMode, @SupplierID, @Amount, @Remarks, @PaymentModeDetails);" & vbCrLf & "SELECT T_ID, TransactionID, Date, PaymentMode, SupplierID, Amount, Remarks, PaymentModeDetails FROM Payment WHERE (T_ID = @T_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TransactionID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaymentModeDetails", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Payment] SET [T_ID] = @T_ID, [TransactionID] = @TransactionID, [Date] = @Date, [PaymentMode] = @PaymentMode, [SupplierID] = @SupplierID, [Amount] = @Amount, [Remarks] = @Remarks, [PaymentModeDetails] = @PaymentModeDetails WHERE (([T_ID] = @Original_T_ID) AND ([TransactionID] = @Original_TransactionID) AND ([Date] = @Original_Date) AND ([PaymentMode] = @Original_PaymentMode) AND ([SupplierID] = @Original_SupplierID) AND ([Amount] = @Original_Amount) AND ((@IsNull_Remarks = 1 AND [Remarks] IS NULL) OR ([Remarks] = @Original_Remarks)) AND ((@IsNull_PaymentModeDetails = 1 AND [PaymentModeDetails] IS NULL) OR ([PaymentModeDetails] = @Original_PaymentModeDetails)));" & vbCrLf & "SELECT T_ID, TransactionID, Date, PaymentMode, SupplierID, Amount, Remarks, PaymentModeDetails FROM Payment WHERE (T_ID = @T_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TransactionID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaymentModeDetails", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_T_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TransactionID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SupplierID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SupplierID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Remarks", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PaymentModeDetails", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PaymentModeDetails", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E500 RID: 58624 RVA: 0x00065675 File Offset: 0x00063875
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E501 RID: 58625 RVA: 0x00886418 File Offset: 0x00884618
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT T_ID, TransactionID, Date, PaymentMode, SupplierID, Amount, Remarks, PaymentModeDetails FROM dbo.Payment"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E502 RID: 58626 RVA: 0x00886478 File Offset: 0x00884678
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.PaymentDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E503 RID: 58627 RVA: 0x008864C0 File Offset: 0x008846C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.PaymentDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim paymentDataTable As Inventory_DBDataSet.PaymentDataTable = New Inventory_DBDataSet.PaymentDataTable()
			Me.Adapter.Fill(paymentDataTable)
			Return paymentDataTable
		End Function

		' Token: 0x0600E504 RID: 58628 RVA: 0x008864FC File Offset: 0x008846FC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.PaymentDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E505 RID: 58629 RVA: 0x0088651C File Offset: 0x0088471C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Payment")
		End Function

		' Token: 0x0600E506 RID: 58630 RVA: 0x00886540 File Offset: 0x00884740
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E507 RID: 58631 RVA: 0x00886568 File Offset: 0x00884768
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E508 RID: 58632 RVA: 0x00886588 File Offset: 0x00884788
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_T_ID As Integer, Original_TransactionID As String, Original_Date As DateTime, Original_PaymentMode As String, Original_SupplierID As Integer, Original_Amount As Decimal, Original_Remarks As String, Original_PaymentModeDetails As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_T_ID
			Dim flag As Boolean = Original_TransactionID = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_TransactionID")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_TransactionID
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Date
			Dim flag2 As Boolean = Original_PaymentMode = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_PaymentMode")
			End If
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_PaymentMode
			Me.Adapter.DeleteCommand.Parameters(4).Value = Original_SupplierID
			Me.Adapter.DeleteCommand.Parameters(5).Value = Original_Amount
			Dim flag3 As Boolean = Original_Remarks = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(6).Value = 1
				Me.Adapter.DeleteCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(6).Value = 0
				Me.Adapter.DeleteCommand.Parameters(7).Value = Original_Remarks
			End If
			Dim flag4 As Boolean = Original_PaymentModeDetails = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(8).Value = 1
				Me.Adapter.DeleteCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(8).Value = 0
				Me.Adapter.DeleteCommand.Parameters(9).Value = Original_PaymentModeDetails
			End If
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag5 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag5 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag6 As Boolean = state = ConnectionState.Closed
				If flag6 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E509 RID: 58633 RVA: 0x0088684C File Offset: 0x00884A4C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(T_ID As Integer, TransactionID As String, _Date As DateTime, PaymentMode As String, SupplierID As Integer, Amount As Decimal, Remarks As String, PaymentModeDetails As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = T_ID
			Dim flag As Boolean = TransactionID = Nothing
			If flag Then
				Throw New ArgumentNullException("TransactionID")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = TransactionID
			Me.Adapter.InsertCommand.Parameters(2).Value = _Date
			Dim flag2 As Boolean = PaymentMode = Nothing
			If flag2 Then
				Throw New ArgumentNullException("PaymentMode")
			End If
			Me.Adapter.InsertCommand.Parameters(3).Value = PaymentMode
			Me.Adapter.InsertCommand.Parameters(4).Value = SupplierID
			Me.Adapter.InsertCommand.Parameters(5).Value = Amount
			Dim flag3 As Boolean = Remarks = Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = Remarks
			End If
			Dim flag4 As Boolean = PaymentModeDetails = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = PaymentModeDetails
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag5 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag5 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag6 As Boolean = state = ConnectionState.Closed
				If flag6 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E50A RID: 58634 RVA: 0x00886A88 File Offset: 0x00884C88
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(T_ID As Integer, TransactionID As String, _Date As DateTime, PaymentMode As String, SupplierID As Integer, Amount As Decimal, Remarks As String, PaymentModeDetails As String, Original_T_ID As Integer, Original_TransactionID As String, Original_Date As DateTime, Original_PaymentMode As String, Original_SupplierID As Integer, Original_Amount As Decimal, Original_Remarks As String, Original_PaymentModeDetails As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = T_ID
			Dim flag As Boolean = TransactionID = Nothing
			If flag Then
				Throw New ArgumentNullException("TransactionID")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = TransactionID
			Me.Adapter.UpdateCommand.Parameters(2).Value = _Date
			Dim flag2 As Boolean = PaymentMode = Nothing
			If flag2 Then
				Throw New ArgumentNullException("PaymentMode")
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = PaymentMode
			Me.Adapter.UpdateCommand.Parameters(4).Value = SupplierID
			Me.Adapter.UpdateCommand.Parameters(5).Value = Amount
			Dim flag3 As Boolean = Remarks = Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = Remarks
			End If
			Dim flag4 As Boolean = PaymentModeDetails = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = PaymentModeDetails
			End If
			Me.Adapter.UpdateCommand.Parameters(8).Value = Original_T_ID
			Dim flag5 As Boolean = Original_TransactionID = Nothing
			If flag5 Then
				Throw New ArgumentNullException("Original_TransactionID")
			End If
			Me.Adapter.UpdateCommand.Parameters(9).Value = Original_TransactionID
			Me.Adapter.UpdateCommand.Parameters(10).Value = Original_Date
			Dim flag6 As Boolean = Original_PaymentMode = Nothing
			If flag6 Then
				Throw New ArgumentNullException("Original_PaymentMode")
			End If
			Me.Adapter.UpdateCommand.Parameters(11).Value = Original_PaymentMode
			Me.Adapter.UpdateCommand.Parameters(12).Value = Original_SupplierID
			Me.Adapter.UpdateCommand.Parameters(13).Value = Original_Amount
			Dim flag7 As Boolean = Original_Remarks = Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = 1
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = 0
				Me.Adapter.UpdateCommand.Parameters(15).Value = Original_Remarks
			End If
			Dim flag8 As Boolean = Original_PaymentModeDetails = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = 1
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = 0
				Me.Adapter.UpdateCommand.Parameters(17).Value = Original_PaymentModeDetails
			End If
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag9 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag9 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag10 As Boolean = state = ConnectionState.Closed
				If flag10 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E50B RID: 58635 RVA: 0x00886EF0 File Offset: 0x008850F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(TransactionID As String, _Date As DateTime, PaymentMode As String, SupplierID As Integer, Amount As Decimal, Remarks As String, PaymentModeDetails As String, Original_T_ID As Integer, Original_TransactionID As String, Original_Date As DateTime, Original_PaymentMode As String, Original_SupplierID As Integer, Original_Amount As Decimal, Original_Remarks As String, Original_PaymentModeDetails As String) As Integer
			Return Me.Update(Original_T_ID, TransactionID, _Date, PaymentMode, SupplierID, Amount, Remarks, PaymentModeDetails, Original_T_ID, Original_TransactionID, Original_Date, Original_PaymentMode, Original_SupplierID, Original_Amount, Original_Remarks, Original_PaymentModeDetails)
		End Function

		' Token: 0x04005876 RID: 22646
		Private _connection As SqlConnection

		' Token: 0x04005877 RID: 22647
		Private _transaction As SqlTransaction

		' Token: 0x04005878 RID: 22648
		Private _commandCollection As SqlCommand()

		' Token: 0x04005879 RID: 22649
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
