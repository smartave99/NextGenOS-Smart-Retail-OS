Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports FluentFTP
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000059 RID: 89
	<DesignerGenerated()>
	Public Partial Class frmESubCategory
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060010E7 RID: 4327 RVA: 0x0000F382 File Offset: 0x0000D582
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmESubCategory_Load
			Me.strb = New StringBuilder()
			Me.InitializeComponent()
		End Sub

		' Token: 0x170006E9 RID: 1769
		' (get) Token: 0x060010EA RID: 4330 RVA: 0x0000F3B0 File Offset: 0x0000D5B0
		' (set) Token: 0x060010EB RID: 4331 RVA: 0x0000F3BA File Offset: 0x0000D5BA
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x170006EA RID: 1770
		' (get) Token: 0x060010EC RID: 4332 RVA: 0x0000F3C3 File Offset: 0x0000D5C3
		' (set) Token: 0x060010ED RID: 4333 RVA: 0x000C2C48 File Offset: 0x000C0E48
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170006EB RID: 1771
		' (get) Token: 0x060010EE RID: 4334 RVA: 0x0000F3CD File Offset: 0x0000D5CD
		' (set) Token: 0x060010EF RID: 4335 RVA: 0x0000F3D7 File Offset: 0x0000D5D7
		Friend Overridable Property DataGridViewImageColumn2 As DataGridViewImageColumn

		' Token: 0x170006EC RID: 1772
		' (get) Token: 0x060010F0 RID: 4336 RVA: 0x0000F3E0 File Offset: 0x0000D5E0
		' (set) Token: 0x060010F1 RID: 4337 RVA: 0x0000F3EA File Offset: 0x0000D5EA
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x170006ED RID: 1773
		' (get) Token: 0x060010F2 RID: 4338 RVA: 0x0000F3F3 File Offset: 0x0000D5F3
		' (set) Token: 0x060010F3 RID: 4339 RVA: 0x0000F3FD File Offset: 0x0000D5FD
		Friend Overridable Property CheckBox2 As CheckBox

		' Token: 0x170006EE RID: 1774
		' (get) Token: 0x060010F4 RID: 4340 RVA: 0x0000F406 File Offset: 0x0000D606
		' (set) Token: 0x060010F5 RID: 4341 RVA: 0x0000F410 File Offset: 0x0000D610
		Friend Overridable Property BRemove As Button

		' Token: 0x170006EF RID: 1775
		' (get) Token: 0x060010F6 RID: 4342 RVA: 0x0000F419 File Offset: 0x0000D619
		' (set) Token: 0x060010F7 RID: 4343 RVA: 0x0000F423 File Offset: 0x0000D623
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x170006F0 RID: 1776
		' (get) Token: 0x060010F8 RID: 4344 RVA: 0x0000F42C File Offset: 0x0000D62C
		' (set) Token: 0x060010F9 RID: 4345 RVA: 0x0000F436 File Offset: 0x0000D636
		Public Overridable Property Picture As PictureBox

		' Token: 0x170006F1 RID: 1777
		' (get) Token: 0x060010FA RID: 4346 RVA: 0x0000F43F File Offset: 0x0000D63F
		' (set) Token: 0x060010FB RID: 4347 RVA: 0x0000F449 File Offset: 0x0000D649
		Friend Overridable Property btnUpdate As DataGridViewImageColumn

		' Token: 0x170006F2 RID: 1778
		' (get) Token: 0x060010FC RID: 4348 RVA: 0x0000F452 File Offset: 0x0000D652
		' (set) Token: 0x060010FD RID: 4349 RVA: 0x0000F45C File Offset: 0x0000D65C
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x170006F3 RID: 1779
		' (get) Token: 0x060010FE RID: 4350 RVA: 0x0000F465 File Offset: 0x0000D665
		' (set) Token: 0x060010FF RID: 4351 RVA: 0x0000F46F File Offset: 0x0000D66F
		Friend Overridable Property Column2 As DataGridViewCheckBoxColumn

		' Token: 0x170006F4 RID: 1780
		' (get) Token: 0x06001100 RID: 4352 RVA: 0x0000F478 File Offset: 0x0000D678
		' (set) Token: 0x06001101 RID: 4353 RVA: 0x0000F482 File Offset: 0x0000D682
		Friend Overridable Property CID As DataGridViewTextBoxColumn

		' Token: 0x170006F5 RID: 1781
		' (get) Token: 0x06001102 RID: 4354 RVA: 0x0000F48B File Offset: 0x0000D68B
		' (set) Token: 0x06001103 RID: 4355 RVA: 0x0000F495 File Offset: 0x0000D695
		Friend Overridable Property Column1 As DataGridViewImageColumn

		' Token: 0x170006F6 RID: 1782
		' (get) Token: 0x06001104 RID: 4356 RVA: 0x0000F49E File Offset: 0x0000D69E
		' (set) Token: 0x06001105 RID: 4357 RVA: 0x0000F4A8 File Offset: 0x0000D6A8
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x170006F7 RID: 1783
		' (get) Token: 0x06001106 RID: 4358 RVA: 0x0000F4B1 File Offset: 0x0000D6B1
		' (set) Token: 0x06001107 RID: 4359 RVA: 0x000C2C8C File Offset: 0x000C0E8C
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.dgw_CellClick
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x170006F8 RID: 1784
		' (get) Token: 0x06001108 RID: 4360 RVA: 0x0000F4BB File Offset: 0x0000D6BB
		' (set) Token: 0x06001109 RID: 4361 RVA: 0x0000F4C5 File Offset: 0x0000D6C5
		Friend Overridable Property btnInsert As DataGridViewImageColumn

		' Token: 0x170006F9 RID: 1785
		' (get) Token: 0x0600110A RID: 4362 RVA: 0x0000F4CE File Offset: 0x0000D6CE
		' (set) Token: 0x0600110B RID: 4363 RVA: 0x0000F4D8 File Offset: 0x0000D6D8
		Friend Overridable Property Panel6 As Panel

		' Token: 0x0600110C RID: 4364 RVA: 0x000C2CD0 File Offset: 0x000C0ED0
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT SubCategory.SubCategoryName, SubCategory.SCPhoto, Category.ID As CID,SubCategory.ID As SID FROM SubCategory INNER JOIN Category ON SubCategory.Category = Category.CategoryName", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), Nothing, Nothing, Nothing, Nothing, ModCommonClasses.rdr(3) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600110D RID: 4365 RVA: 0x0000F4E1 File Offset: 0x0000D6E1
		Private Sub frmESubCategory_Load(sender As Object, e As EventArgs)
			ServicePointManager.ServerCertificateValidationCallback = AddressOf frmESubCategory.ValidateRemoteCertificate
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600110E RID: 4366 RVA: 0x000C2DDC File Offset: 0x000C0FDC
		Public Sub Convert_Language()
			Dim text As String = "SELECT default_lang_eng, other_lang, lang_hin FROM Language_set WHERE lang_hin= '" + GlobalVariables.LoggedInLang_code + "'"
			Try
				Using sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
					Using sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
						Dim dataTable As DataTable = New DataTable()
						sqlDataAdapter.Fill(dataTable)
						GlobalVariables.translations.Clear()
						Try
							For Each obj As Object In dataTable.Rows
								Dim dataRow As DataRow = CType(obj, DataRow)
								Dim text2 As String = dataRow("default_lang_eng").ToString()
								Dim text3 As String = dataRow("other_lang").ToString()
								Dim flag As Boolean = Not GlobalVariables.translations.ContainsKey(text2)
								If flag Then
									GlobalVariables.translations.Add(text2, text3)
								End If
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
						Me.UpdateAllControls(Me, GlobalVariables.translations)
						Me.UpdateControlsRecursive(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600110F RID: 4367 RVA: 0x000C2F54 File Offset: 0x000C1154
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
			If flag Then
				Dim text As String = ctrl.Text
				Dim flag2 As Boolean = translations.ContainsKey(text)
				If flag2 Then
					ctrl.Text = translations(text)
				End If
			End If
			Try
				For Each obj As Object In ctrl.Controls
					Dim control As Control = CType(obj, Control)
					Me.UpdateAllControls(control, translations)
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06001110 RID: 4368 RVA: 0x000C3010 File Offset: 0x000C1210
		Private Sub UpdateControlsRecursive(parent As Control)
			Try
				For Each obj As Object In parent.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateControlsRecursive(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06001111 RID: 4369 RVA: 0x000B726C File Offset: 0x000B546C
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(dataGridViewColumn.HeaderText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(dataGridViewColumn.HeaderText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06001112 RID: 4370 RVA: 0x000B72F4 File Offset: 0x000B54F4
		Private Sub UpdateListViewHeaders(lv As ListView)
			Try
				For Each obj As Object In lv.Columns
					Dim columnHeader As ColumnHeader = CType(obj, ColumnHeader)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(columnHeader.Text)
					If flag Then
						columnHeader.Text = GlobalVariables.translations(columnHeader.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Try
				For Each obj2 As Object In lv.Items
					Dim listViewItem As ListViewItem = CType(obj2, ListViewItem)
					Dim flag2 As Boolean = GlobalVariables.translations.ContainsKey(listViewItem.Text)
					If flag2 Then
						listViewItem.Text = GlobalVariables.translations(listViewItem.Text)
					End If
					Try
						For Each obj3 As Object In listViewItem.SubItems
							Dim listViewSubItem As ListViewItem.ListViewSubItem = CType(obj3, ListViewItem.ListViewSubItem)
							Dim flag3 As Boolean = GlobalVariables.translations.ContainsKey(listViewSubItem.Text)
							If flag3 Then
								listViewSubItem.Text = GlobalVariables.translations(listViewSubItem.Text)
							End If
						Next
					Finally
						Dim enumerator3 As IEnumerator
						If TypeOf enumerator3 Is IDisposable Then
							TryCast(enumerator3, IDisposable).Dispose()
						End If
					End Try
				Next
			Finally
				Dim enumerator2 As IEnumerator
				If TypeOf enumerator2 Is IDisposable Then
					TryCast(enumerator2, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06001113 RID: 4371 RVA: 0x000B7488 File Offset: 0x000B5688
		Public Shared Function ValidateRemoteCertificate(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
			Return True
		End Function

		' Token: 0x06001114 RID: 4372 RVA: 0x000C30BC File Offset: 0x000C12BC
		Private Sub btnRefress_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Dim thread As Thread = New Thread(Sub()
					MyBase.Invoke(New VB_AnonymousDelegate_0(Sub()
						Me.PictureBox1.Visible = True
					End Sub))
					Me.checkdatatoecomm("u", "A", Nothing)
					MyBase.Invoke(New VB_AnonymousDelegate_0(Sub()
						Me.PictureBox1.Visible = False
					End Sub))
				End Sub)
				thread.Start()
			End If
		End Sub

		' Token: 0x06001115 RID: 4373 RVA: 0x000C30F0 File Offset: 0x000C12F0
		Public Sub checkdatatoecomm(mode As String, sendtype As String, r As DataGridViewRow)
			Dim m_mode As String = mode : Dim m_sendtype As String = sendtype : Dim m_r As DataGridViewRow = r
			Try
				Dim thread As Thread = New Thread(Sub()
					Dim flag As Boolean = (Operators.CompareString(m_mode, "u", False) = 0) And (Operators.CompareString(m_sendtype, "A", False) = 0)
					If flag Then
						Try
							For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
								Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
								Me.checkdatarowwise(dataGridViewRow, m_mode)
							Next
						Finally
							Dim enumerator As IEnumerator
							If TypeOf enumerator Is IDisposable Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					Else
						Me.checkdatarowwise(m_r, m_mode)
					End If
				End Sub)
				thread.Start()
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06001116 RID: 4374 RVA: 0x000C3160 File Offset: 0x000C1360
		Public Sub checkdatarowwise(row As DataGridViewRow, mode As String)
			Try
				Thread.Sleep(1000)
				Me.strb.Clear()
				Dim dataTable As DataTable = New DataTable()
				dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
				Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/check-subcategory?"
				Me.strb.Append(text)
				Me.strb.Append("id=" + row.Cells(2).Value.ToString())
				Dim text2 As String = Me.strb.ToString().Trim()
				Dim webRequest As WebRequest = WebRequest.Create(text2)
				Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
				httpWebRequest.Method = "GET"
				httpWebRequest.ContentType = "application/json"
				Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
				Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
					Dim text3 As String = streamReader.ReadToEnd()
					Dim flag As Boolean = text3.Contains("false")
					If flag Then
						row.Cells(4).Value = "offline"
						row.Cells("btnUpdate").[ReadOnly] = False
						row.Cells("btnInsert").[ReadOnly] = True
					Else
						row.Cells(4).Value = "online"
						row.Cells("btnUpdate").[ReadOnly] = True
						row.Cells("btnInsert").[ReadOnly] = False
						Me.senddatatoecomm("u", "S", row)
					End If
				End Using
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06001117 RID: 4375 RVA: 0x000C3360 File Offset: 0x000C1560
		Public Sub senddatatoecomm(mode As String, sendtype As String, r As DataGridViewRow)
			Try
				Dim flag As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\Images")
				If flag Then
					Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\Images\")
				End If
				Dim flag2 As Boolean = Not Directory.Exists(MyProject.Application.Info.DirectoryPath + "\Images\product")
				If flag2 Then
					Directory.CreateDirectory(MyProject.Application.Info.DirectoryPath + "\Images\product\")
				End If
				Dim flag3 As Boolean = Operators.CompareString(sendtype, "A", False) = 0
				If flag3 Then
					Try
						For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Thread.Sleep(1000)
							Me.senddatarowwise(dataGridViewRow, mode)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				Else
					Thread.Sleep(1000)
					Me.senddatarowwise(r, mode)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06001118 RID: 4376 RVA: 0x000B7C70 File Offset: 0x000B5E70
		Private Sub UploadFiletoFTP()
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Try
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword from FTP_Category where c2='Enabled'")
					Dim webClient As WebClient = New WebClient()
					Dim text As String = dataTable.Rows(0)("c1").ToString()
					webClient.Credentials = New NetworkCredential(dataTable.Rows(0)("FtpUser").ToString(), dataTable.Rows(0)("FtpPassword").ToString())
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Else
				MessageBox.Show("Please check your internet connection", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x06001119 RID: 4377 RVA: 0x000C34DC File Offset: 0x000C16DC
		Public Sub senddatarowwise(row As DataGridViewRow, mode As String)
			Try
				MyBase.Invoke(New VB_AnonymousDelegate_0(Sub()
					Dim text As String = MyProject.Application.Info.DirectoryPath + "\Images\product\"
					Dim stringBuilder As StringBuilder = New StringBuilder()
					stringBuilder.Clear()
					Dim text2 As String = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells("Column4").Value)))
					Dim text3 As String = row.Cells(2).Value.ToString()
					Dim text4 As String = row.Cells(1).Value.ToString()
					Dim text5 As String = row.Cells(0).Value.ToString().Trim()
					Dim array As Byte() = CType(row.Cells(1).Value, Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
					Dim text6 As String = Guid.NewGuid().ToString() + "_stmpp.png"
					Dim text7 As String = MyProject.Application.Info.DirectoryPath + "\Images\product\" + text6
					Me.Panel6.BackgroundImage = Me.Picture.Image
					Using bitmap As Bitmap = New Bitmap(Me.Panel6.Width, Me.Panel6.Height)
						Me.Panel6.DrawToBitmap(bitmap, New Rectangle(0, 0, bitmap.Width, bitmap.Height))
						bitmap.Save(text7)
					End Using
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
					Dim text8 As String = "../images/cat/" + text6
					Dim text9 As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/ins-subcategory?"
					stringBuilder.Append(text9)
					stringBuilder.Append("id=" + text2)
					stringBuilder.Append("&cat_id=" + text3)
					stringBuilder.Append("&name=" + text5)
					stringBuilder.Append("&img=" + text8)
					stringBuilder.Append("&mode=" + mode)
					Dim text10 As String = stringBuilder.ToString().Trim()
					Dim webRequest As WebRequest = WebRequest.Create(text10)
					Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
					httpWebRequest.Method = "GET"
					httpWebRequest.ContentType = "application/json"
					Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
						Dim text11 As String = streamReader.ReadToEnd()
						Dim flag As Boolean = text11.Contains("true")
						If flag Then
							Dim text12 As String = text6
							Dim text13 As String = dataTable.Rows(0)("FtpUrl").ToString()
							Dim text14 As String = dataTable.Rows(0)("FtpUser").ToString()
							Dim text15 As String = dataTable.Rows(0)("FtpPassword").ToString()
							Dim text16 As String = text + "/" + text12
							Me.UploadFileToFtp_fluent(text13, text14, text15, text16)
						End If
					End Using
				End Sub))
			Catch ex As Exception
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600111A RID: 4378 RVA: 0x000C3550 File Offset: 0x000C1750
		Public Sub UploadFileToFtp_fluent(ftpUrl As String, ftpUsername As String, ftpPassword As String, filePath As String)
			Try
				Me.ftpClient = New FtpClient(ftpUrl, New NetworkCredential(ftpUsername, ftpPassword), 0, Nothing, Nothing)
				Me.ftpClient.Connect()
				Dim flag As Boolean = File.Exists(filePath)
				If flag Then
					Dim text As String = "/cat/" + Path.GetFileName(filePath)
					Me.ftpClient.UploadFile(filePath, text, FtpRemoteExists.Overwrite, False, FtpVerify.None, Nothing)
					MessageBox.Show("File uploaded successfully.")
				Else
					MessageBox.Show("File does not exist.")
				End If
				Me.ftpClient.Disconnect()
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600111B RID: 4379 RVA: 0x000C3610 File Offset: 0x000C1810
		Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = (e.RowIndex >= 0) And (e.ColumnIndex >= 0)
			If flag Then
				Dim flag2 As Boolean = e.ColumnIndex = 5
				If flag2 Then
					Dim thread As Thread = New Thread(Sub()
						Me.Invoke(New VB_AnonymousDelegate_0(Sub()
							Me.PictureBox1.Visible = True
						End Sub))
						Me.senddatatoecomm("i", "S", Me.dgw.Rows(e.RowIndex))
						Me.Invoke(New VB_AnonymousDelegate_0(Sub()
							Me.PictureBox1.Visible = False
						End Sub))
					End Sub)
					thread.Start()
				End If
				Dim flag3 As Boolean = e.ColumnIndex = 6
				If flag3 Then
					Dim thread2 As Thread = New Thread(Sub()
						Me.Invoke(New VB_AnonymousDelegate_0(Sub()
							Me.PictureBox1.Visible = True
						End Sub))
						Me.checkdatatoecomm("u", "S", Me.dgw.Rows(e.RowIndex))
						Me.Invoke(New VB_AnonymousDelegate_0(Sub()
							Me.PictureBox1.Visible = False
						End Sub))
					End Sub)
					thread2.Start()
				End If
			End If
		End Sub

		' Token: 0x0600111C RID: 4380 RVA: 0x000C36BC File Offset: 0x000C18BC
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim thread As Thread = New Thread(Sub()
				MyBase.Invoke(New VB_AnonymousDelegate_0(Sub()
					Me.PictureBox1.Visible = True
					Me.dgw.[ReadOnly] = True
				End Sub))
				Me.senddatatoecomm("i", "A", Nothing)
				MyBase.Invoke(New VB_AnonymousDelegate_0(Sub()
					Me.dgw.[ReadOnly] = False
					Me.PictureBox1.Visible = False
				End Sub))
			End Sub)
			thread.Start()
		End Sub

		' Token: 0x0400052D RID: 1325
		Private strb As StringBuilder

		' Token: 0x0400052E RID: 1326
		Private ftpClient As FtpClient
	End Class
End Namespace
