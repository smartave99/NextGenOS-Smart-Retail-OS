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
	' Token: 0x0200044F RID: 1103
	<DesignerCategory("code")>
	<ToolboxItem(True)>
	<DataObject(True)>
	<Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")>
	<HelpKeyword("vs.data.TableAdapter")>
	Public Class Invoice_PaymentTableAdapter
		Inherits Component

		' Token: 0x17005803 RID: 22531
		' (get) Token: 0x0600E464 RID: 58468 RVA: 0x00065454 File Offset: 0x00063654
		' (set) Token: 0x0600E465 RID: 58469 RVA: 0x0006545E File Offset: 0x0006365E
		Friend Overridable Property _adapter As SqlDataAdapter

		' Token: 0x0600E466 RID: 58470 RVA: 0x00065467 File Offset: 0x00063667
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Public Sub New()
			Me.ClearBeforeFill = True
		End Sub

		' Token: 0x17005804 RID: 22532
		' (get) Token: 0x0600E467 RID: 58471 RVA: 0x00879910 File Offset: 0x00877B10
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

		' Token: 0x17005805 RID: 22533
		' (get) Token: 0x0600E468 RID: 58472 RVA: 0x00879940 File Offset: 0x00877B40
		' (set) Token: 0x0600E469 RID: 58473 RVA: 0x00879970 File Offset: 0x00877B70
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

		' Token: 0x17005806 RID: 22534
		' (get) Token: 0x0600E46A RID: 58474 RVA: 0x00879A34 File Offset: 0x00877C34
		' (set) Token: 0x0600E46B RID: 58475 RVA: 0x00879A4C File Offset: 0x00877C4C
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

		' Token: 0x17005807 RID: 22535
		' (get) Token: 0x0600E46C RID: 58476 RVA: 0x00879B34 File Offset: 0x00877D34
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

		' Token: 0x17005808 RID: 22536
		' (get) Token: 0x0600E46D RID: 58477 RVA: 0x00879B64 File Offset: 0x00877D64
		' (set) Token: 0x0600E46E RID: 58478 RVA: 0x00065479 File Offset: 0x00063679
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

		' Token: 0x0600E46F RID: 58479 RVA: 0x00879B7C File Offset: 0x00877D7C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitAdapter()
			Me._adapter = New SqlDataAdapter()
			Dim dataTableMapping As DataTableMapping = New DataTableMapping()
			dataTableMapping.SourceTable = "Table"
			dataTableMapping.DataSetTable = "Invoice_Payment"
			dataTableMapping.ColumnMappings.Add("IP_ID", "IP_ID")
			dataTableMapping.ColumnMappings.Add("InvoiceID", "InvoiceID")
			dataTableMapping.ColumnMappings.Add("PaymentDate", "PaymentDate")
			dataTableMapping.ColumnMappings.Add("TotalPaid", "TotalPaid")
			dataTableMapping.ColumnMappings.Add("PaymentMode", "PaymentMode")
			Me._adapter.TableMappings.Add(dataTableMapping)
			Me._adapter.DeleteCommand = New SqlCommand()
			Me._adapter.DeleteCommand.Connection = Me.Connection
			Me._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[Invoice_Payment] WHERE (([IP_ID] = @Original_IP_ID) AND ([InvoiceID] = @Original_InvoiceID) AND ([PaymentDate] = @Original_PaymentDate) AND ([TotalPaid] = @Original_TotalPaid) AND ([PaymentMode] = @Original_PaymentMode))"
			Me._adapter.DeleteCommand.CommandType = CommandType.Text
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_IP_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IP_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PaymentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "PaymentDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.DeleteCommand.Parameters.Add(New SqlParameter("@Original_PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand = New SqlCommand()
			Me._adapter.InsertCommand.Connection = Me.Connection
			Me._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[Invoice_Payment] ([InvoiceID], [PaymentDate], [TotalPaid], [PaymentMode]) VALUES (@InvoiceID, @PaymentDate, @TotalPaid, @PaymentMode);" & vbCrLf & "SELECT IP_ID, InvoiceID, PaymentDate, TotalPaid, PaymentMode FROM Invoice_Payment WHERE (IP_ID = SCOPE_IDENTITY())"
			Me._adapter.InsertCommand.CommandType = CommandType.Text
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaymentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "PaymentDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.InsertCommand.Parameters.Add(New SqlParameter("@PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand = New SqlCommand()
			Me._adapter.UpdateCommand.Connection = Me.Connection
			Me._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[Invoice_Payment] SET [InvoiceID] = @InvoiceID, [PaymentDate] = @PaymentDate, [TotalPaid] = @TotalPaid, [PaymentMode] = @PaymentMode WHERE (([IP_ID] = @Original_IP_ID) AND ([InvoiceID] = @Original_InvoiceID) AND ([PaymentDate] = @Original_PaymentDate) AND ([TotalPaid] = @Original_TotalPaid) AND ([PaymentMode] = @Original_PaymentMode));" & vbCrLf & "SELECT IP_ID, InvoiceID, PaymentDate, TotalPaid, PaymentMode FROM Invoice_Payment WHERE (IP_ID = @IP_ID)"
			Me._adapter.UpdateCommand.CommandType = CommandType.Text
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaymentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "PaymentDate", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Current, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_IP_ID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "IP_ID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_InvoiceID", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "InvoiceID", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PaymentDate", SqlDbType.DateTime, 0, ParameterDirection.Input, 0, 0, "PaymentDate", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_TotalPaid", SqlDbType.[Decimal], 0, ParameterDirection.Input, 18, 2, "TotalPaid", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@Original_PaymentMode", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "PaymentMode", DataRowVersion.Original, False, Nothing, "", "", ""))
			Me._adapter.UpdateCommand.Parameters.Add(New SqlParameter("@IP_ID", SqlDbType.Int, 4, ParameterDirection.Input, 0, 0, "IP_ID", DataRowVersion.Current, False, Nothing, "", "", ""))
		End Sub

		' Token: 0x0600E470 RID: 58480 RVA: 0x00065483 File Offset: 0x00063683
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitConnection()
			Me._connection = New SqlConnection()
			Me._connection.ConnectionString = MySettings.[Default].Inventory_DBConnectionString1
		End Sub

		' Token: 0x0600E471 RID: 58481 RVA: 0x0087A1EC File Offset: 0x008783EC
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		Private Sub InitCommandCollection()
			Me._commandCollection = New SqlCommand(0) {}
			Me._commandCollection(0) = New SqlCommand()
			Me._commandCollection(0).Connection = Me.Connection
			Me._commandCollection(0).CommandText = "SELECT IP_ID, InvoiceID, PaymentDate, TotalPaid, PaymentMode FROM dbo.Invoice_Payment"
			Me._commandCollection(0).CommandType = CommandType.Text
		End Sub

		' Token: 0x0600E472 RID: 58482 RVA: 0x0087A24C File Offset: 0x0087844C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Fill, True)>
		Public Overridable Function Fill(dataTable As Inventory_DBDataSet.Invoice_PaymentDataTable) As Integer
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim clearBeforeFill As Boolean = Me.ClearBeforeFill
			If clearBeforeFill Then
				dataTable.Clear()
			End If
			Return Me.Adapter.Fill(dataTable)
		End Function

		' Token: 0x0600E473 RID: 58483 RVA: 0x0087A294 File Offset: 0x00878494
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.[Select], True)>
		Public Overridable Function GetData() As Inventory_DBDataSet.Invoice_PaymentDataTable
			Me.Adapter.SelectCommand = Me.CommandCollection(0)
			Dim invoice_PaymentDataTable As Inventory_DBDataSet.Invoice_PaymentDataTable = New Inventory_DBDataSet.Invoice_PaymentDataTable()
			Me.Adapter.Fill(invoice_PaymentDataTable)
			Return invoice_PaymentDataTable
		End Function

		' Token: 0x0600E474 RID: 58484 RVA: 0x0087A2D0 File Offset: 0x008784D0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataTable As Inventory_DBDataSet.Invoice_PaymentDataTable) As Integer
			Return Me.Adapter.Update(dataTable)
		End Function

		' Token: 0x0600E475 RID: 58485 RVA: 0x0087A2F0 File Offset: 0x008784F0
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataSet As Inventory_DBDataSet) As Integer
			Return Me.Adapter.Update(dataSet, "Invoice_Payment")
		End Function

		' Token: 0x0600E476 RID: 58486 RVA: 0x0087A314 File Offset: 0x00878514
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRow As DataRow) As Integer
			Return Me.Adapter.Update(New DataRow() { dataRow })
		End Function

		' Token: 0x0600E477 RID: 58487 RVA: 0x0087A33C File Offset: 0x0087853C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		Public Overridable Function Update(dataRows As DataRow()) As Integer
			Return Me.Adapter.Update(dataRows)
		End Function

		' Token: 0x0600E478 RID: 58488 RVA: 0x0087A35C File Offset: 0x0087855C
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Delete, True)>
		Public Overridable Function Delete(Original_IP_ID As Integer, Original_InvoiceID As Integer, Original_PaymentDate As DateTime, Original_TotalPaid As Decimal, Original_PaymentMode As String) As Integer
			Me.Adapter.DeleteCommand.Parameters(0).Value = Original_IP_ID
			Me.Adapter.DeleteCommand.Parameters(1).Value = Original_InvoiceID
			Me.Adapter.DeleteCommand.Parameters(2).Value = Original_PaymentDate
			Me.Adapter.DeleteCommand.Parameters(3).Value = Original_TotalPaid
			Dim flag As Boolean = Original_PaymentMode = Nothing
			If flag Then
				Throw New ArgumentNullException("Original_PaymentMode")
			End If
			Me.Adapter.DeleteCommand.Parameters(4).Value = Original_PaymentMode
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

		' Token: 0x0600E479 RID: 58489 RVA: 0x0087A4C4 File Offset: 0x008786C4
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Insert, True)>
		Public Overridable Function Insert(InvoiceID As Integer, PaymentDate As DateTime, TotalPaid As Decimal, PaymentMode As String) As Integer
			Me.Adapter.InsertCommand.Parameters(0).Value = InvoiceID
			Me.Adapter.InsertCommand.Parameters(1).Value = PaymentDate
			Me.Adapter.InsertCommand.Parameters(2).Value = TotalPaid
			Dim flag As Boolean = PaymentMode = Nothing
			If flag Then
				Throw New ArgumentNullException("PaymentMode")
			End If
			Me.Adapter.InsertCommand.Parameters(3).Value = PaymentMode
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

		' Token: 0x0600E47A RID: 58490 RVA: 0x0087A608 File Offset: 0x00878808
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(InvoiceID As Integer, PaymentDate As DateTime, TotalPaid As Decimal, PaymentMode As String, Original_IP_ID As Integer, Original_InvoiceID As Integer, Original_PaymentDate As DateTime, Original_TotalPaid As Decimal, Original_PaymentMode As String, IP_ID As Integer) As Integer
			Me.Adapter.UpdateCommand.Parameters(0).Value = InvoiceID
			Me.Adapter.UpdateCommand.Parameters(1).Value = PaymentDate
			Me.Adapter.UpdateCommand.Parameters(2).Value = TotalPaid
			Dim flag As Boolean = PaymentMode = Nothing
			If flag Then
				Throw New ArgumentNullException("PaymentMode")
			End If
			Me.Adapter.UpdateCommand.Parameters(3).Value = PaymentMode
			Me.Adapter.UpdateCommand.Parameters(4).Value = Original_IP_ID
			Me.Adapter.UpdateCommand.Parameters(5).Value = Original_InvoiceID
			Me.Adapter.UpdateCommand.Parameters(6).Value = Original_PaymentDate
			Me.Adapter.UpdateCommand.Parameters(7).Value = Original_TotalPaid
			Dim flag2 As Boolean = Original_PaymentMode = Nothing
			If flag2 Then
				Throw New ArgumentNullException("Original_PaymentMode")
			End If
			Me.Adapter.UpdateCommand.Parameters(8).Value = Original_PaymentMode
			Me.Adapter.UpdateCommand.Parameters(9).Value = IP_ID
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

		' Token: 0x0600E47B RID: 58491 RVA: 0x0087A834 File Offset: 0x00878A34
		<DebuggerNonUserCode()>
		<GeneratedCode("System.Data.Design.TypedDataSetGenerator", "17.0.0.0")>
		<HelpKeyword("vs.data.TableAdapter")>
		<DataObjectMethod(DataObjectMethodType.Update, True)>
		Public Overridable Function Update(InvoiceID As Integer, PaymentDate As DateTime, TotalPaid As Decimal, PaymentMode As String, Original_IP_ID As Integer, Original_InvoiceID As Integer, Original_PaymentDate As DateTime, Original_TotalPaid As Decimal, Original_PaymentMode As String) As Integer
			Return Me.Update(InvoiceID, PaymentDate, TotalPaid, PaymentMode, Original_IP_ID, Original_InvoiceID, Original_PaymentDate, Original_TotalPaid, Original_PaymentMode, Original_IP_ID)
		End Function

		' Token: 0x04005858 RID: 22616
		Private _connection As SqlConnection

		' Token: 0x04005859 RID: 22617
		Private _transaction As SqlTransaction

		' Token: 0x0400585A RID: 22618
		Private _commandCollection As SqlCommand()

		' Token: 0x0400585B RID: 22619
		Private _clearBeforeFill As Boolean
	End Class
End Namespace
