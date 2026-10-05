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
	' Token: 0x02000464 RID: 1124
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class ServiceTableAdapter
		Inherits Component

		' Token: 0x17005881 RID: 22657
		' (get) Token: 0x0600E65C RID: 58972 RVA: 0x00065B23 File Offset: 0x00063D23
		' (set) Token: 0x0600E65D RID: 58973 RVA: 0x00065B2D File Offset: 0x00063D2D
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E65E RID: 58974 RVA: 0x00065B36 File Offset: 0x00063D36
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005882 RID: 22658
		' (get) Token: 0x0600E65F RID: 58975 RVA: 0x008ADD1C File Offset: 0x008ABF1C
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

		' Token: 0x17005883 RID: 22659
		' (get) Token: 0x0600E660 RID: 58976 RVA: 0x008ADD4C File Offset: 0x008ABF4C
		' (set) Token: 0x0600E661 RID: 58977 RVA: 0x008ADD7C File Offset: 0x008ABF7C
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

		' Token: 0x17005884 RID: 22660
		' (get) Token: 0x0600E662 RID: 58978 RVA: 0x008ADE40 File Offset: 0x008AC040
		' (set) Token: 0x0600E663 RID: 58979 RVA: 0x008ADE58 File Offset: 0x008AC058
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

		' Token: 0x17005885 RID: 22661
		' (get) Token: 0x0600E664 RID: 58980 RVA: 0x008ADF40 File Offset: 0x008AC140
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

		' Token: 0x17005886 RID: 22662
		' (get) Token: 0x0600E665 RID: 58981 RVA: 0x008ADF70 File Offset: 0x008AC170
		' (set) Token: 0x0600E666 RID: 58982 RVA: 0x00065B48 File Offset: 0x00063D48
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

		' Token: 0x0600E667 RID: 58983 RVA: 0x008ADF88 File Offset: 0x008AC188
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Service"
			dataTableMapping.ColumnMappings.Add("S_ID", "S_ID")
			dataTableMapping.ColumnMappings.Add("ServiceCode", "ServiceCode")
			dataTableMapping.ColumnMappings.Add("CustomerID", "CustomerID")
			dataTableMapping.ColumnMappings.Add("ServiceType", "ServiceType")
			dataTableMapping.ColumnMappings.Add("ServiceCreationDate", "ServiceCreationDate")
			dataTableMapping.ColumnMappings.Add("ItemDescription", "ItemDescription")
			dataTableMapping.ColumnMappings.Add("ProblemDescription", "ProblemDescription")
			dataTableMapping.ColumnMappings.Add("ChargesQuote", "ChargesQuote")
			dataTableMapping.ColumnMappings.Add("AdvanceDeposit", "AdvanceDeposit")
			dataTableMapping.ColumnMappings.Add("EstimatedRepairDate", "EstimatedRepairDate")
			dataTableMapping.ColumnMappings.Add("Remarks", "Remarks")
			dataTableMapping.ColumnMappings.Add("Status", "Status")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Service] WHERE (([S_ID] = @Original_S_ID) AND ([ServiceCode] = @Original_ServiceCode) AND ([CustomerID] = @Original_CustomerID) AND ((@IsNull_ServiceType = 1 AND [ServiceType] IS NULL) OR ([ServiceType] = @Original_ServiceType)) AND ([ServiceCreationDate] = @Original_ServiceCreationDate) AND ([ChargesQuote] = @Original_ChargesQuote) AND ([AdvanceDeposit] = @Original_AdvanceDeposit) AND ([EstimatedRepairDate] = @Original_EstimatedRepairDate) AND ([Status] = @Original_Status))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_S_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "S_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ServiceCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServiceCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_ServiceType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ServiceType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ServiceType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServiceType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ServiceCreationDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ServiceCreationDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ChargesQuote", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ChargesQuote", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_AdvanceDeposit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "AdvanceDeposit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_EstimatedRepairDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EstimatedRepairDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Status", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Service] ([S_ID], [ServiceCode], [CustomerID], [ServiceType], [ServiceCreationDate], [ItemDescription], [ProblemDescription], [ChargesQuote], [AdvanceDeposit], [EstimatedRepairDate], [Remarks], [Status]) VALUES (@S_ID, @ServiceCode, @CustomerID, @ServiceType, @ServiceCreationDate, @ItemDescription, @ProblemDescription, @ChargesQuote, @AdvanceDeposit, @EstimatedRepairDate, @Remarks, @Status);" & vbCrLf & "SELECT S_ID, ServiceCode, CustomerID, ServiceType, ServiceCreationDate, ItemDescription, ProblemDescription, ChargesQuote, AdvanceDeposit, EstimatedRepairDate, Remarks, Status FROM Service WHERE (S_ID = @S_ID)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@S_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "S_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ServiceCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServiceCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ServiceType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServiceType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ServiceCreationDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ServiceCreationDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ItemDescription", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ItemDescription", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ProblemDescription", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ProblemDescription", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@ChargesQuote", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ChargesQuote", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@AdvanceDeposit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "AdvanceDeposit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@EstimatedRepairDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EstimatedRepairDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Status", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Service] SET [S_ID] = @S_ID, [ServiceCode] = @ServiceCode, [CustomerID] = @CustomerID, [ServiceType] = @ServiceType, [ServiceCreationDate] = @ServiceCreationDate, [ItemDescription] = @ItemDescription, [ProblemDescription] = @ProblemDescription, [ChargesQuote] = @ChargesQuote, [AdvanceDeposit] = @AdvanceDeposit, [EstimatedRepairDate] = @EstimatedRepairDate, [Remarks] = @Remarks, [Status] = @Status WHERE (([S_ID] = @Original_S_ID) AND ([ServiceCode] = @Original_ServiceCode) AND ([CustomerID] = @Original_CustomerID) AND ((@IsNull_ServiceType = 1 AND [ServiceType] IS NULL) OR ([ServiceType] = @Original_ServiceType)) AND ([ServiceCreationDate] = @Original_ServiceCreationDate) AND ([ChargesQuote] = @Original_ChargesQuote) AND ([AdvanceDeposit] = @Original_AdvanceDeposit) AND ([EstimatedRepairDate] = @Original_EstimatedRepairDate) AND ([Status] = @Original_Status));" & vbCrLf & "SELECT S_ID, ServiceCode, CustomerID, ServiceType, ServiceCreationDate, ItemDescription, ProblemDescription, ChargesQuote, AdvanceDeposit, EstimatedRepairDate, Remarks, Status FROM Service WHERE (S_ID = @S_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@S_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "S_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ServiceCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServiceCode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ServiceType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServiceType", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ServiceCreationDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ServiceCreationDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ItemDescription", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ItemDescription", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ProblemDescription", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ProblemDescription", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ChargesQuote", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ChargesQuote", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@AdvanceDeposit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "AdvanceDeposit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@EstimatedRepairDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EstimatedRepairDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Remarks", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Remarks", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Status", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_S_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "S_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ServiceCode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServiceCode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CustomerID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "CustomerID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_ServiceType", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ServiceType", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ServiceType", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "ServiceType", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ServiceCreationDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "ServiceCreationDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ChargesQuote", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "ChargesQuote", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_AdvanceDeposit", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "AdvanceDeposit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_EstimatedRepairDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "EstimatedRepairDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Status", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Status", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E668 RID: 58984 RVA: 0x00065B52 File Offset: 0x00063D52
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E669 RID: 58985 RVA: 0x008AECE4 File Offset: 0x008ACEE4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT S_ID, ServiceCode, CustomerID, ServiceType, ServiceCreationDate, ItemDescription, ProblemDescription, ChargesQuote, AdvanceDeposit, EstimatedRepairDate, Remarks, Status FROM dbo.Service"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E66A RID: 58986 RVA: 0x008AED44 File Offset: 0x008ACF44
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.ServiceDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E66B RID: 58987 RVA: 0x008AED8C File Offset: 0x008ACF8C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.ServiceDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim serviceDataTable As Inventory_DBDataSet.ServiceDataTable = New Inventory_DBDataSet.ServiceDataTable()
			Me.Adapter.Fill(serviceDataTable)
			Return serviceDataTable
		End Function

		' Token: 0x0600E66C RID: 58988 RVA: 0x008AEDC8 File Offset: 0x008ACFC8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.ServiceDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E66D RID: 58989 RVA: 0x008AEDE8 File Offset: 0x008ACFE8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Service")
		End Function

		' Token: 0x0600E66E RID: 58990 RVA: 0x008AEE0C File Offset: 0x008AD00C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E66F RID: 58991 RVA: 0x008AEE34 File Offset: 0x008AD034
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E670 RID: 58992 RVA: 0x008AEE54 File Offset: 0x008AD054
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_S_ID As Integer, Original_ServiceCode As String, Original_CustomerID As Integer, Original_ServiceType As String, Original_ServiceCreationDate As DateTime, Original_ChargesQuote As Decimal, Original_AdvanceDeposit As Decimal, Original_EstimatedRepairDate As DateTime, Original_Status As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_S_ID
			Dim flag As Boolean = Original_ServiceCode = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_ServiceCode")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_ServiceCode
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_CustomerID
			Dim flag2 As Boolean = Original_ServiceType = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(3).Value = 1
				Me.Adapter.DeleteCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(3).Value = 0
				Me.Adapter.DeleteCommand.Parameters(4).Value = Original_ServiceType
			End If
			Me.Adapter.DeleteCommand.Parameters(5).Value = Original_ServiceCreationDate
			Me.Adapter.DeleteCommand.Parameters(6).Value = Original_ChargesQuote
			Me.Adapter.DeleteCommand.Parameters(7).Value = Original_AdvanceDeposit
			Me.Adapter.DeleteCommand.Parameters(8).Value = Original_EstimatedRepairDate
			Dim flag3 As Boolean = Original_Status = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_Status")
			End If
			Me.Adapter.DeleteCommand.Parameters(9).Value = Original_Status
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag4 As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag4 Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag5 As Boolean = state = ConnectionState.Closed
				If flag5 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E671 RID: 58993 RVA: 0x008AF0CC File Offset: 0x008AD2CC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(S_ID As Integer, ServiceCode As String, CustomerID As Integer, ServiceType As String, ServiceCreationDate As DateTime, ItemDescription As String, ProblemDescription As String, ChargesQuote As Decimal, AdvanceDeposit As Decimal, EstimatedRepairDate As DateTime, Remarks As String, Status As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = S_ID
			Dim flag As Boolean = ServiceCode = Nothing
			If flag Then
				Throw New ArgumentNullException("ServiceCode")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = ServiceCode
			Me.Adapter.InsertCommand.Parameters(2).Value = CustomerID
			Dim flag2 As Boolean = ServiceType = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = ServiceType
			End If
			Me.Adapter.InsertCommand.Parameters(4).Value = ServiceCreationDate
			Dim flag3 As Boolean = ItemDescription = Nothing
			If flag3 Then
				Throw New ArgumentNullException("ItemDescription")
			End If
			Me.Adapter.InsertCommand.Parameters(5).Value = ItemDescription
			Dim flag4 As Boolean = ProblemDescription = Nothing
			If flag4 Then
				Me.Adapter.InsertCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(6).Value = ProblemDescription
			End If
			Me.Adapter.InsertCommand.Parameters(7).Value = ChargesQuote
			Me.Adapter.InsertCommand.Parameters(8).Value = AdvanceDeposit
			Me.Adapter.InsertCommand.Parameters(9).Value = EstimatedRepairDate
			Dim flag5 As Boolean = Remarks = Nothing
			If flag5 Then
				Me.Adapter.InsertCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(10).Value = Remarks
			End If
			Dim flag6 As Boolean = Status = Nothing
			If flag6 Then
				Throw New ArgumentNullException("Status")
			End If
			Me.Adapter.InsertCommand.Parameters(11).Value = Status
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

		' Token: 0x0600E672 RID: 58994 RVA: 0x008AF3D8 File Offset: 0x008AD5D8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(S_ID As Integer, ServiceCode As String, CustomerID As Integer, ServiceType As String, ServiceCreationDate As DateTime, ItemDescription As String, ProblemDescription As String, ChargesQuote As Decimal, AdvanceDeposit As Decimal, EstimatedRepairDate As DateTime, Remarks As String, Status As String, Original_S_ID As Integer, Original_ServiceCode As String, Original_CustomerID As Integer, Original_ServiceType As String, Original_ServiceCreationDate As DateTime, Original_ChargesQuote As Decimal, Original_AdvanceDeposit As Decimal, Original_EstimatedRepairDate As DateTime, Original_Status As String) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = S_ID
			Dim flag As Boolean = ServiceCode = Nothing
			If flag Then
				Throw New ArgumentNullException("ServiceCode")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = ServiceCode
			Me.Adapter.UpdateCommand.Parameters(2).Value = CustomerID
			Dim flag2 As Boolean = ServiceType = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = ServiceType
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = ServiceCreationDate
			Dim flag3 As Boolean = ItemDescription = Nothing
			If flag3 Then
				Throw New ArgumentNullException("ItemDescription")
			End If
			Me.Adapter.UpdateCommand.Parameters(5).Value = ItemDescription
			Dim flag4 As Boolean = ProblemDescription = Nothing
			If flag4 Then
				Me.Adapter.UpdateCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(6).Value = ProblemDescription
			End If
			Me.Adapter.UpdateCommand.Parameters(7).Value = ChargesQuote
			Me.Adapter.UpdateCommand.Parameters(8).Value = AdvanceDeposit
			Me.Adapter.UpdateCommand.Parameters(9).Value = EstimatedRepairDate
			Dim flag5 As Boolean = Remarks = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(10).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(10).Value = Remarks
			End If
			Dim flag6 As Boolean = Status = Nothing
			If flag6 Then
				Throw New ArgumentNullException("Status")
			End If
			Me.Adapter.UpdateCommand.Parameters(11).Value = Status
			Me.Adapter.UpdateCommand.Parameters(12).Value = Original_S_ID
			Dim flag7 As Boolean = Original_ServiceCode = Nothing
			If flag7 Then
				Throw New ArgumentNullException("Original_ServiceCode")
			End If
			Me.Adapter.UpdateCommand.Parameters(13).Value = Original_ServiceCode
			Me.Adapter.UpdateCommand.Parameters(14).Value = Original_CustomerID
			Dim flag8 As Boolean = Original_ServiceType = Nothing
			If flag8 Then
				Me.Adapter.UpdateCommand.Parameters(15).Value = 1
				Me.Adapter.UpdateCommand.Parameters(16).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(15).Value = 0
				Me.Adapter.UpdateCommand.Parameters(16).Value = Original_ServiceType
			End If
			Me.Adapter.UpdateCommand.Parameters(17).Value = Original_ServiceCreationDate
			Me.Adapter.UpdateCommand.Parameters(18).Value = Original_ChargesQuote
			Me.Adapter.UpdateCommand.Parameters(19).Value = Original_AdvanceDeposit
			Me.Adapter.UpdateCommand.Parameters(20).Value = Original_EstimatedRepairDate
			Dim flag9 As Boolean = Original_Status = Nothing
			If flag9 Then
				Throw New ArgumentNullException("Original_Status")
			End If
			Me.Adapter.UpdateCommand.Parameters(21).Value = Original_Status
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag10 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag10 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag11 As Boolean = state = ConnectionState.Closed
				If flag11 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E673 RID: 58995 RVA: 0x008AF8C0 File Offset: 0x008ADAC0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(ServiceCode As String, CustomerID As Integer, ServiceType As String, ServiceCreationDate As DateTime, ItemDescription As String, ProblemDescription As String, ChargesQuote As Decimal, AdvanceDeposit As Decimal, EstimatedRepairDate As DateTime, Remarks As String, Status As String, Original_S_ID As Integer, Original_ServiceCode As String, Original_CustomerID As Integer, Original_ServiceType As String, Original_ServiceCreationDate As DateTime, Original_ChargesQuote As Decimal, Original_AdvanceDeposit As Decimal, Original_EstimatedRepairDate As DateTime, Original_Status As String) As Integer
			Return Me.Update(Original_S_ID, ServiceCode, CustomerID, ServiceType, ServiceCreationDate, ItemDescription, ProblemDescription, ChargesQuote, AdvanceDeposit, EstimatedRepairDate, Remarks, Status, Original_S_ID, Original_ServiceCode, Original_CustomerID, Original_ServiceType, Original_ServiceCreationDate, Original_ChargesQuote, Original_AdvanceDeposit, Original_EstimatedRepairDate, Original_Status)
		End Function

		' Token: 0x040058C1 RID: 22721
		Private _connection As SqlConnection

		' Token: 0x040058C2 RID: 22722
		Private _transaction As SqlTransaction

		' Token: 0x040058C3 RID: 22723
		Private _commandCollection As SqlCommand()

		' Token: 0x040058C4 RID: 22724
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
