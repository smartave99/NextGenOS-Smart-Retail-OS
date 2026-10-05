Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports MyDBLibrary

Namespace BillPoint
	' Token: 0x02000072 RID: 114
	<DesignerGenerated()>
	Public Partial Class frmAuto_Migrate
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060013E5 RID: 5093 RVA: 0x00010B85 File Offset: 0x0000ED85
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmAuto_Migrate_Load
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000817 RID: 2071
		' (get) Token: 0x060013E8 RID: 5096 RVA: 0x00010BA5 File Offset: 0x0000EDA5
		' (set) Token: 0x060013E9 RID: 5097 RVA: 0x000D6F34 File Offset: 0x000D5134
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

		' Token: 0x17000818 RID: 2072
		' (get) Token: 0x060013EA RID: 5098 RVA: 0x00010BAF File Offset: 0x0000EDAF
		' (set) Token: 0x060013EB RID: 5099 RVA: 0x00010BB9 File Offset: 0x0000EDB9
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x17000819 RID: 2073
		' (get) Token: 0x060013EC RID: 5100 RVA: 0x00010BC2 File Offset: 0x0000EDC2
		' (set) Token: 0x060013ED RID: 5101 RVA: 0x00010BCC File Offset: 0x0000EDCC
		Friend Overridable Property lblProgress As Label

		' Token: 0x1700081A RID: 2074
		' (get) Token: 0x060013EE RID: 5102 RVA: 0x00010BD5 File Offset: 0x0000EDD5
		' (set) Token: 0x060013EF RID: 5103 RVA: 0x000D6F78 File Offset: 0x000D5178
		Private _Button1 As Button
		Friend Overridable Property Button1 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button1_Click_1
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

		' Token: 0x1700081B RID: 2075
		' (get) Token: 0x060013F0 RID: 5104 RVA: 0x00010BDF File Offset: 0x0000EDDF
		' (set) Token: 0x060013F1 RID: 5105 RVA: 0x00010BE9 File Offset: 0x0000EDE9
		Friend Overridable Property Label1 As Label

		' Token: 0x1700081C RID: 2076
		' (get) Token: 0x060013F2 RID: 5106 RVA: 0x00010BF2 File Offset: 0x0000EDF2
		' (set) Token: 0x060013F3 RID: 5107 RVA: 0x00010BFC File Offset: 0x0000EDFC
		Friend Overridable Property lblLastSynchronization As Label

		' Token: 0x1700081D RID: 2077
		' (get) Token: 0x060013F4 RID: 5108 RVA: 0x00010C05 File Offset: 0x0000EE05
		' (set) Token: 0x060013F5 RID: 5109 RVA: 0x00010C0F File Offset: 0x0000EE0F
		Friend Overridable Property lblSyncStatus As Label

		' Token: 0x1700081E RID: 2078
		' (get) Token: 0x060013F6 RID: 5110 RVA: 0x00010C18 File Offset: 0x0000EE18
		' (set) Token: 0x060013F7 RID: 5111 RVA: 0x00010C22 File Offset: 0x0000EE22
		Friend Overridable Property Label3 As Label

		' Token: 0x1700081F RID: 2079
		' (get) Token: 0x060013F8 RID: 5112 RVA: 0x00010C2B File Offset: 0x0000EE2B
		' (set) Token: 0x060013F9 RID: 5113 RVA: 0x00010C35 File Offset: 0x0000EE35
		Friend Overridable Property lblSyncTrigger As Label

		' Token: 0x17000820 RID: 2080
		' (get) Token: 0x060013FA RID: 5114 RVA: 0x00010C3E File Offset: 0x0000EE3E
		' (set) Token: 0x060013FB RID: 5115 RVA: 0x00010C48 File Offset: 0x0000EE48
		Friend Overridable Property Label5 As Label

		' Token: 0x17000821 RID: 2081
		' (get) Token: 0x060013FC RID: 5116 RVA: 0x00010C51 File Offset: 0x0000EE51
		' (set) Token: 0x060013FD RID: 5117 RVA: 0x000D6FBC File Offset: 0x000D51BC
		Private _Timer1 As Timer
		Friend Overridable Property Timer1 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim timer As Timer = Me._Timer1
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer1 = value
				timer = Me._Timer1
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000822 RID: 2082
		' (get) Token: 0x060013FE RID: 5118 RVA: 0x00010C5B File Offset: 0x0000EE5B
		' (set) Token: 0x060013FF RID: 5119 RVA: 0x00010C65 File Offset: 0x0000EE65
		Friend Overridable Property lblUserType As Label

		' Token: 0x06001400 RID: 5120 RVA: 0x000D7000 File Offset: 0x000D5200
		Private Sub frmAuto_Migrate_Load(sender As Object, e As EventArgs)
			Me.LastDataSynchronization_and_status()
			Me.Company_dtl()
			Me.AutoMigration_ControlStatus()
			Me.ProgressBar1.Minimum = 0
			Me.ProgressBar1.Maximum = 100
			Me.ProgressBar1.Value = 0
			Me.ProgressBar1.[Step] = 1
			Me.Timer1.Interval = 60000
			Me.Timer1.Start()
		End Sub

		' Token: 0x06001401 RID: 5121 RVA: 0x00010C6E File Offset: 0x0000EE6E
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.LastDataSynchronization_and_status()
		End Sub

		' Token: 0x06001402 RID: 5122 RVA: 0x000D7078 File Offset: 0x000D5278
		Public Sub LastDataSynchronization_and_status()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Using sqlCommand As SqlCommand = New SqlCommand("SELECT TOP 1 StartTime, EndTime, Status, TriggerType FROM DataMigration_Logs ORDER BY Id DESC", sqlConnection)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim flag As Boolean = sqlDataReader.Read()
							If flag Then
								Dim dateTime As DateTime = sqlDataReader.GetDateTime(0)
								Dim text As String = If(sqlDataReader.IsDBNull(1), "Still running...", sqlDataReader.GetDateTime(1).ToString("g"))
								Dim [string] As String = sqlDataReader.GetString(2)
								Dim string2 As String = sqlDataReader.GetString(3)
								Me.lblLastSynchronization.Text = text
								Me.lblSyncStatus.Text = [string]
								Me.lblSyncTrigger.Text = string2
								Dim flag2 As Boolean = Operators.CompareString([string], "Started", False) = 0
								If flag2 Then
									Me.Button4.Enabled = False
								Else
									Me.Button4.Enabled = True
								End If
							Else
								Me.lblLastSynchronization.Text = "No sync history found."
								Me.lblSyncStatus.Text = ""
								Me.lblSyncTrigger.Text = ""
								Me.Button4.Enabled = True
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				Console.WriteLine("Error fetching sync status: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06001403 RID: 5123 RVA: 0x000D725C File Offset: 0x000D545C
		Public Sub Company_dtl()
			Try
				Dim array As String() = File.ReadAllLines(Application.StartupPath + "\TempDBSettings.dat")
				Me.strdb_name = array(0)
				Using sqlConnection As SqlConnection = New SqlConnection(ModCompanyMasterCS.CompnayMasterCS)
					sqlConnection.Open()
					Dim text As String = "SELECT CompanyName,DBName,Online_DBName FROM RaintechMaster WHERE DBName=@d1"
					Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
						sqlCommand.Parameters.AddWithValue("@d1", Me.strdb_name)
						Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
							Dim hasRows As Boolean = sqlDataReader.HasRows
							If hasRows Then
								While sqlDataReader.Read()
									Me.Online_DBName = sqlDataReader("Online_DBName").ToString()
								End While
							End If
						End Using
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001404 RID: 5124 RVA: 0x000D738C File Offset: 0x000D558C
		Private Sub Button4_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				ModCommonClasses.con = New SqlConnection(ModCS.RaintechMaster_Online_connection())
				ModCommonClasses.con.Open()
				Dim text As String = "select is_db_enable from RaintechMaster where Online_DBName=@d1 and is_active=1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.Online_DBName)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
				If flag2 Then
					Dim flag3 As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr("is_db_enable")))
					Dim flag4 As Boolean = Not flag3
					If flag4 Then
						MessageBox.Show("Please contact Administrator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						ModCommonClasses.rdr.Close()
					End If
				End If
				Dim dbhelper As DBHelper = New DBHelper()
				Dim text2 As String = dbhelper.UpdateConnectionStringFromGrid(Me.Online_DBName)
				Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
				Dim num As Integer = -1
				Dim now As DateTime = DateTime.Now
				Try
					Me.ProgressBar1.Value = 0
					Me.lblProgress.Text = "0%"
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection.Open()
						Dim text3 As String = "INSERT INTO DataMigration_Logs (StartTime, Status, TriggerType) VALUES (@d1, @d2, @d3); SELECT SCOPE_IDENTITY();"
						Using sqlCommand As SqlCommand = New SqlCommand(text3, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@d1", now)
							sqlCommand.Parameters.AddWithValue("@d2", "Started")
							sqlCommand.Parameters.AddWithValue("@d3", "manual")
							num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
						End Using
						sqlConnection.Close()
					End Using
					Me.LastDataSynchronization_and_status()
					Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.cs)
						Using sqlConnection3 As SqlConnection = New SqlConnection(text2)
							sqlConnection2.Open()
							sqlConnection3.Open()
							Dim tableMigrationOrder As List(Of String) = frmAuto_Migrate.GetTableMigrationOrder(sqlConnection2)
							Dim count As Integer = tableMigrationOrder.Count
							Me.ProgressBar1.Maximum = count
							Dim num2 As Integer = count - 1
							For i As Integer = 0 To num2
								Dim text4 As String = tableMigrationOrder(i)
								Me.MigratePendingRows(text4, dictionary, sqlConnection2, sqlConnection3)
								Me.ProgressBar1.Value = i + 1
								Dim num3 As Integer = CInt(Math.Round(CDbl((i + 1)) / CDbl(count) * 100.0))
								Me.lblProgress.Text = num3.ToString() + "%"
								Me.lblProgress.Refresh()
								Me.ProgressBar1.Refresh()
								Application.DoEvents()
							Next
							MessageBox.Show("✅ Sync completed successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						End Using
					End Using
					Dim now2 As DateTime = DateTime.Now
					Dim text5 As String = "Completed"
					Using sqlConnection4 As SqlConnection = New SqlConnection(ModCS.cs)
						sqlConnection4.Open()
						Dim text6 As String = vbCrLf & "        UPDATE DataMigration_Logs " & vbCrLf & "        SET EndTime = @endTime, Status = @status" & vbCrLf & "        WHERE ID = @id"
						Using sqlCommand2 As SqlCommand = New SqlCommand(text6, sqlConnection4)
							sqlCommand2.Parameters.AddWithValue("@endTime", now2)
							sqlCommand2.Parameters.AddWithValue("@status", text5)
							sqlCommand2.Parameters.AddWithValue("@id", num)
							sqlCommand2.ExecuteNonQuery()
						End Using
						sqlConnection4.Close()
					End Using
				Catch ex As Exception
					MessageBox.Show("❌ Error during sync: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					Dim flag5 As Boolean = num <> -1
					If flag5 Then
						Dim now3 As DateTime = DateTime.Now
						Dim text7 As String = "error"
						Dim message As String = ex.Message
						Using sqlConnection5 As SqlConnection = New SqlConnection(ModCS.cs)
							sqlConnection5.Open()
							Dim text8 As String = vbCrLf & "        UPDATE DataMigration_Logs " & vbCrLf & "        SET EndTime = @endTime, Status = @status, ErrorMessage=@ErrorMessage" & vbCrLf & "        WHERE ID = @id"
							Using sqlCommand3 As SqlCommand = New SqlCommand(text8, sqlConnection5)
								sqlCommand3.Parameters.AddWithValue("@endTime", now3)
								sqlCommand3.Parameters.AddWithValue("@status", text7)
								sqlCommand3.Parameters.AddWithValue("@ErrorMessage", message)
								sqlCommand3.Parameters.AddWithValue("@id", num)
								sqlCommand3.ExecuteNonQuery()
							End Using
							sqlConnection5.Close()
						End Using
					End If
				End Try
				Me.LastDataSynchronization_and_status()
			End If
		End Sub

		' Token: 0x06001405 RID: 5125 RVA: 0x000D7918 File Offset: 0x000D5B18
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

		' Token: 0x06001406 RID: 5126 RVA: 0x000D7AE8 File Offset: 0x000D5CE8
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
					Dim flag3 As Boolean = (Operators.CompareString(tableName, "EmailCache", False) <> 0) And (Operators.CompareString(tableName, "Language_set", False) <> 0) And (Operators.CompareString(tableName, "DataMigration_Logs", False) <> 0)
					If flag3 Then
												Dim text4 As String = sqlDataReader3("SyncGuid").ToString()
						hashSet3.Add(text4)
						Dim flag4 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader3("is_remote"))) AndAlso Convert.ToBoolean(RuntimeHelpers.GetObjectValue(sqlDataReader3("is_remote")))
						Dim array As Byte() = CType(sqlDataReader3("Version"), Byte())
						Dim text5 As String = BitConverter.ToString(array).Replace("-", "")
						Dim flag5 As Boolean = False
						Dim flag6 As Boolean = False
						Dim flag7 As Boolean = Not flag4
						If flag7 Then
							flag5 = True
						Else
							Dim flag8 As Boolean = dictionary2.ContainsKey(text4)
							If flag8 Then
								Dim text6 As String = dictionary2(text4)
								Dim flag9 As Boolean = Not String.Equals(text5, text6, StringComparison.OrdinalIgnoreCase)
								If flag9 Then
									flag6 = True
								End If
							End If
						End If
						Dim flag10 As Boolean = Not flag5 AndAlso Not flag6
						If Not flag10 Then
							Dim cols As New List(Of String)()
							Dim list As List(Of String) = New List(Of String)()
							Dim list2 As List(Of SqlParameter) = New List(Of SqlParameter)()
							Dim list3 As List(Of String) = New List(Of String)()
							Dim num As Integer = sqlDataReader3.FieldCount - 1
							For i As Integer = 0 To num
								Dim name As String = sqlDataReader3.GetName(i)
								Dim flag11 As Boolean = Operators.CompareString(name.ToLower(), "is_remote", False) <> 0
								If flag11 Then
									cols.Add("[" + name + "]")
									list.Add("@" + name)
									list3.Add("[" + name + "] = @upd_" + name)
									Dim objectValue2 As Object = RuntimeHelpers.GetObjectValue(sqlDataReader3(name))
									Dim sqlParameter As SqlParameter = New SqlParameter("@" + name, DBNull.Value)
									Dim sqlParameter2 As SqlParameter = New SqlParameter("@upd_" + name, DBNull.Value)
									Dim flag12 As Boolean = objectValue2 IsNot Nothing AndAlso objectValue2 IsNot DBNull.Value
									If flag12 Then
										Dim flag13 As Boolean = dictionary.ContainsKey(name)
										If flag13 Then
											Dim type As Type = dictionary(name)
											Try
												Dim flag14 As Boolean = Operators.CompareString(name, "Version", False) = 0 AndAlso type Is GetType(String) AndAlso TypeOf objectValue2 Is Byte()
												If flag14 Then
													Dim array2 As Byte() = CType(objectValue2, Byte())
													Dim flag15 As Boolean = type Is GetType(String)
													If flag15 Then
														sqlParameter.Value = BitConverter.ToString(array2).Replace("-", "")
														sqlParameter.SqlDbType = SqlDbType.NVarChar
													Else
														Dim flag16 As Boolean = type Is GetType(Byte())
														If Not flag16 Then
															Throw New Exception(String.Format("Unsupported data type for Version: {0}", type.Name))
														End If
														sqlParameter.Value = array2
														Dim text7 As String = sqlDataReader3.GetDataTypeName(i).ToLower()
														Dim flag17 As Boolean = text7.Contains("image")
														If flag17 Then
															sqlParameter.SqlDbType = SqlDbType.Image
														Else
															sqlParameter.SqlDbType = SqlDbType.VarBinary
														End If
													End If
													sqlParameter2.Value = RuntimeHelpers.GetObjectValue(sqlParameter.Value)
													sqlParameter2.SqlDbType = sqlParameter.SqlDbType
												Else
													Dim type2 As Type = type
													Dim flag18 As Boolean = type2 Is GetType(Decimal)
													If flag18 Then
														sqlParameter.Value = Convert.ToDecimal(objectValue2.ToString().Trim(), CultureInfo.InvariantCulture)
														sqlParameter.SqlDbType = SqlDbType.[Decimal]
													Else
														flag18 = type2 Is GetType(Double)
														If flag18 Then
															sqlParameter.Value = Convert.ToDouble(objectValue2.ToString().Trim(), CultureInfo.InvariantCulture)
															sqlParameter.SqlDbType = SqlDbType.Float
														Else
															flag18 = type2 Is GetType(Single)
															If flag18 Then
																sqlParameter.Value = Convert.ToSingle(objectValue2.ToString().Trim(), CultureInfo.InvariantCulture)
																sqlParameter.SqlDbType = SqlDbType.Real
															Else
																flag18 = type2 Is GetType(Integer)
																If flag18 Then
																	sqlParameter.Value = Convert.ToInt32(RuntimeHelpers.GetObjectValue(objectValue2))
																	sqlParameter.SqlDbType = SqlDbType.Int
																Else
																	flag18 = type2 Is GetType(Long)
																	If flag18 Then
																		sqlParameter.Value = Convert.ToInt64(RuntimeHelpers.GetObjectValue(objectValue2))
																		sqlParameter.SqlDbType = SqlDbType.BigInt
																	Else
																		flag18 = type2 Is GetType(DateTime)
																		If flag18 Then
																			sqlParameter.Value = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(objectValue2))
																			sqlParameter.SqlDbType = SqlDbType.DateTime
																		Else
																			flag18 = type2 Is GetType(Byte())
																			If flag18 Then
																				sqlParameter.Value = RuntimeHelpers.GetObjectValue(objectValue2)
																				Dim text8 As String = sqlDataReader3.GetDataTypeName(i).ToLower()
																				Dim flag19 As Boolean = text8.Contains("image")
																				If flag19 Then
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
									Dim flag20 As Boolean = flag6
									If flag20 Then
										list2.Add(sqlParameter2)
									End If
								End If
							Next
							Try
								Dim flag21 As Boolean = flag5
								If flag21 Then
									Dim flag22 As Boolean = False
									Dim flag23 As Boolean = hashSet.Any(Function(ic As String) cols.Any(Function(col As String) col.Trim("["c, "]"c).Equals(ic, StringComparison.OrdinalIgnoreCase)))
									If flag23 Then
										Dim sqlCommand4 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] ON", tableName), remoteCon)
										sqlCommand4.ExecuteNonQuery()
										flag22 = True
									End If
									Dim text9 As String = String.Format("INSERT INTO [{0}] ({1}) VALUES ({2})", tableName, String.Join(",", cols), String.Join(",", list))
									Dim sqlCommand5 As SqlCommand = New SqlCommand(text9, remoteCon)
									sqlCommand5.Parameters.AddRange(list2.ToArray())
									sqlCommand5.ExecuteNonQuery()
									Dim flag24 As Boolean = flag22
									If flag24 Then
										Dim sqlCommand6 As SqlCommand = New SqlCommand(String.Format("SET IDENTITY_INSERT [{0}] OFF", tableName), remoteCon)
										sqlCommand6.ExecuteNonQuery()
									End If
									Using sqlCommand7 As SqlCommand = New SqlCommand(String.Format("UPDATE [{0}] SET is_remote = 1 WHERE SyncGuid = @sync", tableName), localCon)
										sqlCommand7.Parameters.AddWithValue("@sync", text4)
										sqlCommand7.ExecuteNonQuery()
									End Using
								Else
									Dim flag25 As Boolean = flag6
									If flag25 Then
										Dim list4 As List(Of String) = New List(Of String)()
										Dim list5 As List(Of SqlParameter) = New List(Of SqlParameter)()
										Dim num2 As Integer = sqlDataReader3.FieldCount - 1
										For j As Integer = 0 To num2
											Dim colName As String = sqlDataReader3.GetName(j)
											Dim flag26 As Boolean = hashSet.Contains(colName) OrElse Operators.CompareString(colName, "is_remote", False) = 0
											If Not flag26 Then
												list4.Add(String.Format("[{0}] = @upd_{1}", colName, colName))
												Dim sqlParameter3 As SqlParameter = list2.FirstOrDefault(Function(p As SqlParameter) Operators.CompareString(p.ParameterName, "@upd_" + colName, False) = 0)
												Dim flag27 As Boolean = sqlParameter3 IsNot Nothing
												If flag27 Then
													list5.Add(sqlParameter3)
												End If
											End If
										Next
										list5.Add(New SqlParameter("@sync", text4))
										Dim text10 As String = String.Format("UPDATE [{0}] SET {1} WHERE SyncGuid = @sync", tableName, String.Join(", ", list4))
										Using sqlCommand8 As SqlCommand = New SqlCommand(text10, remoteCon)
											sqlCommand8.Parameters.AddRange(list5.ToArray())
											sqlCommand8.ExecuteNonQuery()
										End Using
									End If
								End If
							Catch ex2 As Exception
								Debug.WriteLine(String.Format("❌ Error in {0}: {1}", tableName, ex2.Message))
							End Try
						End If
					End If
				End While
				sqlDataReader3.Close()
				Dim list6 As List(Of String) = hashSet2.Except(hashSet3).ToList()
				Try
					For Each text11 As String In list6
						Using sqlCommand9 As SqlCommand = New SqlCommand(String.Format("DELETE FROM [{0}] WHERE SyncGuid = @sync", tableName), remoteCon)
							sqlCommand9.Parameters.AddWithValue("@sync", text11)
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

		' Token: 0x06001407 RID: 5127 RVA: 0x000D8784 File Offset: 0x000D6984
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

		' Token: 0x06001408 RID: 5128 RVA: 0x000D8888 File Offset: 0x000D6A88
		Private Sub Button1_Click_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.lblUserType.Text, "Admin", False) <> 0
			If flag Then
				MessageBox.Show("Please contact 'Admin' for Online Data Synchronization.")
			Else
				Try
					Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim flag2 As Boolean = Operators.CompareString(Me.Button1.Text, "Stop Auto Data Synchronization", False) = 0
					Dim text As String
					If flag2 Then
						text = "UPDATE AutoMigrationControl SET IsEnabled = 0, UpdatedOn = GETDATE(), UpdatedBy = @UpdatedBy WHERE ID = 1"
						Me.Button1.Text = "Start Auto Data Synchronization"
						Me.Button1.BackColor = Color.Green
						Me.Button1.ForeColor = Color.White
					Else
						text = "UPDATE AutoMigrationControl SET IsEnabled = 1, UpdatedOn = GETDATE(), UpdatedBy = @UpdatedBy WHERE ID = 1"
						Me.Button1.Text = "Stop Auto Data Synchronization"
						Me.Button1.BackColor = Color.Red
						Me.Button1.ForeColor = Color.White
					End If
					Dim sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@UpdatedBy", "System")
					sqlCommand.ExecuteNonQuery()
					sqlConnection.Close()
					Me.AutoMigration_ControlStatus()
				Catch ex As Exception
					MessageBox.Show("Error: " + ex.Message)
				End Try
			End If
		End Sub

		' Token: 0x06001409 RID: 5129 RVA: 0x000D89DC File Offset: 0x000D6BDC
		Public Sub AutoMigration_ControlStatus()
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand("SELECT IsEnabled FROM AutoMigrationControl WHERE ID = 1", sqlConnection)
					Dim objectValue As Object = RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())
					Dim flag As Boolean = objectValue IsNot Nothing AndAlso Convert.ToBoolean(RuntimeHelpers.GetObjectValue(objectValue))
					If flag Then
						Me.Button1.Text = "Stop Auto Data Synchronization"
						Me.Button1.BackColor = Color.Red
						Me.Button1.ForeColor = Color.White
					Else
						Me.Button1.Text = "Start Auto Data Synchronization"
						Me.Button1.BackColor = Color.Green
						Me.Button1.ForeColor = Color.White
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show("Error loading auto-migration status: " + ex.Message)
			End Try
		End Sub

		' Token: 0x040006B2 RID: 1714
		Private strdb_name As String

		' Token: 0x040006B3 RID: 1715
		Private Online_DBName As String
	End Class
End Namespace
