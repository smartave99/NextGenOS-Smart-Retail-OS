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
	' Token: 0x02000471 RID: 1137
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Voucher_OtherDetailsTableAdapter
		Inherits Component

		' Token: 0x170058CF RID: 22735
		' (get) Token: 0x0600E794 RID: 59284 RVA: 0x00065F5A File Offset: 0x0006415A
		' (set) Token: 0x0600E795 RID: 59285 RVA: 0x00065F64 File Offset: 0x00064164
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E796 RID: 59286 RVA: 0x00065F6D File Offset: 0x0006416D
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170058D0 RID: 22736
		' (get) Token: 0x0600E797 RID: 59287 RVA: 0x008C5C38 File Offset: 0x008C3E38
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

		' Token: 0x170058D1 RID: 22737
		' (get) Token: 0x0600E798 RID: 59288 RVA: 0x008C5C68 File Offset: 0x008C3E68
		' (set) Token: 0x0600E799 RID: 59289 RVA: 0x008C5C98 File Offset: 0x008C3E98
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

		' Token: 0x170058D2 RID: 22738
		' (get) Token: 0x0600E79A RID: 59290 RVA: 0x008C5D5C File Offset: 0x008C3F5C
		' (set) Token: 0x0600E79B RID: 59291 RVA: 0x008C5D74 File Offset: 0x008C3F74
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

		' Token: 0x170058D3 RID: 22739
		' (get) Token: 0x0600E79C RID: 59292 RVA: 0x008C5E5C File Offset: 0x008C405C
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

		' Token: 0x170058D4 RID: 22740
		' (get) Token: 0x0600E79D RID: 59293 RVA: 0x008C5E8C File Offset: 0x008C408C
		' (set) Token: 0x0600E79E RID: 59294 RVA: 0x00065F7F File Offset: 0x0006417F
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

		' Token: 0x0600E79F RID: 59295 RVA: 0x008C5EA4 File Offset: 0x008C40A4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Voucher_OtherDetails"
			dataTableMapping.ColumnMappings.Add("VD_ID", "VD_ID")
			dataTableMapping.ColumnMappings.Add("VoucherID", "VoucherID")
			dataTableMapping.ColumnMappings.Add("Particulars", "Particulars")
			dataTableMapping.ColumnMappings.Add("Amount", "Amount")
			dataTableMapping.ColumnMappings.Add("Note", "Note")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Voucher_OtherDetails] WHERE (([VD_ID] = @Original_VD_ID) AND ([VoucherID] = @Original_VoucherID) AND ([Particulars] = @Original_Particulars) AND ([Amount] = @Original_Amount))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_VD_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VD_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_VoucherID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VoucherID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Particulars", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Particulars", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Voucher_OtherDetails] ([VoucherID], [Particulars], [Amount], [Note]) VALUES (@VoucherID, @Particulars, @Amount, @Note);" & vbCrLf & "SELECT VD_ID, VoucherID, Particulars, Amount, Note FROM Voucher_OtherDetails WHERE (VD_ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@VoucherID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VoucherID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Particulars", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Particulars", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Note", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Note", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Voucher_OtherDetails] SET [VoucherID] = @VoucherID, [Particulars] = @Particulars, [Amount] = @Amount, [Note] = @Note WHERE (([VD_ID] = @Original_VD_ID) AND ([VoucherID] = @Original_VoucherID) AND ([Particulars] = @Original_Particulars) AND ([Amount] = @Original_Amount));" & vbCrLf & "SELECT VD_ID, VoucherID, Particulars, Amount, Note FROM Voucher_OtherDetails WHERE (VD_ID = @VD_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@VoucherID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VoucherID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Particulars", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Particulars", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Note", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "Note", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_VD_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VD_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_VoucherID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "VoucherID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Particulars", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Particulars", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Amount", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Amount", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@VD_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "VD_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E7A0 RID: 59296 RVA: 0x00065F89 File Offset: 0x00064189
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E7A1 RID: 59297 RVA: 0x008C6498 File Offset: 0x008C4698
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT VD_ID, VoucherID, Particulars, Amount, Note FROM dbo.Voucher_OtherDetails"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E7A2 RID: 59298 RVA: 0x008C64F8 File Offset: 0x008C46F8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Voucher_OtherDetailsDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E7A3 RID: 59299 RVA: 0x008C6540 File Offset: 0x008C4740
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Voucher_OtherDetailsDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim voucher_OtherDetailsDataTable As Inventory_DBDataSet.Voucher_OtherDetailsDataTable = New Inventory_DBDataSet.Voucher_OtherDetailsDataTable()
			Me.Adapter.Fill(voucher_OtherDetailsDataTable)
			Return voucher_OtherDetailsDataTable
		End Function

		' Token: 0x0600E7A4 RID: 59300 RVA: 0x008C657C File Offset: 0x008C477C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Voucher_OtherDetailsDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E7A5 RID: 59301 RVA: 0x008C659C File Offset: 0x008C479C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Voucher_OtherDetails")
		End Function

		' Token: 0x0600E7A6 RID: 59302 RVA: 0x008C65C0 File Offset: 0x008C47C0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E7A7 RID: 59303 RVA: 0x008C65E8 File Offset: 0x008C47E8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E7A8 RID: 59304 RVA: 0x008C6608 File Offset: 0x008C4808
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_VD_ID As Integer, Original_VoucherID As Integer, Original_Particulars As String, Original_Amount As Decimal) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_VD_ID
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_VoucherID
			Dim flag As Boolean = Original_Particulars = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_Particulars")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_Particulars
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_Amount
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

		' Token: 0x0600E7A9 RID: 59305 RVA: 0x008C674C File Offset: 0x008C494C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(VoucherID As Integer, Particulars As String, Amount As Decimal, Note As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = VoucherID
			Dim flag As Boolean = Particulars = Nothing
			If flag Then
				Throw New ArgumentNullException("Particulars")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = Particulars
			Me.Adapter.InsertCommand.Parameters(2).Value = Amount
			Dim flag2 As Boolean = Note = Nothing
			If flag2 Then
				Me.Adapter.InsertCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.InsertCommand.Parameters(3).Value = Note
			End If
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

		' Token: 0x0600E7AA RID: 59306 RVA: 0x008C68BC File Offset: 0x008C4ABC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(VoucherID As Integer, Particulars As String, Amount As Decimal, Note As String, Original_VD_ID As Integer, Original_VoucherID As Integer, Original_Particulars As String, Original_Amount As Decimal, VD_ID As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = VoucherID
			Dim flag As Boolean = Particulars = Nothing
			If flag Then
				Throw New ArgumentNullException("Particulars")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = Particulars
			Me.Adapter.UpdateCommand.Parameters(2).Value = Amount
			Dim flag2 As Boolean = Note = Nothing
			If flag2 Then
				Me.Adapter.UpdateCommand.Parameters(3).Value = DBNull.Value
			Else
				Me.Adapter.UpdateCommand.Parameters(3).Value = Note
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_VD_ID
			Me.Adapter.UpdateCommand.Parameters(5).Value = Original_VoucherID
			Dim flag3 As Boolean = Original_Particulars = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_Particulars")
			End If
			Me.Adapter.UpdateCommand.Parameters(6).Value = Original_Particulars
			Me.Adapter.UpdateCommand.Parameters(7).Value = Original_Amount
			Me.Adapter.UpdateCommand.Parameters(8).Value = VD_ID
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag4 As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag4 Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag5 As Boolean = state = ConnectionState.Closed
				If flag5 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E7AB RID: 59307 RVA: 0x008C6AF0 File Offset: 0x008C4CF0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(VoucherID As Integer, Particulars As String, Amount As Decimal, Note As String, Original_VD_ID As Integer, Original_VoucherID As Integer, Original_Particulars As String, Original_Amount As Decimal) As Integer
			Return Me.Update(VoucherID, Particulars, Amount, Note, Original_VD_ID, Original_VoucherID, Original_Particulars, Original_Amount, Original_VD_ID)
		End Function

		' Token: 0x04005902 RID: 22786
		Private _connection As SqlConnection

		' Token: 0x04005903 RID: 22787
		Private _transaction As SqlTransaction

		' Token: 0x04005904 RID: 22788
		Private _commandCollection As SqlCommand()

		' Token: 0x04005905 RID: 22789
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
