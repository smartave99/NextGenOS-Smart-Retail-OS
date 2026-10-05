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
	' Token: 0x02000445 RID: 1093
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class BankBranchTableAdapter
		Inherits Component

		' Token: 0x170057C7 RID: 22471
		' (get) Token: 0x0600E374 RID: 58228 RVA: 0x00065116 File Offset: 0x00063316
		' (set) Token: 0x0600E375 RID: 58229 RVA: 0x00065120 File Offset: 0x00063320
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E376 RID: 58230 RVA: 0x00065129 File Offset: 0x00063329
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057C8 RID: 22472
		' (get) Token: 0x0600E377 RID: 58231 RVA: 0x00868474 File Offset: 0x00866674
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

		' Token: 0x170057C9 RID: 22473
		' (get) Token: 0x0600E378 RID: 58232 RVA: 0x008684A4 File Offset: 0x008666A4
		' (set) Token: 0x0600E379 RID: 58233 RVA: 0x008684D4 File Offset: 0x008666D4
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

		' Token: 0x170057CA RID: 22474
		' (get) Token: 0x0600E37A RID: 58234 RVA: 0x00868598 File Offset: 0x00866798
		' (set) Token: 0x0600E37B RID: 58235 RVA: 0x008685B0 File Offset: 0x008667B0
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

		' Token: 0x170057CB RID: 22475
		' (get) Token: 0x0600E37C RID: 58236 RVA: 0x00868698 File Offset: 0x00866898
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

		' Token: 0x170057CC RID: 22476
		' (get) Token: 0x0600E37D RID: 58237 RVA: 0x008686C8 File Offset: 0x008668C8
		' (set) Token: 0x0600E37E RID: 58238 RVA: 0x0006513B File Offset: 0x0006333B
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

		' Token: 0x0600E37F RID: 58239 RVA: 0x008686E0 File Offset: 0x008668E0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "BankBranch"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("BranchName", "BranchName")
			dataTableMapping.ColumnMappings.Add("Address", "Address")
			dataTableMapping.ColumnMappings.Add("ContactNo", "ContactNo")
			dataTableMapping.ColumnMappings.Add("SwiftCode", "SwiftCode")
			dataTableMapping.ColumnMappings.Add("IFSCCode", "IFSCCode")
			dataTableMapping.ColumnMappings.Add("BankName", "BankName")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[BankBranch] WHERE (([Id] = @Original_Id) AND ((@IsNull_BranchName = 1 AND [BranchName] IS NULL) OR ([BranchName] = @Original_BranchName)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_ContactNo = 1 AND [ContactNo] IS NULL) OR ([ContactNo] = @Original_ContactNo)) AND ((@IsNull_SwiftCode = 1 AND [SwiftCode] IS NULL) OR ([SwiftCode] = @Original_SwiftCode)) AND ((@IsNull_IFSCCode = 1 AND [IFSCCode] IS NULL) OR ([IFSCCode] = @Original_IFSCCode)) AND ([BankName] = @Original_BankName))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_BranchName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BranchName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_BranchName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BranchName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ContactNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SwiftCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SwiftCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SwiftCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SwiftCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_IFSCCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IFSCCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_BankName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BankName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[BankBranch] ([Id], [BranchName], [Address], [ContactNo], [SwiftCode], [IFSCCode], [BankName]) VALUES (@Id, @BranchName, @Address, @ContactNo, @SwiftCode, @IFSCCode, @BankName);" & vbCrLf & "SELECT Id, BranchName, Address, ContactNo, SwiftCode, IFSCCode, BankName FROM BankBranch WHERE (Id = @Id)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BranchName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BranchName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SwiftCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SwiftCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IFSCCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@BankName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BankName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[BankBranch] SET [Id] = @Id, [BranchName] = @BranchName, [Address] = @Address, [ContactNo] = @ContactNo, [SwiftCode] = @SwiftCode, [IFSCCode] = @IFSCCode, [BankName] = @BankName WHERE (([Id] = @Original_Id) AND ((@IsNull_BranchName = 1 AND [BranchName] IS NULL) OR ([BranchName] = @Original_BranchName)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_ContactNo = 1 AND [ContactNo] IS NULL) OR ([ContactNo] = @Original_ContactNo)) AND ((@IsNull_SwiftCode = 1 AND [SwiftCode] IS NULL) OR ([SwiftCode] = @Original_SwiftCode)) AND ((@IsNull_IFSCCode = 1 AND [IFSCCode] IS NULL) OR ([IFSCCode] = @Original_IFSCCode)) AND ([BankName] = @Original_BankName));" & vbCrLf & "SELECT Id, BranchName, Address, ContactNo, SwiftCode, IFSCCode, BankName FROM BankBranch WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BranchName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BranchName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SwiftCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SwiftCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IFSCCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@BankName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BankName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_BranchName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "BranchName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_BranchName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BranchName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ContactNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SwiftCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SwiftCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SwiftCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SwiftCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_IFSCCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IFSCCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_BankName", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "BankName", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E380 RID: 58240 RVA: 0x00065145 File Offset: 0x00063345
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E381 RID: 58241 RVA: 0x0086924C File Offset: 0x0086744C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, BranchName, Address, ContactNo, SwiftCode, IFSCCode, BankName FROM dbo.BankBranch"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E382 RID: 58242 RVA: 0x008692AC File Offset: 0x008674AC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.BankBranchDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E383 RID: 58243 RVA: 0x008692F4 File Offset: 0x008674F4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.BankBranchDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim bankBranchDataTable As Inventory_DBDataSet.BankBranchDataTable = New Inventory_DBDataSet.BankBranchDataTable()
			Me.Adapter.Fill(bankBranchDataTable)
			Return bankBranchDataTable
		End Function

		' Token: 0x0600E384 RID: 58244 RVA: 0x00869330 File Offset: 0x00867530
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.BankBranchDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E385 RID: 58245 RVA: 0x00869350 File Offset: 0x00867550
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "BankBranch")
		End Function

		' Token: 0x0600E386 RID: 58246 RVA: 0x00869374 File Offset: 0x00867574
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E387 RID: 58247 RVA: 0x0086939C File Offset: 0x0086759C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E388 RID: 58248 RVA: 0x008693BC File Offset: 0x008675BC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_BranchName As String, Original_Address As String, Original_ContactNo As String, Original_SwiftCode As String, Original_IFSCCode As String, Original_BankName As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Dim flag As Boolean = Original_BranchName = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_BranchName
			End If
			Dim flag2 As Boolean = Original_Address = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Address
			End If
			Dim flag3 As Boolean = Original_ContactNo = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_ContactNo
			End If
			Dim flag4 As Boolean = Original_SwiftCode = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_SwiftCode
			End If
			Dim flag5 As Boolean = Original_IFSCCode = Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_IFSCCode
			End If
			Dim flag6 As Boolean = Original_BankName = Nothing
			If flag6 Then
				Throw New ArgumentNullException("Original_BankName")
			End If
			Me.Adapter.DeleteCommand.Parameters(11).Value = Original_BankName
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

		' Token: 0x0600E389 RID: 58249 RVA: 0x0086979C File Offset: 0x0086799C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(Id As Integer, BranchName As String, Address As String, ContactNo As String, SwiftCode As String, IFSCCode As String, BankName As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = Id
			Dim flag As Boolean = BranchName = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = BranchName
			End If
			Dim flag2 As Boolean = Address = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = Address
			End If
			Dim flag3 As Boolean = ContactNo = Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = ContactNo
			End If
			Dim flag4 As Boolean = SwiftCode = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = SwiftCode
			End If
			Dim flag5 As Boolean = IFSCCode = Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = IFSCCode
			End If
			Dim flag6 As Boolean = BankName = Nothing
			If flag6 Then
				Throw New ArgumentNullException("BankName")
			End If
			Me.Adapter.InsertCommand.Parameters(6).Value = BankName
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

		' Token: 0x0600E38A RID: 58250 RVA: 0x00869A24 File Offset: 0x00867C24
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Id As Integer, BranchName As String, Address As String, ContactNo As String, SwiftCode As String, IFSCCode As String, BankName As String, Original_Id As Integer, Original_BranchName As String, Original_Address As String, Original_ContactNo As String, Original_SwiftCode As String, Original_IFSCCode As String, Original_BankName As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = Id
			Dim flag As Boolean = BranchName = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = BranchName
			End If
			Dim flag2 As Boolean = Address = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = Address
			End If
			Dim flag3 As Boolean = ContactNo = Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = ContactNo
			End If
			Dim flag4 As Boolean = SwiftCode = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = SwiftCode
			End If
			Dim flag5 As Boolean = IFSCCode = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = IFSCCode
			End If
			Dim flag6 As Boolean = BankName = Nothing
			If flag6 Then
				Throw New ArgumentNullException("BankName")
			End If
			Me.Adapter.UpdateCommand.Parameters(6).Value = BankName
			Me.Adapter.UpdateCommand.Parameters(7).Value = Original_Id
			Dim flag7 As Boolean = Original_BranchName = Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = 1
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = 0
				Me.Adapter.UpdateCommand.Parameters(9).Value = Original_BranchName
			End If
			Dim flag8 As Boolean = Original_Address = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = 1
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = 0
				Me.Adapter.UpdateCommand.Parameters(11).Value = Original_Address
			End If
			Dim flag9 As Boolean = Original_ContactNo = Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = 1
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = 0
				Me.Adapter.UpdateCommand.Parameters(13).Value = Original_ContactNo
			End If
			Dim flag10 As Boolean = Original_SwiftCode = Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = 1
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = 0
				Me.Adapter.UpdateCommand.Parameters(15).Value = Original_SwiftCode
			End If
			Dim flag11 As Boolean = Original_IFSCCode = Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = 1
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = 0
				Me.Adapter.UpdateCommand.Parameters(17).Value = Original_IFSCCode
			End If
			Dim flag12 As Boolean = Original_BankName = Nothing
			If flag12 Then
				Throw New ArgumentNullException("Original_BankName")
			End If
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_BankName
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

		' Token: 0x0600E38B RID: 58251 RVA: 0x00869FF8 File Offset: 0x008681F8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(BranchName As String, Address As String, ContactNo As String, SwiftCode As String, IFSCCode As String, BankName As String, Original_Id As Integer, Original_BranchName As String, Original_Address As String, Original_ContactNo As String, Original_SwiftCode As String, Original_IFSCCode As String, Original_BankName As String) As Integer
			Return Me.Update(Original_Id, BranchName, Address, ContactNo, SwiftCode, IFSCCode, BankName, Original_Id, Original_BranchName, Original_Address, Original_ContactNo, Original_SwiftCode, Original_IFSCCode, Original_BankName)
		End Function

		' Token: 0x04005826 RID: 22566
		Private _connection As SqlConnection

		' Token: 0x04005827 RID: 22567
		Private _transaction As SqlTransaction

		' Token: 0x04005828 RID: 22568
		Private _commandCollection As SqlCommand()

		' Token: 0x04005829 RID: 22569
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
