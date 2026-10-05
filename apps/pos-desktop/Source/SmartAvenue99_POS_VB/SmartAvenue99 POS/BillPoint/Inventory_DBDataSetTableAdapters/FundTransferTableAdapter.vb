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
	' Token: 0x0200044E RID: 1102
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class FundTransferTableAdapter
		Inherits Component

		' Token: 0x170057FD RID: 22525
		' (get) Token: 0x0600E44C RID: 58444 RVA: 0x00065401 File Offset: 0x00063601
		' (set) Token: 0x0600E44D RID: 58445 RVA: 0x0006540B File Offset: 0x0006360B
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E44E RID: 58446 RVA: 0x00065414 File Offset: 0x00063614
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057FE RID: 22526
		' (get) Token: 0x0600E44F RID: 58447 RVA: 0x00877B8C File Offset: 0x00875D8C
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

		' Token: 0x170057FF RID: 22527
		' (get) Token: 0x0600E450 RID: 58448 RVA: 0x00877BBC File Offset: 0x00875DBC
		' (set) Token: 0x0600E451 RID: 58449 RVA: 0x00877BEC File Offset: 0x00875DEC
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

		' Token: 0x17005800 RID: 22528
		' (get) Token: 0x0600E452 RID: 58450 RVA: 0x00877CB0 File Offset: 0x00875EB0
		' (set) Token: 0x0600E453 RID: 58451 RVA: 0x00877CC8 File Offset: 0x00875EC8
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

		' Token: 0x17005801 RID: 22529
		' (get) Token: 0x0600E454 RID: 58452 RVA: 0x00877DB0 File Offset: 0x00875FB0
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

		' Token: 0x17005802 RID: 22530
		' (get) Token: 0x0600E455 RID: 58453 RVA: 0x00877DE0 File Offset: 0x00875FE0
		' (set) Token: 0x0600E456 RID: 58454 RVA: 0x00065426 File Offset: 0x00063626
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

		' Token: 0x0600E457 RID: 58455 RVA: 0x00877DF8 File Offset: 0x00875FF8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "FundTransfer"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("AccountTransFrom", "AccountTransFrom")
			dataTableMapping.ColumnMappings.Add("AccountTransTo", "AccountTransTo")
			dataTableMapping.ColumnMappings.Add("Amount", "Amount")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("Operator", "Operator")
			dataTableMapping.ColumnMappings.Add("Notes", "Notes")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[FundTransfer] WHERE (([Id] = @Original_Id) AND ((@IsNull_AccountTransFrom = 1 AND [AccountTransFrom] IS NULL) OR ([AccountTransFrom] = @Original_AccountTransFrom)) AND ((@IsNull_AccountTransTo = 1 AND [AccountTransTo] IS NULL) OR ([AccountTransTo] = @Original_AccountTransTo)) AND ((@IsNull_Amount = 1 AND [Amount] IS NULL) OR ([Amount] = @Original_Amount)) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_Operator = 1 AND [Operator] IS NULL) OR ([Operator] = @Original_Operator)) AND ((@IsNull_Notes = 1 AND [Notes] IS NULL) OR ([Notes] = @Original_Notes)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_AccountTransFrom", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountTransFrom", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AccountTransFrom", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountTransFrom", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_AccountTransTo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountTransTo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AccountTransTo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountTransTo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Amount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Amount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Operator", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Operator", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Operator", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Operator", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Notes", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Notes", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[FundTransfer] ([Id], [AccountTransFrom], [AccountTransTo], [Amount], [Date], [Operator], [Notes]) VALUES (@Id, @AccountTransFrom, @AccountTransTo, @Amount, @Date, @Operator, @Notes);" & vbCrLf & "SELECT Id, AccountTransFrom, AccountTransTo, Amount, Date, Operator, Notes FROM FundTransfer WHERE (Id = @Id)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AccountTransFrom", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountTransFrom", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AccountTransTo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountTransTo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Operator", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Operator", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Notes", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[FundTransfer] SET [Id] = @Id, [AccountTransFrom] = @AccountTransFrom, [AccountTransTo] = @AccountTransTo, [Amount] = @Amount, [Date] = @Date, [Operator] = @Operator, [Notes] = @Notes WHERE (([Id] = @Original_Id) AND ((@IsNull_AccountTransFrom = 1 AND [AccountTransFrom] IS NULL) OR ([AccountTransFrom] = @Original_AccountTransFrom)) AND ((@IsNull_AccountTransTo = 1 AND [AccountTransTo] IS NULL) OR ([AccountTransTo] = @Original_AccountTransTo)) AND ((@IsNull_Amount = 1 AND [Amount] IS NULL) OR ([Amount] = @Original_Amount)) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_Operator = 1 AND [Operator] IS NULL) OR ([Operator] = @Original_Operator)) AND ((@IsNull_Notes = 1 AND [Notes] IS NULL) OR ([Notes] = @Original_Notes)));" & vbCrLf & "SELECT Id, AccountTransFrom, AccountTransTo, Amount, Date, Operator, Notes FROM FundTransfer WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AccountTransFrom", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountTransFrom", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AccountTransTo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountTransTo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Operator", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Operator", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Notes", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_AccountTransFrom", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountTransFrom", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AccountTransFrom", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountTransFrom", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_AccountTransTo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountTransTo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AccountTransTo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountTransTo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Amount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Amount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Operator", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Operator", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Operator", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Operator", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Notes", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Notes", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Notes", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E458 RID: 58456 RVA: 0x00065430 File Offset: 0x00063630
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E459 RID: 58457 RVA: 0x008789E0 File Offset: 0x00876BE0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, AccountTransFrom, AccountTransTo, Amount, Date, Operator, Notes FROM dbo.FundTransfer"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E45A RID: 58458 RVA: 0x00878A40 File Offset: 0x00876C40
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.FundTransferDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E45B RID: 58459 RVA: 0x00878A88 File Offset: 0x00876C88
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.FundTransferDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim fundTransferDataTable As Inventory_DBDataSet.FundTransferDataTable = New Inventory_DBDataSet.FundTransferDataTable()
			Me.Adapter.Fill(fundTransferDataTable)
			Return fundTransferDataTable
		End Function

		' Token: 0x0600E45C RID: 58460 RVA: 0x00878AC4 File Offset: 0x00876CC4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.FundTransferDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E45D RID: 58461 RVA: 0x00878AE4 File Offset: 0x00876CE4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "FundTransfer")
		End Function

		' Token: 0x0600E45E RID: 58462 RVA: 0x00878B08 File Offset: 0x00876D08
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E45F RID: 58463 RVA: 0x00878B30 File Offset: 0x00876D30
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E460 RID: 58464 RVA: 0x00878B50 File Offset: 0x00876D50
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_AccountTransFrom As String, Original_AccountTransTo As String, Original_Amount As Decimal?, Original_Date As DateTime?, Original_Operator As String, Original_Notes As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Dim flag As Boolean = Original_AccountTransFrom = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_AccountTransFrom
			End If
			Dim flag2 As Boolean = Original_AccountTransTo = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_AccountTransTo
			End If
			Dim flag3 As Boolean = Original_Amount IsNot Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_Amount.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = Original_Date IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_Date.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_Operator = Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_Operator
			End If
			Dim flag6 As Boolean = Original_Notes = Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_Notes
			End If
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag7 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag7 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag8 As Boolean = state = ConnectionState.Closed
				If flag8 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E461 RID: 58465 RVA: 0x00878FA8 File Offset: 0x008771A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(Id As Integer, AccountTransFrom As String, AccountTransTo As String, Amount As Decimal?, _Date As DateTime?, _Operator As String, Notes As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = Id
			Dim flag As Boolean = AccountTransFrom = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = AccountTransFrom
			End If
			Dim flag2 As Boolean = AccountTransTo = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = AccountTransTo
			End If
			Dim flag3 As Boolean = Amount IsNot Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = Amount.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = _Date IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = _Date.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = _Operator = Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = _Operator
			End If
			Dim flag6 As Boolean = Notes = Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = Notes
			End If
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag7 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag7 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag8 As Boolean = state = ConnectionState.Closed
				If flag8 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E462 RID: 58466 RVA: 0x00879260 File Offset: 0x00877460
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Id As Integer, AccountTransFrom As String, AccountTransTo As String, Amount As Decimal?, _Date As DateTime?, _Operator As String, Notes As String, Original_Id As Integer, Original_AccountTransFrom As String, Original_AccountTransTo As String, Original_Amount As Decimal?, Original_Date As DateTime?, Original_Operator As String, Original_Notes As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = Id
			Dim flag As Boolean = AccountTransFrom = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = AccountTransFrom
			End If
			Dim flag2 As Boolean = AccountTransTo = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = AccountTransTo
			End If
			Dim flag3 As Boolean = Amount IsNot Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = Amount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag4 As Boolean = _Date IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = _Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = _Operator = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = _Operator
			End If
			Dim flag6 As Boolean = Notes = Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = Notes
			End If
			Me.Adapter.UpdateCommand.Parameters(7).Value = Original_Id
			Dim flag7 As Boolean = Original_AccountTransFrom = Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = 1
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = 0
				Me.Adapter.UpdateCommand.Parameters(9).Value = Original_AccountTransFrom
			End If
			Dim flag8 As Boolean = Original_AccountTransTo = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = 1
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = 0
				Me.Adapter.UpdateCommand.Parameters(11).Value = Original_AccountTransTo
			End If
			Dim flag9 As Boolean = Original_Amount IsNot Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = 0
				Me.Adapter.UpdateCommand.Parameters(13).Value = Original_Amount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = 1
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			End If
			Dim flag10 As Boolean = Original_Date IsNot Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = 0
				Me.Adapter.UpdateCommand.Parameters(15).Value = Original_Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = 1
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			End If
			Dim flag11 As Boolean = Original_Operator = Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = 1
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = 0
				Me.Adapter.UpdateCommand.Parameters(17).Value = Original_Operator
			End If
			Dim flag12 As Boolean = Original_Notes = Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(18).Value = 1
				Me.Adapter.UpdateCommand.Parameters(19).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(18).Value = 0
				Me.Adapter.UpdateCommand.Parameters(19).Value = Original_Notes
			End If
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag13 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag13 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag14 As Boolean = state = ConnectionState.Closed
				If flag14 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E463 RID: 58467 RVA: 0x008798DC File Offset: 0x00877ADC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(AccountTransFrom As String, AccountTransTo As String, Amount As Decimal?, _Date As DateTime?, _Operator As String, Notes As String, Original_Id As Integer, Original_AccountTransFrom As String, Original_AccountTransTo As String, Original_Amount As Decimal?, Original_Date As DateTime?, Original_Operator As String, Original_Notes As String) As Integer
			Return Me.Update(Original_Id, AccountTransFrom, AccountTransTo, Amount, _Date, _Operator, Notes, Original_Id, Original_AccountTransFrom, Original_AccountTransTo, Original_Amount, Original_Date, Original_Operator, Original_Notes)
		End Function

		' Token: 0x04005853 RID: 22611
		Private _connection As SqlConnection

		' Token: 0x04005854 RID: 22612
		Private _transaction As SqlTransaction

		' Token: 0x04005855 RID: 22613
		Private _commandCollection As SqlCommand()

		' Token: 0x04005856 RID: 22614
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
