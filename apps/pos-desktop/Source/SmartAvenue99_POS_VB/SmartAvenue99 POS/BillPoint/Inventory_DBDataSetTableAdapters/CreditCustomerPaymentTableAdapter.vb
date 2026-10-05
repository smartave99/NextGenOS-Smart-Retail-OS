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
	' Token: 0x02000449 RID: 1097
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class CreditCustomerPaymentTableAdapter
		Inherits Component

		' Token: 0x170057DF RID: 22495
		' (get) Token: 0x0600E3D4 RID: 58324 RVA: 0x00065262 File Offset: 0x00063462
		' (set) Token: 0x0600E3D5 RID: 58325 RVA: 0x0006526C File Offset: 0x0006346C
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E3D6 RID: 58326 RVA: 0x00065275 File Offset: 0x00063475
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057E0 RID: 22496
		' (get) Token: 0x0600E3D7 RID: 58327 RVA: 0x0086D6F0 File Offset: 0x0086B8F0
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

		' Token: 0x170057E1 RID: 22497
		' (get) Token: 0x0600E3D8 RID: 58328 RVA: 0x0086D720 File Offset: 0x0086B920
		' (set) Token: 0x0600E3D9 RID: 58329 RVA: 0x0086D750 File Offset: 0x0086B950
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

		' Token: 0x170057E2 RID: 22498
		' (get) Token: 0x0600E3DA RID: 58330 RVA: 0x0086D814 File Offset: 0x0086BA14
		' (set) Token: 0x0600E3DB RID: 58331 RVA: 0x0086D82C File Offset: 0x0086BA2C
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

		' Token: 0x170057E3 RID: 22499
		' (get) Token: 0x0600E3DC RID: 58332 RVA: 0x0086D914 File Offset: 0x0086BB14
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

		' Token: 0x170057E4 RID: 22500
		' (get) Token: 0x0600E3DD RID: 58333 RVA: 0x0086D944 File Offset: 0x0086BB44
		' (set) Token: 0x0600E3DE RID: 58334 RVA: 0x00065287 File Offset: 0x00063487
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

		' Token: 0x0600E3DF RID: 58335 RVA: 0x0086D95C File Offset: 0x0086BB5C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "CreditCustomerPayment"
			dataTableMapping.ColumnMappings.Add("T_ID", "T_ID")
			dataTableMapping.ColumnMappings.Add("TransactionID", "TransactionID")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("PaymentMode", "PaymentMode")
			dataTableMapping.ColumnMappings.Add("Customer_ID", "Customer_ID")
			dataTableMapping.ColumnMappings.Add("Amount", "Amount")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			dataTableMapping.ColumnMappings.Add("PaymentModeDetails", "PaymentModeDetails")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[CreditCustomerPayment] WHERE (([T_ID] = @Original_T_ID) AND ((@IsNull_TransactionID = 1 AND [TransactionID] IS NULL) OR ([TransactionID] = @Original_TransactionID)) AND ([Date] = @Original_Date) AND ((@IsNull_PaymentMode = 1 AND [PaymentMode] IS NULL) OR ([PaymentMode] = @Original_PaymentMode)) AND ([Customer_ID] = @Original_Customer_ID) AND ([Amount] = @Original_Amount) AND ((@IsNull_Remarks = 1 AND [Remarks] IS NULL) OR ([Remarks] = @Original_Remarks)) AND ((@IsNull_PaymentModeDetails = 1 AND [PaymentModeDetails] IS NULL) OR ([PaymentModeDetails] = @Original_PaymentModeDetails)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_T_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_TransactionID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TransactionID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PaymentMode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Customer_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Customer_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Remarks", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PaymentModeDetails", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PaymentModeDetails", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[CreditCustomerPayment] ([T_ID], [TransactionID], [Date], [PaymentMode], [Customer_ID], [Amount], [Remarks], [PaymentModeDetails]) VALUES (@T_ID, @TransactionID, @Date, @PaymentMode, @Customer_ID, @Amount, @Remarks, @PaymentModeDetails);" & vbCrLf & "SELECT T_ID, TransactionID, Date, PaymentMode, Customer_ID, Amount, Remarks, PaymentModeDetails FROM CreditCustomerPayment WHERE (T_ID = @T_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@T_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TransactionID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Customer_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Customer_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaymentModeDetails", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[CreditCustomerPayment] SET [T_ID] = @T_ID, [TransactionID] = @TransactionID, [Date] = @Date, [PaymentMode] = @PaymentMode, [Customer_ID] = @Customer_ID, [Amount] = @Amount, [Remarks] = @Remarks, [PaymentModeDetails] = @PaymentModeDetails WHERE (([T_ID] = @Original_T_ID) AND ((@IsNull_TransactionID = 1 AND [TransactionID] IS NULL) OR ([TransactionID] = @Original_TransactionID)) AND ([Date] = @Original_Date) AND ((@IsNull_PaymentMode = 1 AND [PaymentMode] IS NULL) OR ([PaymentMode] = @Original_PaymentMode)) AND ([Customer_ID] = @Original_Customer_ID) AND ([Amount] = @Original_Amount) AND ((@IsNull_Remarks = 1 AND [Remarks] IS NULL) OR ([Remarks] = @Original_Remarks)) AND ((@IsNull_PaymentModeDetails = 1 AND [PaymentModeDetails] IS NULL) OR ([PaymentModeDetails] = @Original_PaymentModeDetails)));" & vbCrLf & "SELECT T_ID, TransactionID, Date, PaymentMode, Customer_ID, Amount, Remarks, PaymentModeDetails FROM CreditCustomerPayment WHERE (T_ID = @T_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@T_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TransactionID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Customer_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Customer_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaymentModeDetails", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_T_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "T_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_TransactionID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TransactionID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "TransactionID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PaymentMode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Customer_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Customer_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Remarks", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PaymentModeDetails", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PaymentModeDetails", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "PaymentModeDetails", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E3E0 RID: 58336 RVA: 0x00065291 File Offset: 0x00063491
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E3E1 RID: 58337 RVA: 0x0086E55C File Offset: 0x0086C75C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT T_ID, TransactionID, Date, PaymentMode, Customer_ID, Amount, Remarks, PaymentModeDetails FROM dbo.CreditCustomerPayment"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E3E2 RID: 58338 RVA: 0x0086E5BC File Offset: 0x0086C7BC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.CreditCustomerPaymentDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E3E3 RID: 58339 RVA: 0x0086E604 File Offset: 0x0086C804
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.CreditCustomerPaymentDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim creditCustomerPaymentDataTable As Inventory_DBDataSet.CreditCustomerPaymentDataTable = New Inventory_DBDataSet.CreditCustomerPaymentDataTable()
			Me.Adapter.Fill(creditCustomerPaymentDataTable)
			Return creditCustomerPaymentDataTable
		End Function

		' Token: 0x0600E3E4 RID: 58340 RVA: 0x0086E640 File Offset: 0x0086C840
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.CreditCustomerPaymentDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E3E5 RID: 58341 RVA: 0x0086E660 File Offset: 0x0086C860
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "CreditCustomerPayment")
		End Function

		' Token: 0x0600E3E6 RID: 58342 RVA: 0x0086E684 File Offset: 0x0086C884
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E3E7 RID: 58343 RVA: 0x0086E6AC File Offset: 0x0086C8AC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E3E8 RID: 58344 RVA: 0x0086E6CC File Offset: 0x0086C8CC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_T_ID As Integer, Original_TransactionID As String, Original_Date As DateTime, Original_PaymentMode As String, Original_Customer_ID As Integer, Original_Amount As Decimal, Original_Remarks As String, Original_PaymentModeDetails As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_T_ID
			Dim flag As Boolean = Original_TransactionID = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_TransactionID
			End If
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_Date
			Dim flag2 As Boolean = Original_PaymentMode = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(4).Value = 1
				Me.Adapter.DeleteCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(4).Value = 0
				Me.Adapter.DeleteCommand.Parameters(5).Value = Original_PaymentMode
			End If
			Me.Adapter.DeleteCommand.Parameters(6).Value = Original_Customer_ID
			Me.Adapter.DeleteCommand.Parameters(7).Value = Original_Amount
			Dim flag3 As Boolean = Original_Remarks = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(8).Value = 1
				Me.Adapter.DeleteCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(8).Value = 0
				Me.Adapter.DeleteCommand.Parameters(9).Value = Original_Remarks
			End If
			Dim flag4 As Boolean = Original_PaymentModeDetails = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(10).Value = 1
				Me.Adapter.DeleteCommand.Parameters(11).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(10).Value = 0
				Me.Adapter.DeleteCommand.Parameters(11).Value = Original_PaymentModeDetails
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

		' Token: 0x0600E3E9 RID: 58345 RVA: 0x0086EA50 File Offset: 0x0086CC50
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(T_ID As Integer, TransactionID As String, _Date As DateTime, PaymentMode As String, Customer_ID As Integer, Amount As Decimal, Remarks As String, PaymentModeDetails As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = T_ID
			Dim flag As Boolean = TransactionID = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = TransactionID
			End If
			Me.Adapter.InsertCommand.Parameters(2).Value = _Date
			Dim flag2 As Boolean = PaymentMode = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = PaymentMode
			End If
			Me.Adapter.InsertCommand.Parameters(4).Value = Customer_ID
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

		' Token: 0x0600E3EA RID: 58346 RVA: 0x0086ECBC File Offset: 0x0086CEBC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(T_ID As Integer, TransactionID As String, _Date As DateTime, PaymentMode As String, Customer_ID As Integer, Amount As Decimal, Remarks As String, PaymentModeDetails As String, Original_T_ID As Integer, Original_TransactionID As String, Original_Date As DateTime, Original_PaymentMode As String, Original_Customer_ID As Integer, Original_Amount As Decimal, Original_Remarks As String, Original_PaymentModeDetails As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = T_ID
			Dim flag As Boolean = TransactionID = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = TransactionID
			End If
			Me.Adapter.UpdateCommand.Parameters(2).Value = _Date
			Dim flag2 As Boolean = PaymentMode = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = PaymentMode
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = Customer_ID
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
				Me.Adapter.UpdateCommand.Parameters(9).Value = 1
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = 0
				Me.Adapter.UpdateCommand.Parameters(10).Value = Original_TransactionID
			End If
			Me.Adapter.UpdateCommand.Parameters(11).Value = Original_Date
			Dim flag6 As Boolean = Original_PaymentMode = Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = 1
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = 0
				Me.Adapter.UpdateCommand.Parameters(13).Value = Original_PaymentMode
			End If
			Me.Adapter.UpdateCommand.Parameters(14).Value = Original_Customer_ID
			Me.Adapter.UpdateCommand.Parameters(15).Value = Original_Amount
			Dim flag7 As Boolean = Original_Remarks = Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = 1
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = 0
				Me.Adapter.UpdateCommand.Parameters(17).Value = Original_Remarks
			End If
			Dim flag8 As Boolean = Original_PaymentModeDetails = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(18).Value = 1
				Me.Adapter.UpdateCommand.Parameters(19).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(18).Value = 0
				Me.Adapter.UpdateCommand.Parameters(19).Value = Original_PaymentModeDetails
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

		' Token: 0x0600E3EB RID: 58347 RVA: 0x0086F214 File Offset: 0x0086D414
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(TransactionID As String, _Date As DateTime, PaymentMode As String, Customer_ID As Integer, Amount As Decimal, Remarks As String, PaymentModeDetails As String, Original_T_ID As Integer, Original_TransactionID As String, Original_Date As DateTime, Original_PaymentMode As String, Original_Customer_ID As Integer, Original_Amount As Decimal, Original_Remarks As String, Original_PaymentModeDetails As String) As Integer
			Return Me.Update(Original_T_ID, TransactionID, _Date, PaymentMode, Customer_ID, Amount, Remarks, PaymentModeDetails, Original_T_ID, Original_TransactionID, Original_Date, Original_PaymentMode, Original_Customer_ID, Original_Amount, Original_Remarks, Original_PaymentModeDetails)
		End Function

		' Token: 0x0400583A RID: 22586
		Private _connection As SqlConnection

		' Token: 0x0400583B RID: 22587
		Private _transaction As SqlTransaction

		' Token: 0x0400583C RID: 22588
		Private _commandCollection As SqlCommand()

		' Token: 0x0400583D RID: 22589
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
