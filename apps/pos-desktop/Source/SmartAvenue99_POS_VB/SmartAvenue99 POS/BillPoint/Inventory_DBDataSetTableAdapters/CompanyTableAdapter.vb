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
	' Token: 0x02000447 RID: 1095
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class CompanyTableAdapter
		Inherits Component

		' Token: 0x170057D3 RID: 22483
		' (get) Token: 0x0600E3A4 RID: 58276 RVA: 0x000651BC File Offset: 0x000633BC
		' (set) Token: 0x0600E3A5 RID: 58277 RVA: 0x000651C6 File Offset: 0x000633C6
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E3A6 RID: 58278 RVA: 0x000651CF File Offset: 0x000633CF
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057D4 RID: 22484
		' (get) Token: 0x0600E3A7 RID: 58279 RVA: 0x0086A940 File Offset: 0x00868B40
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

		' Token: 0x170057D5 RID: 22485
		' (get) Token: 0x0600E3A8 RID: 58280 RVA: 0x0086A970 File Offset: 0x00868B70
		' (set) Token: 0x0600E3A9 RID: 58281 RVA: 0x0086A9A0 File Offset: 0x00868BA0
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

		' Token: 0x170057D6 RID: 22486
		' (get) Token: 0x0600E3AA RID: 58282 RVA: 0x0086AA64 File Offset: 0x00868C64
		' (set) Token: 0x0600E3AB RID: 58283 RVA: 0x0086AA7C File Offset: 0x00868C7C
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

		' Token: 0x170057D7 RID: 22487
		' (get) Token: 0x0600E3AC RID: 58284 RVA: 0x0086AB64 File Offset: 0x00868D64
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

		' Token: 0x170057D8 RID: 22488
		' (get) Token: 0x0600E3AD RID: 58285 RVA: 0x0086AB94 File Offset: 0x00868D94
		' (set) Token: 0x0600E3AE RID: 58286 RVA: 0x000651E1 File Offset: 0x000633E1
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

		' Token: 0x0600E3AF RID: 58287 RVA: 0x0086ABAC File Offset: 0x00868DAC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Company"
			dataTableMapping.ColumnMappings.Add("ID", "ID")
			dataTableMapping.ColumnMappings.Add("CompanyName", "CompanyName")
			dataTableMapping.ColumnMappings.Add("Address", "Address")
			dataTableMapping.ColumnMappings.Add("State", "State")
			dataTableMapping.ColumnMappings.Add("ContactNo", "ContactNo")
			dataTableMapping.ColumnMappings.Add("EmailID", "EmailID")
			dataTableMapping.ColumnMappings.Add("Logo", "Logo")
			dataTableMapping.ColumnMappings.Add("GSTIN", "GSTIN")
			dataTableMapping.ColumnMappings.Add("CIN", "CIN")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Company] WHERE (([ID] = @Original_ID) AND ((@IsNull_CompanyName = 1 AND [CompanyName] IS NULL) OR ([CompanyName] = @Original_CompanyName)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_State = 1 AND [State] IS NULL) OR ([State] = @Original_State)) AND ((@IsNull_ContactNo = 1 AND [ContactNo] IS NULL) OR ([ContactNo] = @Original_ContactNo)) AND ((@IsNull_EmailID = 1 AND [EmailID] IS NULL) OR ([EmailID] = @Original_EmailID)) AND ((@IsNull_GSTIN = 1 AND [GSTIN] IS NULL) OR ([GSTIN] = @Original_GSTIN)) AND ((@IsNull_CIN = 1 AND [CIN] IS NULL) OR ([CIN] = @Original_CIN)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CompanyName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CompanyName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CompanyName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CompanyName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_State", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ContactNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_EmailID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_GSTIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_GSTIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Company] ([CompanyName], [Address], [State], [ContactNo], [EmailID], [Logo], [GSTIN], [CIN]) VALUES (@CompanyName, @Address, @State, @ContactNo, @EmailID, @Logo, @GSTIN, @CIN);" & vbCrLf & "SELECT ID, CompanyName, Address, State, ContactNo, EmailID, Logo, GSTIN, CIN FROM Company WHERE (ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CompanyName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CompanyName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Logo", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Logo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GSTIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Company] SET [CompanyName] = @CompanyName, [Address] = @Address, [State] = @State, [ContactNo] = @ContactNo, [EmailID] = @EmailID, [Logo] = @Logo, [GSTIN] = @GSTIN, [CIN] = @CIN WHERE (([ID] = @Original_ID) AND ((@IsNull_CompanyName = 1 AND [CompanyName] IS NULL) OR ([CompanyName] = @Original_CompanyName)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_State = 1 AND [State] IS NULL) OR ([State] = @Original_State)) AND ((@IsNull_ContactNo = 1 AND [ContactNo] IS NULL) OR ([ContactNo] = @Original_ContactNo)) AND ((@IsNull_EmailID = 1 AND [EmailID] IS NULL) OR ([EmailID] = @Original_EmailID)) AND ((@IsNull_GSTIN = 1 AND [GSTIN] IS NULL) OR ([GSTIN] = @Original_GSTIN)) AND ((@IsNull_CIN = 1 AND [CIN] IS NULL) OR ([CIN] = @Original_CIN)));" & vbCrLf & "SELECT ID, CompanyName, Address, State, ContactNo, EmailID, Logo, GSTIN, CIN FROM Company WHERE (ID = @ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CompanyName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CompanyName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Logo", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Logo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GSTIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CompanyName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CompanyName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CompanyName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CompanyName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_State", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ContactNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_EmailID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_GSTIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_GSTIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E3B0 RID: 58288 RVA: 0x000651EB File Offset: 0x000633EB
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E3B1 RID: 58289 RVA: 0x0086B988 File Offset: 0x00869B88
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT ID, CompanyName, Address, State, ContactNo, EmailID, Logo, GSTIN, CIN FROM dbo.Company"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E3B2 RID: 58290 RVA: 0x0086B9E8 File Offset: 0x00869BE8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.CompanyDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E3B3 RID: 58291 RVA: 0x0086BA30 File Offset: 0x00869C30
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.CompanyDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim companyDataTable As Inventory_DBDataSet.CompanyDataTable = New Inventory_DBDataSet.CompanyDataTable()
			Me.Adapter.Fill(companyDataTable)
			Return companyDataTable
		End Function

		' Token: 0x0600E3B4 RID: 58292 RVA: 0x0086BA6C File Offset: 0x00869C6C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.CompanyDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E3B5 RID: 58293 RVA: 0x0086BA8C File Offset: 0x00869C8C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Company")
		End Function

		' Token: 0x0600E3B6 RID: 58294 RVA: 0x0086BAB0 File Offset: 0x00869CB0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E3B7 RID: 58295 RVA: 0x0086BAD8 File Offset: 0x00869CD8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E3B8 RID: 58296 RVA: 0x0086BAF8 File Offset: 0x00869CF8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_ID As Integer, Original_CompanyName As String, Original_Address As String, Original_State As String, Original_ContactNo As String, Original_EmailID As String, Original_GSTIN As String, Original_CIN As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_ID
			Dim flag As Boolean = Original_CompanyName = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_CompanyName
			End If
			Dim flag2 As Boolean = Original_Address = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Address
			End If
			Dim flag3 As Boolean = Original_State = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_State
			End If
			Dim flag4 As Boolean = Original_ContactNo = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_ContactNo
			End If
			Dim flag5 As Boolean = Original_EmailID = Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_EmailID
			End If
			Dim flag6 As Boolean = Original_GSTIN = Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_GSTIN
			End If
			Dim flag7 As Boolean = Original_CIN = Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(13).Value = 1
				Me.Adapter.DeleteCommand.Parameters(14).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(13).Value = 0
				Me.Adapter.DeleteCommand.Parameters(14).Value = Original_CIN
			End If
			Dim previousConnectionState As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag8 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag8 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag9 As Boolean = previousConnectionState = ConnectionState.Closed
				If flag9 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E3B9 RID: 58297 RVA: 0x0086BFD0 File Offset: 0x0086A1D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(CompanyName As String, Address As String, State As String, ContactNo As String, EmailID As String, Logo As Byte(), GSTIN As String, CIN As String) As Integer
			Dim flag As Boolean = CompanyName = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(0).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(0).Value = CompanyName
			End If
			Dim flag2 As Boolean = Address = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = Address
			End If
			Dim flag3 As Boolean = State = Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = State
			End If
			Dim flag4 As Boolean = ContactNo = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = ContactNo
			End If
			Dim flag5 As Boolean = EmailID = Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = EmailID
			End If
			Dim flag6 As Boolean = Logo Is Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = Logo
			End If
			Dim flag7 As Boolean = GSTIN = Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = GSTIN
			End If
			Dim flag8 As Boolean = CIN = Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = CIN
			End If
			Dim previousConnectionState As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag9 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag9 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag10 As Boolean = previousConnectionState = ConnectionState.Closed
				If flag10 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E3BA RID: 58298 RVA: 0x0086C2EC File Offset: 0x0086A4EC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(CompanyName As String, Address As String, State As String, ContactNo As String, EmailID As String, Logo As Byte(), GSTIN As String, CIN As String, Original_ID As Integer, Original_CompanyName As String, Original_Address As String, Original_State As String, Original_ContactNo As String, Original_EmailID As String, Original_GSTIN As String, Original_CIN As String, ID As Integer) As Integer
			Dim flag As Boolean = CompanyName = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(0).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(0).Value = CompanyName
			End If
			Dim flag2 As Boolean = Address = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = Address
			End If
			Dim flag3 As Boolean = State = Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = State
			End If
			Dim flag4 As Boolean = ContactNo = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = ContactNo
			End If
			Dim flag5 As Boolean = EmailID = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = EmailID
			End If
			Dim flag6 As Boolean = Logo Is Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = Logo
			End If
			Dim flag7 As Boolean = GSTIN = Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = GSTIN
			End If
			Dim flag8 As Boolean = CIN = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = CIN
			End If
			Me.Adapter.UpdateCommand.Parameters(8).Value = Original_ID
			Dim flag9 As Boolean = Original_CompanyName = Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = 1
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = 0
				Me.Adapter.UpdateCommand.Parameters(10).Value = Original_CompanyName
			End If
			Dim flag10 As Boolean = Original_Address = Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = 1
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = 0
				Me.Adapter.UpdateCommand.Parameters(12).Value = Original_Address
			End If
			Dim flag11 As Boolean = Original_State = Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = 1
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = 0
				Me.Adapter.UpdateCommand.Parameters(14).Value = Original_State
			End If
			Dim flag12 As Boolean = Original_ContactNo = Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = 1
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = 0
				Me.Adapter.UpdateCommand.Parameters(16).Value = Original_ContactNo
			End If
			Dim flag13 As Boolean = Original_EmailID = Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_EmailID
			End If
			Dim flag14 As Boolean = Original_GSTIN = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = 1
				Me.Adapter.UpdateCommand.Parameters(20).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(19).Value = 0
				Me.Adapter.UpdateCommand.Parameters(20).Value = Original_GSTIN
			End If
			Dim flag15 As Boolean = Original_CIN = Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(21).Value = 1
				Me.Adapter.UpdateCommand.Parameters(22).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(21).Value = 0
				Me.Adapter.UpdateCommand.Parameters(22).Value = Original_CIN
			End If
			Me.Adapter.UpdateCommand.Parameters(23).Value = ID
			Dim previousConnectionState As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag16 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag16 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag17 As Boolean = previousConnectionState = ConnectionState.Closed
				If flag17 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E3BB RID: 58299 RVA: 0x0086CA70 File Offset: 0x0086AC70
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(CompanyName As String, Address As String, State As String, ContactNo As String, EmailID As String, Logo As Byte(), GSTIN As String, CIN As String, Original_ID As Integer, Original_CompanyName As String, Original_Address As String, Original_State As String, Original_ContactNo As String, Original_EmailID As String, Original_GSTIN As String, Original_CIN As String) As Integer
			Return Me.Update(CompanyName, Address, State, ContactNo, EmailID, Logo, GSTIN, CIN, Original_ID, Original_CompanyName, Original_Address, Original_State, Original_ContactNo, Original_EmailID, Original_GSTIN, Original_CIN, Original_ID)
		End Function

		' Token: 0x04005830 RID: 22576
		Private _connection As SqlConnection

		' Token: 0x04005831 RID: 22577
		Private _transaction As SqlTransaction

		' Token: 0x04005832 RID: 22578
		Private _commandCollection As SqlCommand()

		' Token: 0x04005833 RID: 22579
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
