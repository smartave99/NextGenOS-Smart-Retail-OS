Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.CompilerServices
Imports Nancy.Json

Namespace BillPoint
	' Token: 0x0200008A RID: 138
	<DesignerGenerated()>
	Public Partial Class frmSMS_AutoDetect
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060016F1 RID: 5873 RVA: 0x00012311 File Offset: 0x00010511
		Public Sub New()
			AddHandler MyBase.FormClosing, AddressOf Me.Form1_FormClosing
			Me.jsonSerializer = New JavaScriptSerializer()
			Me.InitializeComponent()
		End Sub

		' Token: 0x17000934 RID: 2356
		' (get) Token: 0x060016F4 RID: 5876 RVA: 0x0001233F File Offset: 0x0001053F
		' (set) Token: 0x060016F5 RID: 5877 RVA: 0x00012349 File Offset: 0x00010549
		Friend Overridable Property txtOutput As TextBox

		' Token: 0x17000935 RID: 2357
		' (get) Token: 0x060016F6 RID: 5878 RVA: 0x00012352 File Offset: 0x00010552
		' (set) Token: 0x060016F7 RID: 5879 RVA: 0x000FB048 File Offset: 0x000F9248
		Private _btnStartListener As Button
		Friend Overridable Property btnStartListener As Button
			<CompilerGenerated()>
			Get
				Return Me._btnStartListener
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnStartListener_Click
				Dim button As Button = Me._btnStartListener
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnStartListener = value
				button = Me._btnStartListener
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x060016F8 RID: 5880 RVA: 0x000FB08C File Offset: 0x000F928C
		Private Sub btnStartListener_Click(sender As Object, e As EventArgs)
			Me.serverThread = New System.Threading.Thread(AddressOf Me.StartServer)
			Me.serverThread.IsBackground = True
			Me.serverThread.Start()
			Me.btnStartListener.Enabled = False
			Me.UpdateLog("Server started! Waiting for SMS...")
		End Sub

		' Token: 0x060016F9 RID: 5881 RVA: 0x000FB0E4 File Offset: 0x000F92E4
		Private Sub StartServer()
			Try
				Me.Listener = New HttpListener()
				Me.Listener.Prefixes.Add("http://192.168.31.239:8080/smsreceiver/")
				Me.Listener.Start()
				While True
					Dim context As HttpListenerContext = Me.Listener.GetContext()
					Me.ProcessRequest(context)
				End While
			Catch ex As Exception
				Me.UpdateLog("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060016FA RID: 5882 RVA: 0x000FB174 File Offset: 0x000F9374
		Private Sub ProcessRequest(context As HttpListenerContext)
			Dim request As HttpListenerRequest = context.Request
			Dim response As HttpListenerResponse = context.Response
			Dim text As String = ""
			Try
				Dim httpMethod As String = request.HttpMethod
				Me.UpdateLog("Method: " + httpMethod)
				Me.UpdateLog("Content-Type: " + request.ContentType)
				Dim flag As Boolean = request.QueryString.HasKeys()
				If flag Then
					Me.UpdateLog(">> Data found in URL (QueryString):")
					For Each text2 As String In request.QueryString.AllKeys
						text = String.Concat(New String() { text, text2, ": ", request.QueryString(text2), vbCrLf })
					Next
				End If
				Dim hasEntityBody As Boolean = request.HasEntityBody
				If hasEntityBody Then
					Using streamReader As StreamReader = New StreamReader(request.InputStream, request.ContentEncoding)
						Dim text3 As String = streamReader.ReadToEnd()
						Dim flag2 As Boolean = Not String.IsNullOrEmpty(text3)
						If flag2 Then
							Me.UpdateLog(">> Data found in Body:")
							text += text3
						End If
					End Using
				End If
				Dim flag3 As Boolean = String.IsNullOrEmpty(text)
				If flag3 Then
					Me.UpdateLog("WARNING: No data found in URL or Body.")
				Else
					Me.UpdateLog("-----------------")
					Me.UpdateLog("SMS CONTENT:")
					Me.UpdateLog(text)
					Me.UpdateLog("-----------------")
				End If
				Dim text4 As String = "OK"
				Dim bytes As Byte() = Encoding.UTF8.GetBytes(text4)
				response.ContentLength64 = CLng(bytes.Length)
				response.OutputStream.Write(bytes, 0, bytes.Length)
				response.OutputStream.Close()
			Catch ex As Exception
				Me.UpdateLog("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x060016FB RID: 5883 RVA: 0x000FB394 File Offset: 0x000F9594
		Private Sub UpdateLog(message As String)
			Dim invokeRequired As Boolean = Me.txtOutput.InvokeRequired
			If invokeRequired Then
				Me.txtOutput.Invoke(New VB_AnonymousDelegate_0(Sub()
					Me.UpdateLog(message)
				End Sub))
			Else
				Me.txtOutput.AppendText(message + vbCrLf)
			End If
		End Sub

		' Token: 0x060016FC RID: 5884 RVA: 0x000FB400 File Offset: 0x000F9600
		Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs)
			Dim flag As Boolean = Me.Listener IsNot Nothing AndAlso Me.Listener.IsListening
			If flag Then
				Me.Listener.[Stop]()
			End If
		End Sub

		' Token: 0x04000896 RID: 2198
		Private serverThread As Thread

		' Token: 0x04000897 RID: 2199
		Private Listener As HttpListener

		' Token: 0x04000898 RID: 2200
		Private jsonSerializer As JavaScriptSerializer
	End Class
End Namespace
