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
Imports Renci.SshNet

Namespace BillPoint
	' Token: 0x02000050 RID: 80
	<DesignerGenerated()>
	Public Partial Class frmECategory
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06000F25 RID: 3877 RVA: 0x0000E464 File Offset: 0x0000C664
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmECategory_Load
			Me.strb = New StringBuilder()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000636 RID: 1590
		' (get) Token: 0x06000F28 RID: 3880 RVA: 0x0000E492 File Offset: 0x0000C692
		' (set) Token: 0x06000F29 RID: 3881 RVA: 0x0000E49C File Offset: 0x0000C69C
		Friend Overridable Property PictureBox1 As PictureBox

		' Token: 0x17000637 RID: 1591
		' (get) Token: 0x06000F2A RID: 3882 RVA: 0x0000E4A5 File Offset: 0x0000C6A5
		' (set) Token: 0x06000F2B RID: 3883 RVA: 0x000B6D38 File Offset: 0x000B4F38
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton1 = value
				gelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000638 RID: 1592
		' (get) Token: 0x06000F2C RID: 3884 RVA: 0x0000E4AF File Offset: 0x0000C6AF
		' (set) Token: 0x06000F2D RID: 3885 RVA: 0x000B6D7C File Offset: 0x000B4F7C
		Private _btnRefress As GelButton
		Friend Overridable Property btnRefress As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnRefress
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnRefress_Click
				Dim gelButton As GelButton = Me._btnRefress
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnRefress = value
				gelButton = Me._btnRefress
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000639 RID: 1593
		' (get) Token: 0x06000F2E RID: 3886 RVA: 0x0000E4B9 File Offset: 0x0000C6B9
		' (set) Token: 0x06000F2F RID: 3887 RVA: 0x000B6DC0 File Offset: 0x000B4FC0
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnCash_Click
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

		' Token: 0x1700063A RID: 1594
		' (get) Token: 0x06000F30 RID: 3888 RVA: 0x0000E4C3 File Offset: 0x0000C6C3
		' (set) Token: 0x06000F31 RID: 3889 RVA: 0x0000E4CD File Offset: 0x0000C6CD
		Public Overridable Property Picture As PictureBox

		' Token: 0x1700063B RID: 1595
		' (get) Token: 0x06000F32 RID: 3890 RVA: 0x0000E4D6 File Offset: 0x0000C6D6
		' (set) Token: 0x06000F33 RID: 3891 RVA: 0x0000E4E0 File Offset: 0x0000C6E0
		Friend Overridable Property DataGridViewImageColumn2 As DataGridViewImageColumn

		' Token: 0x1700063C RID: 1596
		' (get) Token: 0x06000F34 RID: 3892 RVA: 0x0000E4E9 File Offset: 0x0000C6E9
		' (set) Token: 0x06000F35 RID: 3893 RVA: 0x0000E4F3 File Offset: 0x0000C6F3
		Friend Overridable Property DataGridViewImageColumn1 As DataGridViewImageColumn

		' Token: 0x1700063D RID: 1597
		' (get) Token: 0x06000F36 RID: 3894 RVA: 0x0000E4FC File Offset: 0x0000C6FC
		' (set) Token: 0x06000F37 RID: 3895 RVA: 0x000B6E04 File Offset: 0x000B5004
		Private _CheckBox2 As CheckBox
		Friend Overridable Property CheckBox2 As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._CheckBox2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.CheckBox2_CheckedChanged
				Dim checkBox As CheckBox = Me._CheckBox2
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._CheckBox2 = value
				checkBox = Me._CheckBox2
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700063E RID: 1598
		' (get) Token: 0x06000F38 RID: 3896 RVA: 0x0000E506 File Offset: 0x0000C706
		' (set) Token: 0x06000F39 RID: 3897 RVA: 0x0000E510 File Offset: 0x0000C710
		Friend Overridable Property Panel6 As Panel

		' Token: 0x1700063F RID: 1599
		' (get) Token: 0x06000F3A RID: 3898 RVA: 0x0000E519 File Offset: 0x0000C719
		' (set) Token: 0x06000F3B RID: 3899 RVA: 0x0000E523 File Offset: 0x0000C723
		Friend Overridable Property BRemove As Button

		' Token: 0x17000640 RID: 1600
		' (get) Token: 0x06000F3C RID: 3900 RVA: 0x0000E52C File Offset: 0x0000C72C
		' (set) Token: 0x06000F3D RID: 3901 RVA: 0x0000E536 File Offset: 0x0000C736
		Friend Overridable Property btnInsert As DataGridViewImageColumn

		' Token: 0x17000641 RID: 1601
		' (get) Token: 0x06000F3E RID: 3902 RVA: 0x0000E53F File Offset: 0x0000C73F
		' (set) Token: 0x06000F3F RID: 3903 RVA: 0x0000E549 File Offset: 0x0000C749
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17000642 RID: 1602
		' (get) Token: 0x06000F40 RID: 3904 RVA: 0x0000E552 File Offset: 0x0000C752
		' (set) Token: 0x06000F41 RID: 3905 RVA: 0x0000E55C File Offset: 0x0000C75C
		Friend Overridable Property Column2 As DataGridViewCheckBoxColumn

		' Token: 0x17000643 RID: 1603
		' (get) Token: 0x06000F42 RID: 3906 RVA: 0x0000E565 File Offset: 0x0000C765
		' (set) Token: 0x06000F43 RID: 3907 RVA: 0x0000E56F File Offset: 0x0000C76F
		Friend Overridable Property ID As DataGridViewTextBoxColumn

		' Token: 0x17000644 RID: 1604
		' (get) Token: 0x06000F44 RID: 3908 RVA: 0x0000E578 File Offset: 0x0000C778
		' (set) Token: 0x06000F45 RID: 3909 RVA: 0x0000E582 File Offset: 0x0000C782
		Friend Overridable Property Column1 As DataGridViewImageColumn

		' Token: 0x17000645 RID: 1605
		' (get) Token: 0x06000F46 RID: 3910 RVA: 0x0000E58B File Offset: 0x0000C78B
		' (set) Token: 0x06000F47 RID: 3911 RVA: 0x0000E595 File Offset: 0x0000C795
		Friend Overridable Property Description As DataGridViewTextBoxColumn

		' Token: 0x17000646 RID: 1606
		' (get) Token: 0x06000F48 RID: 3912 RVA: 0x0000E59E File Offset: 0x0000C79E
		' (set) Token: 0x06000F49 RID: 3913 RVA: 0x0000E5A8 File Offset: 0x0000C7A8
		Friend Overridable Property btnUpdate As DataGridViewImageColumn

		' Token: 0x17000647 RID: 1607
		' (get) Token: 0x06000F4A RID: 3914 RVA: 0x0000E5B1 File Offset: 0x0000C7B1
		' (set) Token: 0x06000F4B RID: 3915 RVA: 0x000B6E48 File Offset: 0x000B5048
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

		' Token: 0x06000F4C RID: 3916 RVA: 0x000B6E8C File Offset: 0x000B508C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(categoryname),CPhoto,ID from category order by categoryname", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06000F4D RID: 3917 RVA: 0x0000E5BB File Offset: 0x0000C7BB
		Private Sub frmECategory_Load(sender As Object, e As EventArgs)
			ServicePointManager.ServerCertificateValidationCallback = AddressOf frmECategory.ValidateRemoteCertificate
			Me.Getdata()
			Me.Convert_Language()
		End Sub

		' Token: 0x06000F4E RID: 3918 RVA: 0x000B6F8C File Offset: 0x000B518C
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

		' Token: 0x06000F4F RID: 3919 RVA: 0x000B7104 File Offset: 0x000B5304
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

		' Token: 0x06000F50 RID: 3920 RVA: 0x000B71C0 File Offset: 0x000B53C0
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

		' Token: 0x06000F51 RID: 3921 RVA: 0x000B726C File Offset: 0x000B546C
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

		' Token: 0x06000F52 RID: 3922 RVA: 0x000B72F4 File Offset: 0x000B54F4
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

		' Token: 0x06000F53 RID: 3923 RVA: 0x000B7488 File Offset: 0x000B5688
		Public Shared Function ValidateRemoteCertificate(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
			Return True
		End Function

		' Token: 0x06000F54 RID: 3924 RVA: 0x000B749C File Offset: 0x000B569C
		Public Sub senddatarowwise(row As DataGridViewRow, mode As String)
			Try
				MyBase.Invoke(New VB_AnonymousDelegate_0(Sub()
					Dim text As String = MyProject.Application.Info.DirectoryPath + "\Images\product\"
					Dim stringBuilder As StringBuilder = New StringBuilder()
					stringBuilder.Clear()
					Dim text2 As String = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(row.Cells(2).Value)))
					Dim text3 As String = row.Cells(0).Value.ToString()
					Dim array As Byte() = CType(row.Cells(1).Value, Byte())
					Dim memoryStream As MemoryStream = New MemoryStream(array)
					Me.Picture.Image = Image.FromStream(memoryStream)
					Dim text4 As String = Guid.NewGuid().ToString() + "_tmpp.png"
					Dim text5 As String = MyProject.Application.Info.DirectoryPath + "\Images\product\" + text4
					Me.Panel6.BackgroundImage = Me.Picture.Image
					Using bitmap As Bitmap = New Bitmap(Me.Panel6.Width, Me.Panel6.Height)
						Me.Panel6.DrawToBitmap(bitmap, New Rectangle(0, 0, bitmap.Width, bitmap.Height))
						bitmap.Save(text5)
					End Using
					Dim dataTable As DataTable = New DataTable()
					dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
					Dim text6 As String = "../images/cat/" + text4
					Dim text7 As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/ins-category?"
					stringBuilder.Append(text7)
					stringBuilder.Append("id=" + text2)
					stringBuilder.Append("&catname=" + text3)
					stringBuilder.Append("&catimg=" + text6)
					stringBuilder.Append("&mode=" + mode)
					Dim text8 As String = stringBuilder.ToString().Trim()
					Dim webRequest As WebRequest = WebRequest.Create(text8)
					Dim httpWebRequest As HttpWebRequest = CType(webRequest, HttpWebRequest)
					httpWebRequest.Method = "GET"
					httpWebRequest.ContentType = "application/json"
					Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
					Using streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
						Dim text9 As String = streamReader.ReadToEnd()
						Dim flag As Boolean = text9.Contains("true")
						If flag Then
							Dim text10 As String = text4
							Dim text11 As String = dataTable.Rows(0)("FtpUrl").ToString()
							Dim text12 As String = dataTable.Rows(0)("FtpUser").ToString()
							Dim text13 As String = dataTable.Rows(0)("FtpPassword").ToString()
							Dim text14 As String = text + "/" + text10
							Me.UploadFileToFtp_fluent(text11, text12, text13, text14)
						End If
					End Using
				End Sub))
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x06000F55 RID: 3925 RVA: 0x000B74FC File Offset: 0x000B56FC
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

		' Token: 0x06000F56 RID: 3926 RVA: 0x000B75BC File Offset: 0x000B57BC
		Public Sub UploadFileToSftp(sftpHost As String, sftpUsername As String, sftpPassword As String, filePath As String, port As Integer)
			Try
				Dim flag As Boolean = Not File.Exists(filePath)
				If flag Then
					Throw New FileNotFoundException("File not found: " + filePath)
				End If
				Using sftpClient As SftpClient = New SftpClient(sftpHost, port, sftpUsername, sftpPassword)
					sftpClient.Connect()
					Using fileStream As FileStream = File.OpenRead(filePath)
						sftpClient.UploadFile(fileStream, Path.GetFileName(filePath), True)
						Console.WriteLine("File uploaded successfully.")
					End Using
					sftpClient.Disconnect()
				End Using
			Catch ex As Exception
				Console.WriteLine("Error during SFTP upload: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06000F57 RID: 3927 RVA: 0x000B7698 File Offset: 0x000B5898
		Public Shared Sub UploadFileToFtp_x(ftpUrl As String, username As String, password As String, filePath As String)
			Try
				Dim fileName As String = Path.GetFileName(filePath)
				Dim text As String = String.Format("{0}/{1}", ftpUrl, fileName)
				Console.WriteLine(String.Format("Attempting to upload to FTP path: {0}", text))
				Dim ftpWebRequest As FtpWebRequest = CType(WebRequest.Create(text), FtpWebRequest)
				ftpWebRequest.Method = "STOR"
				ftpWebRequest.Credentials = New NetworkCredential(username, password)
				ftpWebRequest.UseBinary = True
				ftpWebRequest.UsePassive = True
				ftpWebRequest.KeepAlive = False
				Dim array As Byte()
				Using fileStream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
					' The following expression was wrapped in a checked-expression
					array = New Byte(CInt((fileStream.Length - 1L)) + 1 - 1) {}
					fileStream.Read(array, 0, array.Length)
				End Using
				ftpWebRequest.ContentLength = CLng(array.Length)
				Using requestStream As Stream = ftpWebRequest.GetRequestStream()
					requestStream.Write(array, 0, array.Length)
				End Using
				Using ftpWebResponse As FtpWebResponse = CType(ftpWebRequest.GetResponse(), FtpWebResponse)
					Console.WriteLine(String.Format("Upload Status: {0}", ftpWebResponse.StatusDescription))
				End Using
			Catch ex As WebException
				Dim flag As Boolean = TypeOf ex.Response Is FtpWebResponse
				If flag Then
					Dim ftpWebResponse2 As FtpWebResponse = CType(ex.Response, FtpWebResponse)
					Console.WriteLine(String.Format("Error: {0} - {1}", ftpWebResponse2.StatusCode, ftpWebResponse2.StatusDescription))
				Else
					Console.WriteLine(String.Format("Error: {0}", ex.Message))
				End If
			Catch ex2 As Exception
				Console.WriteLine(String.Format("Error: {0}", ex2.Message))
			End Try
		End Sub

		' Token: 0x06000F58 RID: 3928 RVA: 0x000B78C8 File Offset: 0x000B5AC8
		Public Sub UploadFileToFTP(DirPath As String, tmpfilename As String, FtpUrl As String, FtpUser As String, FtpPass As String)
			Dim flag As Boolean = Directory.Exists(DirPath)
			If flag Then
				Dim text As String = Path.Combine(DirPath, tmpfilename)
				Dim flag2 As Boolean = Not File.Exists(text)
				If flag2 Then
					MessageBox.Show("File does not exist: " + text)
				Else
					Dim text2 As String = FtpUrl.TrimEnd(New Char() { "/"c }) + "/cat/" + tmpfilename
					Try
						Dim ftpWebRequest As FtpWebRequest = CType(WebRequest.Create(text2), FtpWebRequest)
						ftpWebRequest.Method = "STOR"
						ftpWebRequest.Credentials = New NetworkCredential(FtpUser, FtpPass)
						ftpWebRequest.UsePassive = True
						ftpWebRequest.UseBinary = True
						ftpWebRequest.KeepAlive = False
						ftpWebRequest.Timeout = 60000
						Dim array As Byte() = File.ReadAllBytes(text)
						ftpWebRequest.ContentLength = CLng(array.Length)
						Using requestStream As Stream = ftpWebRequest.GetRequestStream()
							requestStream.Write(array, 0, array.Length)
						End Using
						Using ftpWebResponse As FtpWebResponse = CType(ftpWebRequest.GetResponse(), FtpWebResponse)
							Me.dgw.Rows(0).Cells(4).Value = "online"
							MessageBox.Show("File uploaded successfully. Status: " + ftpWebResponse.StatusDescription)
						End Using
					Catch ex As WebException
						Dim flag3 As Boolean = ex.Response IsNot Nothing
						If flag3 Then
							Dim ftpWebResponse2 As FtpWebResponse = CType(ex.Response, FtpWebResponse)
							MessageBox.Show("File upload failed: " + ftpWebResponse2.StatusDescription)
						Else
							MessageBox.Show("An error occurred: " + ex.Message)
						End If
					Catch ex2 As Exception
						MessageBox.Show("An unexpected error occurred: " + ex2.Message)
					End Try
				End If
			Else
				MessageBox.Show("Directory does not exist: " + DirPath)
			End If
		End Sub

		' Token: 0x06000F59 RID: 3929 RVA: 0x000B7AF4 File Offset: 0x000B5CF4
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

		' Token: 0x06000F5A RID: 3930 RVA: 0x000B7C70 File Offset: 0x000B5E70
		Private Sub UploadFileToFTP()
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

		' Token: 0x06000F5B RID: 3931 RVA: 0x000B7D50 File Offset: 0x000B5F50
		Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.CheckBox2.Checked
			If checked Then
				Try
					For Each obj As Object In CType(Me.dgw.Rows, IEnumerable)
						Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
						dataGridViewRow.Cells(3).Value = True
					Next
				Finally
					Dim enumerator As IEnumerator
					If TypeOf enumerator Is IDisposable Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Else
				Dim flag As Boolean = Not Me.CheckBox2.Checked
				If flag Then
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataGridViewRow2.Cells(3).Value = False
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
				End If
			End If
		End Sub

		' Token: 0x06000F5C RID: 3932 RVA: 0x0000E5DE File Offset: 0x0000C7DE
		Private Sub btnCash_Click(sender As Object, e As EventArgs)
			Me.senddatatoecomm("i", "A", Nothing)
		End Sub

		' Token: 0x06000F5D RID: 3933 RVA: 0x000B7E5C File Offset: 0x000B605C
		Private Sub dgw_CellClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = (e.RowIndex >= 0) And (e.ColumnIndex >= 0)
			If flag Then
				Dim flag2 As Boolean = e.ColumnIndex = 5
				If flag2 Then
					Dim thread As Thread = New Thread(Sub()
						Me.Invoke(New VB_AnonymousDelegate_0(Sub()
							Me.PictureBox1.Visible = True
							Me.dgw.[ReadOnly] = True
						End Sub))
						Me.senddatatoecomm("i", "S", Me.dgw.Rows(e.RowIndex))
						Me.Invoke(New VB_AnonymousDelegate_0(Sub()
							Me.dgw.[ReadOnly] = False
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
							Me.dgw.[ReadOnly] = True
						End Sub))
						Me.checkdatatoecomm("u", "S", Me.dgw.Rows(e.RowIndex))
						Me.Invoke(New VB_AnonymousDelegate_0(Sub()
							Me.dgw.[ReadOnly] = False
							Me.PictureBox1.Visible = False
						End Sub))
					End Sub)
					thread2.Start()
				End If
			End If
		End Sub

		' Token: 0x06000F5E RID: 3934 RVA: 0x000B7F08 File Offset: 0x000B6108
		Public Sub checkdatarowwise(row As DataGridViewRow, mode As String)
			Try
				Thread.Sleep(1000)
				Me.strb.Clear()
				Dim dataTable As DataTable = New DataTable()
				dataTable = clsfun.ExecDataTable("Select c2,FtpUrl,FtpUser,FtpPassword,WebUrl from FTP_Category where c2='Enabled'")
				Dim text As String = dataTable.Rows(0)("WebUrl").ToString() + "/api/check-category?"
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

		' Token: 0x06000F5F RID: 3935 RVA: 0x000B8108 File Offset: 0x000B6308
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

		' Token: 0x06000F60 RID: 3936 RVA: 0x000B8178 File Offset: 0x000B6378
		Private Sub btnRefress_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = ModFunc.CheckForInternetConnection()
			If flag Then
				Dim thread As Thread = New Thread(Sub()
					MyBase.Invoke(New VB_AnonymousDelegate_0(Sub()
						Me.PictureBox1.Visible = True
						Me.dgw.[ReadOnly] = True
					End Sub))
					Me.checkdatatoecomm("u", "A", Nothing)
					MyBase.Invoke(New VB_AnonymousDelegate_0(Sub()
						Me.dgw.[ReadOnly] = False
						Me.PictureBox1.Visible = False
					End Sub))
				End Sub)
				thread.Start()
			End If
		End Sub

		' Token: 0x06000F61 RID: 3937 RVA: 0x000B81AC File Offset: 0x000B63AC
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
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

		' Token: 0x04000469 RID: 1129
		Private ftpClient As FtpClient

		' Token: 0x0400046A RID: 1130
		Private strb As StringBuilder
	End Class
End Namespace
