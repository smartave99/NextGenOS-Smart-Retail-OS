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
	' Token: 0x02000465 RID: 1125
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class SettingTableAdapter
		Inherits Component

		' Token: 0x17005887 RID: 22663
		' (get) Token: 0x0600E674 RID: 58996 RVA: 0x00065B76 File Offset: 0x00063D76
		' (set) Token: 0x0600E675 RID: 58997 RVA: 0x00065B80 File Offset: 0x00063D80
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E676 RID: 58998 RVA: 0x00065B89 File Offset: 0x00063D89
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005888 RID: 22664
		' (get) Token: 0x0600E677 RID: 58999 RVA: 0x008AF900 File Offset: 0x008ADB00
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

		' Token: 0x17005889 RID: 22665
		' (get) Token: 0x0600E678 RID: 59000 RVA: 0x008AF930 File Offset: 0x008ADB30
		' (set) Token: 0x0600E679 RID: 59001 RVA: 0x008AF960 File Offset: 0x008ADB60
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

		' Token: 0x1700588A RID: 22666
		' (get) Token: 0x0600E67A RID: 59002 RVA: 0x008AFA24 File Offset: 0x008ADC24
		' (set) Token: 0x0600E67B RID: 59003 RVA: 0x008AFA3C File Offset: 0x008ADC3C
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

		' Token: 0x1700588B RID: 22667
		' (get) Token: 0x0600E67C RID: 59004 RVA: 0x008AFB24 File Offset: 0x008ADD24
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

		' Token: 0x1700588C RID: 22668
		' (get) Token: 0x0600E67D RID: 59005 RVA: 0x008AFB54 File Offset: 0x008ADD54
		' (set) Token: 0x0600E67E RID: 59006 RVA: 0x00065B9B File Offset: 0x00063D9B
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

		' Token: 0x0600E67F RID: 59007 RVA: 0x008AFB6C File Offset: 0x008ADD6C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Setting"
			dataTableMapping.ColumnMappings.Add("ID", "ID")
			dataTableMapping.ColumnMappings.Add("PurchaseTax", "PurchaseTax")
			dataTableMapping.ColumnMappings.Add("SalesTax", "SalesTax")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Setting] WHERE (([ID] = @Original_ID) AND ([PurchaseTax] = @Original_PurchaseTax) AND ([SalesTax] = @Original_SalesTax))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PurchaseTax", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseTax", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_SalesTax", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesTax", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Setting] ([PurchaseTax], [SalesTax]) VALUES (@PurchaseTax, @SalesTax);" & vbCrLf & "SELECT ID, PurchaseTax, SalesTax FROM Setting WHERE (ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PurchaseTax", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseTax", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@SalesTax", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesTax", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Setting] SET [PurchaseTax] = @PurchaseTax, [SalesTax] = @SalesTax WHERE (([ID] = @Original_ID) AND ([PurchaseTax] = @Original_PurchaseTax) AND ([SalesTax] = @Original_SalesTax));" & vbCrLf & "SELECT ID, PurchaseTax, SalesTax FROM Setting WHERE (ID = @ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PurchaseTax", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseTax", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@SalesTax", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesTax", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PurchaseTax", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PurchaseTax", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_SalesTax", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "SalesTax", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E680 RID: 59008 RVA: 0x00065BA5 File Offset: 0x00063DA5
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E681 RID: 59009 RVA: 0x008AFFB0 File Offset: 0x008AE1B0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT ID, PurchaseTax, SalesTax FROM dbo.Setting"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E682 RID: 59010 RVA: 0x008B0010 File Offset: 0x008AE210
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.SettingDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E683 RID: 59011 RVA: 0x008B0058 File Offset: 0x008AE258
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.SettingDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim settingDataTable As Inventory_DBDataSet.SettingDataTable = New Inventory_DBDataSet.SettingDataTable()
			Me.Adapter.Fill(settingDataTable)
			Return settingDataTable
		End Function

		' Token: 0x0600E684 RID: 59012 RVA: 0x008B0094 File Offset: 0x008AE294
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.SettingDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E685 RID: 59013 RVA: 0x008B00B4 File Offset: 0x008AE2B4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Setting")
		End Function

		' Token: 0x0600E686 RID: 59014 RVA: 0x008B00D8 File Offset: 0x008AE2D8
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E687 RID: 59015 RVA: 0x008B0100 File Offset: 0x008AE300
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E688 RID: 59016 RVA: 0x008B0120 File Offset: 0x008AE320
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_ID As Integer, Original_PurchaseTax As String, Original_SalesTax As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_ID
			Dim flag As Boolean = Original_PurchaseTax = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_PurchaseTax")
			End If
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_PurchaseTax
			Dim flag2 As Boolean = Original_SalesTax = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_SalesTax")
			End If
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_SalesTax
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

		' Token: 0x0600E689 RID: 59017 RVA: 0x008B0254 File Offset: 0x008AE454
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(PurchaseTax As String, SalesTax As String) As Integer
			Dim flag As Boolean = PurchaseTax = Nothing
			If flag Then
				Throw New ArgumentNullException("PurchaseTax")
			End If
			Me.Adapter.InsertCommand.Parameters(0).Value = PurchaseTax
			Dim flag2 As Boolean = SalesTax = Nothing
			If flag2 Then
				Throw New ArgumentNullException("SalesTax")
			End If
			Me.Adapter.InsertCommand.Parameters(1).Value = SalesTax
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

		' Token: 0x0600E68A RID: 59018 RVA: 0x008B0364 File Offset: 0x008AE564
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PurchaseTax As String, SalesTax As String, Original_ID As Integer, Original_PurchaseTax As String, Original_SalesTax As String, ID As Integer) As Integer
			Dim flag As Boolean = PurchaseTax = Nothing
			If flag Then
				Throw New ArgumentNullException("PurchaseTax")
			End If
			Me.Adapter.UpdateCommand.Parameters(0).Value = PurchaseTax
			Dim flag2 As Boolean = SalesTax = Nothing
			If flag2 Then
				Throw New ArgumentNullException("SalesTax")
			End If
			Me.Adapter.UpdateCommand.Parameters(1).Value = SalesTax
			Me.Adapter.UpdateCommand.Parameters(2).Value = Original_ID
			Dim flag3 As Boolean = Original_PurchaseTax = Nothing
			If flag3 Then
				Throw New ArgumentNullException("Original_PurchaseTax")
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = Original_PurchaseTax
			Dim flag4 As Boolean = Original_SalesTax = Nothing
			If flag4 Then
				Throw New ArgumentNullException("Original_SalesTax")
			End If
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_SalesTax
			Me.Adapter.UpdateCommand.Parameters(5).Value = ID
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

		' Token: 0x0600E68B RID: 59019 RVA: 0x008B0528 File Offset: 0x008AE728
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(PurchaseTax As String, SalesTax As String, Original_ID As Integer, Original_PurchaseTax As String, Original_SalesTax As String) As Integer
			Return Me.Update(PurchaseTax, SalesTax, Original_ID, Original_PurchaseTax, Original_SalesTax, Original_ID)
		End Function

		' Token: 0x040058C6 RID: 22726
		Private _connection As SqlConnection

		' Token: 0x040058C7 RID: 22727
		Private _transaction As SqlTransaction

		' Token: 0x040058C8 RID: 22728
		Private _commandCollection As SqlCommand()

		' Token: 0x040058C9 RID: 22729
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
