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
	' Token: 0x02000448 RID: 1096
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Company_ContactsTableAdapter
		Inherits Component

		' Token: 0x170057D9 RID: 22489
		' (get) Token: 0x0600E3BC RID: 58300 RVA: 0x0006520F File Offset: 0x0006340F
		' (set) Token: 0x0600E3BD RID: 58301 RVA: 0x00065219 File Offset: 0x00063419
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E3BE RID: 58302 RVA: 0x00065222 File Offset: 0x00063422
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057DA RID: 22490
		' (get) Token: 0x0600E3BF RID: 58303 RVA: 0x0086CAA8 File Offset: 0x0086ACA8
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

		' Token: 0x170057DB RID: 22491
		' (get) Token: 0x0600E3C0 RID: 58304 RVA: 0x0086CAD8 File Offset: 0x0086ACD8
		' (set) Token: 0x0600E3C1 RID: 58305 RVA: 0x0086CB08 File Offset: 0x0086AD08
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

		' Token: 0x170057DC RID: 22492
		' (get) Token: 0x0600E3C2 RID: 58306 RVA: 0x0086CBCC File Offset: 0x0086ADCC
		' (set) Token: 0x0600E3C3 RID: 58307 RVA: 0x0086CBE4 File Offset: 0x0086ADE4
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

		' Token: 0x170057DD RID: 22493
		' (get) Token: 0x0600E3C4 RID: 58308 RVA: 0x0086CCCC File Offset: 0x0086AECC
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

		' Token: 0x170057DE RID: 22494
		' (get) Token: 0x0600E3C5 RID: 58309 RVA: 0x0086CCFC File Offset: 0x0086AEFC
		' (set) Token: 0x0600E3C6 RID: 58310 RVA: 0x00065234 File Offset: 0x00063434
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

		' Token: 0x0600E3C7 RID: 58311 RVA: 0x0086CD14 File Offset: 0x0086AF14
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Company_Contacts"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("ContactPerson", "ContactPerson")
			dataTableMapping.ColumnMappings.Add("ContactNo", "ContactNo")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Company_Contacts] WHERE (([Id] = @Original_Id) AND ([ContactPerson] = @Original_ContactPerson) AND ([ContactNo] = @Original_ContactNo))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ContactPerson", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactPerson", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Company_Contacts] ([ContactPerson], [ContactNo]) VALUES (@ContactPerson, @ContactNo);" & vbCrLf & "SELECT Id, ContactPerson, ContactNo FROM Company_Contacts WHERE (Id = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ContactPerson", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactPerson", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Company_Contacts] SET [ContactPerson] = @ContactPerson, [ContactNo] = @ContactNo WHERE (([Id] = @Original_Id) AND ([ContactPerson] = @Original_ContactPerson) AND ([ContactNo] = @Original_ContactNo));" & vbCrLf & "SELECT Id, ContactPerson, ContactNo FROM Company_Contacts WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ContactPerson", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactPerson", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ContactPerson", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactPerson", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E3C8 RID: 58312 RVA: 0x0006523E File Offset: 0x0006343E
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E3C9 RID: 58313 RVA: 0x0086D158 File Offset: 0x0086B358
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, ContactPerson, ContactNo FROM dbo.Company_Contacts"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E3CA RID: 58314 RVA: 0x0086D1B8 File Offset: 0x0086B3B8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Company_ContactsDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E3CB RID: 58315 RVA: 0x0086D200 File Offset: 0x0086B400
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Company_ContactsDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim company_ContactsDataTable As Inventory_DBDataSet.Company_ContactsDataTable = New Inventory_DBDataSet.Company_ContactsDataTable()
			Me.Adapter.Fill(company_ContactsDataTable)
			Return company_ContactsDataTable
		End Function

		' Token: 0x0600E3CC RID: 58316 RVA: 0x0086D23C File Offset: 0x0086B43C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Company_ContactsDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E3CD RID: 58317 RVA: 0x0086D25C File Offset: 0x0086B45C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Company_Contacts")
		End Function

		' Token: 0x0600E3CE RID: 58318 RVA: 0x0086D280 File Offset: 0x0086B480
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E3CF RID: 58319 RVA: 0x0086D2A8 File Offset: 0x0086B4A8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E3D0 RID: 58320 RVA: 0x0086D2C8 File Offset: 0x0086B4C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_ContactPerson As String, Original_ContactNo As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Dim flag As Boolean = Original_ContactPerson = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_ContactPerson")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_ContactPerson
			Dim flag2 As Boolean = Original_ContactNo = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_ContactNo")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_ContactNo
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag3 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag3 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag4 As Boolean = state = ConnectionState.Closed
				If flag4 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E3D1 RID: 58321 RVA: 0x0086D3FC File Offset: 0x0086B5FC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(ContactPerson As String, ContactNo As String) As Integer
			Dim flag As Boolean = ContactPerson = Nothing
			If flag Then
				Throw New ArgumentNullException("ContactPerson")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = ContactPerson
			Dim flag2 As Boolean = ContactNo = Nothing
			If flag2 Then
				Throw New ArgumentNullException("ContactNo")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = ContactNo
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

		' Token: 0x0600E3D2 RID: 58322 RVA: 0x0086D50C File Offset: 0x0086B70C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ContactPerson As String, ContactNo As String, Original_Id As Integer, Original_ContactPerson As String, Original_ContactNo As String, Id As Integer) As Integer
			Dim flag As Boolean = ContactPerson = Nothing
			If flag Then
				Throw New ArgumentNullException("ContactPerson")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = ContactPerson
			Dim flag2 As Boolean = ContactNo = Nothing
			If flag2 Then
				Throw New ArgumentNullException("ContactNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = ContactNo
			Me.Adapter.UpdateCommand.Parameters(2).Value = Original_Id
			Dim flag3 As Boolean = Original_ContactPerson = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_ContactPerson")
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_ContactPerson
			Dim flag4 As Boolean = Original_ContactNo = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Original_ContactNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_ContactNo
			Me.Adapter.UpdateCommand.Parameters(5).Value = Id
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag5 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag5 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag6 As Boolean = state = ConnectionState.Closed
				If flag6 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E3D3 RID: 58323 RVA: 0x0086D6D0 File Offset: 0x0086B8D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ContactPerson As String, ContactNo As String, Original_Id As Integer, Original_ContactPerson As String, Original_ContactNo As String) As Integer
			Return Me.Update(ContactPerson, ContactNo, Original_Id, Original_ContactPerson, Original_ContactNo, Original_Id)
		End Function

		' Token: 0x04005835 RID: 22581
		Private _connection As SqlConnection

		' Token: 0x04005836 RID: 22582
		Private _transaction As SqlTransaction

		' Token: 0x04005837 RID: 22583
		Private _commandCollection As SqlCommand()

		' Token: 0x04005838 RID: 22584
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
