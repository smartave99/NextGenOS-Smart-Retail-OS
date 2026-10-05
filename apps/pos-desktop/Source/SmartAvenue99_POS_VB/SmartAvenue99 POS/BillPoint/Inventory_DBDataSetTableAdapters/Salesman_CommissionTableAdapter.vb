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
	' Token: 0x02000461 RID: 1121
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Salesman_CommissionTableAdapter
		Inherits Component

		' Token: 0x1700586F RID: 22639
		' (get) Token: 0x0600E614 RID: 58900 RVA: 0x00065A2A File Offset: 0x00063C2A
		' (set) Token: 0x0600E615 RID: 58901 RVA: 0x00065A34 File Offset: 0x00063C34
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E616 RID: 58902 RVA: 0x00065A3D File Offset: 0x00063C3D
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005870 RID: 22640
		' (get) Token: 0x0600E617 RID: 58903 RVA: 0x008A4F74 File Offset: 0x008A3174
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

		' Token: 0x17005871 RID: 22641
		' (get) Token: 0x0600E618 RID: 58904 RVA: 0x008A4FA4 File Offset: 0x008A31A4
		' (set) Token: 0x0600E619 RID: 58905 RVA: 0x008A4FD4 File Offset: 0x008A31D4
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

		' Token: 0x17005872 RID: 22642
		' (get) Token: 0x0600E61A RID: 58906 RVA: 0x008A5098 File Offset: 0x008A3298
		' (set) Token: 0x0600E61B RID: 58907 RVA: 0x008A50B0 File Offset: 0x008A32B0
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

		' Token: 0x17005873 RID: 22643
		' (get) Token: 0x0600E61C RID: 58908 RVA: 0x008A5198 File Offset: 0x008A3398
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

		' Token: 0x17005874 RID: 22644
		' (get) Token: 0x0600E61D RID: 58909 RVA: 0x008A51C8 File Offset: 0x008A33C8
		' (set) Token: 0x0600E61E RID: 58910 RVA: 0x00065A4F File Offset: 0x00063C4F
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

		' Token: 0x0600E61F RID: 58911 RVA: 0x008A51E0 File Offset: 0x008A33E0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Salesman_Commission"
			dataTableMapping.ColumnMappings.Add("ID", "ID")
			dataTableMapping.ColumnMappings.Add("InvoiceID", "InvoiceID")
			dataTableMapping.ColumnMappings.Add("CommissionPer", "CommissionPer")
			dataTableMapping.ColumnMappings.Add("Commission", "Commission")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Salesman_Commission] WHERE (([ID] = @Original_ID) AND ([InvoiceID] = @Original_InvoiceID) AND ([CommissionPer] = @Original_CommissionPer) AND ([Commission] = @Original_Commission))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_CommissionPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CommissionPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Commission", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Commission", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Salesman_Commission] ([InvoiceID], [CommissionPer], [Commission]) VALUES (@InvoiceID, @CommissionPer, @Commission);" & vbCrLf & "SELECT ID, InvoiceID, CommissionPer, Commission FROM Salesman_Commission WHERE (ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@CommissionPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CommissionPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Commission", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Commission", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Salesman_Commission] SET [InvoiceID] = @InvoiceID, [CommissionPer] = @CommissionPer, [Commission] = @Commission WHERE (([ID] = @Original_ID) AND ([InvoiceID] = @Original_InvoiceID) AND ([CommissionPer] = @Original_CommissionPer) AND ([Commission] = @Original_Commission));" & vbCrLf & "SELECT ID, InvoiceID, CommissionPer, Commission FROM Salesman_Commission WHERE (ID = @ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@CommissionPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CommissionPer", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Commission", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Commission", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_CommissionPer", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "CommissionPer", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Commission", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "Commission", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E620 RID: 58912 RVA: 0x00065A59 File Offset: 0x00063C59
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E621 RID: 58913 RVA: 0x008A573C File Offset: 0x008A393C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT ID, InvoiceID, CommissionPer, Commission FROM dbo.Salesman_Commission"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E622 RID: 58914 RVA: 0x008A579C File Offset: 0x008A399C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Salesman_CommissionDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E623 RID: 58915 RVA: 0x008A57E4 File Offset: 0x008A39E4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Salesman_CommissionDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim salesman_CommissionDataTable As Inventory_DBDataSet.Salesman_CommissionDataTable = New Inventory_DBDataSet.Salesman_CommissionDataTable()
			Me.Adapter.Fill(salesman_CommissionDataTable)
			Return salesman_CommissionDataTable
		End Function

		' Token: 0x0600E624 RID: 58916 RVA: 0x008A5820 File Offset: 0x008A3A20
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Salesman_CommissionDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E625 RID: 58917 RVA: 0x008A5840 File Offset: 0x008A3A40
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Salesman_Commission")
		End Function

		' Token: 0x0600E626 RID: 58918 RVA: 0x008A5864 File Offset: 0x008A3A64
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E627 RID: 58919 RVA: 0x008A588C File Offset: 0x008A3A8C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E628 RID: 58920 RVA: 0x008A58AC File Offset: 0x008A3AAC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_ID As Integer, Original_InvoiceID As Integer, Original_CommissionPer As Decimal, Original_Commission As Decimal) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_ID
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_InvoiceID
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_CommissionPer
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_Commission
			Dim state As ConnectionState = Me.Adapter.DeleteCommand.Connection.State
			Dim flag As Boolean = (Me.Adapter.DeleteCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag Then
				Me.Adapter.DeleteCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag2 As Boolean = state = ConnectionState.Closed
				If flag2 Then
					Me.Adapter.DeleteCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E629 RID: 58921 RVA: 0x008A59E0 File Offset: 0x008A3BE0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(InvoiceID As Integer, CommissionPer As Decimal, Commission As Decimal) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = InvoiceID
			Me.Adapter.InsertCommand.Parameters(1).Value = CommissionPer
			Me.Adapter.InsertCommand.Parameters(2).Value = Commission
			Dim state As ConnectionState = Me.Adapter.InsertCommand.Connection.State
			Dim flag As Boolean = (Me.Adapter.InsertCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag Then
				Me.Adapter.InsertCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag2 As Boolean = state = ConnectionState.Closed
				If flag2 Then
					Me.Adapter.InsertCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E62A RID: 58922 RVA: 0x008A5AF0 File Offset: 0x008A3CF0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(InvoiceID As Integer, CommissionPer As Decimal, Commission As Decimal, Original_ID As Integer, Original_InvoiceID As Integer, Original_CommissionPer As Decimal, Original_Commission As Decimal, ID As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = InvoiceID
			Me.Adapter.UpdateCommand.Parameters(1).Value = CommissionPer
			Me.Adapter.UpdateCommand.Parameters(2).Value = Commission
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_ID
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_InvoiceID
			Me.Adapter.UpdateCommand.Parameters(5).Value = Original_CommissionPer
			Me.Adapter.UpdateCommand.Parameters(6).Value = Original_Commission
			Me.Adapter.UpdateCommand.Parameters(7).Value = ID
			Dim state As ConnectionState = Me.Adapter.UpdateCommand.Connection.State
			Dim flag As Boolean = (Me.Adapter.UpdateCommand.Connection.State And ConnectionState.Open) <> ConnectionState.Open
			If flag Then
				Me.Adapter.UpdateCommand.Connection.Open()
			End If
			Dim num2 As Integer
			Try
				Dim num As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
				num2 = num
			Finally
				Dim flag2 As Boolean = state = ConnectionState.Closed
				If flag2 Then
					Me.Adapter.UpdateCommand.Connection.Close()
				End If
			End Try
			Return num2
		End Function

		' Token: 0x0600E62B RID: 58923 RVA: 0x008A5CB0 File Offset: 0x008A3EB0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(InvoiceID As Integer, CommissionPer As Decimal, Commission As Decimal, Original_ID As Integer, Original_InvoiceID As Integer, Original_CommissionPer As Decimal, Original_Commission As Decimal) As Integer
			Return Me.Update(InvoiceID, CommissionPer, Commission, Original_ID, Original_InvoiceID, Original_CommissionPer, Original_Commission, Original_ID)
		End Function

		' Token: 0x040058B2 RID: 22706
		Private _connection As SqlConnection

		' Token: 0x040058B3 RID: 22707
		Private _transaction As SqlTransaction

		' Token: 0x040058B4 RID: 22708
		Private _commandCollection As SqlCommand()

		' Token: 0x040058B5 RID: 22709
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
