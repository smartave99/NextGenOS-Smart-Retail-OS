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
	' Token: 0x02000470 RID: 1136
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class VoucherTableAdapter
		Inherits Component

		' Token: 0x170058C9 RID: 22729
		' (get) Token: 0x0600E77C RID: 59260 RVA: 0x00065F07 File Offset: 0x00064107
		' (set) Token: 0x0600E77D RID: 59261 RVA: 0x00065F11 File Offset: 0x00064111
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E77E RID: 59262 RVA: 0x00065F1A File Offset: 0x0006411A
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170058CA RID: 22730
		' (get) Token: 0x0600E77F RID: 59263 RVA: 0x008C4764 File Offset: 0x008C2964
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

		' Token: 0x170058CB RID: 22731
		' (get) Token: 0x0600E780 RID: 59264 RVA: 0x008C4794 File Offset: 0x008C2994
		' (set) Token: 0x0600E781 RID: 59265 RVA: 0x008C47C4 File Offset: 0x008C29C4
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

		' Token: 0x170058CC RID: 22732
		' (get) Token: 0x0600E782 RID: 59266 RVA: 0x008C4888 File Offset: 0x008C2A88
		' (set) Token: 0x0600E783 RID: 59267 RVA: 0x008C48A0 File Offset: 0x008C2AA0
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

		' Token: 0x170058CD RID: 22733
		' (get) Token: 0x0600E784 RID: 59268 RVA: 0x008C4988 File Offset: 0x008C2B88
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

		' Token: 0x170058CE RID: 22734
		' (get) Token: 0x0600E785 RID: 59269 RVA: 0x008C49B8 File Offset: 0x008C2BB8
		' (set) Token: 0x0600E786 RID: 59270 RVA: 0x00065F2C File Offset: 0x0006412C
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

		' Token: 0x0600E787 RID: 59271 RVA: 0x008C49D0 File Offset: 0x008C2BD0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Voucher"
			dataTableMapping.ColumnMappings.Add("Id", "Id")
			dataTableMapping.ColumnMappings.Add("VoucherNo", "VoucherNo")
			dataTableMapping.ColumnMappings.Add("Name", "Name")
			dataTableMapping.ColumnMappings.Add("Date", "Date")
			dataTableMapping.ColumnMappings.Add("Details", "Details")
			dataTableMapping.ColumnMappings.Add("GrandTotal", "GrandTotal")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Voucher] WHERE (([Id] = @Original_Id) AND ([VoucherNo] = @Original_VoucherNo) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ([Date] = @Original_Date) AND ((@IsNull_Details = 1 AND [Details] IS NULL) OR ([Details] = @Original_Details)) AND ([GrandTotal] = @Original_GrandTotal))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_VoucherNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Name", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@IsNull_Details", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Details", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Details", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Details", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Voucher] ([Id], [VoucherNo], [Name], [Date], [Details], [GrandTotal]) VALUES (@Id, @VoucherNo, @Name, @Date, @Details, @GrandTotal);" & vbCrLf & "SELECT Id, VoucherNo, Name, Date, Details, GrandTotal FROM Voucher WHERE (Id = @Id)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@VoucherNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Details", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Details", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Voucher] SET [Id] = @Id, [VoucherNo] = @VoucherNo, [Name] = @Name, [Date] = @Date, [Details] = @Details, [GrandTotal] = @GrandTotal WHERE (([Id] = @Original_Id) AND ([VoucherNo] = @Original_VoucherNo) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ([Date] = @Original_Date) AND ((@IsNull_Details = 1 AND [Details] IS NULL) OR ([Details] = @Original_Details)) AND ([GrandTotal] = @Original_GrandTotal));" & vbCrLf & "SELECT Id, VoucherNo, Name, Date, Details, GrandTotal FROM Voucher WHERE (Id = @Id)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@VoucherNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Details", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Details", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Id", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_VoucherNo", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "VoucherNo", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Name", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Name", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Name", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Date", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "Date", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IsNull_Details", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "Details", DataRowVersion.Original, True, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Details", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Details", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_GrandTotal", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "GrandTotal", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E788 RID: 59272 RVA: 0x00065F36 File Offset: 0x00064136
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E789 RID: 59273 RVA: 0x008C52A0 File Offset: 0x008C34A0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Id, VoucherNo, Name, Date, Details, GrandTotal FROM dbo.Voucher"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E78A RID: 59274 RVA: 0x008C5300 File Offset: 0x008C3500
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.VoucherDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E78B RID: 59275 RVA: 0x008C5348 File Offset: 0x008C3548
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.VoucherDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim voucherDataTable As Inventory_DBDataSet.VoucherDataTable = New Inventory_DBDataSet.VoucherDataTable()
			Me.Adapter.Fill(voucherDataTable)
			Return voucherDataTable
		End Function

		' Token: 0x0600E78C RID: 59276 RVA: 0x008C5384 File Offset: 0x008C3584
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.VoucherDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E78D RID: 59277 RVA: 0x008C53A4 File Offset: 0x008C35A4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Voucher")
		End Function

		' Token: 0x0600E78E RID: 59278 RVA: 0x008C53C8 File Offset: 0x008C35C8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E78F RID: 59279 RVA: 0x008C53F0 File Offset: 0x008C35F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E790 RID: 59280 RVA: 0x008C5410 File Offset: 0x008C3610
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Id As Integer, Original_VoucherNo As String, Original_Name As String, Original_Date As DateTime, Original_Details As String, Original_GrandTotal As Decimal) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Id
			Dim flag As Boolean = Original_VoucherNo = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_VoucherNo")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_VoucherNo
			Dim flag2 As Boolean = Original_Name = Nothing
			If flag2 Then
				Me.Adapter.DeleteCommand.Parameters(2).Value = 1
				Me.Adapter.DeleteCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(2).Value = 0
				Me.Adapter.DeleteCommand.Parameters(3).Value = Original_Name
			End If
			Me.Adapter.DeleteCommand.Parameters(4).Value = Original_Date
			Dim flag3 As Boolean = Original_Details = Nothing
			If flag3 Then
				Me.Adapter.DeleteCommand.Parameters(5).Value = 1
				Me.Adapter.DeleteCommand.Parameters(6).Value = DBNull.Value
			Else
				Me.Adapter.DeleteCommand.Parameters(5).Value = 0
				Me.Adapter.DeleteCommand.Parameters(6).Value = Original_Details
			End If
			Me.Adapter.DeleteCommand.Parameters(7).Value = Original_GrandTotal
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

		' Token: 0x0600E791 RID: 59281 RVA: 0x008C5678 File Offset: 0x008C3878
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(Id As Integer, VoucherNo As String, Name As String, _Date As DateTime, Details As String, GrandTotal As Decimal) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = Id
			Dim flag As Boolean = VoucherNo = Nothing
			If flag Then
				Throw New ArgumentNullException("VoucherNo")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = VoucherNo
			Dim flag2 As Boolean = Name = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(2).Value = Name
			End If
			Me.Adapter.InsertCommand.Parameters(3).Value = _Date
			Dim flag3 As Boolean = Details = Nothing
			If flag3 Then
				Me.Adapter.InsertCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(4).Value = Details
			End If
			Me.Adapter.InsertCommand.Parameters(5).Value = GrandTotal
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag4 As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag4 Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag5 As Boolean = state = ConnectionState.Closed
				If flag5 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E792 RID: 59282 RVA: 0x008C5858 File Offset: 0x008C3A58
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Id As Integer, VoucherNo As String, Name As String, _Date As DateTime, Details As String, GrandTotal As Decimal, Original_Id As Integer, Original_VoucherNo As String, Original_Name As String, Original_Date As DateTime, Original_Details As String, Original_GrandTotal As Decimal) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = Id
			Dim flag As Boolean = VoucherNo = Nothing
			If flag Then
				Throw New ArgumentNullException("VoucherNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = VoucherNo
			Dim flag2 As Boolean = Name = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(2).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(2).Value = Name
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = _Date
			Dim flag3 As Boolean = Details = Nothing
			If flag3 Then
				Me.Adapter.UpdateCommand.Parameters(4).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(4).Value = Details
			End If
			Me.Adapter.UpdateCommand.Parameters(5).Value = GrandTotal
			Me.Adapter.UpdateCommand.Parameters(6).Value = Original_Id
			Dim flag4 As Boolean = Original_VoucherNo = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Original_VoucherNo")
			End If
			Me.Adapter.UpdateCommand.Parameters(7).Value = Original_VoucherNo
			Dim flag5 As Boolean = Original_Name = Nothing
			If flag5 Then
				Me.Adapter.UpdateCommand.Parameters(8).Value = 1
				Me.Adapter.UpdateCommand.Parameters(9).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(8).Value = 0
				Me.Adapter.UpdateCommand.Parameters(9).Value = Original_Name
			End If
			Me.Adapter.UpdateCommand.Parameters(10).Value = Original_Date
			Dim flag6 As Boolean = Original_Details = Nothing
			If flag6 Then
				Me.Adapter.UpdateCommand.Parameters(11).Value = 1
				Me.Adapter.UpdateCommand.Parameters(12).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(11).Value = 0
				Me.Adapter.UpdateCommand.Parameters(12).Value = Original_Details
			End If
			Me.Adapter.UpdateCommand.Parameters(13).Value = Original_GrandTotal
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag7 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag7 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag8 As Boolean = state = ConnectionState.Closed
				If flag8 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E793 RID: 59283 RVA: 0x008C5C08 File Offset: 0x008C3E08
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(VoucherNo As String, Name As String, _Date As DateTime, Details As String, GrandTotal As Decimal, Original_Id As Integer, Original_VoucherNo As String, Original_Name As String, Original_Date As DateTime, Original_Details As String, Original_GrandTotal As Decimal) As Integer
			Return Me.Update(Original_Id, VoucherNo, Name, _Date, Details, GrandTotal, Original_Id, Original_VoucherNo, Original_Name, Original_Date, Original_Details, Original_GrandTotal)
		End Function

		' Token: 0x040058FD RID: 22781
		Private _connection As SqlConnection

		' Token: 0x040058FE RID: 22782
		Private _transaction As SqlTransaction

		' Token: 0x040058FF RID: 22783
		Private _commandCollection As SqlCommand()

		' Token: 0x04005900 RID: 22784
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
