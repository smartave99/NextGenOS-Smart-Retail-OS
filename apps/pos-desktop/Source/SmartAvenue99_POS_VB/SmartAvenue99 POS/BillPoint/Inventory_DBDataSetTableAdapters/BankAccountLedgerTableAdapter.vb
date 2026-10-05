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
	' Token: 0x02000443 RID: 1091
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class BankAccountLedgerTableAdapter
		Inherits Component

		' Token: 0x170057BB RID: 22459
		' (get) Token: 0x0600E344 RID: 58180 RVA: 0x00065070 File Offset: 0x00063270
		' (set) Token: 0x0600E345 RID: 58181 RVA: 0x0006507A File Offset: 0x0006327A
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E346 RID: 58182 RVA: 0x00065083 File Offset: 0x00063283
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057BC RID: 22460
		' (get) Token: 0x0600E347 RID: 58183 RVA: 0x00864580 File Offset: 0x00862780
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

		' Token: 0x170057BD RID: 22461
		' (get) Token: 0x0600E348 RID: 58184 RVA: 0x008645B0 File Offset: 0x008627B0
		' (set) Token: 0x0600E349 RID: 58185 RVA: 0x008645E0 File Offset: 0x008627E0
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

		' Token: 0x170057BE RID: 22462
		' (get) Token: 0x0600E34A RID: 58186 RVA: 0x008646A4 File Offset: 0x008628A4
		' (set) Token: 0x0600E34B RID: 58187 RVA: 0x008646BC File Offset: 0x008628BC
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

		' Token: 0x170057BF RID: 22463
		' (get) Token: 0x0600E34C RID: 58188 RVA: 0x008647A4 File Offset: 0x008629A4
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

		' Token: 0x170057C0 RID: 22464
		' (get) Token: 0x0600E34D RID: 58189 RVA: 0x008647D4 File Offset: 0x008629D4
		' (set) Token: 0x0600E34E RID: 58190 RVA: 0x00065095 File Offset: 0x00063295
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

		' Token: 0x0600E34F RID: 58191 RVA: 0x008647EC File Offset: 0x008629EC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "BankAccountLedger"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("AccNo", "AccNo")
			dataTableMapping.ColumnMappings.Add("LedgerNo", "LedgerNo")
			dataTableMapping.ColumnMappings.Add("Label", "Label")
			dataTableMapping.ColumnMappings.Add("Debit", "Debit")
			dataTableMapping.ColumnMappings.Add("Credit", "Credit")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[BankAccountLedger] WHERE (([Id] = @Original_Id) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_AccNo = 1 AND [AccNo] IS NULL) OR ([AccNo] = @Original_AccNo)) AND ((@IsNull_LedgerNo = 1 AND [LedgerNo] IS NULL) OR ([LedgerNo] = @Original_LedgerNo)) AND ((@IsNull_Label = 1 AND [Label] IS NULL) OR ([Label] = @Original_Label)) AND ((@IsNull_Debit = 1 AND [Debit] IS NULL) OR ([Debit] = @Original_Debit)) AND ((@IsNull_Credit = 1 AND [Credit] IS NULL) OR ([Credit] = @Original_Credit)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_AccNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AccNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_LedgerNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_LedgerNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Label", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Label", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Debit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Debit", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Debit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Debit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Credit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Credit", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Credit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Credit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[BankAccountLedger] ([Date], [AccNo], [LedgerNo], [Label], [Debit], [Credit]) VALUES (@Date, @AccNo, @LedgerNo, @Label, @Debit, @Credit);" & vbCrLf & "SELECT Id, Date, AccNo, LedgerNo, Label, Debit, Credit FROM BankAccountLedger WHERE (Id = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AccNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@LedgerNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Label", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Debit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Debit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Credit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Credit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[BankAccountLedger] SET [Date] = @Date, [AccNo] = @AccNo, [LedgerNo] = @LedgerNo, [Label] = @Label, [Debit] = @Debit, [Credit] = @Credit WHERE (([Id] = @Original_Id) AND ((@IsNull_Date = 1 AND [Date] IS NULL) OR ([Date] = @Original_Date)) AND ((@IsNull_AccNo = 1 AND [AccNo] IS NULL) OR ([AccNo] = @Original_AccNo)) AND ((@IsNull_LedgerNo = 1 AND [LedgerNo] IS NULL) OR ([LedgerNo] = @Original_LedgerNo)) AND ((@IsNull_Label = 1 AND [Label] IS NULL) OR ([Label] = @Original_Label)) AND ((@IsNull_Debit = 1 AND [Debit] IS NULL) OR ([Debit] = @Original_Debit)) AND ((@IsNull_Credit = 1 AND [Credit] IS NULL) OR ([Credit] = @Original_Credit)));" & vbCrLf & "SELECT Id, Date, AccNo, LedgerNo, Label, Debit, Credit FROM BankAccountLedger WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AccNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@LedgerNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Label", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Debit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Debit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Credit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Credit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Date", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_AccNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AccNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_LedgerNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_LedgerNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Label", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Label", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Debit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Debit", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Debit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Debit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Credit", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Credit", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Credit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Credit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E350 RID: 58192 RVA: 0x0006509F File Offset: 0x0006329F
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E351 RID: 58193 RVA: 0x00865394 File Offset: 0x00863594
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, Date, AccNo, LedgerNo, Label, Debit, Credit FROM dbo.BankAccountLedger"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E352 RID: 58194 RVA: 0x008653F4 File Offset: 0x008635F4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.BankAccountLedgerDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E353 RID: 58195 RVA: 0x0086543C File Offset: 0x0086363C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.BankAccountLedgerDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim bankAccountLedgerDataTable As Inventory_DBDataSet.BankAccountLedgerDataTable = New Inventory_DBDataSet.BankAccountLedgerDataTable()
			Me.Adapter.Fill(bankAccountLedgerDataTable)
			Return bankAccountLedgerDataTable
		End Function

		' Token: 0x0600E354 RID: 58196 RVA: 0x00865478 File Offset: 0x00863678
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.BankAccountLedgerDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E355 RID: 58197 RVA: 0x00865498 File Offset: 0x00863698
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "BankAccountLedger")
		End Function

		' Token: 0x0600E356 RID: 58198 RVA: 0x008654BC File Offset: 0x008636BC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E357 RID: 58199 RVA: 0x008654E4 File Offset: 0x008636E4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E358 RID: 58200 RVA: 0x00865504 File Offset: 0x00863704
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_Date As DateTime?, Original_AccNo As String, Original_LedgerNo As String, Original_Label As String, Original_Debit As Decimal?, Original_Credit As Decimal?) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Dim flag As Boolean = Original_Date IsNot Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Date.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			End If
			Dim flag2 As Boolean = Original_AccNo = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_AccNo
			End If
			Dim flag3 As Boolean = Original_LedgerNo = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_LedgerNo
			End If
			Dim flag4 As Boolean = Original_Label = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_Label
			End If
			Dim flag5 As Boolean = Original_Debit IsNot Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_Debit.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Original_Credit IsNot Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_Credit.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
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

		' Token: 0x0600E359 RID: 58201 RVA: 0x0086596C File Offset: 0x00863B6C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(_Date As DateTime?, AccNo As String, LedgerNo As String, Label As String, Debit As Decimal?, Credit As Decimal?) As Integer
			Dim flag As Boolean = _Date IsNot Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(0).Value = _Date.Value
			Else
				Me.Adapter.InsertCommand.Parameters(0).Value = DBNull.Value
			End If
			Dim flag2 As Boolean = AccNo = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = AccNo
			End If
			Dim flag3 As Boolean = LedgerNo = Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = LedgerNo
			End If
			Dim flag4 As Boolean = Label = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = Label
			End If
			Dim flag5 As Boolean = Debit IsNot Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = Debit.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Credit IsNot Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = Credit.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
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

		' Token: 0x0600E35A RID: 58202 RVA: 0x00865C10 File Offset: 0x00863E10
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(_Date As DateTime?, AccNo As String, LedgerNo As String, Label As String, Debit As Decimal?, Credit As Decimal?, Original_Id As Integer, Original_Date As DateTime?, Original_AccNo As String, Original_LedgerNo As String, Original_Label As String, Original_Debit As Decimal?, Original_Credit As Decimal?, Id As Integer) As Integer
			Dim flag As Boolean = _Date IsNot Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(0).Value = _Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(0).Value = DBNull.Value
			End If
			Dim flag2 As Boolean = AccNo = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = AccNo
			End If
			Dim flag3 As Boolean = LedgerNo = Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = LedgerNo
			End If
			Dim flag4 As Boolean = Label = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = Label
			End If
			Dim flag5 As Boolean = Debit IsNot Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = Debit.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			End If
			Dim flag6 As Boolean = Credit IsNot Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = Credit.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(6).Value = Original_Id
			Dim flag7 As Boolean = Original_Date IsNot Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = 0
				Me.Adapter.UpdateCommand.Parameters(8).Value = Original_Date.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = 1
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			End If
			Dim flag8 As Boolean = Original_AccNo = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = 1
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = 0
				Me.Adapter.UpdateCommand.Parameters(10).Value = Original_AccNo
			End If
			Dim flag9 As Boolean = Original_LedgerNo = Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = 1
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = 0
				Me.Adapter.UpdateCommand.Parameters(12).Value = Original_LedgerNo
			End If
			Dim flag10 As Boolean = Original_Label = Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = 1
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = 0
				Me.Adapter.UpdateCommand.Parameters(14).Value = Original_Label
			End If
			Dim flag11 As Boolean = Original_Debit IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = 0
				Me.Adapter.UpdateCommand.Parameters(16).Value = Original_Debit.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = 1
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			End If
			Dim flag12 As Boolean = Original_Credit IsNot Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_Credit.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(19).Value = Id
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

		' Token: 0x0600E35B RID: 58203 RVA: 0x008662A4 File Offset: 0x008644A4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(_Date As DateTime?, AccNo As String, LedgerNo As String, Label As String, Debit As Decimal?, Credit As Decimal?, Original_Id As Integer, Original_Date As DateTime?, Original_AccNo As String, Original_LedgerNo As String, Original_Label As String, Original_Debit As Decimal?, Original_Credit As Decimal?) As Integer
			Return Me.Update(_Date, AccNo, LedgerNo, Label, Debit, Credit, Original_Id, Original_Date, Original_AccNo, Original_LedgerNo, Original_Label, Original_Debit, Original_Credit, Original_Id)
		End Function

		' Token: 0x0400581C RID: 22556
		Private _connection As SqlConnection

		' Token: 0x0400581D RID: 22557
		Private _transaction As SqlTransaction

		' Token: 0x0400581E RID: 22558
		Private _commandCollection As SqlCommand()

		' Token: 0x0400581F RID: 22559
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
