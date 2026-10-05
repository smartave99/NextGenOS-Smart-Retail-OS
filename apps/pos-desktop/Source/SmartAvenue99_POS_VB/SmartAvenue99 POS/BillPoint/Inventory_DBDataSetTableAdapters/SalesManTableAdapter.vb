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
	' Token: 0x02000460 RID: 1120
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class SalesManTableAdapter
		Inherits Component

		' Token: 0x17005869 RID: 22633
		' (get) Token: 0x0600E5FC RID: 58876 RVA: 0x000659D7 File Offset: 0x00063BD7
		' (set) Token: 0x0600E5FD RID: 58877 RVA: 0x000659E1 File Offset: 0x00063BE1
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E5FE RID: 58878 RVA: 0x000659EA File Offset: 0x00063BEA
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x1700586A RID: 22634
		' (get) Token: 0x0600E5FF RID: 58879 RVA: 0x008A255C File Offset: 0x008A075C
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

		' Token: 0x1700586B RID: 22635
		' (get) Token: 0x0600E600 RID: 58880 RVA: 0x008A258C File Offset: 0x008A078C
		' (set) Token: 0x0600E601 RID: 58881 RVA: 0x008A25BC File Offset: 0x008A07BC
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

		' Token: 0x1700586C RID: 22636
		' (get) Token: 0x0600E602 RID: 58882 RVA: 0x008A2680 File Offset: 0x008A0880
		' (set) Token: 0x0600E603 RID: 58883 RVA: 0x008A2698 File Offset: 0x008A0898
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

		' Token: 0x1700586D RID: 22637
		' (get) Token: 0x0600E604 RID: 58884 RVA: 0x008A2780 File Offset: 0x008A0980
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

		' Token: 0x1700586E RID: 22638
		' (get) Token: 0x0600E605 RID: 58885 RVA: 0x008A27B0 File Offset: 0x008A09B0
		' (set) Token: 0x0600E606 RID: 58886 RVA: 0x000659FC File Offset: 0x00063BFC
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

		' Token: 0x0600E607 RID: 58887 RVA: 0x008A27C8 File Offset: 0x008A09C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "SalesMan"
			dataTableMapping.ColumnMappings.Add("SM_ID", "SM_ID")
			dataTableMapping.ColumnMappings.Add("SalesMan_ID", "SalesMan_ID")
			dataTableMapping.ColumnMappings.Add("Name", "Name")
			dataTableMapping.ColumnMappings.Add("Address", "Address")
			dataTableMapping.ColumnMappings.Add("City", "City")
			dataTableMapping.ColumnMappings.Add("State", "State")
			dataTableMapping.ColumnMappings.Add("ZipCode", "ZipCode")
			dataTableMapping.ColumnMappings.Add("ContactNo", "ContactNo")
			dataTableMapping.ColumnMappings.Add("EmailID", "EmailID")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			dataTableMapping.ColumnMappings.Add("Photo", "Photo")
			dataTableMapping.ColumnMappings.Add("CommissionPer", "CommissionPer")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[SalesMan] WHERE (([SM_ID] = @Original_SM_ID) AND ((@IsNull_SalesMan_ID = 1 AND [SalesMan_ID] IS NULL) OR ([SalesMan_ID] = @Original_SalesMan_ID)) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_City = 1 AND [City] IS NULL) OR ([City] = @Original_City)) AND ((@IsNull_State = 1 AND [State] IS NULL) OR ([State] = @Original_State)) AND ((@IsNull_ZipCode = 1 AND [ZipCode] IS NULL) OR ([ZipCode] = @Original_ZipCode)) AND ((@IsNull_ContactNo = 1 AND [ContactNo] IS NULL) OR ([ContactNo] = @Original_ContactNo)) AND ((@IsNull_EmailID = 1 AND [EmailID] IS NULL) OR ([EmailID] = @Original_EmailID)) AND ((@IsNull_CommissionPer = 1 AND [CommissionPer] IS NULL) OR ([CommissionPer] = @Original_CommissionPer)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SM_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SM_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_SalesMan_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesMan_ID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SalesMan_ID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesMan_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Name", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_City", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_City", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_State", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ZipCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ZipCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ContactNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_EmailID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CommissionPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CommissionPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CommissionPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CommissionPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[SalesMan] ([SM_ID], [SalesMan_ID], [Name], [Address], [City], [State], [ZipCode], [ContactNo], [EmailID], [Remarks], [Photo], [CommissionPer]) VALUES (@SM_ID, @SalesMan_ID, @Name, @Address, @City, @State, @ZipCode, @ContactNo, @EmailID, @Remarks, @Photo, @CommissionPer);" & vbCrLf & "SELECT SM_ID, SalesMan_ID, Name, Address, City, State, ZipCode, ContactNo, EmailID, Remarks, Photo, CommissionPer FROM SalesMan WHERE (SM_ID = @SM_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SM_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SM_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SalesMan_ID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesMan_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@City", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ZipCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Photo", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Photo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CommissionPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CommissionPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[SalesMan] SET [SM_ID] = @SM_ID, [SalesMan_ID] = @SalesMan_ID, [Name] = @Name, [Address] = @Address, [City] = @City, [State] = @State, [ZipCode] = @ZipCode, [ContactNo] = @ContactNo, [EmailID] = @EmailID, [Remarks] = @Remarks, [Photo] = @Photo, [CommissionPer] = @CommissionPer WHERE (([SM_ID] = @Original_SM_ID) AND ((@IsNull_SalesMan_ID = 1 AND [SalesMan_ID] IS NULL) OR ([SalesMan_ID] = @Original_SalesMan_ID)) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_City = 1 AND [City] IS NULL) OR ([City] = @Original_City)) AND ((@IsNull_State = 1 AND [State] IS NULL) OR ([State] = @Original_State)) AND ((@IsNull_ZipCode = 1 AND [ZipCode] IS NULL) OR ([ZipCode] = @Original_ZipCode)) AND ((@IsNull_ContactNo = 1 AND [ContactNo] IS NULL) OR ([ContactNo] = @Original_ContactNo)) AND ((@IsNull_EmailID = 1 AND [EmailID] IS NULL) OR ([EmailID] = @Original_EmailID)) AND ((@IsNull_CommissionPer = 1 AND [CommissionPer] IS NULL) OR ([CommissionPer] = @Original_CommissionPer)));" & vbCrLf & "SELECT SM_ID, SalesMan_ID, Name, Address, City, State, ZipCode, ContactNo, EmailID, Remarks, Photo, CommissionPer FROM SalesMan WHERE (SM_ID = @SM_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SM_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SM_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SalesMan_ID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesMan_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@City", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ZipCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Photo", SqlDbType.Image, 0, ParameterDirection.Input, 0, 0, "Photo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CommissionPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CommissionPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SM_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SM_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_SalesMan_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "SalesMan_ID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SalesMan_ID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesMan_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Name", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Address", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_City", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_City", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_State", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ZipCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ZipCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ContactNo", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_EmailID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CommissionPer", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CommissionPer", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CommissionPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CommissionPer", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E608 RID: 58888 RVA: 0x00065A06 File Offset: 0x00063C06
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E609 RID: 58889 RVA: 0x008A39B0 File Offset: 0x008A1BB0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT SM_ID, SalesMan_ID, Name, Address, City, State, ZipCode, ContactNo, EmailID, Remarks, Photo, CommissionPer FROM dbo.SalesMan"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E60A RID: 58890 RVA: 0x008A3A10 File Offset: 0x008A1C10
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.SalesManDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E60B RID: 58891 RVA: 0x008A3A58 File Offset: 0x008A1C58
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.SalesManDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim salesManDataTable As Inventory_DBDataSet.SalesManDataTable = New Inventory_DBDataSet.SalesManDataTable()
			Me.Adapter.Fill(salesManDataTable)
			Return salesManDataTable
		End Function

		' Token: 0x0600E60C RID: 58892 RVA: 0x008A3A94 File Offset: 0x008A1C94
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.SalesManDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E60D RID: 58893 RVA: 0x008A3AB4 File Offset: 0x008A1CB4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "SalesMan")
		End Function

		' Token: 0x0600E60E RID: 58894 RVA: 0x008A3AD8 File Offset: 0x008A1CD8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E60F RID: 58895 RVA: 0x008A3B00 File Offset: 0x008A1D00
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E610 RID: 58896 RVA: 0x008A3B20 File Offset: 0x008A1D20
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_SM_ID As Integer, Original_SalesMan_ID As String, Original_Name As String, Original_Address As String, Original_City As String, Original_State As String, Original_ZipCode As String, Original_ContactNo As String, Original_EmailID As String, Original_CommissionPer As Decimal?) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_SM_ID
			Dim flag As Boolean = Original_SalesMan_ID = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_SalesMan_ID
			End If
			Dim flag2 As Boolean = Original_Name = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Name
			End If
			Dim flag3 As Boolean = Original_Address = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_Address
			End If
			Dim flag4 As Boolean = Original_City = Nothing
			If flag4 Then
				Me.Adapter.DeleteCommand.Parameters(7).Value = 1
				Me.Adapter.DeleteCommand.Parameters(8).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(7).Value = 0
				Me.Adapter.DeleteCommand.Parameters(8).Value = Original_City
			End If
			Dim flag5 As Boolean = Original_State = Nothing
			If flag5 Then
				Me.Adapter.DeleteCommand.Parameters(9).Value = 1
				Me.Adapter.DeleteCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(9).Value = 0
				Me.Adapter.DeleteCommand.Parameters(10).Value = Original_State
			End If
			Dim flag6 As Boolean = Original_ZipCode = Nothing
			If flag6 Then
				Me.Adapter.DeleteCommand.Parameters(11).Value = 1
				Me.Adapter.DeleteCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(11).Value = 0
				Me.Adapter.DeleteCommand.Parameters(12).Value = Original_ZipCode
			End If
			Dim flag7 As Boolean = Original_ContactNo = Nothing
			If flag7 Then
				Me.Adapter.DeleteCommand.Parameters(13).Value = 1
				Me.Adapter.DeleteCommand.Parameters(14).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(13).Value = 0
				Me.Adapter.DeleteCommand.Parameters(14).Value = Original_ContactNo
			End If
			Dim flag8 As Boolean = Original_EmailID = Nothing
			If flag8 Then
				Me.Adapter.DeleteCommand.Parameters(15).Value = 1
				Me.Adapter.DeleteCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(15).Value = 0
				Me.Adapter.DeleteCommand.Parameters(16).Value = Original_EmailID
			End If
			Dim flag9 As Boolean = Original_CommissionPer IsNot Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(17).Value = 0
				Me.Adapter.DeleteCommand.Parameters(18).Value = Original_CommissionPer.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(17).Value = 1
				Me.Adapter.DeleteCommand.Parameters(18).Value = DBNull.Value
			End If
			Dim previousConnectionState As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag10 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag10 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag11 As Boolean = previousConnectionState = ConnectionState.Closed
				If flag11 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E611 RID: 58897 RVA: 0x008A4134 File Offset: 0x008A2334
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(SM_ID As Integer, SalesMan_ID As String, Name As String, Address As String, City As String, State As String, ZipCode As String, ContactNo As String, EmailID As String, Remarks As String, Photo As Byte(), CommissionPer As Decimal?) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = SM_ID
			Dim flag As Boolean = SalesMan_ID = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = SalesMan_ID
			End If
			Dim flag2 As Boolean = Name = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = Name
			End If
			Dim flag3 As Boolean = Address = Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = Address
			End If
			Dim flag4 As Boolean = City = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = City
			End If
			Dim flag5 As Boolean = State = Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(5).Value = State
			End If
			Dim flag6 As Boolean = ZipCode = Nothing
			If flag6 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = ZipCode
			End If
			Dim flag7 As Boolean = ContactNo = Nothing
			If flag7 Then
				Me.Adapter.InsertCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(7).Value = ContactNo
			End If
			Dim flag8 As Boolean = EmailID = Nothing
			If flag8 Then
				Me.Adapter.InsertCommand.Parameters(8).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(8).Value = EmailID
			End If
			Dim flag9 As Boolean = Remarks = Nothing
			If flag9 Then
				Me.Adapter.InsertCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(9).Value = Remarks
			End If
			Dim flag10 As Boolean = Photo Is Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = Photo
			End If
			Dim flag11 As Boolean = CommissionPer IsNot Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = CommissionPer.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			End If
			Dim previousConnectionState As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag12 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag12 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag13 As Boolean = previousConnectionState = ConnectionState.Closed
				If flag13 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E612 RID: 58898 RVA: 0x008A4574 File Offset: 0x008A2774
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(SM_ID As Integer, SalesMan_ID As String, Name As String, Address As String, City As String, State As String, ZipCode As String, ContactNo As String, EmailID As String, Remarks As String, Photo As Byte(), CommissionPer As Decimal?, Original_SM_ID As Integer, Original_SalesMan_ID As String, Original_Name As String, Original_Address As String, Original_City As String, Original_State As String, Original_ZipCode As String, Original_ContactNo As String, Original_EmailID As String, Original_CommissionPer As Decimal?) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = SM_ID
			Dim flag As Boolean = SalesMan_ID = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = SalesMan_ID
			End If
			Dim flag2 As Boolean = Name = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = Name
			End If
			Dim flag3 As Boolean = Address = Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = Address
			End If
			Dim flag4 As Boolean = City = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = City
			End If
			Dim flag5 As Boolean = State = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(5).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(5).Value = State
			End If
			Dim flag6 As Boolean = ZipCode = Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = ZipCode
			End If
			Dim flag7 As Boolean = ContactNo = Nothing
			If flag7 Then
				Me.Adapter.UpdateCommand.Parameters(7).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(7).Value = ContactNo
			End If
			Dim flag8 As Boolean = EmailID = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = EmailID
			End If
			Dim flag9 As Boolean = Remarks = Nothing
			If flag9 Then
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(9).Value = Remarks
			End If
			Dim flag10 As Boolean = Photo Is Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = Photo
			End If
			Dim flag11 As Boolean = CommissionPer IsNot Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = CommissionPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			End If
			Me.Adapter.UpdateCommand.Parameters(12).Value = Original_SM_ID
			Dim flag12 As Boolean = Original_SalesMan_ID = Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = 1
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = 0
				Me.Adapter.UpdateCommand.Parameters(14).Value = Original_SalesMan_ID
			End If
			Dim flag13 As Boolean = Original_Name = Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = 1
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = 0
				Me.Adapter.UpdateCommand.Parameters(16).Value = Original_Name
			End If
			Dim flag14 As Boolean = Original_Address = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = 1
				Me.Adapter.UpdateCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = 0
				Me.Adapter.UpdateCommand.Parameters(18).Value = Original_Address
			End If
			Dim flag15 As Boolean = Original_City = Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = 1
				Me.Adapter.UpdateCommand.Parameters(20).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(19).Value = 0
				Me.Adapter.UpdateCommand.Parameters(20).Value = Original_City
			End If
			Dim flag16 As Boolean = Original_State = Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(21).Value = 1
				Me.Adapter.UpdateCommand.Parameters(22).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(21).Value = 0
				Me.Adapter.UpdateCommand.Parameters(22).Value = Original_State
			End If
			Dim flag17 As Boolean = Original_ZipCode = Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(23).Value = 1
				Me.Adapter.UpdateCommand.Parameters(24).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(23).Value = 0
				Me.Adapter.UpdateCommand.Parameters(24).Value = Original_ZipCode
			End If
			Dim flag18 As Boolean = Original_ContactNo = Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(25).Value = 1
				Me.Adapter.UpdateCommand.Parameters(26).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(25).Value = 0
				Me.Adapter.UpdateCommand.Parameters(26).Value = Original_ContactNo
			End If
			Dim flag19 As Boolean = Original_EmailID = Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(27).Value = 1
				Me.Adapter.UpdateCommand.Parameters(28).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(27).Value = 0
				Me.Adapter.UpdateCommand.Parameters(28).Value = Original_EmailID
			End If
			Dim flag20 As Boolean = Original_CommissionPer IsNot Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(29).Value = 0
				Me.Adapter.UpdateCommand.Parameters(30).Value = Original_CommissionPer.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(29).Value = 1
				Me.Adapter.UpdateCommand.Parameters(30).Value = DBNull.Value
			End If
			Dim previousConnectionState As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag21 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag21 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag22 As Boolean = previousConnectionState = ConnectionState.Closed
				If flag22 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E613 RID: 58899 RVA: 0x008A4F30 File Offset: 0x008A3130
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(SalesMan_ID As String, Name As String, Address As String, City As String, State As String, ZipCode As String, ContactNo As String, EmailID As String, Remarks As String, Photo As Byte(), CommissionPer As Decimal?, Original_SM_ID As Integer, Original_SalesMan_ID As String, Original_Name As String, Original_Address As String, Original_City As String, Original_State As String, Original_ZipCode As String, Original_ContactNo As String, Original_EmailID As String, Original_CommissionPer As Decimal?) As Integer
			Return Me.Update(Original_SM_ID, SalesMan_ID, Name, Address, City, State, ZipCode, ContactNo, EmailID, Remarks, Photo, CommissionPer, Original_SM_ID, Original_SalesMan_ID, Original_Name, Original_Address, Original_City, Original_State, Original_ZipCode, Original_ContactNo, Original_EmailID, Original_CommissionPer)
		End Function

		' Token: 0x040058AD RID: 22701
		Private _connection As SqlConnection

		' Token: 0x040058AE RID: 22702
		Private _transaction As SqlTransaction

		' Token: 0x040058AF RID: 22703
		Private _commandCollection As SqlCommand()

		' Token: 0x040058B0 RID: 22704
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
