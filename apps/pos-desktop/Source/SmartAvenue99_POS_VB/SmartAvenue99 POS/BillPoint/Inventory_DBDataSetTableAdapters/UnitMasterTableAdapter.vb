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
	' Token: 0x0200046F RID: 1135
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class UnitMasterTableAdapter
		Inherits Component

		' Token: 0x170058C3 RID: 22723
		' (get) Token: 0x0600E764 RID: 59236 RVA: 0x00065EB4 File Offset: 0x000640B4
		' (set) Token: 0x0600E765 RID: 59237 RVA: 0x00065EBE File Offset: 0x000640BE
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E766 RID: 59238 RVA: 0x00065EC7 File Offset: 0x000640C7
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x170058C4 RID: 22724
		' (get) Token: 0x0600E767 RID: 59239 RVA: 0x008C3E50 File Offset: 0x008C2050
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

		' Token: 0x170058C5 RID: 22725
		' (get) Token: 0x0600E768 RID: 59240 RVA: 0x008C3E80 File Offset: 0x008C2080
		' (set) Token: 0x0600E769 RID: 59241 RVA: 0x008C3EB0 File Offset: 0x008C20B0
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

		' Token: 0x170058C6 RID: 22726
		' (get) Token: 0x0600E76A RID: 59242 RVA: 0x008C3F74 File Offset: 0x008C2174
		' (set) Token: 0x0600E76B RID: 59243 RVA: 0x008C3F8C File Offset: 0x008C218C
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

		' Token: 0x170058C7 RID: 22727
		' (get) Token: 0x0600E76C RID: 59244 RVA: 0x008C4074 File Offset: 0x008C2274
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

		' Token: 0x170058C8 RID: 22728
		' (get) Token: 0x0600E76D RID: 59245 RVA: 0x008C40A4 File Offset: 0x008C22A4
		' (set) Token: 0x0600E76E RID: 59246 RVA: 0x00065ED9 File Offset: 0x000640D9
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

		' Token: 0x0600E76F RID: 59247 RVA: 0x008C40BC File Offset: 0x008C22BC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "UnitMaster"
			dataTableMapping.ColumnMappings.Add("Unit", "Unit")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[UnitMaster] WHERE (([Unit] = @Original_Unit))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_Unit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Unit", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[UnitMaster] ([Unit]) VALUES (@Unit);" & vbCrLf & "SELECT Unit FROM UnitMaster WHERE (Unit = @Unit)"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@Unit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Unit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[UnitMaster] SET [Unit] = @Unit WHERE (([Unit] = @Original_Unit));" & vbCrLf & "SELECT Unit FROM UnitMaster WHERE (Unit = @Unit)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Unit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Unit", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_Unit", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "Unit", DataRowVersion.Original, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E770 RID: 59248 RVA: 0x00065EE3 File Offset: 0x000640E3
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E771 RID: 59249 RVA: 0x008C4310 File Offset: 0x008C2510
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT Unit FROM dbo.UnitMaster"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E772 RID: 59250 RVA: 0x008C4370 File Offset: 0x008C2570
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.UnitMasterDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E773 RID: 59251 RVA: 0x008C43B8 File Offset: 0x008C25B8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.UnitMasterDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim unitMasterDataTable As Inventory_DBDataSet.UnitMasterDataTable = New Inventory_DBDataSet.UnitMasterDataTable()
			Me.Adapter.Fill(unitMasterDataTable)
			Return unitMasterDataTable
		End Function

		' Token: 0x0600E774 RID: 59252 RVA: 0x008C43F4 File Offset: 0x008C25F4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.UnitMasterDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E775 RID: 59253 RVA: 0x008C4414 File Offset: 0x008C2614
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "UnitMaster")
		End Function

		' Token: 0x0600E776 RID: 59254 RVA: 0x008C4438 File Offset: 0x008C2638
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E777 RID: 59255 RVA: 0x008C4460 File Offset: 0x008C2660
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E778 RID: 59256 RVA: 0x008C4480 File Offset: 0x008C2680
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_Unit As String) As Integer
			Dim flag As Boolean = Original_Unit = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_Unit")
			End If
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_Unit
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

		' Token: 0x0600E779 RID: 59257 RVA: 0x008C455C File Offset: 0x008C275C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(Unit As String) As Integer
			Dim flag As Boolean = Unit = Nothing
			If flag Then
				Throw New ArgumentNullException("Unit")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = Unit
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

		' Token: 0x0600E77A RID: 59258 RVA: 0x008C4638 File Offset: 0x008C2838
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Unit As String, Original_Unit As String) As Integer
			Dim flag As Boolean = Unit = Nothing
			If flag Then
				Throw New ArgumentNullException("Unit")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = Unit
			Dim flag2 As Boolean = Original_Unit = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_Unit")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = Original_Unit
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

		' Token: 0x0600E77B RID: 59259 RVA: 0x008C4748 File Offset: 0x008C2948
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(Original_Unit As String) As Integer
			Return Me.Update(Original_Unit, Original_Unit)
		End Function

		' Token: 0x040058F8 RID: 22776
		Private _connection As SqlConnection

		' Token: 0x040058F9 RID: 22777
		Private _transaction As SqlTransaction

		' Token: 0x040058FA RID: 22778
		Private _commandCollection As SqlCommand()

		' Token: 0x040058FB RID: 22779
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
