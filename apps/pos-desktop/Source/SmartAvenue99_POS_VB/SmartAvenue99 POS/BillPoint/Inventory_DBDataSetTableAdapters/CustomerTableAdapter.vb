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
	' Token: 0x0200044A RID: 1098
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class CustomerTableAdapter
		Inherits Component

		' Token: 0x170057E5 RID: 22501
		' (get) Token: 0x0600E3EC RID: 58348 RVA: 0x000652B5 File Offset: 0x000634B5
		' (set) Token: 0x0600E3ED RID: 58349 RVA: 0x000652BF File Offset: 0x000634BF
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E3EE RID: 58350 RVA: 0x000652C8 File Offset: 0x000634C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170057E6 RID: 22502
		' (get) Token: 0x0600E3EF RID: 58351 RVA: 0x0086F24C File Offset: 0x0086D44C
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

		' Token: 0x170057E7 RID: 22503
		' (get) Token: 0x0600E3F0 RID: 58352 RVA: 0x0086F27C File Offset: 0x0086D47C
		' (set) Token: 0x0600E3F1 RID: 58353 RVA: 0x0086F2AC File Offset: 0x0086D4AC
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

		' Token: 0x170057E8 RID: 22504
		' (get) Token: 0x0600E3F2 RID: 58354 RVA: 0x0086F370 File Offset: 0x0086D570
		' (set) Token: 0x0600E3F3 RID: 58355 RVA: 0x0086F388 File Offset: 0x0086D588
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

		' Token: 0x170057E9 RID: 22505
		' (get) Token: 0x0600E3F4 RID: 58356 RVA: 0x0086F470 File Offset: 0x0086D670
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

		' Token: 0x170057EA RID: 22506
		' (get) Token: 0x0600E3F5 RID: 58357 RVA: 0x0086F4A0 File Offset: 0x0086D6A0
		' (set) Token: 0x0600E3F6 RID: 58358 RVA: 0x000652DA File Offset: 0x000634DA
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

		' Token: 0x0600E3F7 RID: 58359 RVA: 0x0086F4B8 File Offset: 0x0086D6B8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Customer"
			dataTableMapping.ColumnMappings.Add("ID", "ID")
			dataTableMapping.ColumnMappings.Add("CustomerID", "CustomerID")
			dataTableMapping.ColumnMappings.Add("Name", "Name")
			dataTableMapping.ColumnMappings.Add("Address", "Address")
			dataTableMapping.ColumnMappings.Add("City", "City")
			dataTableMapping.ColumnMappings.Add("State", "State")
			dataTableMapping.ColumnMappings.Add("ZipCode", "ZipCode")
			dataTableMapping.ColumnMappings.Add("ContactNo", "ContactNo")
			dataTableMapping.ColumnMappings.Add("EmailID", "EmailID")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			dataTableMapping.ColumnMappings.Add("AccountNumber", "AccountNumber")
			dataTableMapping.ColumnMappings.Add("AccountName", "AccountName")
			dataTableMapping.ColumnMappings.Add("Bank", "Bank")
			dataTableMapping.ColumnMappings.Add("Branch", "Branch")
			dataTableMapping.ColumnMappings.Add("IFSCCode", "IFSCCode")
			dataTableMapping.ColumnMappings.Add("GSTIN", "GSTIN")
			dataTableMapping.ColumnMappings.Add("PAN", "PAN")
			dataTableMapping.ColumnMappings.Add("CIN", "CIN")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Customer] WHERE (([ID] = @Original_ID) AND ((@IsNull_CustomerID = 1 AND [CustomerID] IS NULL) OR ([CustomerID] = @Original_CustomerID)) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_City = 1 AND [City] IS NULL) OR ([City] = @Original_City)) AND ((@IsNull_State = 1 AND [State] IS NULL) OR ([State] = @Original_State)) AND ((@IsNull_ZipCode = 1 AND [ZipCode] IS NULL) OR ([ZipCode] = @Original_ZipCode)) AND ((@IsNull_ContactNo = 1 AND [ContactNo] IS NULL) OR ([ContactNo] = @Original_ContactNo)) AND ((@IsNull_EmailID = 1 AND [EmailID] IS NULL) OR ([EmailID] = @Original_EmailID)) AND ((@IsNull_AccountNumber = 1 AND [AccountNumber] IS NULL) OR ([AccountNumber] = @Original_AccountNumber)) AND ((@IsNull_AccountName = 1 AND [AccountName] IS NULL) OR ([AccountName] = @Original_AccountName)) AND ((@IsNull_Bank = 1 AND [Bank] IS NULL) OR ([Bank] = @Original_Bank)) AND ((@IsNull_Branch = 1 AND [Branch] IS NULL) OR ([Branch] = @Original_Branch)) AND ((@IsNull_IFSCCode = 1 AND [IFSCCode] IS NULL) OR ([IFSCCode] = @Original_IFSCCode)) AND ((@IsNull_GSTIN = 1 AND [GSTIN] IS NULL) OR ([GSTIN] = @Original_GSTIN)) AND ((@IsNull_PAN = 1 AND [PAN] IS NULL) OR ([PAN] = @Original_PAN)) AND ((@IsNull_CIN = 1 AND [CIN] IS NULL) OR ([CIN] = @Original_CIN)))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CustomerID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_AccountNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountNumber", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AccountNumber", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountNumber", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_AccountName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AccountName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Bank", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Bank", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Bank", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Bank", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Branch", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Branch", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Branch", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Branch", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_IFSCCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IFSCCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_GSTIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_GSTIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_PAN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PAN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PAN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PAN", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_CIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Customer] ([ID], [CustomerID], [Name], [Address], [City], [State], [ZipCode], [ContactNo], [EmailID], [Remarks], [AccountNumber], [AccountName], [Bank], [Branch], [IFSCCode], [GSTIN], [PAN], [CIN]) VALUES (@ID, @CustomerID, @Name, @Address, @City, @State, @ZipCode, @ContactNo, @EmailID, @Remarks, @AccountNumber, @AccountName, @Bank, @Branch, @IFSCCode, @GSTIN, @PAN, @CIN);" & vbCrLf & "SELECT ID, CustomerID, Name, Address, City, State, ZipCode, ContactNo, EmailID, Remarks, AccountNumber, AccountName, Bank, Branch, IFSCCode, GSTIN, PAN, CIN FROM Customer WHERE (ID = @ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CustomerID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@City", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ZipCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AccountNumber", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountNumber", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AccountName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Bank", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Bank", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Branch", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Branch", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@IFSCCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GSTIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PAN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PAN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Customer] SET [ID] = @ID, [CustomerID] = @CustomerID, [Name] = @Name, [Address] = @Address, [City] = @City, [State] = @State, [ZipCode] = @ZipCode, [ContactNo] = @ContactNo, [EmailID] = @EmailID, [Remarks] = @Remarks, [AccountNumber] = @AccountNumber, [AccountName] = @AccountName, [Bank] = @Bank, [Branch] = @Branch, [IFSCCode] = @IFSCCode, [GSTIN] = @GSTIN, [PAN] = @PAN, [CIN] = @CIN WHERE (([ID] = @Original_ID) AND ((@IsNull_CustomerID = 1 AND [CustomerID] IS NULL) OR ([CustomerID] = @Original_CustomerID)) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_Address = 1 AND [Address] IS NULL) OR ([Address] = @Original_Address)) AND ((@IsNull_City = 1 AND [City] IS NULL) OR ([City] = @Original_City)) AND ((@IsNull_State = 1 AND [State] IS NULL) OR ([State] = @Original_State)) AND ((@IsNull_ZipCode = 1 AND [ZipCode] IS NULL) OR ([ZipCode] = @Original_ZipCode)) AND ((@IsNull_ContactNo = 1 AND [ContactNo] IS NULL) OR ([ContactNo] = @Original_ContactNo)) AND ((@IsNull_EmailID = 1 AND [EmailID] IS NULL) OR ([EmailID] = @Original_EmailID)) AND ((@IsNull_AccountNumber = 1 AND [AccountNumber] IS NULL) OR ([AccountNumber] = @Original_AccountNumber)) AND ((@IsNull_AccountName = 1 AND [AccountName] IS NULL) OR ([AccountName] = @Original_AccountName)) AND ((@IsNull_Bank = 1 AND [Bank] IS NULL) OR ([Bank] = @Original_Bank)) AND ((@IsNull_Branch = 1 AND [Branch] IS NULL) OR ([Branch] = @Original_Branch)) AND ((@IsNull_IFSCCode = 1 AND [IFSCCode] IS NULL) OR ([IFSCCode] = @Original_IFSCCode)) AND ((@IsNull_GSTIN = 1 AND [GSTIN] IS NULL) OR ([GSTIN] = @Original_GSTIN)) AND ((@IsNull_PAN = 1 AND [PAN] IS NULL) OR ([PAN] = @Original_PAN)) AND ((@IsNull_CIN = 1 AND [CIN] IS NULL) OR ([CIN] = @Original_CIN)));" & vbCrLf & "SELECT ID, CustomerID, Name, Address, City, State, ZipCode, ContactNo, EmailID, Remarks, AccountNumber, AccountName, Bank, Branch, IFSCCode, GSTIN, PAN, CIN FROM Customer WHERE (ID = @ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CustomerID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Address", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Address", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@City", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "City", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@State", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "State", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ZipCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ZipCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ContactNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ContactNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EmailID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "EmailID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AccountNumber", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountNumber", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AccountName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Bank", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Bank", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Branch", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Branch", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IFSCCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GSTIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PAN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PAN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CustomerID", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Original, False, Nothing, "", "", ""))
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
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_AccountNumber", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountNumber", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AccountNumber", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountNumber", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_AccountName", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AccountName", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "AccountName", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Bank", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Bank", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Bank", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Bank", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Branch", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Branch", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Branch", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Branch", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_IFSCCode", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IFSCCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "IFSCCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_GSTIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_GSTIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "GSTIN", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_PAN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "PAN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PAN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PAN", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_CIN", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CIN", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "CIN", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E3F8 RID: 58360 RVA: 0x000652E4 File Offset: 0x000634E4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E3F9 RID: 58361 RVA: 0x00871140 File Offset: 0x0086F340
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT ID, CustomerID, Name, Address, City, State, ZipCode, ContactNo, EmailID, Remarks, AccountNumber, AccountName, Bank, Branch, IFSCCode, GSTIN, PAN, CIN FROM dbo.Customer"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E3FA RID: 58362 RVA: 0x008711A0 File Offset: 0x0086F3A0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.CustomerDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E3FB RID: 58363 RVA: 0x008711E8 File Offset: 0x0086F3E8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.CustomerDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim customerDataTable As Inventory_DBDataSet.CustomerDataTable = New Inventory_DBDataSet.CustomerDataTable()
			Me.Adapter.Fill(customerDataTable)
			Return customerDataTable
		End Function

		' Token: 0x0600E3FC RID: 58364 RVA: 0x00871224 File Offset: 0x0086F424
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.CustomerDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E3FD RID: 58365 RVA: 0x00871244 File Offset: 0x0086F444
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Customer")
		End Function

		' Token: 0x0600E3FE RID: 58366 RVA: 0x00871268 File Offset: 0x0086F468
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E3FF RID: 58367 RVA: 0x00871290 File Offset: 0x0086F490
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E400 RID: 58368 RVA: 0x008712B0 File Offset: 0x0086F4B0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_ID As Integer, Original_CustomerID As String, Original_Name As String, Original_Address As String, Original_City As String, Original_State As String, Original_ZipCode As String, Original_ContactNo As String, Original_EmailID As String, Original_AccountNumber As String, Original_AccountName As String, Original_Bank As String, Original_Branch As String, Original_IFSCCode As String, Original_GSTIN As String, Original_PAN As String, Original_CIN As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_ID
			Dim flag As Boolean = Original_CustomerID = Nothing
			If flag Then
				Me.Adapter.DeleteCommand.Parameters(1).Value = 1
				Me.Adapter.DeleteCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(1).Value = 0
				Me.Adapter.DeleteCommand.Parameters(2).Value = Original_CustomerID
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
			Dim flag9 As Boolean = Original_AccountNumber = Nothing
			If flag9 Then
				Me.Adapter.DeleteCommand.Parameters(17).Value = 1
				Me.Adapter.DeleteCommand.Parameters(18).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(17).Value = 0
				Me.Adapter.DeleteCommand.Parameters(18).Value = Original_AccountNumber
			End If
			Dim flag10 As Boolean = Original_AccountName = Nothing
			If flag10 Then
				Me.Adapter.DeleteCommand.Parameters(19).Value = 1
				Me.Adapter.DeleteCommand.Parameters(20).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(19).Value = 0
				Me.Adapter.DeleteCommand.Parameters(20).Value = Original_AccountName
			End If
			Dim flag11 As Boolean = Original_Bank = Nothing
			If flag11 Then
				Me.Adapter.DeleteCommand.Parameters(21).Value = 1
				Me.Adapter.DeleteCommand.Parameters(22).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(21).Value = 0
				Me.Adapter.DeleteCommand.Parameters(22).Value = Original_Bank
			End If
			Dim flag12 As Boolean = Original_Branch = Nothing
			If flag12 Then
				Me.Adapter.DeleteCommand.Parameters(23).Value = 1
				Me.Adapter.DeleteCommand.Parameters(24).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(23).Value = 0
				Me.Adapter.DeleteCommand.Parameters(24).Value = Original_Branch
			End If
			Dim flag13 As Boolean = Original_IFSCCode = Nothing
			If flag13 Then
				Me.Adapter.DeleteCommand.Parameters(25).Value = 1
				Me.Adapter.DeleteCommand.Parameters(26).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(25).Value = 0
				Me.Adapter.DeleteCommand.Parameters(26).Value = Original_IFSCCode
			End If
			Dim flag14 As Boolean = Original_GSTIN = Nothing
			If flag14 Then
				Me.Adapter.DeleteCommand.Parameters(27).Value = 1
				Me.Adapter.DeleteCommand.Parameters(28).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(27).Value = 0
				Me.Adapter.DeleteCommand.Parameters(28).Value = Original_GSTIN
			End If
			Dim flag15 As Boolean = Original_PAN = Nothing
			If flag15 Then
				Me.Adapter.DeleteCommand.Parameters(29).Value = 1
				Me.Adapter.DeleteCommand.Parameters(30).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(29).Value = 0
				Me.Adapter.DeleteCommand.Parameters(30).Value = Original_PAN
			End If
			Dim flag16 As Boolean = Original_CIN = Nothing
			If flag16 Then
				Me.Adapter.DeleteCommand.Parameters(31).Value = 1
				Me.Adapter.DeleteCommand.Parameters(32).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(31).Value = 0
				Me.Adapter.DeleteCommand.Parameters(32).Value = Original_CIN
			End If
			Dim previousConnectionState As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag17 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag17 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag18 As Boolean = previousConnectionState = ConnectionState.Closed
				If flag18 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E401 RID: 58369 RVA: 0x00871CD8 File Offset: 0x0086FED8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(ID As Integer, CustomerID As String, Name As String, Address As String, City As String, State As String, ZipCode As String, ContactNo As String, EmailID As String, Remarks As String, AccountNumber As String, AccountName As String, Bank As String, Branch As String, IFSCCode As String, GSTIN As String, PAN As String, CIN As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = ID
			Dim flag As Boolean = CustomerID = Nothing
			If flag Then
				Me.Adapter.InsertCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(1).Value = CustomerID
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
			Dim flag10 As Boolean = AccountNumber = Nothing
			If flag10 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = AccountNumber
			End If
			Dim flag11 As Boolean = AccountName = Nothing
			If flag11 Then
				Me.Adapter.InsertCommand.Parameters(11).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(11).Value = AccountName
			End If
			Dim flag12 As Boolean = Bank = Nothing
			If flag12 Then
				Me.Adapter.InsertCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(12).Value = Bank
			End If
			Dim flag13 As Boolean = Branch = Nothing
			If flag13 Then
				Me.Adapter.InsertCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(13).Value = Branch
			End If
			Dim flag14 As Boolean = IFSCCode = Nothing
			If flag14 Then
				Me.Adapter.InsertCommand.Parameters(14).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(14).Value = IFSCCode
			End If
			Dim flag15 As Boolean = GSTIN = Nothing
			If flag15 Then
				Me.Adapter.InsertCommand.Parameters(15).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(15).Value = GSTIN
			End If
			Dim flag16 As Boolean = PAN = Nothing
			If flag16 Then
				Me.Adapter.InsertCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(16).Value = PAN
			End If
			Dim flag17 As Boolean = CIN = Nothing
			If flag17 Then
				Me.Adapter.InsertCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(17).Value = CIN
			End If
			Dim previousConnectionState As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag18 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag18 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag19 As Boolean = previousConnectionState = ConnectionState.Closed
				If flag19 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E402 RID: 58370 RVA: 0x008722F0 File Offset: 0x008704F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ID As Integer, CustomerID As String, Name As String, Address As String, City As String, State As String, ZipCode As String, ContactNo As String, EmailID As String, Remarks As String, AccountNumber As String, AccountName As String, Bank As String, Branch As String, IFSCCode As String, GSTIN As String, PAN As String, CIN As String, Original_ID As Integer, Original_CustomerID As String, Original_Name As String, Original_Address As String, Original_City As String, Original_State As String, Original_ZipCode As String, Original_ContactNo As String, Original_EmailID As String, Original_AccountNumber As String, Original_AccountName As String, Original_Bank As String, Original_Branch As String, Original_IFSCCode As String, Original_GSTIN As String, Original_PAN As String, Original_CIN As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = ID
			Dim flag As Boolean = CustomerID = Nothing
			If flag Then
				Me.Adapter.UpdateCommand.Parameters(1).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(1).Value = CustomerID
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
			Dim flag10 As Boolean = AccountNumber = Nothing
			If flag10 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = AccountNumber
			End If
			Dim flag11 As Boolean = AccountName = Nothing
			If flag11 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = AccountName
			End If
			Dim flag12 As Boolean = Bank = Nothing
			If flag12 Then
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(12).Value = Bank
			End If
			Dim flag13 As Boolean = Branch = Nothing
			If flag13 Then
				Me.Adapter.UpdateCommand.Parameters(13).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(13).Value = Branch
			End If
			Dim flag14 As Boolean = IFSCCode = Nothing
			If flag14 Then
				Me.Adapter.UpdateCommand.Parameters(14).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(14).Value = IFSCCode
			End If
			Dim flag15 As Boolean = GSTIN = Nothing
			If flag15 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = GSTIN
			End If
			Dim flag16 As Boolean = PAN = Nothing
			If flag16 Then
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(16).Value = PAN
			End If
			Dim flag17 As Boolean = CIN = Nothing
			If flag17 Then
				Me.Adapter.UpdateCommand.Parameters(17).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(17).Value = CIN
			End If
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_ID
			Dim flag18 As Boolean = Original_CustomerID = Nothing
			If flag18 Then
				Me.Adapter.UpdateCommand.Parameters(19).Value = 1
				Me.Adapter.UpdateCommand.Parameters(20).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(19).Value = 0
				Me.Adapter.UpdateCommand.Parameters(20).Value = Original_CustomerID
			End If
			Dim flag19 As Boolean = Original_Name = Nothing
			If flag19 Then
				Me.Adapter.UpdateCommand.Parameters(21).Value = 1
				Me.Adapter.UpdateCommand.Parameters(22).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(21).Value = 0
				Me.Adapter.UpdateCommand.Parameters(22).Value = Original_Name
			End If
			Dim flag20 As Boolean = Original_Address = Nothing
			If flag20 Then
				Me.Adapter.UpdateCommand.Parameters(23).Value = 1
				Me.Adapter.UpdateCommand.Parameters(24).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(23).Value = 0
				Me.Adapter.UpdateCommand.Parameters(24).Value = Original_Address
			End If
			Dim flag21 As Boolean = Original_City = Nothing
			If flag21 Then
				Me.Adapter.UpdateCommand.Parameters(25).Value = 1
				Me.Adapter.UpdateCommand.Parameters(26).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(25).Value = 0
				Me.Adapter.UpdateCommand.Parameters(26).Value = Original_City
			End If
			Dim flag22 As Boolean = Original_State = Nothing
			If flag22 Then
				Me.Adapter.UpdateCommand.Parameters(27).Value = 1
				Me.Adapter.UpdateCommand.Parameters(28).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(27).Value = 0
				Me.Adapter.UpdateCommand.Parameters(28).Value = Original_State
			End If
			Dim flag23 As Boolean = Original_ZipCode = Nothing
			If flag23 Then
				Me.Adapter.UpdateCommand.Parameters(29).Value = 1
				Me.Adapter.UpdateCommand.Parameters(30).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(29).Value = 0
				Me.Adapter.UpdateCommand.Parameters(30).Value = Original_ZipCode
			End If
			Dim flag24 As Boolean = Original_ContactNo = Nothing
			If flag24 Then
				Me.Adapter.UpdateCommand.Parameters(31).Value = 1
				Me.Adapter.UpdateCommand.Parameters(32).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(31).Value = 0
				Me.Adapter.UpdateCommand.Parameters(32).Value = Original_ContactNo
			End If
			Dim flag25 As Boolean = Original_EmailID = Nothing
			If flag25 Then
				Me.Adapter.UpdateCommand.Parameters(33).Value = 1
				Me.Adapter.UpdateCommand.Parameters(34).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(33).Value = 0
				Me.Adapter.UpdateCommand.Parameters(34).Value = Original_EmailID
			End If
			Dim flag26 As Boolean = Original_AccountNumber = Nothing
			If flag26 Then
				Me.Adapter.UpdateCommand.Parameters(35).Value = 1
				Me.Adapter.UpdateCommand.Parameters(36).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(35).Value = 0
				Me.Adapter.UpdateCommand.Parameters(36).Value = Original_AccountNumber
			End If
			Dim flag27 As Boolean = Original_AccountName = Nothing
			If flag27 Then
				Me.Adapter.UpdateCommand.Parameters(37).Value = 1
				Me.Adapter.UpdateCommand.Parameters(38).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(37).Value = 0
				Me.Adapter.UpdateCommand.Parameters(38).Value = Original_AccountName
			End If
			Dim flag28 As Boolean = Original_Bank = Nothing
			If flag28 Then
				Me.Adapter.UpdateCommand.Parameters(39).Value = 1
				Me.Adapter.UpdateCommand.Parameters(40).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(39).Value = 0
				Me.Adapter.UpdateCommand.Parameters(40).Value = Original_Bank
			End If
			Dim flag29 As Boolean = Original_Branch = Nothing
			If flag29 Then
				Me.Adapter.UpdateCommand.Parameters(41).Value = 1
				Me.Adapter.UpdateCommand.Parameters(42).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(41).Value = 0
				Me.Adapter.UpdateCommand.Parameters(42).Value = Original_Branch
			End If
			Dim flag30 As Boolean = Original_IFSCCode = Nothing
			If flag30 Then
				Me.Adapter.UpdateCommand.Parameters(43).Value = 1
				Me.Adapter.UpdateCommand.Parameters(44).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(43).Value = 0
				Me.Adapter.UpdateCommand.Parameters(44).Value = Original_IFSCCode
			End If
			Dim flag31 As Boolean = Original_GSTIN = Nothing
			If flag31 Then
				Me.Adapter.UpdateCommand.Parameters(45).Value = 1
				Me.Adapter.UpdateCommand.Parameters(46).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(45).Value = 0
				Me.Adapter.UpdateCommand.Parameters(46).Value = Original_GSTIN
			End If
			Dim flag32 As Boolean = Original_PAN = Nothing
			If flag32 Then
				Me.Adapter.UpdateCommand.Parameters(47).Value = 1
				Me.Adapter.UpdateCommand.Parameters(48).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(47).Value = 0
				Me.Adapter.UpdateCommand.Parameters(48).Value = Original_PAN
			End If
			Dim flag33 As Boolean = Original_CIN = Nothing
			If flag33 Then
				Me.Adapter.UpdateCommand.Parameters(49).Value = 1
				Me.Adapter.UpdateCommand.Parameters(50).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(49).Value = 0
				Me.Adapter.UpdateCommand.Parameters(50).Value = Original_CIN
			End If
			Dim previousConnectionState As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag34 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag34 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag35 As Boolean = previousConnectionState = ConnectionState.Closed
				If flag35 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E403 RID: 58371 RVA: 0x0087329C File Offset: 0x0087149C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(CustomerID As String, Name As String, Address As String, City As String, State As String, ZipCode As String, ContactNo As String, EmailID As String, Remarks As String, AccountNumber As String, AccountName As String, Bank As String, Branch As String, IFSCCode As String, GSTIN As String, PAN As String, CIN As String, Original_ID As Integer, Original_CustomerID As String, Original_Name As String, Original_Address As String, Original_City As String, Original_State As String, Original_ZipCode As String, Original_ContactNo As String, Original_EmailID As String, Original_AccountNumber As String, Original_AccountName As String, Original_Bank As String, Original_Branch As String, Original_IFSCCode As String, Original_GSTIN As String, Original_PAN As String, Original_CIN As String) As Integer
			Return Me.Update(Original_ID, CustomerID, Name, Address, City, State, ZipCode, ContactNo, EmailID, Remarks, AccountNumber, AccountName, Bank, Branch, IFSCCode, GSTIN, PAN, CIN, Original_ID, Original_CustomerID, Original_Name, Original_Address, Original_City, Original_State, Original_ZipCode, Original_ContactNo, Original_EmailID, Original_AccountNumber, Original_AccountName, Original_Bank, Original_Branch, Original_IFSCCode, Original_GSTIN, Original_PAN, Original_CIN)
		End Function

		' Token: 0x0400583F RID: 22591
		Private _connection As SqlConnection

		' Token: 0x04005840 RID: 22592
		Private _transaction As SqlTransaction

		' Token: 0x04005841 RID: 22593
		Private _commandCollection As SqlCommand()

		' Token: 0x04005842 RID: 22594
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
