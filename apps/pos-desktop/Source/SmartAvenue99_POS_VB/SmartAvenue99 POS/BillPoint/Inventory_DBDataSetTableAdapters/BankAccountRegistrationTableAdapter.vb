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
	' Token: 0x02000444 RID: 1092
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class BankAccountRegistrationTableAdapter
		Inherits Component

		' Token: 0x170057C1 RID: 22465
		' (get) Token: 0x0600E35C RID: 58204 RVA: 0x000650C3 File Offset: 0x000632C3
		' (set) Token: 0x0600E35D RID: 58205 RVA: 0x000650CD File Offset: 0x000632CD
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E35E RID: 58206 RVA: 0x000650D6 File Offset: 0x000632D6
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057C2 RID: 22466
		' (get) Token: 0x0600E35F RID: 58207 RVA: 0x008662D8 File Offset: 0x008644D8
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

		' Token: 0x170057C3 RID: 22467
		' (get) Token: 0x0600E360 RID: 58208 RVA: 0x00866308 File Offset: 0x00864508
		' (set) Token: 0x0600E361 RID: 58209 RVA: 0x00866338 File Offset: 0x00864538
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

		' Token: 0x170057C4 RID: 22468
		' (get) Token: 0x0600E362 RID: 58210 RVA: 0x008663FC File Offset: 0x008645FC
		' (set) Token: 0x0600E363 RID: 58211 RVA: 0x00866414 File Offset: 0x00864614
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

		' Token: 0x170057C5 RID: 22469
		' (get) Token: 0x0600E364 RID: 58212 RVA: 0x008664FC File Offset: 0x008646FC
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

		' Token: 0x170057C6 RID: 22470
		' (get) Token: 0x0600E365 RID: 58213 RVA: 0x0086652C File Offset: 0x0086472C
		' (set) Token: 0x0600E366 RID: 58214 RVA: 0x000650E8 File Offset: 0x000632E8
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

		' Token: 0x0600E367 RID: 58215 RVA: 0x00866544 File Offset: 0x00864744
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "BankAccountRegistration"
			dataTableMapping.ColumnMappings.Add("AccountNo", "AccountNo")
			dataTableMapping.ColumnMappings.Add("AccountName", "AccountName")
			dataTableMapping.ColumnMappings.Add("AccountType", "AccountType")
			dataTableMapping.ColumnMappings.Add("OpeningDate", "OpeningDate")
			dataTableMapping.ColumnMappings.Add("BalanceAmount", "BalanceAmount")
			dataTableMapping.ColumnMappings.Add("Active", "Active")
			dataTableMapping.ColumnMappings.Add("BranchID", "BranchID")
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[BankAccountRegistration] WHERE (([AccountNo] = @Original_AccountNo) AND ((@IsNull_AccountName = 1 AND [AccountName] IS NULL) OR ([AccountName] = @Original_AccountName)) AND ((@IsNull_AccountType = 1 AND [AccountType] IS NULL) OR ([AccountType] = @Original_AccountType)) AND ((@IsNull_OpeningDate = 1 AND [OpeningDate] IS NULL) OR ([OpeningDate] = @Original_OpeningDate)) AND ((@IsNull_BalanceAmount = 1 AND [BalanceAmount] IS NULL) OR ([BalanceAmount] = @Original_BalanceAmount)) AND ((@IsNull_Active = 1 AND [Active] IS NULL) OR ([Active] = @Original_Active)) AND ((@IsNull_BranchID = 1 AND [BranchID] IS NULL) OR ([BranchID] = @Original_BranchID)) AND ((@IsNull_Id = 1 AND [Id] IS NULL) OR ([Id] = @Original_Id)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AccountNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_AccountName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AccountName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_AccountType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AccountType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_OpeningDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OpeningDate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_OpeningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "OpeningDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_BalanceAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BalanceAmount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_BalanceAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "BalanceAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Active", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Active", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_BranchID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BranchID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_BranchID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BranchID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[BankAccountRegistration] ([AccountNo], [AccountName], [AccountType], [OpeningDate], [BalanceAmount], [Active], [BranchID], [Id]) VALUES (@AccountNo, @AccountName, @AccountType, @OpeningDate, @BalanceAmount, @Active, @BranchID, @Id);" & vbCrLf & "SELECT AccountNo, AccountName, AccountType, OpeningDate, BalanceAmount, Active, BranchID, Id FROM BankAccountRegistration WHERE (AccountNo = @AccountNo)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AccountNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AccountName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AccountType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@OpeningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "OpeningDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BalanceAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "BalanceAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Active", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BranchID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BranchID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[BankAccountRegistration] SET [AccountNo] = @AccountNo, [AccountName] = @AccountName, [AccountType] = @AccountType, [OpeningDate] = @OpeningDate, [BalanceAmount] = @BalanceAmount, [Active] = @Active, [BranchID] = @BranchID, [Id] = @Id WHERE (([AccountNo] = @Original_AccountNo) AND ((@IsNull_AccountName = 1 AND [AccountName] IS NULL) OR ([AccountName] = @Original_AccountName)) AND ((@IsNull_AccountType = 1 AND [AccountType] IS NULL) OR ([AccountType] = @Original_AccountType)) AND ((@IsNull_OpeningDate = 1 AND [OpeningDate] IS NULL) OR ([OpeningDate] = @Original_OpeningDate)) AND ((@IsNull_BalanceAmount = 1 AND [BalanceAmount] IS NULL) OR ([BalanceAmount] = @Original_BalanceAmount)) AND ((@IsNull_Active = 1 AND [Active] IS NULL) OR ([Active] = @Original_Active)) AND ((@IsNull_BranchID = 1 AND [BranchID] IS NULL) OR ([BranchID] = @Original_BranchID)) AND ((@IsNull_Id = 1 AND [Id] IS NULL) OR ([Id] = @Original_Id)));" & vbCrLf & "SELECT AccountNo, AccountName, AccountType, OpeningDate, BalanceAmount, Active, BranchID, Id FROM BankAccountRegistration WHERE (AccountNo = @AccountNo)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AccountNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AccountName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AccountType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@OpeningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "OpeningDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BalanceAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "BalanceAmount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Active", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BranchID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BranchID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AccountNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_AccountName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AccountName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_AccountType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AccountType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_OpeningDate", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "OpeningDate", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_OpeningDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "OpeningDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_BalanceAmount", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BalanceAmount", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_BalanceAmount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "BalanceAmount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Active", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Active", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Active", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_BranchID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BranchID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_BranchID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BranchID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E368 RID: 58216 RVA: 0x000650F2 File Offset: 0x000632F2
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E369 RID: 58217 RVA: 0x008672C4 File Offset: 0x008654C4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT AccountNo, AccountName, AccountType, OpeningDate, BalanceAmount, Active, BranchID, Id FROM dbo.BankAccountRegistration"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E36A RID: 58218 RVA: 0x00867324 File Offset: 0x00865524
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.BankAccountRegistrationDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E36B RID: 58219 RVA: 0x0086736C File Offset: 0x0086556C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.BankAccountRegistrationDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim bankAccountRegistrationDataTable As Inventory_DBDataSet.BankAccountRegistrationDataTable = New Inventory_DBDataSet.BankAccountRegistrationDataTable()
			Me.Adapter.Fill(bankAccountRegistrationDataTable)
			Return bankAccountRegistrationDataTable
		End Function

		' Token: 0x0600E36C RID: 58220 RVA: 0x008673A8 File Offset: 0x008655A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.BankAccountRegistrationDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E36D RID: 58221 RVA: 0x008673C8 File Offset: 0x008655C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "BankAccountRegistration")
		End Function

		' Token: 0x0600E36E RID: 58222 RVA: 0x008673EC File Offset: 0x008655EC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E36F RID: 58223 RVA: 0x00867414 File Offset: 0x00865614
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E370 RID: 58224 RVA: 0x00867434 File Offset: 0x00865634
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_AccountNo As String, Original_AccountName As String, Original_AccountType As String, Original_OpeningDate As DateTime?, Original_BalanceAmount As Decimal?, Original_Active As String, Original_BranchID As Integer?, Original_Id As Integer?) As Integer
			Dim flag As Boolean = Original_AccountNo = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_AccountNo")
			End If
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_AccountNo
			Dim flag2 As Boolean = Original_AccountName = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_AccountName
			End If
			Dim flag3 As Boolean = Original_AccountType = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_AccountType
			End If
			Dim flag4 As Boolean = Original_OpeningDate IsNot Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_OpeningDate.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = Original_BalanceAmount IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_BalanceAmount.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_Active = Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_Active
			End If
			Dim flag7 As Boolean = Original_BranchID IsNot Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_BranchID.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_Id IsNot Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(13).Value = 0
				Me.Adapter.DeleteCommand.Parameters(14).Value = Original_Id.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(13).Value = 1
				Me.Adapter.DeleteCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag9 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag9 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag10 As Boolean = state = ConnectionState.Closed
				If flag10 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E371 RID: 58225 RVA: 0x00867950 File Offset: 0x00865B50
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(AccountNo As String, AccountName As String, AccountType As String, OpeningDate As DateTime?, BalanceAmount As Decimal?, Active As String, BranchID As Integer?, Id As Integer?) As Integer
			Dim flag As Boolean = AccountNo = Nothing
			If flag Then
				Throw New ArgumentNullException("AccountNo")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = AccountNo
			Dim flag2 As Boolean = AccountName = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = AccountName
			End If
			Dim flag3 As Boolean = AccountType = Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = AccountType
			End If
			Dim flag4 As Boolean = OpeningDate IsNot Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = OpeningDate.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = BalanceAmount IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = BalanceAmount.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Active = Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = Active
			End If
			Dim flag7 As Boolean = BranchID IsNot Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = BranchID.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Id IsNot Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = Id.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
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

		' Token: 0x0600E372 RID: 58226 RVA: 0x00867C84 File Offset: 0x00865E84
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(AccountNo As String, AccountName As String, AccountType As String, OpeningDate As DateTime?, BalanceAmount As Decimal?, Active As String, BranchID As Integer?, Id As Integer?, Original_AccountNo As String, Original_AccountName As String, Original_AccountType As String, Original_OpeningDate As DateTime?, Original_BalanceAmount As Decimal?, Original_Active As String, Original_BranchID As Integer?, Original_Id As Integer?) As Integer
			Dim flag As Boolean = AccountNo = Nothing
			If flag Then
				Throw New ArgumentNullException("AccountNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = AccountNo
			Dim flag2 As Boolean = AccountName = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = AccountName
			End If
			Dim flag3 As Boolean = AccountType = Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = AccountType
			End If
			Dim flag4 As Boolean = OpeningDate IsNot Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = OpeningDate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			End If
			Dim flag5 As Boolean = BalanceAmount IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = BalanceAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Active = Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = Active
			End If
			Dim flag7 As Boolean = BranchID IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = BranchID.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Id IsNot Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = Id.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			End If
			Dim flag9 As Boolean = Original_AccountNo = Nothing
			If flag9 Then
				Throw New ArgumentNullException("Original_AccountNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(8).Value = Original_AccountNo
			Dim flag10 As Boolean = Original_AccountName = Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = 1
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = 0
				Me.Adapter.UpdateCommand.Parameters(10).Value = Original_AccountName
			End If
			Dim flag11 As Boolean = Original_AccountType = Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = 1
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = 0
				Me.Adapter.UpdateCommand.Parameters(12).Value = Original_AccountType
			End If
			Dim flag12 As Boolean = Original_OpeningDate IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = 0
				Me.Adapter.UpdateCommand.Parameters(14).Value = Original_OpeningDate.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = 1
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			End If
			Dim flag13 As Boolean = Original_BalanceAmount IsNot Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = 0
				Me.Adapter.UpdateCommand.Parameters(16).Value = Original_BalanceAmount.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = 1
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag14 As Boolean = Original_Active = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_Active
			End If
			Dim flag15 As Boolean = Original_BranchID IsNot Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = 0
				Me.Adapter.UpdateCommand.Parameters(20).Value = Original_BranchID.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(19).Value = 1
				Me.Adapter.UpdateCommand.Parameters(20).Value = DBNull.Value
			End If
			Dim flag16 As Boolean = Original_Id IsNot Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(21).Value = 0
				Me.Adapter.UpdateCommand.Parameters(22).Value = Original_Id.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(21).Value = 1
				Me.Adapter.UpdateCommand.Parameters(22).Value = DBNull.Value
			End If
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag17 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag17 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag18 As Boolean = state = ConnectionState.Closed
				If flag18 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E373 RID: 58227 RVA: 0x0086843C File Offset: 0x0086663C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(AccountName As String, AccountType As String, OpeningDate As DateTime?, BalanceAmount As Decimal?, Active As String, BranchID As Integer?, Id As Integer?, Original_AccountNo As String, Original_AccountName As String, Original_AccountType As String, Original_OpeningDate As DateTime?, Original_BalanceAmount As Decimal?, Original_Active As String, Original_BranchID As Integer?, Original_Id As Integer?) As Integer
			Return Me.Update(Original_AccountNo, AccountName, AccountType, OpeningDate, BalanceAmount, Active, BranchID, Id, Original_AccountNo, Original_AccountName, Original_AccountType, Original_OpeningDate, Original_BalanceAmount, Original_Active, Original_BranchID, Original_Id)
		End Function

		' Token: 0x04005821 RID: 22561
		Private _connection As SqlConnection

		' Token: 0x04005822 RID: 22562
		Private _transaction As SqlTransaction

		' Token: 0x04005823 RID: 22563
		Private _commandCollection As SqlCommand()

		' Token: 0x04005824 RID: 22564
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
