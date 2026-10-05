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
	' Token: 0x02000442 RID: 1090
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class BankTableAdapter
		Inherits Component

		' Token: 0x170057B5 RID: 22453
		' (get) Token: 0x0600E32C RID: 58156 RVA: 0x0006501D File Offset: 0x0006321D
		' (set) Token: 0x0600E32D RID: 58157 RVA: 0x00065027 File Offset: 0x00063227
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E32E RID: 58158 RVA: 0x00065030 File Offset: 0x00063230
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057B6 RID: 22454
		' (get) Token: 0x0600E32F RID: 58159 RVA: 0x00863C6C File Offset: 0x00861E6C
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

		' Token: 0x170057B7 RID: 22455
		' (get) Token: 0x0600E330 RID: 58160 RVA: 0x00863C9C File Offset: 0x00861E9C
		' (set) Token: 0x0600E331 RID: 58161 RVA: 0x00863CCC File Offset: 0x00861ECC
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

		' Token: 0x170057B8 RID: 22456
		' (get) Token: 0x0600E332 RID: 58162 RVA: 0x00863D90 File Offset: 0x00861F90
		' (set) Token: 0x0600E333 RID: 58163 RVA: 0x00863DA8 File Offset: 0x00861FA8
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

		' Token: 0x170057B9 RID: 22457
		' (get) Token: 0x0600E334 RID: 58164 RVA: 0x00863E90 File Offset: 0x00862090
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

		' Token: 0x170057BA RID: 22458
		' (get) Token: 0x0600E335 RID: 58165 RVA: 0x00863EC0 File Offset: 0x008620C0
		' (set) Token: 0x0600E336 RID: 58166 RVA: 0x00065042 File Offset: 0x00063242
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

		' Token: 0x0600E337 RID: 58167 RVA: 0x00863ED8 File Offset: 0x008620D8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Bank"
			dataTableMapping.ColumnMappings.Add("BankName", "BankName")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Bank] WHERE (([BankName] = @Original_BankName))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_BankName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BankName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Bank] ([BankName]) VALUES (@BankName);" & vbCrLf & "SELECT BankName FROM Bank WHERE (BankName = @BankName)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BankName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BankName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Bank] SET [BankName] = @BankName WHERE (([BankName] = @Original_BankName));" & vbCrLf & "SELECT BankName FROM Bank WHERE (BankName = @BankName)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BankName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BankName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_BankName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BankName", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E338 RID: 58168 RVA: 0x0006504C File Offset: 0x0006324C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E339 RID: 58169 RVA: 0x0086412C File Offset: 0x0086232C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT BankName FROM dbo.Bank"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E33A RID: 58170 RVA: 0x0086418C File Offset: 0x0086238C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.BankDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E33B RID: 58171 RVA: 0x008641D4 File Offset: 0x008623D4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.BankDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim bankDataTable As Inventory_DBDataSet.BankDataTable = New Inventory_DBDataSet.BankDataTable()
			Me.Adapter.Fill(bankDataTable)
			Return bankDataTable
		End Function

		' Token: 0x0600E33C RID: 58172 RVA: 0x00864210 File Offset: 0x00862410
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.BankDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E33D RID: 58173 RVA: 0x00864230 File Offset: 0x00862430
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Bank")
		End Function

		' Token: 0x0600E33E RID: 58174 RVA: 0x00864254 File Offset: 0x00862454
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E33F RID: 58175 RVA: 0x0086427C File Offset: 0x0086247C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E340 RID: 58176 RVA: 0x0086429C File Offset: 0x0086249C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_BankName As String) As Integer
			Dim flag As Boolean = Original_BankName = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_BankName")
			End If
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_BankName
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

		' Token: 0x0600E341 RID: 58177 RVA: 0x00864378 File Offset: 0x00862578
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(BankName As String) As Integer
			Dim flag As Boolean = BankName = Nothing
			If flag Then
				Throw New ArgumentNullException("BankName")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = BankName
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag2 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag2 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag3 As Boolean = state = ConnectionState.Closed
				If flag3 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E342 RID: 58178 RVA: 0x00864454 File Offset: 0x00862654
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(BankName As String, Original_BankName As String) As Integer
			Dim flag As Boolean = BankName = Nothing
			If flag Then
				Throw New ArgumentNullException("BankName")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = BankName
			Dim flag2 As Boolean = Original_BankName = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_BankName")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = Original_BankName
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag3 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag3 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag4 As Boolean = state = ConnectionState.Closed
				If flag4 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E343 RID: 58179 RVA: 0x00864564 File Offset: 0x00862764
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Original_BankName As String) As Integer
			Return Me.Update(Original_BankName, Original_BankName)
		End Function

		' Token: 0x04005817 RID: 22551
		Private _connection As SqlConnection

		' Token: 0x04005818 RID: 22552
		Private _transaction As SqlTransaction

		' Token: 0x04005819 RID: 22553
		Private _commandCollection As SqlCommand()

		' Token: 0x0400581A RID: 22554
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
