Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json.Linq

Namespace BillPoint
	' Token: 0x0200011E RID: 286
	<DesignerGenerated()>
	Public Partial Class frmImageReader
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x060031A8 RID: 12712 RVA: 0x0001EDA2 File Offset: 0x0001CFA2
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmImageReader_Load
			Me.Photoname = ""
			Me.IsImageChanged = False
			Me.apiKey = "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"
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001360 RID: 4960
		' (get) Token: 0x060031AB RID: 12715 RVA: 0x0001EDE2 File Offset: 0x0001CFE2
		' (set) Token: 0x060031AC RID: 12716 RVA: 0x001EC49C File Offset: 0x001EA69C
		Private _btnUpload As Button
		Friend Overridable Property btnUpload As Button
			<CompilerGenerated()>
			Get
				Return Me._btnUpload
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnUpload_Click
				Dim button As Button = Me._btnUpload
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnUpload = value
				button = Me._btnUpload
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001361 RID: 4961
		' (get) Token: 0x060031AD RID: 12717 RVA: 0x0001EDEC File Offset: 0x0001CFEC
		' (set) Token: 0x060031AE RID: 12718 RVA: 0x001EC4E0 File Offset: 0x001EA6E0
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001362 RID: 4962
		' (get) Token: 0x060031AF RID: 12719 RVA: 0x0001EDF6 File Offset: 0x0001CFF6
		' (set) Token: 0x060031B0 RID: 12720 RVA: 0x001EC524 File Offset: 0x001EA724
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

		' Token: 0x17001363 RID: 4963
		' (get) Token: 0x060031B1 RID: 12721 RVA: 0x0001EE00 File Offset: 0x0001D000
		' (set) Token: 0x060031B2 RID: 12722 RVA: 0x0001EE0A File Offset: 0x0001D00A
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x17001364 RID: 4964
		' (get) Token: 0x060031B3 RID: 12723 RVA: 0x0001EE13 File Offset: 0x0001D013
		' (set) Token: 0x060031B4 RID: 12724 RVA: 0x001EC568 File Offset: 0x001EA768
		Private _BStartCapture As Button
		Friend Overridable Property BStartCapture As Button
			<CompilerGenerated()>
			Get
				Return Me._BStartCapture
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.BStartCapture_Click
				Dim button As Button = Me._BStartCapture
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._BStartCapture = value
				button = Me._BStartCapture
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001365 RID: 4965
		' (get) Token: 0x060031B5 RID: 12725 RVA: 0x0001EE1D File Offset: 0x0001D01D
		' (set) Token: 0x060031B6 RID: 12726 RVA: 0x0001EE27 File Offset: 0x0001D027
		Friend Overridable Property Browse As Button

		' Token: 0x17001366 RID: 4966
		' (get) Token: 0x060031B7 RID: 12727 RVA: 0x0001EE30 File Offset: 0x0001D030
		' (set) Token: 0x060031B8 RID: 12728 RVA: 0x0001EE3A File Offset: 0x0001D03A
		Friend Overridable Property BRemove As Button

		' Token: 0x17001367 RID: 4967
		' (get) Token: 0x060031B9 RID: 12729 RVA: 0x0001EE43 File Offset: 0x0001D043
		' (set) Token: 0x060031BA RID: 12730 RVA: 0x0001EE4D File Offset: 0x0001D04D
		Public Overridable Property Picture As PictureBox

		' Token: 0x060031BB RID: 12731 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub frmImageReader_Load(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060031BC RID: 12732 RVA: 0x001EC5AC File Offset: 0x001EA7AC
		Private Async Sub btnUpload_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Image Files|*.jpg;*.png;*.bmp"
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				Me.TextBox1.Text = Await Me.PerformOCR(openFileDialog.FileName)
			End If
		End Sub

		' Token: 0x060031BD RID: 12733 RVA: 0x001EC5F4 File Offset: 0x001EA7F4
		Public Async Function PerformOCR(imagePath As String) As Task(Of String)
			Dim text2 As String
			Try
				Dim flag As Boolean = Not File.Exists(imagePath)
				If flag Then
					MessageBox.Show("Error: Image file not found!")
					text2 = ""
				Else
					Dim imageBytes As Byte() = File.ReadAllBytes(imagePath)
					Dim base64Image As String = Convert.ToBase64String(imageBytes)
					Dim jsonRequest As String = "{" & vbCrLf & "    ""model"": ""gpt-4o""," & vbCrLf & "    ""messages"": [        " & vbCrLf & "        {""role"": ""system"", ""content"": ""You are an OCR assistant that extracts product names from images. Only return the product name without any additional text.""}," & vbCrLf & "        {""role"": ""user"", ""content"": [" & vbCrLf & "            {""type"": ""image_url"", ""image_url"": {""url"": ""data:image/jpeg;base64," + base64Image + """}}" & vbCrLf & "        ]}" & vbCrLf & "    ]" & vbCrLf & "}"
					Using client As HttpClient = New HttpClient()
						client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Me.apiKey)
						Dim response As HttpResponseMessage = Await client.PostAsync("https://api.openai.com/v1/chat/completions", New StringContent(jsonRequest, Encoding.UTF8, "application/json"))
						Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
						If response.StatusCode <> HttpStatusCode.OK Then
							MessageBox.Show("API Error: " + jsonResponse)
							text2 = ""
						Else
							Dim result As JObject = JObject.Parse(jsonResponse)
							If result("choices") Is Nothing OrElse result("choices").Count() = 0 Then
								MessageBox.Show("Error: No response from GPT-4 Vision.")
								text2 = ""
							Else
								Dim text As String = result("choices")(0)("message")("content").ToString()
								text2 = text
							End If
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("OCR Error: " + ex.Message)
				text2 = ""
			End Try
			Return text2
		End Function

		' Token: 0x060031BE RID: 12734 RVA: 0x00009E98 File Offset: 0x00008098
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
		End Sub

		' Token: 0x060031BF RID: 12735 RVA: 0x001EC640 File Offset: 0x001EA840
		Private Async Sub Button1_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Image Files|*.jpg;*.png;*.bmp"
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				Me.TextBox1.Text = Await Me.PerformOCR_(openFileDialog.FileName)
				Dim match As Match = Regex.Match(Me.TextBox1.Text, "^\S+")
				If match.Success Then
					Dim cleanedStr As String = match.Value
					Dim matchx As Match = Regex.Match(cleanedStr, "^[a-zA-Z0-9\s]+")
					If matchx.Success AndAlso matchx.Value.Length > 1 Then
						' The following expression was wrapped in a checked-expression
						Me.TextBox2.Text = matchx.Value.Substring(0, matchx.Value.Length - 2)
					Else
						Me.TextBox2.Text = matchx.Value
					End If
				Else
					MessageBox.Show("No valid characters found")
				End If
			End If
		End Sub

		' Token: 0x060031C0 RID: 12736 RVA: 0x001EC688 File Offset: 0x001EA888
		Public Async Function PerformOCR_(imagePath As String) As Task(Of String)
			Dim text As String
			Try
				Dim flag As Boolean = Not File.Exists(imagePath)
				If flag Then
					MessageBox.Show("Error: Image file not found!")
					text = ""
				Else
					Dim imageBytes As Byte() = File.ReadAllBytes(imagePath)
					Dim base64Image As String = Convert.ToBase64String(imageBytes)
					Dim jsonRequest As String = "{" & vbCrLf & "            ""model"": ""gpt-4o-mini""," & vbCrLf & "            ""messages"": [" & vbCrLf & "                {""role"": ""system"", ""content"": ""Identify main object of image and provide product name in hindi only(name with singular noun, not plural noun).""}," & vbCrLf & "                {""role"": ""user"", ""content"": [" & vbCrLf & "                    {""type"": ""image_url"", ""image_url"": {""url"": ""data:image/jpeg;base64," + base64Image + """}}" & vbCrLf & "                ]}" & vbCrLf & "            ]" & vbCrLf & "        }"
					Using client As HttpClient = New HttpClient()
						client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Me.apiKey)
						Dim response As HttpResponseMessage = Await client.PostAsync("https://api.openai.com/v1/chat/completions", New StringContent(jsonRequest, Encoding.UTF8, "application/json"))
						Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
						If response.StatusCode <> HttpStatusCode.OK Then
							MessageBox.Show("API Error: " + jsonResponse)
							text = ""
						Else
							Dim result As JObject = JObject.Parse(jsonResponse)
							If result("choices") Is Nothing OrElse result("choices").Count() = 0 Then
								MessageBox.Show("Error: No response from GPT-4 Vision.")
								text = ""
							Else
								Dim extractedText As String = result("choices")(0)("message")("content").ToString()
								text = extractedText
							End If
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("OCR Error: " + ex.Message)
				text = ""
			End Try
			Return text
		End Function

		' Token: 0x060031C1 RID: 12737 RVA: 0x001EC6D4 File Offset: 0x001EA8D4
		Private Sub BStartCapture_Click(sender As Object, e As EventArgs)
			Dim frmCamera As frmCamera = New frmCamera()
			frmCamera.ShowDialog()
			Dim flag As Boolean = ModCommonClasses.TempFileNames2.Length > 0
			If flag Then
				Me.Picture.Image = Image.FromFile(ModCommonClasses.TempFileNames2)
				Me.Photoname = ModCommonClasses.TempFileNames2
				Me.IsImageChanged = True
				Me.ImageExtrator()
			End If
		End Sub

		' Token: 0x060031C2 RID: 12738 RVA: 0x001EC734 File Offset: 0x001EA934
		Public Async Sub ImageExtrator()
			Dim flag As Boolean = File.Exists(ModCommonClasses.TempFileNames2)
			If flag Then
				Me.TextBox1.Text = Await Me.PerformOCR_(ModCommonClasses.TempFileNames2)
				Dim match As Match = Regex.Match(Me.TextBox1.Text, "^\S+")
				If match.Success Then
					Dim cleanedStr As String = match.Value
					Dim matchx As Match = Regex.Match(cleanedStr, "^[a-zA-Z0-9\s]+")
					If matchx.Success AndAlso matchx.Value.Length > 1 Then
						' The following expression was wrapped in a checked-expression
						Me.TextBox2.Text = matchx.Value.Substring(0, matchx.Value.Length - 2)
					Else
						Me.TextBox2.Text = matchx.Value
					End If
				Else
					MessageBox.Show("No valid characters found")
				End If
			Else
				MessageBox.Show("Captured image not found.")
			End If
		End Sub

		' Token: 0x04001557 RID: 5463
		Private Photoname As String

		' Token: 0x04001558 RID: 5464
		Private IsImageChanged As Boolean

		' Token: 0x04001559 RID: 5465
		Private apiKey As String
	End Class
End Namespace
