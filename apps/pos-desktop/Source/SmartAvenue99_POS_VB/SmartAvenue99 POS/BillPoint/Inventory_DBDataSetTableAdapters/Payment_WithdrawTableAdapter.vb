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
	' Token: 0x02000456 RID: 1110
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Payment_WithdrawTableAdapter
		Inherits Component

		' Token: 0x1700582D RID: 22573
		' (get) Token: 0x0600E50C RID: 58636 RVA: 0x00065699 File Offset: 0x00063899
		' (set) Token: 0x0600E50D RID: 58637 RVA: 0x000656A3 File Offset: 0x000638A3
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E50E RID: 58638 RVA: 0x000656AC File Offset: 0x000638AC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x1700582E RID: 22574
		' (get) Token: 0x0600E50F RID: 58639 RVA: 0x00886F28 File Offset: 0x00885128
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

		' Token: 0x1700582F RID: 22575
		' (get) Token: 0x0600E510 RID: 58640 RVA: 0x00886F58 File Offset: 0x00885158
		' (set) Token: 0x0600E511 RID: 58641 RVA: 0x00886F88 File Offset: 0x00885188
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

		' Token: 0x17005830 RID: 22576
		' (get) Token: 0x0600E512 RID: 58642 RVA: 0x0088704C File Offset: 0x0088524C
		' (set) Token: 0x0600E513 RID: 58643 RVA: 0x00887064 File Offset: 0x00885264
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

		' Token: 0x17005831 RID: 22577
		' (get) Token: 0x0600E514 RID: 58644 RVA: 0x0088714C File Offset: 0x0088534C
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

		' Token: 0x17005832 RID: 22578
		' (get) Token: 0x0600E515 RID: 58645 RVA: 0x0088717C File Offset: 0x0088537C
		' (set) Token: 0x0600E516 RID: 58646 RVA: 0x000656BE File Offset: 0x000638BE
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

		' Token: 0x0600E517 RID: 58647 RVA: 0x00887194 File Offset: 0x00885394
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Payment_Withdraw"
			dataTableMapping.ColumnMappings.Add("id", "id")
			dataTableMapping.ColumnMappings.Add("AccountFrom", "AccountFrom")
			dataTableMapping.ColumnMappings.Add("PaymentMode", "PaymentMode")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("Amount", "Amount")
			dataTableMapping.ColumnMappings.Add("ReceiverName", "ReceiverName")
			dataTableMapping.ColumnMappings.Add("PhoneNo", "PhoneNo")
			dataTableMapping.ColumnMappings.Add("Notes", "Notes")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Payment_Withdraw] WHERE (([id] = @Original_id) AND ((@IsNull_AccountFrom = 1 AND [AccountFrom] IS NULL) OR ([AccountFrom] = @Original_AccountFrom)) AND ((@IsNull_PaymentMode = 1 AND [PaymentMode] IS NULL) OR ([PaymentMode] = @Original_PaymentMode)) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_Amount = 1 AND [Amount] IS NULL) OR ([Amount] = @Original_Amount)) AND ((@IsNull_ReceiverName = 1 AND [ReceiverName] IS NULL) OR ([ReceiverName] = @Original_ReceiverName)) AND ((@IsNull_PhoneNo = 1 AND [PhoneNo] IS NULL) OR ([PhoneNo] = @Original_PhoneNo)) AND ((@IsNull_Notes = 1 AND [Notes] IS NULL) OR ([Notes] = @Original_Notes)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_AccountFrom", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountFrom", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AccountFrom", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountFrom", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PaymentMode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Amount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Amount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ReceiverName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReceiverName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ReceiverName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReceiverName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PhoneNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PhoneNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PhoneNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PhoneNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Notes", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Notes", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Payment_Withdraw] ([id], [AccountFrom], [PaymentMode], [Date], [Amount], [ReceiverName], [PhoneNo], [Notes]) VALUES (@id, @AccountFrom, @PaymentMode, @Date, @Amount, @ReceiverName, @PhoneNo, @Notes);" & vbCrLf & "SELECT id, AccountFrom, PaymentMode, Date, Amount, ReceiverName, PhoneNo, Notes FROM Payment_Withdraw WHERE (id = @id)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AccountFrom", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountFrom", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ReceiverName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReceiverName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PhoneNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PhoneNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Notes", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Payment_Withdraw] SET [id] = @id, [AccountFrom] = @AccountFrom, [PaymentMode] = @PaymentMode, [Date] = @Date, [Amount] = @Amount, [ReceiverName] = @ReceiverName, [PhoneNo] = @PhoneNo, [Notes] = @Notes WHERE (([id] = @Original_id) AND ((@IsNull_AccountFrom = 1 AND [AccountFrom] IS NULL) OR ([AccountFrom] = @Original_AccountFrom)) AND ((@IsNull_PaymentMode = 1 AND [PaymentMode] IS NULL) OR ([PaymentMode] = @Original_PaymentMode)) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_Amount = 1 AND [Amount] IS NULL) OR ([Amount] = @Original_Amount)) AND ((@IsNull_ReceiverName = 1 AND [ReceiverName] IS NULL) OR ([ReceiverName] = @Original_ReceiverName)) AND ((@IsNull_PhoneNo = 1 AND [PhoneNo] IS NULL) OR ([PhoneNo] = @Original_PhoneNo)) AND ((@IsNull_Notes = 1 AND [Notes] IS NULL) OR ([Notes] = @Original_Notes)));" & vbCrLf & "SELECT id, AccountFrom, PaymentMode, Date, Amount, ReceiverName, PhoneNo, Notes FROM Payment_Withdraw WHERE (id = @id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AccountFrom", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountFrom", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ReceiverName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReceiverName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PhoneNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PhoneNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Notes", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_AccountFrom", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountFrom", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AccountFrom", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountFrom", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PaymentMode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Amount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Amount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ReceiverName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ReceiverName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ReceiverName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ReceiverName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PhoneNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PhoneNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PhoneNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PhoneNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Notes", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Notes", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E518 RID: 58648 RVA: 0x000656C8 File Offset: 0x000638C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E519 RID: 58649 RVA: 0x00887F18 File Offset: 0x00886118
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT id, AccountFrom, PaymentMode, Date, Amount, ReceiverName, PhoneNo, Notes FROM dbo.Payment_Withdraw"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E51A RID: 58650 RVA: 0x00887F78 File Offset: 0x00886178
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Payment_WithdrawDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E51B RID: 58651 RVA: 0x00887FC0 File Offset: 0x008861C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Payment_WithdrawDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim payment_WithdrawDataTable As Inventory_DBDataSet.Payment_WithdrawDataTable = New Inventory_DBDataSet.Payment_WithdrawDataTable()
			Me.Adapter.Fill(payment_WithdrawDataTable)
			Return payment_WithdrawDataTable
		End Function

		' Token: 0x0600E51C RID: 58652 RVA: 0x00887FFC File Offset: 0x008861FC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Payment_WithdrawDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E51D RID: 58653 RVA: 0x0088801C File Offset: 0x0088621C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Payment_Withdraw")
		End Function

		' Token: 0x0600E51E RID: 58654 RVA: 0x00888040 File Offset: 0x00886240
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E51F RID: 58655 RVA: 0x00888068 File Offset: 0x00886268
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E520 RID: 58656 RVA: 0x00888088 File Offset: 0x00886288
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_id As Integer, Original_AccountFrom As String, Original_PaymentMode As String, Original_Date As DateTime?, Original_Amount As Decimal?, Original_ReceiverName As String, Original_PhoneNo As String, Original_Notes As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_id
			Dim flag As Boolean = Original_AccountFrom = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_AccountFrom
			End If
			Dim flag2 As Boolean = Original_PaymentMode = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_PaymentMode
			End If
			Dim flag3 As Boolean = Original_Date IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_Date.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Original_Amount IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_Amount.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_ReceiverName = Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_ReceiverName
			End If
			Dim flag6 As Boolean = Original_PhoneNo = Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_PhoneNo
			End If
			Dim flag7 As Boolean = Original_Notes = Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(13).Value = 1
				Me.Adapter.DeleteCommand.Parameters(14).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(13).Value = 0
				Me.Adapter.DeleteCommand.Parameters(14).Value = Original_Notes
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

		' Token: 0x0600E521 RID: 58657 RVA: 0x00888578 File Offset: 0x00886778
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(id As Integer, AccountFrom As String, PaymentMode As String, _Date As DateTime?, Amount As Decimal?, ReceiverName As String, PhoneNo As String, Notes As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = id
			Dim flag As Boolean = AccountFrom = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = AccountFrom
			End If
			Dim flag2 As Boolean = PaymentMode = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = PaymentMode
			End If
			Dim flag3 As Boolean = _Date IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = _Date.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Amount IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = Amount.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = ReceiverName = Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = ReceiverName
			End If
			Dim flag6 As Boolean = PhoneNo = Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = PhoneNo
			End If
			Dim flag7 As Boolean = Notes = Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = Notes
			End If
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

		' Token: 0x0600E522 RID: 58658 RVA: 0x00888880 File Offset: 0x00886A80
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(id As Integer, AccountFrom As String, PaymentMode As String, _Date As DateTime?, Amount As Decimal?, ReceiverName As String, PhoneNo As String, Notes As String, Original_id As Integer, Original_AccountFrom As String, Original_PaymentMode As String, Original_Date As DateTime?, Original_Amount As Decimal?, Original_ReceiverName As String, Original_PhoneNo As String, Original_Notes As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = id
			Dim flag As Boolean = AccountFrom = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = AccountFrom
			End If
			Dim flag2 As Boolean = PaymentMode = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = PaymentMode
			End If
			Dim flag3 As Boolean = _Date IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = _Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Amount IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = Amount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = ReceiverName = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = ReceiverName
			End If
			Dim flag6 As Boolean = PhoneNo = Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = PhoneNo
			End If
			Dim flag7 As Boolean = Notes = Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = Notes
			End If
			Me.Adapter.UpdateCommand.Parameters(8).Value = Original_id
			Dim flag8 As Boolean = Original_AccountFrom = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = 1
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = 0
				Me.Adapter.UpdateCommand.Parameters(10).Value = Original_AccountFrom
			End If
			Dim flag9 As Boolean = Original_PaymentMode = Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = 1
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = 0
				Me.Adapter.UpdateCommand.Parameters(12).Value = Original_PaymentMode
			End If
			Dim flag10 As Boolean = Original_Date IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = 0
				Me.Adapter.UpdateCommand.Parameters(14).Value = Original_Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = 1
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_Amount IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = 0
				Me.Adapter.UpdateCommand.Parameters(16).Value = Original_Amount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = 1
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_ReceiverName = Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_ReceiverName
			End If
			Dim flag13 As Boolean = Original_PhoneNo = Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = 1
				Me.Adapter.UpdateCommand.Parameters(20).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(19).Value = 0
				Me.Adapter.UpdateCommand.Parameters(20).Value = Original_PhoneNo
			End If
			Dim flag14 As Boolean = Original_Notes = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(21).Value = 1
				Me.Adapter.UpdateCommand.Parameters(22).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(21).Value = 0
				Me.Adapter.UpdateCommand.Parameters(22).Value = Original_Notes
			End If
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

		' Token: 0x0600E523 RID: 58659 RVA: 0x00888FE4 File Offset: 0x008871E4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(AccountFrom As String, PaymentMode As String, _Date As DateTime?, Amount As Decimal?, ReceiverName As String, PhoneNo As String, Notes As String, Original_id As Integer, Original_AccountFrom As String, Original_PaymentMode As String, Original_Date As DateTime?, Original_Amount As Decimal?, Original_ReceiverName As String, Original_PhoneNo As String, Original_Notes As String) As Integer
			Return Me.Update(Original_id, AccountFrom, PaymentMode, _Date, Amount, ReceiverName, PhoneNo, Notes, Original_id, Original_AccountFrom, Original_PaymentMode, Original_Date, Original_Amount, Original_ReceiverName, Original_PhoneNo, Original_Notes)
		End Function

		' Token: 0x0400587B RID: 22651
		Private _connection As SqlConnection

		' Token: 0x0400587C RID: 22652
		Private _transaction As SqlTransaction

		' Token: 0x0400587D RID: 22653
		Private _commandCollection As SqlCommand()

		' Token: 0x0400587E RID: 22654
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
