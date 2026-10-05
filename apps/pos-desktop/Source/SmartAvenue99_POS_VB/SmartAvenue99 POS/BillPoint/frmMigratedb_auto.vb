Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports Microsoft.SqlServer.Management.Common
Imports Microsoft.SqlServer.Management.Sdk.Sfc
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x0200012D RID: 301
	<DesignerGenerated()>
	Public Partial Class frmMigratedb_auto
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06003451 RID: 13393 RVA: 0x00203AC0 File Offset: 0x00201CC0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmMigratedb_auto_Load
			Me.localConnStr = ModCS.cs
			Me.onlineConnStr = "Server=103.86.177.172,1433;Initial Catalog=Raintech_DB9_20250629155123;User ID=sa;Password=%$nI4dSXxF90j9@$5#Jhx;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
			Me.colTypes = New Dictionary(Of String, Type)()
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700144A RID: 5194
		' (get) Token: 0x06003454 RID: 13396 RVA: 0x000203DD File Offset: 0x0001E5DD
		' (set) Token: 0x06003455 RID: 13397 RVA: 0x002041AC File Offset: 0x002023AC
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click
				Dim button As Button = Me._Button1
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700144B RID: 5195
		' (get) Token: 0x06003456 RID: 13398 RVA: 0x000203E7 File Offset: 0x0001E5E7
		' (set) Token: 0x06003457 RID: 13399 RVA: 0x002041F0 File Offset: 0x002023F0
		Private _Button2 As Button
		Friend Overridable Property Button2 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button2_Click
				Dim button As Button = Me._Button2
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700144C RID: 5196
		' (get) Token: 0x06003458 RID: 13400 RVA: 0x000203F1 File Offset: 0x0001E5F1
		' (set) Token: 0x06003459 RID: 13401 RVA: 0x000203FB File Offset: 0x0001E5FB
		Friend Overridable Property DataGridView1 As DataGridView

		' Token: 0x1700144D RID: 5197
		' (get) Token: 0x0600345A RID: 13402 RVA: 0x00020404 File Offset: 0x0001E604
		' (set) Token: 0x0600345B RID: 13403 RVA: 0x0002040E File Offset: 0x0001E60E
		Friend Overridable Property DataGridView2 As DataGridView

		' Token: 0x1700144E RID: 5198
		' (get) Token: 0x0600345C RID: 13404 RVA: 0x00020417 File Offset: 0x0001E617
		' (set) Token: 0x0600345D RID: 13405 RVA: 0x00020421 File Offset: 0x0001E621
		Friend Overridable Property Button3 As Button

		' Token: 0x1700144F RID: 5199
		' (get) Token: 0x0600345E RID: 13406 RVA: 0x0002042A File Offset: 0x0001E62A
		' (set) Token: 0x0600345F RID: 13407 RVA: 0x00204234 File Offset: 0x00202434
		Private _Button4 As Button
		Friend Overridable Property Button4 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button4_Click
				Dim button As Button = Me._Button4
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001450 RID: 5200
		' (get) Token: 0x06003460 RID: 13408 RVA: 0x00020434 File Offset: 0x0001E634
		' (set) Token: 0x06003461 RID: 13409 RVA: 0x00204278 File Offset: 0x00202478
		Private _Button5 As Button
		Friend Overridable Property Button5 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button5_Click
				Dim button As Button = Me._Button5
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button5 = value
				button = Me._Button5
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001451 RID: 5201
		' (get) Token: 0x06003462 RID: 13410 RVA: 0x0002043E File Offset: 0x0001E63E
		' (set) Token: 0x06003463 RID: 13411 RVA: 0x002042BC File Offset: 0x002024BC
		Private _Button6 As Button
		Friend Overridable Property Button6 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button6_Click
				Dim button As Button = Me._Button6
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button6 = value
				button = Me._Button6
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001452 RID: 5202
		' (get) Token: 0x06003464 RID: 13412 RVA: 0x00020448 File Offset: 0x0001E648
		' (set) Token: 0x06003465 RID: 13413 RVA: 0x00204300 File Offset: 0x00202500
		Private _Button7 As Button
		Friend Overridable Property Button7 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button7_Click
				Dim button As Button = Me._Button7
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button7 = value
				button = Me._Button7
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001453 RID: 5203
		' (get) Token: 0x06003466 RID: 13414 RVA: 0x00020452 File Offset: 0x0001E652
		' (set) Token: 0x06003467 RID: 13415 RVA: 0x00204344 File Offset: 0x00202544
		Private _Button8 As Button
		Friend Overridable Property Button8 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button8
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button8_Click
				Dim button As Button = Me._Button8
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button8 = value
				button = Me._Button8
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001454 RID: 5204
		' (get) Token: 0x06003468 RID: 13416 RVA: 0x0002045C File Offset: 0x0001E65C
		' (set) Token: 0x06003469 RID: 13417 RVA: 0x00204388 File Offset: 0x00202588
		Private _Button9 As Button
		Friend Overridable Property Button9 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button9
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button9_Click
				Dim button As Button = Me._Button9
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button9 = value
				button = Me._Button9
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600346A RID: 13418 RVA: 0x00020466 File Offset: 0x0001E666
		Private Sub frmMigratedb_auto_Load(sender As Object, e As EventArgs)
			Me.TestConnection()
			Me.BindTables()
		End Sub

		' Token: 0x0600346B RID: 13419 RVA: 0x002043CC File Offset: 0x002025CC
		Public Sub BindTables()
			Dim dataTable As DataTable = New DataTable()
			Dim dataTable2 As DataTable = New DataTable()
			Try
				Me.localCon = New SqlConnection(Me.localConnStr)
				Me.remoteCon = New SqlConnection(Me.onlineConnStr)
				Me.localCon.Open()
				Me.remoteCon.Open()
				Dim text As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
				Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, Me.localCon)
				sqlDataAdapter.Fill(dataTable)
				Me.DataGridView1.DataSource = dataTable
				Dim text2 As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'"
				Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(text2, Me.remoteCon)
				sqlDataAdapter2.Fill(dataTable2)
				Me.DataGridView2.DataSource = dataTable2
				Try
					For Each obj As Object In dataTable.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Dim localTable As String = dataRow("TABLE_NAME").ToString()
						Dim flag As Boolean = dataTable2.AsEnumerable().Any(Function(r As DataRow) Operators.CompareString(r("TABLE_NAME").ToString(), localTable, False) = 0)
						Dim flag2 As Boolean = Not flag
						If flag2 Then
							dataRow("TABLE_NAME") = Operators.ConcatenateObject(dataRow("TABLE_NAME"), " (Missing in Remote)")
						Else
							dataRow("TABLE_NAME") = Operators.ConcatenateObject(dataRow("TABLE_NAME"), " (Available in Remote)")
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch ex As Exception
				MessageBox.Show("Compare error: " + ex.Message)
			Finally
				Dim flag3 As Boolean = Me.localCon.State = ConnectionState.Open
				If flag3 Then
					Me.localCon.Close()
				End If
				Dim flag4 As Boolean = Me.remoteCon.State = ConnectionState.Open
				If flag4 Then
					Me.remoteCon.Close()
				End If
			End Try
		End Sub

		' Token: 0x0600346C RID: 13420 RVA: 0x0020460C File Offset: 0x0020280C
		Private Sub TestConnection()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(Me.onlineConnStr)
					sqlConnection.Open()
				End Using
			Catch ex As Exception
				MessageBox.Show("❌ SQL Exception: " + ex.Message, "Error")
			End Try
		End Sub

		' Token: 0x0600346D RID: 13421 RVA: 0x00204688 File Offset: 0x00202888
		Public Function CreateDatabaseIfNotExists(serverConnStrWithoutDB As String, databaseName As String) As Boolean
			Dim flag2 As Boolean
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(serverConnStrWithoutDB)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand(String.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName), sqlConnection)
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
					Dim flag As Boolean = objectValue Is Nothing
					If flag Then
						Dim sqlCommand2 As SqlCommand = New SqlCommand(String.Format("CREATE DATABASE [{0}]", databaseName), sqlConnection)
						sqlCommand2.ExecuteNonQuery()
						flag2 = True
					Else
						MessageBox.Show("✅ Already Exist!," + databaseName)
						flag2 = False
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show("DB Check/Create Error: " + ex.Message)
				flag2 = False
			End Try
			Return flag2
		End Function

		' Token: 0x0600346E RID: 13422 RVA: 0x00204758 File Offset: 0x00202958
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim text As String = "Server=103.86.177.172,1433;User ID=sa;Password=%$nI4dSXxF90j9@$5#Jh;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;Initial Catalog=master"
			Dim text2 As String = "admin_testdb1"
			Me.CreateDatabaseIfNotExists(text, text2)
		End Sub

		' Token: 0x0600346F RID: 13423 RVA: 0x0020477C File Offset: 0x0020297C
		Public Sub SyncTableStructure(tableName As String)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(Me.localConnStr)
					Using sqlConnection2 As SqlConnection = New SqlConnection(Me.onlineConnStr)
						sqlConnection.Open()
						sqlConnection2.Open()
						Dim dataTable As DataTable = New DataTable()
						Dim sqlCommand As SqlCommand = New SqlCommand(vbCrLf & "    SELECT " & vbCrLf & "        c.COLUMN_NAME, " & vbCrLf & "        c.DATA_TYPE, " & vbCrLf & "        c.CHARACTER_MAXIMUM_LENGTH, " & vbCrLf & "        c.IS_NULLABLE," & vbCrLf & "        c.COLUMN_DEFAULT," & vbCrLf & "        c.NUMERIC_PRECISION," & vbCrLf & "        c.NUMERIC_SCALE," & vbCrLf & "        COLUMNPROPERTY(OBJECT_ID(c.TABLE_SCHEMA + '.' + c.TABLE_NAME), c.COLUMN_NAME, 'IsIdentity') AS IsIdentity" & vbCrLf & "    FROM INFORMATION_SCHEMA.COLUMNS c" & vbCrLf & "    WHERE c.TABLE_NAME = @tbl", sqlConnection)
						sqlCommand.Parameters.AddWithValue("@tbl", tableName)
						dataTable.Load(sqlCommand.ExecuteReader())
						Dim sqlCommand2 As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tbl", sqlConnection2)
						sqlCommand2.Parameters.AddWithValue("@tbl", tableName)
						Dim flag As Boolean = Conversions.ToInteger(sqlCommand2.ExecuteScalar()) > 0
						Dim flag2 As Boolean = Not flag
						If flag2 Then
							Dim text As String = String.Format("CREATE TABLE [{0}] (", tableName)
							Try
								For Each obj As Object In dataTable.Rows
									Dim dataRow As DataRow = CType(obj, DataRow)
									text = text + Me.ColumnDefinition(dataRow) + ","
								Next
							Finally
								Dim enumerator As IEnumerator
								If TypeOf enumerator Is IDisposable Then
									TryCast(enumerator, IDisposable).Dispose()
								End If
							End Try
							text = text.TrimEnd(New Char() { ","c }) + ")"
							Dim sqlCommand3 As SqlCommand = New SqlCommand(text, sqlConnection2)
							sqlCommand3.ExecuteNonQuery()
						Else
							Try
								For Each obj2 As Object In dataTable.Rows
									Dim dataRow2 As DataRow = CType(obj2, DataRow)
									Dim text2 As String = dataRow2("COLUMN_NAME").ToString()
									Dim sqlCommand4 As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tbl AND COLUMN_NAME = @col", sqlConnection2)
									sqlCommand4.Parameters.AddWithValue("@tbl", tableName)
									sqlCommand4.Parameters.AddWithValue("@col", text2)
									Dim flag3 As Boolean = Conversions.ToInteger(sqlCommand4.ExecuteScalar()) > 0
									Dim flag4 As Boolean = Not flag3
									If flag4 Then
										Dim text3 As String = String.Format("ALTER TABLE [{0}] ADD {1}", tableName, Me.ColumnDefinition(dataRow2))
										Dim sqlCommand5 As SqlCommand = New SqlCommand(text3, sqlConnection2)
										sqlCommand5.ExecuteNonQuery()
									End If
								Next
							Finally
								Dim enumerator2 As IEnumerator
								If TypeOf enumerator2 Is IDisposable Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
						End If
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("Error during sync: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003470 RID: 13424 RVA: 0x00204A64 File Offset: 0x00202C64
		Private Function ColumnDefinition(row As DataRow) As String
			Dim text As String = row("COLUMN_NAME").ToString()
			Dim text2 As String = row("DATA_TYPE").ToString().ToUpper()
			Dim text3 As String = If((Operators.CompareString(row("IS_NULLABLE").ToString(), "YES", False) = 0), "NULL", "NOT NULL")
			Dim text4 As String = String.Format("[{0}] {1}", text, text2)
			Dim flag As Boolean = Operators.CompareString(text2, "VARCHAR", False) = 0 OrElse Operators.CompareString(text2, "NVARCHAR", False) = 0 OrElse Operators.CompareString(text2, "CHAR", False) = 0
			If flag Then
				Dim objectValue As Object = RuntimeHelpers.GetObjectValue(row("CHARACTER_MAXIMUM_LENGTH"))
				text4 += String.Format("({0})", RuntimeHelpers.GetObjectValue(If((objectValue Is DBNull.Value OrElse Conversions.ToInteger(objectValue) < 0), "MAX", objectValue)))
			Else
				Dim flag2 As Boolean = Operators.CompareString(text2, "DECIMAL", False) = 0 OrElse Operators.CompareString(text2, "NUMERIC", False) = 0
				If flag2 Then
					Dim num As Integer = If(Microsoft.VisualBasic.Information.IsDBNull(RuntimeHelpers.GetObjectValue(row("NUMERIC_PRECISION"))), 18, Convert.ToInt32(RuntimeHelpers.GetObjectValue(row("NUMERIC_PRECISION"))))
					Dim num2 As Integer = If(Microsoft.VisualBasic.Information.IsDBNull(RuntimeHelpers.GetObjectValue(row("NUMERIC_SCALE"))), 0, Convert.ToInt32(RuntimeHelpers.GetObjectValue(row("NUMERIC_SCALE"))))
					text4 += String.Format("({0},{1})", num, num2)
				End If
			End If
			Dim flag3 As Boolean = row.Table.Columns.Contains("IsIdentity") AndAlso Not Microsoft.VisualBasic.Information.IsDBNull(RuntimeHelpers.GetObjectValue(row("IsIdentity"))) AndAlso Convert.ToInt32(RuntimeHelpers.GetObjectValue(row("IsIdentity"))) = 1
			If flag3 Then
				text4 += " IDENTITY(1,1)"
			End If
			Return text4 + " " + text3
		End Function

		' Token: 0x06003471 RID: 13425 RVA: 0x00204C74 File Offset: 0x00202E74
		Public Sub MigrateTablesWithData(localConnStr As String, onlineConnStr As String)
			Dim list As List(Of String) = New List(Of String)() From { "TaxCat", "UnitMaster", "SMS" }
			Try
				For Each text As String In list
					Try
						Using sqlConnection As SqlConnection = New SqlConnection(localConnStr)
							Using sqlConnection2 As SqlConnection = New SqlConnection(onlineConnStr)
								sqlConnection.Open()
								sqlConnection2.Open()
								Dim sqlCommand As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @table", sqlConnection2)
								sqlCommand.Parameters.AddWithValue("@table", text)
								Dim flag As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())) > 0
								Dim flag2 As Boolean = Not flag
								If flag2 Then
									Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(String.Format("SELECT * FROM {0} WHERE 1 = 0", text), sqlConnection)
									Dim dataTable As DataTable = New DataTable()
									sqlDataAdapter.FillSchema(dataTable, SchemaType.Source)
									Dim text2 As String = Me.BuildCreateTableSQL(dataTable, text)
									Dim sqlCommand2 As SqlCommand = New SqlCommand(text2, sqlConnection2)
									sqlCommand2.ExecuteNonQuery()
								End If
								Dim sqlCommand3 As SqlCommand = New SqlCommand(String.Format("SELECT * FROM {0}", text), sqlConnection)
								Dim sqlDataAdapter2 As SqlDataAdapter = New SqlDataAdapter(sqlCommand3)
								Dim dataTable2 As DataTable = New DataTable()
								sqlDataAdapter2.Fill(dataTable2)
								Try
									For Each obj As Object In dataTable2.Rows
										Dim dataRow As DataRow = CType(obj, DataRow)
										Dim flag3 As Boolean = Not dataTable2.Columns.Contains("id")
										If Not flag3 Then
											Dim objectValue As Object = RuntimeHelpers.GetObjectValue(dataRow("id"))
											Dim sqlCommand4 As SqlCommand = New SqlCommand(String.Format("SELECT COUNT(*) FROM {0} WHERE id = @id", text), sqlConnection2)
											sqlCommand4.Parameters.AddWithValue("@id", RuntimeHelpers.GetObjectValue(objectValue))
											Dim flag4 As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand4.ExecuteScalar())) > 0
											Dim flag5 As Boolean = Not flag4
											If flag5 Then
												Dim text4 As String = String.Join(",", dataTable2.Columns.Cast(Of DataColumn)().Select(Function(c As DataColumn) c.ColumnName))
												Dim text6 As String = String.Join(",", dataTable2.Columns.Cast(Of DataColumn)().Select(Function(c As DataColumn) "@" + c.ColumnName))
												Dim sqlCommand5 As SqlCommand = New SqlCommand(String.Format("INSERT INTO {0} ({1}) VALUES ({2})", text, text4, text6), sqlConnection2)
												Try
													For Each obj2 As Object In dataTable2.Columns
														Dim dataColumn As DataColumn = CType(obj2, DataColumn)
														sqlCommand5.Parameters.AddWithValue("@" + dataColumn.ColumnName, RuntimeHelpers.GetObjectValue(dataRow(dataColumn.ColumnName)))
													Next
												Finally
													Dim enumerator3 As IEnumerator
													If TypeOf enumerator3 Is IDisposable Then
														TryCast(enumerator3, IDisposable).Dispose()
													End If
												End Try
												sqlCommand5.ExecuteNonQuery()
											End If
										End If
									Next
								Finally
									Dim enumerator2 As IEnumerator
									If TypeOf enumerator2 Is IDisposable Then
										TryCast(enumerator2, IDisposable).Dispose()
									End If
								End Try
							End Using
						End Using
					Catch ex As Exception
						MessageBox.Show(String.Format("❌ Error in table '{0}': {1}", text, ex.Message))
					End Try
				Next
			Finally
				Dim enumerator As List(Of String).Enumerator
				CType(enumerator, IDisposable).Dispose()
			End Try
		End Sub

		' Token: 0x06003472 RID: 13426 RVA: 0x0020507C File Offset: 0x0020327C
		Public Function BuildCreateTableSQL(dt As DataTable, tableName As String) As String
			Dim text As String = String.Format("CREATE TABLE {0} (", tableName)
			Dim list As List(Of String) = New List(Of String)()
			Try
				For Each obj As Object In dt.Columns
					Dim dataColumn As DataColumn = CType(obj, DataColumn)
					Dim text2 As String = String.Format("[{0}] {1}", dataColumn.ColumnName, Me.GetSQLType(dataColumn))
					Dim flag As Boolean = Not dataColumn.AllowDBNull
					If flag Then
						text2 += " NOT NULL"
					End If
					list.Add(text2)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			text = text + String.Join(",", list) + ")"
			Return text
		End Function

		' Token: 0x06003473 RID: 13427 RVA: 0x0020514C File Offset: 0x0020334C
		Public Function GetSQLType(col As DataColumn) As String
			Select Case col.DataType.ToString()
				Case "System.DateTime"
					Return "DATETIME"
				Case "System.Double"
					Return "FLOAT"
				Case "System.Boolean"
					Return "BIT"
				Case "System.Int64"
					Return "BIGINT"
				Case "System.Decimal"
					Return "DECIMAL(18,2)"
				Case "System.String"
					Return String.Format("NVARCHAR({0})", If(col.MaxLength <= 0, "MAX", col.MaxLength.ToString()))
				Case "System.Int32"
					Return "INT"
				Case Else
					Return "NVARCHAR(MAX)"
			End Select
		End Function

		' Token: 0x06003474 RID: 13428 RVA: 0x002052C0 File Offset: 0x002034C0
		Private Sub Button2_Click(sender As Object, e As EventArgs)
			Dim frmMigratedb_auto As frmMigratedb_auto = New frmMigratedb_auto()
			Using sqlConnection As SqlConnection = New SqlConnection(frmMigratedb_auto.localConnStr)
				sqlConnection.Open()
				Dim schema As DataTable = sqlConnection.GetSchema("Tables")
				Try
					For Each obj As Object In schema.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Dim text As String = dataRow("TABLE_NAME").ToString()
						frmMigratedb_auto.SyncTableStructure(text)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End Using
		End Sub

		' Token: 0x06003475 RID: 13429 RVA: 0x002052C0 File Offset: 0x002034C0
		Private Sub Button5_Click(sender As Object, e As EventArgs)
			Dim frmMigratedb_auto As frmMigratedb_auto = New frmMigratedb_auto()
			Using sqlConnection As SqlConnection = New SqlConnection(frmMigratedb_auto.localConnStr)
				sqlConnection.Open()
				Dim schema As DataTable = sqlConnection.GetSchema("Tables")
				Try
					For Each obj As Object In schema.Rows
						Dim dataRow As DataRow = CType(obj, DataRow)
						Dim text As String = dataRow("TABLE_NAME").ToString()
						frmMigratedb_auto.SyncTableStructure(text)
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			End Using
		End Sub

		' Token: 0x06003476 RID: 13430 RVA: 0x0020537C File Offset: 0x0020357C
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(Me.localConnStr)
					Using sqlConnection2 As SqlConnection = New SqlConnection(Me.onlineConnStr)
						sqlConnection.Open()
						sqlConnection2.Open()
						Dim tableMigrationOrder As List(Of String) = frmMigratedb_auto.GetTableMigrationOrder(sqlConnection)
						Try
							For Each text As String In tableMigrationOrder
								Me.MigratePendingRows(text, dictionary, sqlConnection, sqlConnection2)
								Console.WriteLine("Migrating: " + text)
							Next
						Finally
							Dim enumerator As List(Of String).Enumerator
							CType(enumerator, IDisposable).Dispose()
						End Try
						MessageBox.Show("✅ Sync completed successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("❌ Error during sync: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06003477 RID: 13431 RVA: 0x002054A4 File Offset: 0x002036A4
		Private Sub MigratePendingRows(tableName As String, tableKeys As Dictionary(Of String, String), localCon As SqlConnection, remoteCon As SqlConnection)
			' The following expression was wrapped in a checked-statement
			Try
				Dim dictionary As Dictionary(Of String, Type) = New Dictionary(Of String, Type)()
				Dim hashSet As HashSet(Of String) = New HashSet(Of String)()
				Using sqlCommand As SqlCommand = New SqlCommand(String.Format("SELECT TOP 0 * FROM [{0}]", tableName), remoteCon)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SchemaOnly)
						Dim schemaTable As DataTable = sqlDataReader.GetSchemaTable()
						Try
							For Each obj As Object In schemaTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text As String = dataRow("ColumnName").ToString()
								dictionary(text) = CType(dataRow("DataType"), Type)
								Dim flag As Boolean = schemaTable.Columns.Contains("IsIdentity") AndAlso Conversions.ToBoolean(dataRow("IsIdentity"))
								If flag Then
									hashSet.Add(text)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End Using
				End Using
				Dim dictionary2 As Dictionary(Of String, String) = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
				Dim hashSet2 As HashSet(Of String) = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
				Using sqlCommand2 As SqlCommand = New SqlCommand(String.Format("SELECT SyncGuid, Version FROM [{0}]", tableName), remoteCon)
					Using sqlDataReader2 As SqlDataReader = sqlCommand2.ExecuteReader()
						While sqlDataReader2.Read()
							Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlDataReader2("Version"))
							Dim flag2 As Boolean = TypeOf objectValue Is Byte()
							Dim text2 As String
							If flag2 Then
								text2 = BitConverter.ToString(CType(objectValue, Byte())).Replace("-", "")
							Else
								text2 = objectValue.ToString()
							End If
							Dim text3 As String = sqlDataReader2("SyncGuid").ToString()
							dictionary2(text3) = text2
							hashSet2.Add(text3)
						End While
					End Using
				End Using
				Dim hashSet3 As HashSet(Of String) = New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
				Dim sqlCommand3 As SqlCommand = New SqlCommand(String.Format("SELECT * FROM [{0}] WHERE ISNULL(is_remote, 0) IN (0, 1)", tableName), localCon)
				Dim sqlDataReader3 As SqlDataReader = sqlCommand3.ExecuteReader()
				While sqlDataReader3.Read()
					
					Dim text4 As String = sqlDataReader3("SyncGuid").ToString()
					hashSet3.Add(text4)
					Dim flag3 As Boolean = Not Microsoft.VisualBasic.Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader3("is_remote"))) AndAlso Convert.ToBoolean(RuntimeHelpers.GetObjectValue(sqlDataReader3("is_remote")))
					Dim array As Byte() = CType(sqlDataReader3("Version"), Byte())
					Dim text5 As String = BitConverter.ToString(array).Replace("-", "")
					Dim flag4 As Boolean = False
					Dim flag5 As Boolean = False
					Dim flag6 As Boolean = Not flag3
					If flag6 Then
						flag4 = True
					Else
						Dim flag7 As Boolean = dictionary2.ContainsKey(text4)
						If flag7 Then
							Dim text6 As String = dictionary2(text4)
							Dim flag8 As Boolean = Not String.Equals(text5, text6, StringComparison.OrdinalIgnoreCase)
							If flag8 Then
								flag5 = True
							End If
						End If
					End If
					Dim flag9 As Boolean = Not flag4 AndAlso Not flag5
					If Not flag9 Then
						Dim cols As New List(Of String)()
						Dim list As List(Of String) = New List(Of String)()
						Dim list2 As List(Of SqlParameter) = New List(Of SqlParameter)()
						Dim list3 As List(Of String) = New List(Of String)()
						Dim num As Integer = sqlDataReader3.FieldCount - 1
						For i As Integer = 0 To num
							Dim name As String = sqlDataReader3.GetName(i)
							Dim flag10 As Boolean = Operators.CompareString(name.ToLower(), "is_remote", False) <> 0
							If flag10 Then
								cols.Add("[" + name + "]")
								list.Add("@" + name)
								list3.Add("[" + name + "] = @upd_" + name)
								Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(sqlDataReader3(name))
								Dim sqlParameter As SqlParameter = New SqlParameter("@" + name, DBNull.Value)
								Dim sqlParameter2 As SqlParameter = New SqlParameter("@upd_" + name, DBNull.Value)
								Dim flag11 As Boolean = objectValue2 IsNot Nothing AndAlso objectValue2 IsNot DBNull.Value
								If flag11 Then
									Dim flag12 As Boolean = dictionary.ContainsKey(name)
									If flag12 Then
										Dim type As Type = dictionary(name)
										Try
											Dim flag13 As Boolean = Operators.CompareString(name, "Version", False) = 0 AndAlso type Is GetType(String) AndAlso TypeOf objectValue2 Is Byte()
											If flag13 Then
												Dim array2 As Byte() = CType(objectValue2, Byte())
												sqlParameter.Value = BitConverter.ToString(array2).Replace("-", "")
												sqlParameter.SqlDbType = SqlDbType.NVarChar
												sqlParameter2.Value = RuntimeHelpers.GetObjectValue(sqlParameter.Value)
												sqlParameter2.SqlDbType = sqlParameter.SqlDbType
											Else
												Dim type2 As Type = type
												Dim flag14 As Boolean = type2 Is GetType(Decimal)
												If flag14 Then
													sqlParameter.Value = Convert.ToDecimal(objectValue2.ToString().Trim(), CultureInfo.InvariantCulture)
													sqlParameter.SqlDbType = SqlDbType.[Decimal]
												Else
													flag14 = type2 Is GetType(Double)
													If flag14 Then
														sqlParameter.Value = Convert.ToDouble(objectValue2.ToString().Trim(), CultureInfo.InvariantCulture)
														sqlParameter.SqlDbType = SqlDbType.Float
													Else
														flag14 = type2 Is GetType(Single)
														If flag14 Then
															sqlParameter.Value = Convert.ToSingle(objectValue2.ToString().Trim(), CultureInfo.InvariantCulture)
															sqlParameter.SqlDbType = SqlDbType.Real
														Else
															flag14 = type2 Is GetType(Integer)
															If flag14 Then
																sqlParameter.Value = Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue2))
																sqlParameter.SqlDbType = SqlDbType.Int
															Else
																flag14 = type2 Is GetType(Long)
																If flag14 Then
																	sqlParameter.Value = Convert.ToInt64(RuntimeHelpers.GetObjectValue(objectValue2))
																	sqlParameter.SqlDbType = SqlDbType.BigInt
																Else
																	flag14 = type2 Is GetType(DateTime)
																	If flag14 Then
																		sqlParameter.Value = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(objectValue2))
																		sqlParameter.SqlDbType = SqlDbType.DateTime
																	Else
																		flag14 = type2 Is GetType(Byte())
																		If flag14 Then
																			sqlParameter.Value = RuntimeHelpers.GetObjectValue(objectValue2)
																			Dim text7 As String = sqlDataReader3.GetDataTypeName(i).ToLower()
																			Dim flag15 As Boolean = text7.Contains("image")
																			If flag15 Then
																				sqlParameter.SqlDbType = SqlDbType.Image
																			Else
																				sqlParameter.SqlDbType = SqlDbType.VarBinary
																			End If
																		Else
																			sqlParameter.Value = RuntimeHelpers.GetObjectValue(objectValue2)
																			sqlParameter.SqlDbType = Me.GetSqlDbTypeFromType(type)
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
												sqlParameter2.Value = RuntimeHelpers.GetObjectValue(sqlParameter.Value)
												sqlParameter2.SqlDbType = sqlParameter.SqlDbType
											End If
										Catch ex As Exception
											Throw New Exception(String.Format("Column '{0}' value '{1}' could not be converted to {2}.", name, RuntimeHelpers.GetObjectValue(objectValue2), type.Name), ex)
										End Try
									Else
										sqlParameter.Value = RuntimeHelpers.GetObjectValue(objectValue2)
										sqlParameter2.Value = RuntimeHelpers.GetObjectValue(objectValue2)
									End If
								End If
								list2.Add(sqlParameter)
								Dim flag16 As Boolean = flag5
								If flag16 Then
									list2.Add(sqlParameter2)
								End If
							End If
						Next
						Try
							Dim flag17 As Boolean = flag4
							If flag17 Then
								Dim flag18 As Boolean = False
								Dim flag19 As Boolean = hashSet.Any(Function(ic As String) cols.Any(Function(c As String) String.Equals(c.Trim("["c, "]"c), ic, StringComparison.OrdinalIgnoreCase)))
								If flag19 Then
									Dim sqlCommand4 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] ON", tableName), remoteCon)
									sqlCommand4.ExecuteNonQuery()
									flag18 = True
								End If
								Dim text8 As String = String.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tableName, String.Join(",", cols), String.Join(",", list))
								Dim sqlCommand5 As SqlCommand = New SqlCommand(text8, remoteCon)
								sqlCommand5.Parameters.AddRange(list2.ToArray())
								sqlCommand5.ExecuteNonQuery()
								Dim flag20 As Boolean = flag18
								If flag20 Then
									Dim sqlCommand6 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] OFF", tableName), remoteCon)
									sqlCommand6.ExecuteNonQuery()
								End If
								Using sqlCommand7 As SqlCommand = New SqlCommand(String.Format("UPDATE [{0}] SET is_remote = 1 WHERE SyncGuid = @sync", tableName), localCon)
									sqlCommand7.Parameters.AddWithValue("@sync", text4)
									sqlCommand7.ExecuteNonQuery()
								End Using
							Else
								Dim flag21 As Boolean = flag5
								If flag21 Then
									Dim text9 As String = String.Format("UPDATE [{0}] SET {1} WHERE SyncGuid = @sync", tableName, String.Join(", ", list3))
									Dim sqlCommand8 As SqlCommand = New SqlCommand(text9, remoteCon)
									sqlCommand8.Parameters.AddRange(list2.ToArray())
									sqlCommand8.Parameters.AddWithValue("@sync", text4)
									sqlCommand8.ExecuteNonQuery()
								End If
							End If
						Catch ex2 As Exception
							Debug.WriteLine(String.Format("❌ Error in {0}: {1}", tableName, ex2.Message))
						End Try
					End If
				End While
				sqlDataReader3.Close()
				Dim list4 As List(Of String) = hashSet2.Except(hashSet3).ToList()
				Try
					For Each text10 As String In list4
						Using sqlCommand9 As SqlCommand = New SqlCommand(String.Format("DELETE FROM [{0}] WHERE SyncGuid = @sync", tableName), remoteCon)
							sqlCommand9.Parameters.AddWithValue("@sync", text10)
							sqlCommand9.ExecuteNonQuery()
						End Using
					Next
				Finally
					Dim enumerator2 As List(Of String).Enumerator
					CType(enumerator2, IDisposable).Dispose()
				End Try
			Catch ex3 As Exception
				MessageBox.Show("❌ Error in table " + tableName + ": " + ex3.Message)
			End Try
		End Sub

		' Token: 0x06003478 RID: 13432 RVA: 0x00009E98 File Offset: 0x00008098
		Public Sub sjsi()
		End Sub

		' Token: 0x06003479 RID: 13433 RVA: 0x00020477 File Offset: 0x0001E677
		Private Sub Button6_Click(sender As Object, e As EventArgs)
			Me.AddAndPopulateSyncGuidAndIsRemoteColumn(ModCS.cs)
		End Sub

		' Token: 0x0600347A RID: 13434 RVA: 0x00205F80 File Offset: 0x00204180
		Public Sub AddAndPopulateSyncGuidAndIsRemoteColumn(connectionString As String)
			Using sqlConnection As SqlConnection = New SqlConnection(connectionString)
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", sqlConnection)
				Dim sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
				Dim list As List(Of String) = New List(Of String)()
				While sqlDataReader.Read()
					list.Add(sqlDataReader("TABLE_NAME").ToString())
				End While
				sqlDataReader.Close()
				Try
					For Each text As String In list
						Dim sqlCommand2 As SqlCommand = New SqlCommand(String.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = 'is_remote'", text), sqlConnection)
						Dim flag As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand2.ExecuteScalar())) > 0
						Dim flag2 As Boolean = Not flag
						If flag2 Then
							Dim sqlCommand3 As SqlCommand = New SqlCommand(String.Format("ALTER TABLE [{0}] ADD is_remote BIT DEFAULT 0", text), sqlConnection)
							sqlCommand3.ExecuteNonQuery()
							Console.WriteLine(String.Format("✅ Added is_remote to table: {0}", text))
						Else
							Console.WriteLine(String.Format("ℹ️ is_remote already exists in table: {0}", text))
						End If
						Dim sqlCommand4 As SqlCommand = New SqlCommand(String.Format("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = 'SyncGuid'", text), sqlConnection)
						Dim flag3 As Boolean = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand4.ExecuteScalar())) > 0
						Dim flag4 As Boolean = Not flag3
						If flag4 Then
							Dim sqlCommand5 As SqlCommand = New SqlCommand(String.Format("ALTER TABLE [{0}] ADD SyncGuid UNIQUEIDENTIFIER DEFAULT NEWID()", text), sqlConnection)
							sqlCommand5.ExecuteNonQuery()
							Console.WriteLine(String.Format("✅ Added SyncGuid to table: {0}", text))
						Else
							Console.WriteLine(String.Format("ℹ️ SyncGuid already exists in table: {0}", text))
						End If
						Dim sqlCommand6 As SqlCommand = New SqlCommand(String.Format("UPDATE [{0}] SET SyncGuid = NEWID() WHERE SyncGuid IS NULL", text), sqlConnection)
						Dim num As Integer = sqlCommand6.ExecuteNonQuery()
						Dim flag5 As Boolean = num > 0
						If flag5 Then
							Console.WriteLine(String.Format("🔄 Updated {0} NULL SyncGuid values in: {1}", num, text))
						End If
					Next
				Finally
					Dim enumerator As List(Of String).Enumerator
					CType(enumerator, IDisposable).Dispose()
				End Try
				sqlConnection.Close()
			End Using
		End Sub

		' Token: 0x0600347B RID: 13435 RVA: 0x000D8784 File Offset: 0x000D6984
		Private Function GetSqlDbTypeFromType(type As Type) As SqlDbType
			Dim flag As Boolean = type Is GetType(Integer)
			Dim sqlDbType As SqlDbType
			If flag Then
				sqlDbType = SqlDbType.Int
			Else
				Dim flag2 As Boolean = type Is GetType(String)
				If flag2 Then
					sqlDbType = SqlDbType.NVarChar
				Else
					Dim flag3 As Boolean = type Is GetType(DateTime)
					If flag3 Then
						sqlDbType = SqlDbType.DateTime
					Else
						Dim flag4 As Boolean = type Is GetType(Boolean)
						If flag4 Then
							sqlDbType = SqlDbType.Bit
						Else
							Dim flag5 As Boolean = type Is GetType(Decimal)
							If flag5 Then
								sqlDbType = SqlDbType.[Decimal]
							Else
								Dim flag6 As Boolean = type Is GetType(Double)
								If flag6 Then
									sqlDbType = SqlDbType.Float
								Else
									Dim flag7 As Boolean = type Is GetType(Byte())
									If flag7 Then
										sqlDbType = SqlDbType.Image
									Else
										Dim flag8 As Boolean = type Is GetType(Guid)
										If flag8 Then
											sqlDbType = SqlDbType.UniqueIdentifier
										Else
											Dim flag9 As Boolean = type Is GetType(Long)
											If flag9 Then
												sqlDbType = SqlDbType.BigInt
											Else
												Dim flag10 As Boolean = type Is GetType(Short)
												If flag10 Then
													sqlDbType = SqlDbType.SmallInt
												Else
													sqlDbType = SqlDbType.[Variant]
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
			Return sqlDbType
		End Function

		' Token: 0x0600347C RID: 13436 RVA: 0x0020619C File Offset: 0x0020439C
		Private Sub Button7_Click(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(Me.onlineConnStr)
					sqlConnection.Open()
					Dim text As String = vbCrLf & "                DECLARE @sql NVARCHAR(MAX) = '';" & vbCrLf & "                SELECT @sql += 'ALTER TABLE [' + s.name + '].[' + t.name + '] DROP CONSTRAINT [' + fk.name + '];' + CHAR(13)" & vbCrLf & "                FROM sys.foreign_keys fk" & vbCrLf & "                JOIN sys.tables t ON fk.parent_object_id = t.object_id" & vbCrLf & "                JOIN sys.schemas s ON t.schema_id = s.schema_id;" & vbCrLf & "                EXEC sp_executesql @sql;"
					Dim sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.ExecuteNonQuery()
					Dim sqlCommand2 As SqlCommand = New SqlCommand(vbCrLf & "                SELECT '[' + s.name + '].[' + t.name + ']' " & vbCrLf & "                FROM sys.tables t" & vbCrLf & "                INNER JOIN sys.schemas s ON t.schema_id = s.schema_id" & vbCrLf & "                ORDER BY t.name DESC", sqlConnection)
					Dim list As List(Of String) = New List(Of String)()
					Using sqlDataReader As SqlDataReader = sqlCommand2.ExecuteReader()
						While sqlDataReader.Read()
							list.Add(sqlDataReader.GetString(0))
						End While
					End Using
					Try
						For Each text2 As String In list
							Dim sqlCommand3 As SqlCommand = New SqlCommand(String.Format("DROP TABLE {0}", text2), sqlConnection)
							sqlCommand3.ExecuteNonQuery()
						Next
					Finally
						Dim enumerator As List(Of String).Enumerator
						CType(enumerator, IDisposable).Dispose()
					End Try
					MessageBox.Show("All tables and foreign key constraints dropped successfully.")
				End Using
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600347D RID: 13437 RVA: 0x002062E8 File Offset: 0x002044E8
		Private Sub Button8_Click(sender As Object, e As EventArgs)
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(Me.localConnStr)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand(vbCrLf & "                SELECT t.name AS TableName" & vbCrLf & "                FROM sys.columns c" & vbCrLf & "                INNER JOIN sys.tables t ON c.object_id = t.object_id" & vbCrLf & "                WHERE c.name = 'is_remote'" & vbCrLf & "            ", sqlConnection)
					Dim list As List(Of String) = New List(Of String)()
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							list.Add(sqlDataReader("TableName").ToString())
						End While
					End Using
					Try
						For Each text As String In list
							Dim sqlCommand2 As SqlCommand = New SqlCommand(String.Format("UPDATE [{0}] SET is_remote = 0", text), sqlConnection)
							sqlCommand2.ExecuteNonQuery()
						Next
					Finally
						Dim enumerator As List(Of String).Enumerator
						CType(enumerator, IDisposable).Dispose()
					End Try
					MessageBox.Show("All 'is_remote' columns set to 0 successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End Using
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600347E RID: 13438 RVA: 0x00206430 File Offset: 0x00204630
		Private Sub Button9_Click(sender As Object, e As EventArgs)
			Try
				Dim cs As String = ModCS.cs
				Dim text As String = Me.onlineConnStr
				Dim sqlConnection As SqlConnection = New SqlConnection(cs)
				Dim server As Server = New Server(New ServerConnection(sqlConnection))
				Dim database As Database = server.Databases("Raintech_DB9")
				Dim sqlConnection2 As SqlConnection = New SqlConnection(text)
				Dim server2 As Server = New Server(New ServerConnection(sqlConnection2))
				Dim scripter As Scripter = New Scripter(server)
				scripter.Options.ScriptData = False
				scripter.Options.ScriptSchema = True
				scripter.Options.WithDependencies = False
				scripter.Options.DriAll = True
				scripter.Options.Indexes = True
				scripter.Options.SchemaQualify = True
				scripter.Options.IncludeHeaders = True
				Dim list As List(Of Urn) = New List(Of Urn)()
				Try
					For Each obj As Object In database.Tables
						Dim table As Table = CType(obj, Table)
						Dim flag As Boolean = Not table.IsSystemObject
						If flag Then
							list.Add(table.Urn)
						End If
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Dim stringCollection As StringCollection = scripter.Script(list.ToArray())
				Dim list2 As List(Of String) = stringCollection.Cast(Of String)().ToList()
				Try
					For Each text2 As String In list2
						Dim flag2 As Boolean = Not String.IsNullOrWhiteSpace(text2)
						If flag2 Then
							Dim text3 As String = Regex.Replace(text2, "(?i)(\[Version\]\s+)([^\s,]+)", "$1NVARCHAR(200)")
							server2.ConnectionContext.ExecuteNonQuery(text3)
						End If
					Next
				Finally
					Dim enumerator2 As List(Of String).Enumerator
					CType(enumerator2, IDisposable).Dispose()
				End Try
				MessageBox.Show("Schema migrated successfully.")
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600347F RID: 13439 RVA: 0x00206664 File Offset: 0x00204864
		Public Shared Function GetTableMigrationOrder(con As SqlConnection) As List(Of String)
			Dim dependencies As New Dictionary(Of String, List(Of String))()
			Dim allTables As New HashSet(Of String)()
			Dim sqlCommand As New SqlCommand("SELECT fk.name AS FK_Name, tp.name AS ParentTable, tr.name AS ChildTable FROM sys.foreign_keys fk INNER JOIN sys.tables tp ON fk.referenced_object_id = tp.object_id INNER JOIN sys.tables tr ON fk.parent_object_id = tr.object_id", con)
			Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
				While sqlDataReader.Read()
					Dim parentTable As String = sqlDataReader("ParentTable").ToString()
					Dim childTable As String = sqlDataReader("ChildTable").ToString()
					If Not dependencies.ContainsKey(childTable) Then
						dependencies(childTable) = New List(Of String)()
					End If
					dependencies(childTable).Add(parentTable)
					allTables.Add(parentTable)
					allTables.Add(childTable)
				End While
			End Using
			Dim sqlCommand2 As New SqlCommand("SELECT name FROM sys.tables", con)
			Using sqlDataReader2 As SqlDataReader = sqlCommand2.ExecuteReader()
				While sqlDataReader2.Read()
					allTables.Add(sqlDataReader2("name").ToString())
				End While
			End Using
			Dim visited As New HashSet(Of String)()
			Dim result As New List(Of String)()
			Dim visitAction As Action(Of String) = Nothing
			visitAction = Sub(t As String)
				If Not visited.Contains(t) Then
					visited.Add(t)
					If dependencies.ContainsKey(t) Then
						For Each dep As String In dependencies(t)
							visitAction(dep)
						Next
					End If
					result.Add(t)
				End If
			End Sub
			For Each table As String In allTables
				visitAction(table)
			Next
			Return result.Distinct().ToList()
		End Function

		' Token: 0x06003480 RID: 13440 RVA: 0x00206834 File Offset: 0x00204A34
		Public Shared Sub MigrateAllInOrder(localConStr As String, remoteConStr As String)
			Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
			Using sqlConnection As SqlConnection = New SqlConnection(localConStr)
				Using sqlConnection2 As SqlConnection = New SqlConnection(remoteConStr)
					sqlConnection.Open()
					sqlConnection2.Open()
					Dim tableMigrationOrder As List(Of String) = frmMigratedb_auto.GetTableMigrationOrder(sqlConnection)
					Try
						For Each text As String In tableMigrationOrder
							Console.WriteLine("Migrating: " + text)
						Next
					Finally
						Dim enumerator As List(Of String).Enumerator
						CType(enumerator, IDisposable).Dispose()
					End Try
				End Using
			End Using
		End Sub

		' Token: 0x04001694 RID: 5780
		Private localConnStr As String

		' Token: 0x04001695 RID: 5781
		Private onlineConnStr As String

		' Token: 0x04001696 RID: 5782
		Private con As SqlConnection

		' Token: 0x04001697 RID: 5783
		Private da As SqlDataAdapter

		' Token: 0x04001698 RID: 5784
		Private dt As DataTable

		' Token: 0x04001699 RID: 5785
		Private localCon As SqlConnection

		' Token: 0x0400169A RID: 5786
		Private remoteCon As SqlConnection

		' Token: 0x0400169B RID: 5787
		Private colTypes As Dictionary(Of String, Type)
	End Class
End Namespace
