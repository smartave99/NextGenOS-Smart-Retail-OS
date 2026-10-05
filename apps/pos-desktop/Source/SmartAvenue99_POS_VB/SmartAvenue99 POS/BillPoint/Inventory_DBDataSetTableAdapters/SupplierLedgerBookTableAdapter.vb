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
	' Token: 0x0200046D RID: 1133
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class SupplierLedgerBookTableAdapter
		Inherits Component

		' Token: 0x170058B7 RID: 22711
		' (get) Token: 0x0600E734 RID: 59188 RVA: 0x00065E0E File Offset: 0x0006400E
		' (set) Token: 0x0600E735 RID: 59189 RVA: 0x00065E18 File Offset: 0x00064018
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E736 RID: 59190 RVA: 0x00065E21 File Offset: 0x00064021
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170058B8 RID: 22712
		' (get) Token: 0x0600E737 RID: 59191 RVA: 0x008C188C File Offset: 0x008BFA8C
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

		' Token: 0x170058B9 RID: 22713
		' (get) Token: 0x0600E738 RID: 59192 RVA: 0x008C18BC File Offset: 0x008BFABC
		' (set) Token: 0x0600E739 RID: 59193 RVA: 0x008C18EC File Offset: 0x008BFAEC
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

		' Token: 0x170058BA RID: 22714
		' (get) Token: 0x0600E73A RID: 59194 RVA: 0x008C19B0 File Offset: 0x008BFBB0
		' (set) Token: 0x0600E73B RID: 59195 RVA: 0x008C19C8 File Offset: 0x008BFBC8
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

		' Token: 0x170058BB RID: 22715
		' (get) Token: 0x0600E73C RID: 59196 RVA: 0x008C1AB0 File Offset: 0x008BFCB0
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

		' Token: 0x170058BC RID: 22716
		' (get) Token: 0x0600E73D RID: 59197 RVA: 0x008C1AE0 File Offset: 0x008BFCE0
		' (set) Token: 0x0600E73E RID: 59198 RVA: 0x00065E33 File Offset: 0x00064033
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

		' Token: 0x0600E73F RID: 59199 RVA: 0x008C1AF8 File Offset: 0x008BFCF8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "SupplierLedgerBook"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("Name", "Name")
			dataTableMapping.ColumnMappings.Add("LedgerNo", "LedgerNo")
			dataTableMapping.ColumnMappings.Add("Label", "Label")
			dataTableMapping.ColumnMappings.Add("Debit", "Debit")
			dataTableMapping.ColumnMappings.Add("Credit", "Credit")
			dataTableMapping.ColumnMappings.Add("PartyID", "PartyID")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[SupplierLedgerBook] WHERE (([Id] = @Original_Id) AND ([Date] = @Original_Date) AND ([Name] = @Original_Name) AND ([LedgerNo] = @Original_LedgerNo) AND ([Label] = @Original_Label) AND ([Debit] = @Original_Debit) AND ([Credit] = @Original_Credit) AND ((@IsNull_PartyID = 1 AND [PartyID] IS NULL) OR ([PartyID] = @Original_PartyID)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_LedgerNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Label", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Debit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Debit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Credit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Credit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PartyID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PartyID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PartyID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PartyID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[SupplierLedgerBook] ([Date], [Name], [LedgerNo], [Label], [Debit], [Credit], [PartyID]) VALUES (@Date, @Name, @LedgerNo, @Label, @Debit, @Credit, @PartyID);" & vbCrLf & "SELECT Id, Date, Name, LedgerNo, Label, Debit, Credit, PartyID FROM SupplierLedgerBook WHERE (Id = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@LedgerNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Label", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Debit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Debit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Credit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Credit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PartyID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PartyID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[SupplierLedgerBook] SET [Date] = @Date, [Name] = @Name, [LedgerNo] = @LedgerNo, [Label] = @Label, [Debit] = @Debit, [Credit] = @Credit, [PartyID] = @PartyID WHERE (([Id] = @Original_Id) AND ([Date] = @Original_Date) AND ([Name] = @Original_Name) AND ([LedgerNo] = @Original_LedgerNo) AND ([Label] = @Original_Label) AND ([Debit] = @Original_Debit) AND ([Credit] = @Original_Credit) AND ((@IsNull_PartyID = 1 AND [PartyID] IS NULL) OR ([PartyID] = @Original_PartyID)));" & vbCrLf & "SELECT Id, Date, Name, LedgerNo, Label, Debit, Credit, PartyID FROM SupplierLedgerBook WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@LedgerNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Label", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Debit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Debit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Credit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Credit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PartyID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PartyID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_LedgerNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "LedgerNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Label", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Label", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Debit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Debit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Credit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Credit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PartyID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PartyID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PartyID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PartyID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E740 RID: 59200 RVA: 0x00065E3D File Offset: 0x0006403D
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E741 RID: 59201 RVA: 0x008C253C File Offset: 0x008C073C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, Date, Name, LedgerNo, Label, Debit, Credit, PartyID FROM dbo.SupplierLedgerBook"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E742 RID: 59202 RVA: 0x008C259C File Offset: 0x008C079C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.SupplierLedgerBookDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E743 RID: 59203 RVA: 0x008C25E4 File Offset: 0x008C07E4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.SupplierLedgerBookDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim supplierLedgerBookDataTable As Inventory_DBDataSet.SupplierLedgerBookDataTable = New Inventory_DBDataSet.SupplierLedgerBookDataTable()
			Me.Adapter.Fill(supplierLedgerBookDataTable)
			Return supplierLedgerBookDataTable
		End Function

		' Token: 0x0600E744 RID: 59204 RVA: 0x008C2620 File Offset: 0x008C0820
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.SupplierLedgerBookDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E745 RID: 59205 RVA: 0x008C2640 File Offset: 0x008C0840
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "SupplierLedgerBook")
		End Function

		' Token: 0x0600E746 RID: 59206 RVA: 0x008C2664 File Offset: 0x008C0864
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E747 RID: 59207 RVA: 0x008C268C File Offset: 0x008C088C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E748 RID: 59208 RVA: 0x008C26AC File Offset: 0x008C08AC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_Date As DateTime, Original_Name As String, Original_LedgerNo As String, Original_Label As String, Original_Debit As Decimal, Original_Credit As Decimal, Original_PartyID As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_Date
			Dim flag As Boolean = Original_Name = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_Name")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Name
			Dim flag2 As Boolean = Original_LedgerNo = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_LedgerNo")
			End If
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_LedgerNo
			Dim flag3 As Boolean = Original_Label = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_Label")
			End If
			Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Label
			Me.Adapter.DeleteCommand.Parameters(5).Value = Original_Debit
			Me.Adapter.DeleteCommand.Parameters(6).Value = Original_Credit
			Dim flag4 As Boolean = Original_PartyID = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_PartyID
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

		' Token: 0x0600E749 RID: 59209 RVA: 0x008C2914 File Offset: 0x008C0B14
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(_Date As DateTime, Name As String, LedgerNo As String, Label As String, Debit As Decimal, Credit As Decimal, PartyID As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = _Date
			Dim flag As Boolean = Name = Nothing
			If flag Then
				Throw New ArgumentNullException("Name")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = Name
			Dim flag2 As Boolean = LedgerNo = Nothing
			If flag2 Then
				Throw New ArgumentNullException("LedgerNo")
			End If
			Me.Adapter.InsertCommand.Parameters(2).Value = LedgerNo
			Dim flag3 As Boolean = Label = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Label")
			End If
			Me.Adapter.InsertCommand.Parameters(3).Value = Label
			Me.Adapter.InsertCommand.Parameters(4).Value = Debit
			Me.Adapter.InsertCommand.Parameters(5).Value = Credit
			Dim flag4 As Boolean = PartyID = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = PartyID
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

		' Token: 0x0600E74A RID: 59210 RVA: 0x008C2B14 File Offset: 0x008C0D14
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(_Date As DateTime, Name As String, LedgerNo As String, Label As String, Debit As Decimal, Credit As Decimal, PartyID As String, Original_Id As Integer, Original_Date As DateTime, Original_Name As String, Original_LedgerNo As String, Original_Label As String, Original_Debit As Decimal, Original_Credit As Decimal, Original_PartyID As String, Id As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = _Date
			Dim flag As Boolean = Name = Nothing
			If flag Then
				Throw New ArgumentNullException("Name")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = Name
			Dim flag2 As Boolean = LedgerNo = Nothing
			If flag2 Then
				Throw New ArgumentNullException("LedgerNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(2).Value = LedgerNo
			Dim flag3 As Boolean = Label = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Label")
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = Label
			Me.Adapter.UpdateCommand.Parameters(4).Value = Debit
			Me.Adapter.UpdateCommand.Parameters(5).Value = Credit
			Dim flag4 As Boolean = PartyID = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = PartyID
			End If
			Me.Adapter.UpdateCommand.Parameters(7).Value = Original_Id
			Me.Adapter.UpdateCommand.Parameters(8).Value = Original_Date
			Dim flag5 As Boolean = Original_Name = Nothing
			If flag5 Then
				Throw New ArgumentNullException("Original_Name")
			End If
			Me.Adapter.UpdateCommand.Parameters(9).Value = Original_Name
			Dim flag6 As Boolean = Original_LedgerNo = Nothing
			If flag6 Then
				Throw New ArgumentNullException("Original_LedgerNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(10).Value = Original_LedgerNo
			Dim flag7 As Boolean = Original_Label = Nothing
			If flag7 Then
				Throw New ArgumentNullException("Original_Label")
			End If
			Me.Adapter.UpdateCommand.Parameters(11).Value = Original_Label
			Me.Adapter.UpdateCommand.Parameters(12).Value = Original_Debit
			Me.Adapter.UpdateCommand.Parameters(13).Value = Original_Credit
			Dim flag8 As Boolean = Original_PartyID = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = 1
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = 0
				Me.Adapter.UpdateCommand.Parameters(15).Value = Original_PartyID
			End If
			Me.Adapter.UpdateCommand.Parameters(16).Value = Id
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

		' Token: 0x0600E74B RID: 59211 RVA: 0x008C2F00 File Offset: 0x008C1100
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(_Date As DateTime, Name As String, LedgerNo As String, Label As String, Debit As Decimal, Credit As Decimal, PartyID As String, Original_Id As Integer, Original_Date As DateTime, Original_Name As String, Original_LedgerNo As String, Original_Label As String, Original_Debit As Decimal, Original_Credit As Decimal, Original_PartyID As String) As Integer
			Return Me.Update(_Date, Name, LedgerNo, Label, Debit, Credit, PartyID, Original_Id, Original_Date, Original_Name, Original_LedgerNo, Original_Label, Original_Debit, Original_Credit, Original_PartyID, Original_Id)
		End Function

		' Token: 0x040058EE RID: 22766
		Private _connection As SqlConnection

		' Token: 0x040058EF RID: 22767
		Private _transaction As SqlTransaction

		' Token: 0x040058F0 RID: 22768
		Private _commandCollection As SqlCommand()

		' Token: 0x040058F1 RID: 22769
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
