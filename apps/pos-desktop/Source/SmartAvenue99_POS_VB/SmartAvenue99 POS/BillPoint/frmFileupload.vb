Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports Renci.SshNet

Namespace BillPoint
	' Token: 0x02000111 RID: 273
	<DesignerGenerated()>
	Public Partial Class frmFileupload
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06002DCC RID: 11724 RVA: 0x0001D04B File Offset: 0x0001B24B
		Public Sub New()
			Me.InitializeComponent()
		End Sub

		' Token: 0x170011D1 RID: 4561
		' (get) Token: 0x06002DCF RID: 11727 RVA: 0x0001D059 File Offset: 0x0001B259
		' (set) Token: 0x06002DD0 RID: 11728 RVA: 0x001C6AD4 File Offset: 0x001C4CD4
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

		' Token: 0x06002DD1 RID: 11729 RVA: 0x001C6B18 File Offset: 0x001C4D18
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim text As String = "ftp://raintechweb.com/"
			Dim text2 As String = "salebooster"
			Dim text3 As String = "8d3Rt66&n"
			Dim text4 As String = "C:/Users/hp/Desktop/test.png"
			frmFileupload.UploadFileToFtp_x(text, text2, text3, text4)
		End Sub

		' Token: 0x06002DD2 RID: 11730 RVA: 0x000B75BC File Offset: 0x000B57BC
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

		' Token: 0x06002DD3 RID: 11731 RVA: 0x001C6B48 File Offset: 0x001C4D48
		Public Shared Sub UploadFileToFtp_x(ftpUrl As String, username As String, password As String, filePath As String)
			Try
				Dim fileName As String = Path.GetFileName(filePath)
				Dim text As String = String.Format("{0}/{1}", ftpUrl, fileName)
				Console.WriteLine(String.Format("Attempting to upload to FTP path: {0}", text))
				Dim ftpWebRequest As FtpWebRequest = CType(WebRequest.Create(text), FtpWebRequest)
				ftpWebRequest.Method = "STOR"
				ftpWebRequest.Credentials = New NetworkCredential(username, password)
				ftpWebRequest.UsePassive = False
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
	End Class
End Namespace
