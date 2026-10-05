Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports MyDBLibrary

Namespace BillPoint
	' Token: 0x0200007D RID: 125
	<DesignerGenerated()>
	Public Partial Class frmBranchReport_Dashboard
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060014D6 RID: 5334 RVA: 0x000E0264 File Offset: 0x000DE464
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBranchReport_Dashboard_Load
			AddHandler MyBase.FormClosing, AddressOf Me.frmBranchReport_Dashboard_FormClosing
			Me.helper = New DBHelper()
			Me.connStr = Me.helper.RaintechMaster_Online_connection()
			Me.remoteConStr = Me.connStr
			Me.lastClickedButton = Nothing
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000869 RID: 2153
		' (get) Token: 0x060014D9 RID: 5337 RVA: 0x00011283 File Offset: 0x0000F483
		' (set) Token: 0x060014DA RID: 5338 RVA: 0x0001128D File Offset: 0x0000F48D
		Friend Overridable Property txtCompanyId As TextBox

		' Token: 0x1700086A RID: 2154
		' (get) Token: 0x060014DB RID: 5339 RVA: 0x00011296 File Offset: 0x0000F496
		' (set) Token: 0x060014DC RID: 5340 RVA: 0x000112A0 File Offset: 0x0000F4A0
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x1700086B RID: 2155
		' (get) Token: 0x060014DD RID: 5341 RVA: 0x000112A9 File Offset: 0x0000F4A9
		' (set) Token: 0x060014DE RID: 5342 RVA: 0x000E0ECC File Offset: 0x000DF0CC
		Private _btnLogin As Button
		Friend Overridable Property btnLogin As Button
			<CompilerGenerated()>
			Get
				Return Me._btnLogin
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnLogin_Click
				Dim button As Button = Me._btnLogin
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnLogin = value
				button = Me._btnLogin
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700086C RID: 2156
		' (get) Token: 0x060014DF RID: 5343 RVA: 0x000112B3 File Offset: 0x0000F4B3
		' (set) Token: 0x060014E0 RID: 5344 RVA: 0x000112BD File Offset: 0x0000F4BD
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700086D RID: 2157
		' (get) Token: 0x060014E1 RID: 5345 RVA: 0x000112C6 File Offset: 0x0000F4C6
		' (set) Token: 0x060014E2 RID: 5346 RVA: 0x000E0F10 File Offset: 0x000DF110
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.dgw_MouseClick
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellContentClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
					RemoveHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
					AddHandler dataGridView.CellContentClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x1700086E RID: 2158
		' (get) Token: 0x060014E3 RID: 5347 RVA: 0x000112D0 File Offset: 0x0000F4D0
		' (set) Token: 0x060014E4 RID: 5348 RVA: 0x000112DA File Offset: 0x0000F4DA
		Friend Overridable Property flpItemsCategory As FlowLayoutPanel

		' Token: 0x1700086F RID: 2159
		' (get) Token: 0x060014E5 RID: 5349 RVA: 0x000112E3 File Offset: 0x0000F4E3
		' (set) Token: 0x060014E6 RID: 5350 RVA: 0x000112ED File Offset: 0x0000F4ED
		Friend Overridable Property flpItems_BV As FlowLayoutPanel

		' Token: 0x17000870 RID: 2160
		' (get) Token: 0x060014E7 RID: 5351 RVA: 0x000112F6 File Offset: 0x0000F4F6
		' (set) Token: 0x060014E8 RID: 5352 RVA: 0x00011300 File Offset: 0x0000F500
		Friend Overridable Property FlowLayoutPanel1 As FlowLayoutPanel

		' Token: 0x17000871 RID: 2161
		' (get) Token: 0x060014E9 RID: 5353 RVA: 0x00011309 File Offset: 0x0000F509
		' (set) Token: 0x060014EA RID: 5354 RVA: 0x00011313 File Offset: 0x0000F513
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17000872 RID: 2162
		' (get) Token: 0x060014EB RID: 5355 RVA: 0x0001131C File Offset: 0x0000F51C
		' (set) Token: 0x060014EC RID: 5356 RVA: 0x00011326 File Offset: 0x0000F526
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000873 RID: 2163
		' (get) Token: 0x060014ED RID: 5357 RVA: 0x0001132F File Offset: 0x0000F52F
		' (set) Token: 0x060014EE RID: 5358 RVA: 0x00011339 File Offset: 0x0000F539
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17000874 RID: 2164
		' (get) Token: 0x060014EF RID: 5359 RVA: 0x00011342 File Offset: 0x0000F542
		' (set) Token: 0x060014F0 RID: 5360 RVA: 0x0001134C File Offset: 0x0000F54C
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17000875 RID: 2165
		' (get) Token: 0x060014F1 RID: 5361 RVA: 0x00011355 File Offset: 0x0000F555
		' (set) Token: 0x060014F2 RID: 5362 RVA: 0x0001135F File Offset: 0x0000F55F
		Friend Overridable Property Column5 As DataGridViewCheckBoxColumn

		' Token: 0x17000876 RID: 2166
		' (get) Token: 0x060014F3 RID: 5363 RVA: 0x00011368 File Offset: 0x0000F568
		' (set) Token: 0x060014F4 RID: 5364 RVA: 0x00011372 File Offset: 0x0000F572
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17000877 RID: 2167
		' (get) Token: 0x060014F5 RID: 5365 RVA: 0x0001137B File Offset: 0x0000F57B
		' (set) Token: 0x060014F6 RID: 5366 RVA: 0x00011385 File Offset: 0x0000F585
		Friend Overridable Property btnDel As DataGridViewButtonColumn

		' Token: 0x17000878 RID: 2168
		' (get) Token: 0x060014F7 RID: 5367 RVA: 0x0001138E File Offset: 0x0000F58E
		' (set) Token: 0x060014F8 RID: 5368 RVA: 0x00011398 File Offset: 0x0000F598
		Friend Overridable Property Column7 As DataGridViewTextBoxColumn

		' Token: 0x060014F9 RID: 5369 RVA: 0x000E0F70 File Offset: 0x000DF170
		Private Sub btnLogin_Click(sender As Object, e As EventArgs)
			Dim text As String = Me.txtCompanyId.Text.Trim()
			Dim flag As Boolean = String.IsNullOrEmpty(text)
			If flag Then
				MessageBox.Show("Please enter a Company ID.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Not Me.CheckCompanyExists(text)
				If flag2 Then
					MessageBox.Show("Company ID not found in remote database.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				Else
					Try
						Me.ImportCompanyDataToLocal(text)
						MessageBox.Show("✅ Company data imported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.txtCompanyId.Text = ""
						Me.Getdata()
					Catch ex As Exception
						MessageBox.Show("❌ Failed to import company data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x060014FA RID: 5370 RVA: 0x000E104C File Offset: 0x000DF24C
		Private Function CheckCompanyExists(companyId As String) As Boolean
			Dim flag As Boolean = False
			Using sqlConnection As SqlConnection = New SqlConnection(Me.remoteConStr)
				sqlConnection.Open()
				Dim sqlCommand As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM RaintechMaster WHERE company_id = @companyId", sqlConnection)
				sqlCommand.Parameters.AddWithValue("@companyId", companyId)
				flag = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar())) > 0
			End Using
			Return flag
		End Function

		' Token: 0x060014FB RID: 5371 RVA: 0x000E10C8 File Offset: 0x000DF2C8
		Private Sub ImportCompanyDataToLocal(companyId As String)
			Using sqlConnection As SqlConnection = New SqlConnection(Me.remoteConStr)
				Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.ReadCS())
					sqlConnection.Open()
					sqlConnection2.Open()
					Dim sqlCommand As SqlCommand = New SqlCommand("SELECT COUNT(*) FROM RaintechMaster WHERE company_id = @companyId", sqlConnection2)
					sqlCommand.Parameters.AddWithValue("@companyId", companyId)
					Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand.ExecuteScalar()))
					Dim flag As Boolean = num > 0
					If flag Then
						MessageBox.Show("⚠️ Company already exists in local database. No insert performed.")
					Else
						Dim sqlCommand2 As SqlCommand = New SqlCommand("SELECT *" & vbCrLf & "FROM RaintechMaster" & vbCrLf & "WHERE company_id = @companyId" & vbCrLf & "  AND id2 = (" & vbCrLf & "    SELECT MAX(id2)" & vbCrLf & "    FROM RaintechMaster" & vbCrLf & "    WHERE company_id = @companyId" & vbCrLf & ");", sqlConnection)
						sqlCommand2.Parameters.AddWithValue("@companyId", companyId)
						Dim sqlDataReader As SqlDataReader = sqlCommand2.ExecuteReader()
						Dim schemaTable As DataTable = sqlDataReader.GetSchemaTable()
						Dim list As List(Of String) = New List(Of String)()
						Try
							For Each obj As Object In schemaTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								list.Add("[" + dataRow("ColumnName").ToString() + "]")
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Dim dataTable As DataTable = New DataTable()
						dataTable.Load(sqlDataReader)
						Dim flag2 As Boolean = dataTable.Rows.Count > 0
						If flag2 Then
							Dim sqlCommand3 As SqlCommand = New SqlCommand("SET IDENTITY_INSERT RaintechMaster ON", sqlConnection2)
							sqlCommand3.ExecuteNonQuery()
							Try
								For Each obj2 As Object In dataTable.Rows
									Dim dataRow2 As DataRow = CType(obj2, DataRow)
									Dim text As String = String.Join(",", list)
									Dim text3 As String = String.Join(",", list.Select(Function(cn As String) "@" + cn.Replace("[", "").Replace("]", "")))
									Dim text4 As String = String.Format("INSERT INTO RaintechMaster ({0}) VALUES ({1})", text, text3)
									Dim sqlCommand4 As SqlCommand = New SqlCommand(text4, sqlConnection2)
									Try
										For Each text5 As String In list
											Dim text6 As String = text5.Replace("[", "").Replace("]", "")
											sqlCommand4.Parameters.AddWithValue("@" + text6, RuntimeHelpers.GetObjectValue(dataRow2(text6)))
										Next
									Finally
										Dim enumerator3 As List(Of String).Enumerator
										CType(enumerator3, IDisposable).Dispose()
									End Try
									sqlCommand4.ExecuteNonQuery()
								Next
							Finally
								Dim enumerator2 As IEnumerator
								If TypeOf enumerator2 Is IDisposable Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
							Dim sqlCommand5 As SqlCommand = New SqlCommand("SET IDENTITY_INSERT RaintechMaster OFF", sqlConnection2)
							sqlCommand5.ExecuteNonQuery()
						Else
							MessageBox.Show("❌ Company ID not found in remote server.")
						End If
					End If
				End Using
			End Using
		End Sub

		' Token: 0x060014FC RID: 5372 RVA: 0x000113A1 File Offset: 0x0000F5A1
		Private Sub frmBranchReport_Dashboard_Load(sender As Object, e As EventArgs)
			Me.Getdata()
			Me.FillCategory()
		End Sub

		' Token: 0x060014FD RID: 5373 RVA: 0x000E1418 File Offset: 0x000DF618
		Public Sub Getdata()
			Try
				ModCS.cs = ModCS.ReadCS()
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT Id,RTRIM(CompanyName),RTRIM(DBName),RTRIM(Online_DBName),is_active, RTRIM(company_id) FROM RaintechMaster ORDER BY Id", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), Convert.ToBoolean(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr(4))), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060014FE RID: 5374 RVA: 0x000E1568 File Offset: 0x000DF768
		Public Sub FillCategory()
			Dim num As Integer = 70
			Dim num2 As Integer = 70
			Dim num3 As Integer = 4
			Me.flpItems_BV.Controls.Clear()
			Me.flpItems_BV.Padding = New Padding(num3)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
				sqlConnection.Open()
				Dim text As String = "SELECT RTRIM(category_name), id, icon_img FROM tbl_master_menu_header where is_deleted='false' and Id in (8,9,10) order by orderby"
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Dim [string] As String = sqlDataReader.GetString(0)
							Dim flag As Boolean = False
							Using sqlConnection2 As SqlConnection = New SqlConnection(ModCS.ReadCS())
								sqlConnection2.Open()
								Dim text2 As String = "SELECT COUNT(*) FROM tbl_master_menu WHERE category_name = @d1 and for_admin=1"
								Using sqlCommand2 As SqlCommand = New SqlCommand(text2, sqlConnection2)
									sqlCommand2.Parameters.AddWithValue("@d1", [string])
									Dim num4 As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlCommand2.ExecuteScalar()))
									flag = num4 > 0
								End Using
							End Using
							Dim flag2 As Boolean = flag
							If flag2 Then
								Dim text3 As String = sqlDataReader.GetValue(0).ToString()
								Dim array As Byte() = If((Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("icon_img")))), CType(sqlDataReader("icon_img"), Byte()), Nothing)
								Dim button As Button = New Button()
								button.Tag = text3
								button.Size = New Size(num, num2)
								button.BackColor = Color.White
								button.FlatStyle = FlatStyle.Flat
								button.FlatAppearance.BorderSize = 0
								button.Margin = New Padding(num3)
								Dim flag3 As Boolean = array IsNot Nothing
								If flag3 Then
									Using memoryStream As MemoryStream = New MemoryStream(array)
										Dim image As Image = Image.FromStream(memoryStream)
										Dim bitmap As Bitmap = New Bitmap(image, New Size(num, num2))
										bitmap.MakeTransparent(Color.White)
										button.BackgroundImage = bitmap
										button.BackgroundImageLayout = ImageLayout.Stretch
									End Using
								End If
								Me.flpItemsCategory.Controls.Add(button)
								AddHandler button.Click, AddressOf Me.btnCategory_Click
							End If
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x060014FF RID: 5375 RVA: 0x000E1858 File Offset: 0x000DFA58
		Private Sub btnCategory_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim flag As Boolean = Me.lastClickedButton Is button
				If flag Then
					Me.flpItems_BV.Visible = Not Me.flpItems_BV.Visible
				Else
					Me.flpItems_BV.Visible = True
					Me.lastClickedButton = button
					Dim text As String = button.Tag.ToString()
					Me.FillSubCategory(text)
					Application.DoEvents()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001500 RID: 5376 RVA: 0x000E1900 File Offset: 0x000DFB00
		Private Sub btnSubCategory_Click(sender As Object, e As EventArgs)
			Try
				Dim button As Button = CType(sender, Button)
				Dim flag As Boolean = button.Tag IsNot Nothing
				If flag Then
					Dim num As Integer = Conversions.ToInteger(button.Tag)
					Using sqlConnection As SqlConnection = New SqlConnection(ModCS.ReadCS())
						sqlConnection.Open()
						Dim text As String = "SELECT RTRIM(sub_category_name), id, icon_img, form_name FROM tbl_master_menu WHERE id = @id"
						Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
							sqlCommand.Parameters.AddWithValue("@id", num)
							Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
								Dim flag2 As Boolean = sqlDataReader.Read()
								If flag2 Then
									Dim text2 As String = sqlDataReader("form_name").ToString().Trim() + "1"
									Dim type As Type = MyProject.Forms.frmMainMenu.[GetType]()
									Dim method As MethodInfo = type.GetMethod(text2, BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic)
									Dim flag3 As Boolean = method IsNot Nothing
									If flag3 Then
										method.Invoke(MyProject.Forms.frmMainMenu, Nothing)
									Else
										MessageBox.Show("Function '" + text2 + "' not found in frmMainMenu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
									End If
								End If
							End Using
						End Using
					End Using
				Else
					MessageBox.Show("Button tag is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001501 RID: 5377 RVA: 0x000E1AEC File Offset: 0x000DFCEC
		Public Sub FillSubCategory(strCategory As String)
			Dim num As Integer = 90
			Dim num2 As Integer = 90
			Dim num3 As Integer = 8
			Me.flpItems_BV.Controls.Clear()
			Me.flpItems_BV.Padding = New Padding(num3)
			Using sqlConnection As SqlConnection = New SqlConnection(ModCS.ReadCS())
				sqlConnection.Open()
				Dim text As String = "SELECT RTRIM(sub_category_name), id, icon_img, visual_status FROM tbl_master_menu WHERE is_deleted='false' and category_name = @Category and for_admin=1"
				Using sqlCommand As SqlCommand = New SqlCommand(text, sqlConnection)
					sqlCommand.Parameters.AddWithValue("@Category", strCategory)
					Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
						While sqlDataReader.Read()
							Dim num4 As Short = Conversions.ToShort(sqlDataReader.GetValue(1))
							Dim array As Byte() = If((Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("icon_img")))), CType(sqlDataReader("icon_img"), Byte()), Nothing)
							Dim button As Button = New Button()
							button.Tag = num4
							button.Size = New Size(num, num2)
							button.BackColor = Color.White
							button.FlatStyle = FlatStyle.Flat
							button.FlatAppearance.BorderSize = 0
							button.FlatAppearance.MouseOverBackColor = button.BackColor
							button.FlatAppearance.MouseDownBackColor = button.BackColor
							button.Margin = New Padding(num3)
							Dim flag As Boolean = array IsNot Nothing
							If flag Then
								Using memoryStream As MemoryStream = New MemoryStream(array)
									Dim image As Image = Image.FromStream(memoryStream)
									button.BackgroundImage = New Bitmap(image, New Size(num, num2))
									button.BackgroundImageLayout = ImageLayout.Stretch
								End Using
							End If
							AddHandler button.Click, AddressOf Me.btnSubCategory_Click
							Me.flpItems_BV.Controls.Add(button)
						End While
					End Using
				End Using
			End Using
		End Sub

		' Token: 0x06001502 RID: 5378 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub dgw_MouseClick(sender As Object, e As MouseEventArgs)
		End Sub

		' Token: 0x06001503 RID: 5379 RVA: 0x000113B2 File Offset: 0x0000F5B2
		Private Sub frmBranchReport_Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs)
			ModCS.ResetToLocalDB()
		End Sub

		' Token: 0x06001504 RID: 5380 RVA: 0x000E1D44 File Offset: 0x000DFF44
		Private Sub dgw_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.dgw.Columns(e.ColumnIndex).Name, "btnDel", False) = 0 AndAlso e.RowIndex >= 0
			If flag Then
				Try
					Dim value As Object = Me.dgw.Rows(e.RowIndex).Cells(1).Value
					Dim text As String = If((value IsNot Nothing), value.ToString().Trim(), Nothing)
					Dim value2 As Object = Me.dgw.Rows(e.RowIndex).Cells(5).Value
					Dim text2 As String = If((value2 IsNot Nothing), value2.ToString().Trim(), Nothing)
					Dim num As Integer = Conversions.ToInteger(Me.dgw.Rows(e.RowIndex).Cells(7).Value)
					Dim dialogResult As DialogResult = MessageBox.Show("Are you sure you want to delete '" + text + "'?", "Delete Branch", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
					Dim flag2 As Boolean = dialogResult = DialogResult.Yes
					If flag2 Then
						Me.DeleteBranchFromDB(text2)
						MessageBox.Show("🗑️ Branch deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Me.Getdata()
					End If
				Catch ex As Exception
					MessageBox.Show("❌ Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				Try
					Dim flag3 As Boolean = Me.dgw.CurrentRow IsNot Nothing AndAlso Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.CurrentRow.Cells(3).Value))
					If flag3 Then
						Dim text3 As String = Me.dgw.CurrentRow.Cells(1).Value.ToString().Trim()
						Dim value3 As Object = Me.dgw.Rows(e.RowIndex).Cells(5).Value
						Dim text4 As String = If((value3 IsNot Nothing), value3.ToString().Trim(), Nothing)
						Dim text5 As String = ""
						Try
							Using sqlConnection As SqlConnection = New SqlConnection(ModCS.RaintechMaster_Online_connection())
								sqlConnection.Open()
								Using sqlCommand As SqlCommand = New SqlCommand("SELECT *" & vbCrLf & "FROM RaintechMaster" & vbCrLf & "WHERE company_id = @company_id" & vbCrLf & "  AND id2 = (" & vbCrLf & "    SELECT MAX(id2)" & vbCrLf & "    FROM RaintechMaster" & vbCrLf & "    WHERE company_id = @company_id" & vbCrLf & ");", sqlConnection)
									sqlCommand.Parameters.AddWithValue("@company_id", text4)
									Using sqlDataReader As SqlDataReader = sqlCommand.ExecuteReader()
										Dim hasRows As Boolean = sqlDataReader.HasRows
										If hasRows Then
											While sqlDataReader.Read()
												text5 = sqlDataReader("Online_DBName").ToString()
											End While
										Else
											MessageBox.Show("No record found for the given company_id.")
										End If
									End Using
								End Using
							End Using
						Catch ex2 As Exception
							MessageBox.Show("Error reading: " + ex2.Message)
						End Try
						Dim flag4 As Boolean = Not String.IsNullOrWhiteSpace(text5)
						If flag4 Then
							ModCS.UpdateConnectionStringFromGrid(text5)
							MessageBox.Show("Connected to Branch: " + text3)
						Else
							ModCS.cs = ModCS.ReadCS()
							MessageBox.Show("No Branch selected. Using default Branch.")
						End If
					Else
						ModCS.cs = ModCS.ReadCS()
						MessageBox.Show("Nothing selected. Using default Branch.")
					End If
				Catch ex3 As Exception
					ModCS.cs = ModCS.ReadCS()
					MessageBox.Show("Error: " + ex3.Message)
				End Try
			End If
		End Sub

		' Token: 0x06001505 RID: 5381 RVA: 0x000E2164 File Offset: 0x000E0364
		Public Sub DeleteBranchFromDB(selectedCompany As Object)
			Try
				ModCS.cs = ModCS.ReadCS()
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					sqlConnection.Open()
					Using sqlCommand As SqlCommand = New SqlCommand("DELETE FROM RaintechMaster WHERE company_id = @company_id", sqlConnection)
						sqlCommand.Parameters.AddWithValue("@company_id", RuntimeHelpers.GetObjectValue(selectedCompany))
						sqlCommand.ExecuteNonQuery()
					End Using
					sqlConnection.Close()
				End Using
			Catch ex As Exception
				MessageBox.Show("Error Deleting:" + ex.Message)
			End Try
		End Sub

		' Token: 0x0400072E RID: 1838
		Private helper As DBHelper

		' Token: 0x0400072F RID: 1839
		Private connStr As String

		' Token: 0x04000730 RID: 1840
		Private remoteConStr As String

		' Token: 0x04000731 RID: 1841
		Private lastClickedButton As Button
	End Class
End Namespace
