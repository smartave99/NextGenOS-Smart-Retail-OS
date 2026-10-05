Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net.Http
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports BillPoint.My
Imports BillPoint.My.Resources
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports UglyToad.PdfPig
Imports UglyToad.PdfPig.Content
Imports ZXing
Imports ZXing.QrCode

Namespace BillPoint
	' Token: 0x02000137 RID: 311
	<DesignerGenerated()>
	Public Partial Class frmPdfReader
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06003551 RID: 13649 RVA: 0x0020C5CC File Offset: 0x0020A7CC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmPdfReader_Load
			Me.dt_DSaleProduct = New DataTable()
			Me.dtBarcodes = New DataTable()
			Me.apiKey = ""
			Me.url = ""
			Me.filetype = ""
			Me.imgPath = ""
			Me.selectedRowIndex = -1
			Me.strtype = 0
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001496 RID: 5270
		' (get) Token: 0x06003554 RID: 13652 RVA: 0x00020A66 File Offset: 0x0001EC66
		' (set) Token: 0x06003555 RID: 13653 RVA: 0x00020A70 File Offset: 0x0001EC70
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17001497 RID: 5271
		' (get) Token: 0x06003556 RID: 13654 RVA: 0x00020A79 File Offset: 0x0001EC79
		' (set) Token: 0x06003557 RID: 13655 RVA: 0x0020D4D4 File Offset: 0x0020B6D4
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewCellEventHandler As DataGridViewCellEventHandler = AddressOf Me.DataGridView1_CellDoubleClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.CellDoubleClick, dataGridViewCellEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001498 RID: 5272
		' (get) Token: 0x06003558 RID: 13656 RVA: 0x00020A83 File Offset: 0x0001EC83
		' (set) Token: 0x06003559 RID: 13657 RVA: 0x0020D518 File Offset: 0x0020B718
		Private _btnProcessPdf As Button
		Friend Overridable Property btnProcessPdf As Button
			<CompilerGenerated()>
			Get
				Return Me._btnProcessPdf
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnProcessPdf_Click
				Dim button As Button = Me._btnProcessPdf
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnProcessPdf = value
				button = Me._btnProcessPdf
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001499 RID: 5273
		' (get) Token: 0x0600355A RID: 13658 RVA: 0x00020A8D File Offset: 0x0001EC8D
		' (set) Token: 0x0600355B RID: 13659 RVA: 0x0020D55C File Offset: 0x0020B75C
		Private _btnResult As Button
		Friend Overridable Property btnResult As Button
			<CompilerGenerated()>
			Get
				Return Me._btnResult
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnResult_Click
				Dim button As Button = Me._btnResult
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnResult = value
				button = Me._btnResult
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700149A RID: 5274
		' (get) Token: 0x0600355C RID: 13660 RVA: 0x00020A97 File Offset: 0x0001EC97
		' (set) Token: 0x0600355D RID: 13661 RVA: 0x00020AA1 File Offset: 0x0001ECA1
		Friend Overridable Property TextBox2 As TextBox

		' Token: 0x1700149B RID: 5275
		' (get) Token: 0x0600355E RID: 13662 RVA: 0x00020AAA File Offset: 0x0001ECAA
		' (set) Token: 0x0600355F RID: 13663 RVA: 0x0020D5A0 File Offset: 0x0020B7A0
		Private _btnSettle As Button
		Friend Overridable Property btnSettle As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSettle
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSettle_Click
				Dim button As Button = Me._btnSettle
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSettle = value
				button = Me._btnSettle
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700149C RID: 5276
		' (get) Token: 0x06003560 RID: 13664 RVA: 0x00020AB4 File Offset: 0x0001ECB4
		' (set) Token: 0x06003561 RID: 13665 RVA: 0x00020ABE File Offset: 0x0001ECBE
		Friend Overridable Property txtID_temp As TextBox

		' Token: 0x1700149D RID: 5277
		' (get) Token: 0x06003562 RID: 13666 RVA: 0x00020AC7 File Offset: 0x0001ECC7
		' (set) Token: 0x06003563 RID: 13667 RVA: 0x00020AD1 File Offset: 0x0001ECD1
		Friend Overridable Property txtBar As TextBox

		' Token: 0x1700149E RID: 5278
		' (get) Token: 0x06003564 RID: 13668 RVA: 0x00020ADA File Offset: 0x0001ECDA
		' (set) Token: 0x06003565 RID: 13669 RVA: 0x00020AE4 File Offset: 0x0001ECE4
		Public Overridable Property Photo As PictureBox

		' Token: 0x1700149F RID: 5279
		' (get) Token: 0x06003566 RID: 13670 RVA: 0x00020AED File Offset: 0x0001ECED
		' (set) Token: 0x06003567 RID: 13671 RVA: 0x00020AF7 File Offset: 0x0001ECF7
		Friend Overridable Property pbgiftqr As PictureBox

		' Token: 0x170014A0 RID: 5280
		' (get) Token: 0x06003568 RID: 13672 RVA: 0x00020B00 File Offset: 0x0001ED00
		' (set) Token: 0x06003569 RID: 13673 RVA: 0x00020B0A File Offset: 0x0001ED0A
		Friend Overridable Property txtBarcode As TextBox

		' Token: 0x170014A1 RID: 5281
		' (get) Token: 0x0600356A RID: 13674 RVA: 0x00020B13 File Offset: 0x0001ED13
		' (set) Token: 0x0600356B RID: 13675 RVA: 0x00020B1D File Offset: 0x0001ED1D
		Friend Overridable Property TextBox4 As TextBox

		' Token: 0x170014A2 RID: 5282
		' (get) Token: 0x0600356C RID: 13676 RVA: 0x00020B26 File Offset: 0x0001ED26
		' (set) Token: 0x0600356D RID: 13677 RVA: 0x00020B30 File Offset: 0x0001ED30
		Friend Overridable Property txtMrp_per As TextBox

		' Token: 0x170014A3 RID: 5283
		' (get) Token: 0x0600356E RID: 13678 RVA: 0x00020B39 File Offset: 0x0001ED39
		' (set) Token: 0x0600356F RID: 13679 RVA: 0x00020B43 File Offset: 0x0001ED43
		Friend Overridable Property Label1 As Label

		' Token: 0x170014A4 RID: 5284
		' (get) Token: 0x06003570 RID: 13680 RVA: 0x00020B4C File Offset: 0x0001ED4C
		' (set) Token: 0x06003571 RID: 13681 RVA: 0x00020B56 File Offset: 0x0001ED56
		Friend Overridable Property Label2 As Label

		' Token: 0x170014A5 RID: 5285
		' (get) Token: 0x06003572 RID: 13682 RVA: 0x00020B5F File Offset: 0x0001ED5F
		' (set) Token: 0x06003573 RID: 13683 RVA: 0x00020B69 File Offset: 0x0001ED69
		Friend Overridable Property txtWholesale_per As TextBox

		' Token: 0x170014A6 RID: 5286
		' (get) Token: 0x06003574 RID: 13684 RVA: 0x00020B72 File Offset: 0x0001ED72
		' (set) Token: 0x06003575 RID: 13685 RVA: 0x0020D5E4 File Offset: 0x0020B7E4
		Private _chkAll As CheckBox
		Friend Overridable Property chkAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkAll = value
				checkBox = Me._chkAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170014A7 RID: 5287
		' (get) Token: 0x06003576 RID: 13686 RVA: 0x00020B7C File Offset: 0x0001ED7C
		' (set) Token: 0x06003577 RID: 13687 RVA: 0x0020D628 File Offset: 0x0020B828
		Private _btnApply As Button
		Friend Overridable Property btnApply As Button
			<CompilerGenerated()>
			Get
				Return Me._btnApply
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnApply_Click
				Dim button As Button = Me._btnApply
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnApply = value
				button = Me._btnApply
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170014A8 RID: 5288
		' (get) Token: 0x06003578 RID: 13688 RVA: 0x00020B86 File Offset: 0x0001ED86
		' (set) Token: 0x06003579 RID: 13689 RVA: 0x00020B90 File Offset: 0x0001ED90
		Friend Overridable Property pnlDate As Panel

		' Token: 0x170014A9 RID: 5289
		' (get) Token: 0x0600357A RID: 13690 RVA: 0x00020B99 File Offset: 0x0001ED99
		' (set) Token: 0x0600357B RID: 13691 RVA: 0x0020D66C File Offset: 0x0020B86C
		Private _dtpDate As DateTimePicker
		Friend Overridable Property dtpDate As DateTimePicker
			<CompilerGenerated()>
			Get
				Return Me._dtpDate
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DateTimePicker)
				Dim keyEventHandler As KeyEventHandler = AddressOf Me.dtpDate_KeyDown
				Dim dateTimePicker As DateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					RemoveHandler dateTimePicker.KeyDown, keyEventHandler
				End If
				Me._dtpDate = value
				dateTimePicker = Me._dtpDate
				If dateTimePicker IsNot Nothing Then
					AddHandler dateTimePicker.KeyDown, keyEventHandler
				End If
			End Set
		End Property

		' Token: 0x170014AA RID: 5290
		' (get) Token: 0x0600357C RID: 13692 RVA: 0x00020BA3 File Offset: 0x0001EDA3
		' (set) Token: 0x0600357D RID: 13693 RVA: 0x0020D6B0 File Offset: 0x0020B8B0
		Private _btnOk As Button
		Friend Overridable Property btnOk As Button
			<CompilerGenerated()>
			Get
				Return Me._btnOk
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnOk_Click
				Dim button As Button = Me._btnOk
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnOk = value
				button = Me._btnOk
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170014AB RID: 5291
		' (get) Token: 0x0600357E RID: 13694 RVA: 0x00020BAD File Offset: 0x0001EDAD
		' (set) Token: 0x0600357F RID: 13695 RVA: 0x00020BB7 File Offset: 0x0001EDB7
		Friend Overridable Property ProgressBar1 As ProgressBar

		' Token: 0x170014AC RID: 5292
		' (get) Token: 0x06003580 RID: 13696 RVA: 0x00020BC0 File Offset: 0x0001EDC0
		' (set) Token: 0x06003581 RID: 13697 RVA: 0x0020D6F4 File Offset: 0x0020B8F4
		Private _GelButton3 As Button
		Friend Overridable Property GelButton3 As Button
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim button As Button = Me._GelButton3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._GelButton3 = value
				button = Me._GelButton3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06003582 RID: 13698 RVA: 0x0020D738 File Offset: 0x0020B938
		Private Sub btnProcessPdf_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Supported Files|*.pdf;*.jpg;*.jpeg;*.png"
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				Dim fileName As String = openFileDialog.FileName
				Dim text As String = Path.GetExtension(fileName).ToLower()
				Dim text2 As String = ""
				Me.imgPath = fileName
				Me.filetype = text
				Dim flag2 As Boolean = Operators.CompareString(text, ".pdf", False) = 0
				If flag2 Then
					text2 = Me.ReadPdfWithPdfPig(fileName)
				Else
					Dim flag3 As Boolean = Operators.CompareString(text, ".jpg", False) = 0 OrElse Operators.CompareString(text, ".jpeg", False) = 0 OrElse Operators.CompareString(text, ".png", False) = 0
					If Not flag3 Then
						MessageBox.Show("Unsupported file type.")
						Return
					End If
				End If
				Me.TextBox1.Text = text2
				Me.TextBox2.Text = "items: A list of extracted product details, each containing:" & vbCrLf & "sl_no: Serial number of the item in the invoice of first coloumn in table." & vbCrLf & "product_name: Name of the product." & vbCrLf & "hsn_code: HSN code assigned as per government rules (if available, otherwise null)." & vbCrLf & "quantity: Quantity purchased." & vbCrLf & "unit: Unit of measurement." & vbCrLf & vbCrLf & "rate: Price per Quantity." & vbCrLf & "total_gst_rate: tax GST percentage (SGST + CGST + IGST) as applicable to the product." & vbCrLf & "discount: total discount percentage as applicable to the product (if available, otherwise null)." & vbCrLf & "If anyThen field is missing, mark it as null. Ensure accuracy by considering synonyms and variations in formatting. Return only the structured JSON output without any additional explanation." & vbCrLf & "according to this product class generate"
			End If
		End Sub

		' Token: 0x06003583 RID: 13699 RVA: 0x0020D818 File Offset: 0x0020BA18
		Public Async Function PerformOCR(imagePath As String) As Task
			Try
				Dim flag As Boolean = Not File.Exists(imagePath)
				If flag Then
					MessageBox.Show("Error: Image file not found!")
				Else
					Dim imageBytes As Byte() = File.ReadAllBytes(imagePath)
					Dim base64Image As String = Convert.ToBase64String(imageBytes)
					Dim requestData As Dictionary(Of String, Object) = New Dictionary(Of String, Object)() From { { "model", "gpt-4o" }, { "messages", New List(Of Object)() From { New Dictionary(Of String, String)() From { { "role", "system" }, { "content", "You are an OCR assistant. Extract product data as JSON with items: A list of extracted product details, each containing:" & vbCrLf & "sl_no: Serial number of the item in the invoice of first coloumn in table." & vbCrLf & "product_name: Name of the product." & vbCrLf & "hsn_code: HSN code assigned as per government rules (if available, otherwise null)." & vbCrLf & "quantity: Quantity purchased." & vbCrLf & "unit: Unit of measurement." & vbCrLf & vbCrLf & "rate: Price per Quantity." & vbCrLf & "total_gst_rate: tax GST percentage (SGST + CGST + IGST) as applicable to the product." & vbCrLf & "discount: total discount percentage as applicable to the product (if available, otherwise null)." & vbCrLf & "If anyThen field is missing, mark it as null. Ensure accuracy by considering synonyms and variations in formatting. Return only the structured JSON output without any additional explanation." & vbCrLf & "according to this product class generate" } }, New Dictionary(Of String, Object)() From { { "role", "user" }, { "content", New List(Of Object)() From { New Dictionary(Of String, Object)() From { { "type", "image_url" }, { "image_url", New Dictionary(Of String, String)() From { { "url", "data:image/jpeg;base64," + base64Image } } } } } } } } }, { "temperature", 0.2 } }
					Dim jsonData As String = JsonConvert.SerializeObject(requestData)
					Using client As HttpClient = New HttpClient()
						client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Me.apiKey)
						Dim content As StringContent = New StringContent(jsonData, Encoding.UTF8, "application/json")
						Dim response As HttpResponseMessage = Await client.PostAsync("https://api.openai.com/v1/chat/completions", content)
						If response.IsSuccessStatusCode Then
							Dim responseString As String = Await response.Content.ReadAsStringAsync()
							Dim jsonResponse As JObject = JObject.Parse(responseString)
							Dim rawContent As String = jsonResponse("choices")(0)("message")("content").ToString()
							Dim cleanJson As String = rawContent.Replace("```json", "").Replace("```", "").Trim()
							Dim parsedJson As JObject = JObject.Parse(cleanJson)
							If parsedJson("items") IsNot Nothing Then
								Dim products As List(Of frmPdfReader.Product) = JsonConvert.DeserializeObject(Of List(Of frmPdfReader.Product))(parsedJson("items").ToString())
								Me.DataGridView1.Invoke(New VB_AnonymousDelegate_0(Sub()
									Me.DataGridView1.DataSource = Nothing
									Me.DataGridView1.Rows.Clear()
									Me.DataGridView1.Columns.Clear()
									Dim dataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
									dataGridViewCheckBoxColumn.Name = "Select"
									dataGridViewCheckBoxColumn.HeaderText = "Select"
									dataGridViewCheckBoxColumn.DataPropertyName = "IsChecked"
									dataGridViewCheckBoxColumn.TrueValue = True
									dataGridViewCheckBoxColumn.FalseValue = False
									dataGridViewCheckBoxColumn.[ReadOnly] = False
									Me.DataGridView1.Columns.Add(dataGridViewCheckBoxColumn)
									Me.DataGridView1.DataSource = products
									Try
										For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
											Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
											Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
											If flag2 Then
												dataGridViewRow.Cells("Select").Value = True
											End If
										Next
									Finally
										Dim enumerator As IEnumerator
										If TypeOf enumerator Is IDisposable Then
											TryCast(enumerator, IDisposable).Dispose()
										End If
									End Try
									Dim array As String() = New String() { "MRP", "SALE PRICE", "W PRICE", "COLOR", "SIZE", "PART NUMBER", "BATCH NUMBER", "M DATE", "EX DATE" }
									For Each text As String In array
										Dim flag3 As Boolean = Not Me.DataGridView1.Columns.Contains(text)
										If flag3 Then
											Me.DataGridView1.Columns.Add(text, text)
										End If
									Next
									Try
										For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
											Dim dataGridViewRow2 As DataGridViewRow = CType(obj2, DataGridViewRow)
											Dim flag4 As Boolean = Not dataGridViewRow2.IsNewRow
											If flag4 Then
												For Each text2 As String In array
													dataGridViewRow2.Cells(text2).Value = ""
												Next
											End If
										Next
									Finally
										Dim enumerator2 As IEnumerator
										If TypeOf enumerator2 Is IDisposable Then
											TryCast(enumerator2, IDisposable).Dispose()
										End If
									End Try
								End Sub))
								AddHandler Me.btnApply.Click, AddressOf Me.btnApply_Click
								Me.btnApply_Click(Nothing, EventArgs.Empty)
							Else
								MessageBox.Show("No items found in OCR response.")
							End If
						Else
							MessageBox.Show("API Error: " + response.StatusCode.ToString())
						End If
					End Using
				End If
			Catch ex As Exception
				MessageBox.Show("OCR Exception: " + ex.Message)
			End Try
		End Function

		' Token: 0x06003584 RID: 13700 RVA: 0x0020D864 File Offset: 0x0020BA64
		Private Function ReadPdfWithPdfPig(pdfPath As String) As String
			Dim stringBuilder As StringBuilder = New StringBuilder()
			Using fileStream As FileStream = New FileStream(pdfPath, FileMode.Open, FileAccess.Read)
				Using pdfDocument As PdfDocument = PdfDocument.Open(fileStream, Nothing)
					Try
						For Each page As Page In pdfDocument.GetPages()
							stringBuilder.AppendLine(page.Text)
						Next
					Finally
						Dim enumerator As IEnumerator(Of Page)
						If enumerator IsNot Nothing Then
							enumerator.Dispose()
						End If
					End Try
				End Using
			End Using
			Return stringBuilder.ToString()
		End Function

		' Token: 0x06003585 RID: 13701 RVA: 0x0020D91C File Offset: 0x0020BB1C
		Public Sub GetApiDtl()
			Dim dataTable As DataTable = New DataTable()
			Dim sqlConnection As SqlConnection = New SqlConnection(ModCS.cs)
			sqlConnection.Open()
			Dim text As String = "select * from tbl_api_setting where isDefault='Yes' and isEnabled='Yes' "
			Dim sqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(text, sqlConnection)
			sqlDataAdapter.Fill(dataTable)
			Dim flag As Boolean = dataTable.Rows.Count > 0
			If flag Then
				Me.apiKey = dataTable.Rows(0)(2).ToString()
				Me.url = dataTable.Rows(0)(1).ToString()
			End If
			sqlConnection.Close()
		End Sub

		' Token: 0x06003586 RID: 13702 RVA: 0x0020D9B0 File Offset: 0x0020BBB0
		Public Async Function MakeApiRequest(prompt As String) As Task
			Dim requestData As Dictionary(Of String, Object) = New Dictionary(Of String, Object)() From { { "model", "gpt-4o" }, { "messages", New List(Of Object)() From { New Dictionary(Of String, String)() From { { "role", "user" }, { "content", prompt } } } }, { "temperature", 0.7 } }
			Dim jsonData As String = JsonConvert.SerializeObject(requestData)
			Try
				Using client As HttpClient = New HttpClient()
					client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Me.apiKey)
					Dim content As StringContent = New StringContent(jsonData, Encoding.UTF8, "application/json")
					Dim response As HttpResponseMessage = Await client.PostAsync(Me.url, content)
					If response.IsSuccessStatusCode Then
						Dim responseString As String = Await response.Content.ReadAsStringAsync()
						Dim jsonResponse As JObject = JObject.Parse(responseString)
						Dim rawContent As String = jsonResponse("choices")(0)("message")("content").ToString()
						Dim cleanJson As String = rawContent.Replace("```json", "").Replace("```", "").Trim()
						Dim parsedJson As JObject = JObject.Parse(cleanJson)
						If parsedJson("items") IsNot Nothing Then
							Dim products As List(Of frmPdfReader.Product) = JsonConvert.DeserializeObject(Of List(Of frmPdfReader.Product))(parsedJson("items").ToString())
							Me.DataGridView1.Invoke(New VB_AnonymousDelegate_0(Sub()
								Me.DataGridView1.DataSource = Nothing
								Me.DataGridView1.Rows.Clear()
								Me.DataGridView1.Columns.Clear()
								Dim flag As Boolean = False
								Try
									For Each obj As Object In Me.DataGridView1.Columns
										Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
										Dim flag2 As Boolean = Operators.CompareString(dataGridViewColumn.Name, "Select", False) = 0
										If flag2 Then
											flag = True
											Exit For
										End If
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
								Dim flag3 As Boolean = Not flag
								If flag3 Then
									Dim dataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
									dataGridViewCheckBoxColumn.Name = "Select"
									dataGridViewCheckBoxColumn.HeaderText = "Select"
									dataGridViewCheckBoxColumn.DataPropertyName = "IsChecked"
									dataGridViewCheckBoxColumn.TrueValue = True
									dataGridViewCheckBoxColumn.FalseValue = False
									dataGridViewCheckBoxColumn.[ReadOnly] = False
									Me.DataGridView1.Columns.Add(dataGridViewCheckBoxColumn)
								End If
								Me.DataGridView1.DataSource = products
								Try
									For Each obj2 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
										Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
										Dim flag4 As Boolean = Not dataGridViewRow.IsNewRow
										If flag4 Then
											dataGridViewRow.Cells("Select").Value = True
										End If
									Next
								Finally
									Dim enumerator2 As IEnumerator
									If TypeOf enumerator2 Is IDisposable Then
										TryCast(enumerator2, IDisposable).Dispose()
									End If
								End Try
								Dim array As String() = New String() { "MRP", "SALE PRICE", "W PRICE", "COLOR", "SIZE", "PART NUMBER", "BATCH NUMBER", "M DATE", "EX DATE" }
								For Each text As String In array
									Dim flag5 As Boolean = Not Me.DataGridView1.Columns.Contains(text)
									If flag5 Then
										Me.DataGridView1.Columns.Add(text, text)
									End If
								Next
								Try
									For Each obj3 As Object In CType(Me.DataGridView1.Rows, IEnumerable)
										Dim dataGridViewRow2 As DataGridViewRow = CType(obj3, DataGridViewRow)
										Dim flag6 As Boolean = Not dataGridViewRow2.IsNewRow
										If flag6 Then
											For Each text2 As String In array
												dataGridViewRow2.Cells(text2).Value = ""
											Next
										End If
									Next
								Finally
									Dim enumerator3 As IEnumerator
									If TypeOf enumerator3 Is IDisposable Then
										TryCast(enumerator3, IDisposable).Dispose()
									End If
								End Try
							End Sub))
							AddHandler Me.btnApply.Click, AddressOf Me.btnApply_Click
							Me.btnApply_Click(Nothing, EventArgs.Empty)
						Else
							MessageBox.Show("Error: 'items' key not found in JSON response.")
						End If
					Else
						MessageBox.Show("API Error: " + response.StatusCode.ToString())
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show("Exception: " + ex.Message)
			End Try
		End Function

		' Token: 0x06003587 RID: 13703 RVA: 0x00020BCA File Offset: 0x0001EDCA
		Private Sub ShowProductsInGrid(products As List(Of frmPdfReader.Product))
			Me.DataGridView1.DataSource = Nothing
			Me.DataGridView1.DataSource = products
		End Sub

		' Token: 0x06003588 RID: 13704 RVA: 0x0020D9FC File Offset: 0x0020BBFC
		Public Async Function MakeApiRequest_(prompt As String) As Task
			Dim requestData As Dictionary(Of String, Object) = New Dictionary(Of String, Object)() From { { "model", "gpt-4o" }, { "messages", New List(Of Object)() From { New Dictionary(Of String, String)() From { { "role", "user" }, { "content", prompt } } } }, { "temperature", 0.7 } }
			Dim jsonData As String = JsonConvert.SerializeObject(requestData)
			Try
				Using client As HttpClient = New HttpClient()
					client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Me.apiKey)
					Dim content As StringContent = New StringContent(jsonData, Encoding.UTF8, "application/json")
					Dim response As HttpResponseMessage = Await client.PostAsync(Me.url, content)
					If response.IsSuccessStatusCode Then
						Dim responseString As String = Await response.Content.ReadAsStringAsync()
						Dim jsonResponse As JObject = JObject.Parse(responseString)
						Dim rawContent As String = jsonResponse("choices")(0)("message")("content").ToString()
						Dim cleanJson As String = rawContent.Replace("```json", "").Replace("```", "").Trim()
						Dim parsedJson As JObject = JObject.Parse(cleanJson)
						If parsedJson("items") IsNot Nothing Then
							Dim products As List(Of frmPdfReader.Product) = JsonConvert.DeserializeObject(Of List(Of frmPdfReader.Product))(parsedJson("items").ToString())
							Me.DataGridView1.Invoke(New VB_AnonymousDelegate_0(Sub()
								Me.DataGridView1.DataSource = Nothing
								Dim dataGridViewCheckBoxColumn As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
								dataGridViewCheckBoxColumn.Name = "Select"
								dataGridViewCheckBoxColumn.HeaderText = "Select"
								dataGridViewCheckBoxColumn.DataPropertyName = "IsChecked"
								dataGridViewCheckBoxColumn.TrueValue = True
								dataGridViewCheckBoxColumn.FalseValue = False
								dataGridViewCheckBoxColumn.[ReadOnly] = False
								Dim flag As Boolean = Me.DataGridView1.Columns("Select") Is Nothing
								If flag Then
									Me.DataGridView1.Columns.Insert(0, dataGridViewCheckBoxColumn)
								End If
								Me.DataGridView1.DataSource = products
							End Sub))
						Else
							MessageBox.Show("Error: 'items' key not found in JSON response.")
						End If
					Else
						MessageBox.Show("API Error: " + response.StatusCode.ToString())
					End If
				End Using
			Catch ex As Exception
				MessageBox.Show("Exception: " + ex.Message)
			End Try
		End Function

		' Token: 0x06003589 RID: 13705 RVA: 0x0020DA48 File Offset: 0x0020BC48
		Private Async Sub btnResult_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Internet connection is not available", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Me.ProgressBar1.Visible = True
				Me.btnResult.Enabled = False
				Try
					Dim flag2 As Boolean = Operators.CompareString(Me.filetype, ".pdf", False) = 0
					If flag2 Then
						Dim strPrompt As String = "You are an expert in data extraction. Extract structured invoice product data from the following unstructured text." & vbCrLf & "Text:" + Me.TextBox1.Text + vbCrLf & "Extracted Data Format: Return the output in JSON format with the following fields:" & vbCrLf + Me.TextBox2.Text
						Await Me.MakeApiRequest(strPrompt)
					ElseIf Operators.CompareString(Me.filetype, ".jpg", False) = 0 OrElse Operators.CompareString(Me.filetype, ".jpeg", False) = 0 OrElse Operators.CompareString(Me.filetype, ".png", False) = 0 Then
						Await Me.PerformOCR(Me.imgPath)
					Else
						MessageBox.Show("Unsupported file type.")
					End If
				Catch ex As Exception
					MessageBox.Show("Error: " + ex.Message)
				Finally
					Me.ProgressBar1.Visible = False
					Me.btnResult.Enabled = True
				End Try
			End If
		End Sub

		' Token: 0x0600358A RID: 13706 RVA: 0x0020DA90 File Offset: 0x0020BC90
		Private Sub btnSettle_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Dim num As Integer = Me.DataGridView1.Rows.Count - 1
			For i As Integer = 0 To num
				Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(i)
				Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
				If Not isNewRow Then
					Dim flag As Boolean = String.IsNullOrWhiteSpace(Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))) OrElse String.IsNullOrWhiteSpace(Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value))) OrElse String.IsNullOrWhiteSpace(Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)))
					If flag Then
						MessageBox.Show("Product Name, Rate & Qty can not be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Me.DataGridView1.CurrentCell = dataGridViewRow.Cells(If(String.IsNullOrWhiteSpace(Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))), 2, If(String.IsNullOrWhiteSpace(Convert.ToString(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value))), 4, 6)))
						Me.DataGridView1.BeginEdit(True)
						Return
					End If
				End If
			Next
			Dim flag2 As Boolean = Me.DataGridView1.Rows.Count > 0
			If flag2 Then
				Me.InsertD_SaleProduct()
				MyProject.Forms.frmPurchaseEntry.Button10.Visible = True
				Return
			End If
			MessageBox.Show("No Data for Settlement!")
		End Sub

		' Token: 0x0600358B RID: 13707 RVA: 0x0011427C File Offset: 0x0011247C
		Private Function GenerateIDProd() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("PID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x0600358C RID: 13708 RVA: 0x0020DC20 File Offset: 0x0020BE20
		Public Sub BCodeDisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT RTRIM(BCode) FROM Company"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.txtBar.Text = ModCommonClasses.rdr.GetValue(0).ToString()
				Else
					Me.txtBar.Text = ""
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600358D RID: 13709 RVA: 0x0020DD08 File Offset: 0x0020BF08
		Private Function GenerateIDx() As String
			ModCommonClasses.con = New SqlConnection(ModCS.cs)
			Dim text As String = "0000"
			Try
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT TOP 1 ID FROM Product_OpeningStock ORDER BY ID DESC", ModCommonClasses.con)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Dim hasRows As Boolean = ModCommonClasses.rdr.HasRows
				If hasRows Then
					ModCommonClasses.rdr.Read()
					text = Conversions.ToString(ModCommonClasses.rdr("ID"))
				End If
				ModCommonClasses.rdr.Close()
				text = Conversions.ToString(Conversions.ToDouble(text) + 1.0)
				Dim flag As Boolean = Conversions.ToDouble(text) <= 9.0
				If flag Then
					text = "000" + text
				Else
					Dim flag2 As Boolean = Conversions.ToDouble(text) <= 99.0
					If flag2 Then
						text = "00" + text
					Else
						Dim flag3 As Boolean = Conversions.ToDouble(text) <= 999.0
						If flag3 Then
							text = "0" + text
						End If
					End If
				End If
			Catch ex As Exception
				Dim flag4 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag4 Then
					ModCommonClasses.con.Close()
				End If
				text = "0000"
			End Try
			Return text
		End Function

		' Token: 0x0600358E RID: 13710 RVA: 0x0020DE74 File Offset: 0x0020C074
		Private Sub Generate_GiftQR(qrcode As String)
			Dim flag As Boolean = Not String.IsNullOrEmpty(qrcode)
			If flag Then
				Dim bitmap As Bitmap = New BarcodeWriter() With { .Format = BarcodeFormat.QR_CODE, .Options = New QrCodeEncodingOptions() With { .Width = 200, .Height = 200 } }.Write(qrcode)
				Me.pbgiftqr.Image = bitmap
			Else
				MessageBox.Show("Please enter content to generate QR code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End If
		End Sub

		' Token: 0x0600358F RID: 13711 RVA: 0x0020DEF8 File Offset: 0x0020C0F8
		Private Sub frmPdfReader_Load(sender As Object, e As EventArgs)
			Me.GetApiDtl()
			Me.chkAll.Checked = True
			Me.dtBarcodes.Clear()
			Dim flag As Boolean = Me.dtBarcodes Is Nothing
			If flag Then
				Me.dtBarcodes = New DataTable()
			End If
			Dim flag2 As Boolean = Not Me.dtBarcodes.Columns.Contains("Barcode")
			If flag2 Then
				Me.dtBarcodes.Columns.Add("Barcode", GetType(String))
			End If
			Dim flag3 As Boolean = Not Me.dtBarcodes.Columns.Contains("Qty")
			If flag3 Then
				Me.dtBarcodes.Columns.Add("Qty", GetType(String))
			End If
			Me.ProgressBar1.Style = ProgressBarStyle.Marquee
			Me.ProgressBar1.Visible = False
			Me.ProgressBar1.MarqueeAnimationSpeed = 30
		End Sub

		' Token: 0x06003590 RID: 13712 RVA: 0x0020DFE4 File Offset: 0x0020C1E4
		Public Sub InsertD_SaleProduct()
			Try
				' The following expression was wrapped in a checked-expression
				Dim num As Integer = Me.DataGridView1.Rows.Count - 1
				Dim i As Integer = 0
				While i <= num
					Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.Rows(i)
					Dim flag As Boolean = Convert.ToBoolean(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(0).Value))
					If flag Then
						Dim isNewRow As Boolean = dataGridViewRow.IsNewRow
						If Not isNewRow Then
							Me.txtID_temp.Text = Me.GenerateIDProd()
							Dim text As String = "P-" + Me.GenerateIDProd()
							Me.BCodeDisplay()
							Dim text2 As String = Conversions.ToString(1000.0 + Conversions.ToDouble(Me.GenerateIDx()))
							Dim text3 As String = Me.txtBar.Text + text2
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text4 As String = "SELECT * FROM Defaulttaxtype WHERE id = 1"
							ModCommonClasses.cmd = New SqlCommand(text4)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag2 As Boolean = ModCommonClasses.rdr.Read()
							If flag2 Then
								Me.strStax = ModCommonClasses.rdr(1).ToString()
								Me.strPtax = ModCommonClasses.rdr(2).ToString()
								Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag3 Then
									ModCommonClasses.rdr.Close()
								End If
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text5 As String = "SELECT * FROM tbl_loyalty_setting WHERE id = 1"
							ModCommonClasses.cmd = New SqlCommand(text5)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
							Dim flag4 As Boolean = ModCommonClasses.rdr.Read()
							If flag4 Then
								Dim text6 As String = ModCommonClasses.rdr(1).ToString()
								Dim num2 As Double = Conversions.ToDouble(ModCommonClasses.rdr(2).ToString())
								Dim flag5 As Boolean = ModCommonClasses.rdr IsNot Nothing
								If flag5 Then
									ModCommonClasses.rdr.Close()
								End If
							End If
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text7 As String = "insert into Product(PID,ProductCode, Productname, SubCategoryID, Description, CostPrice, Discount,CGST, " & vbCrLf & "        Barcode,PurchaseUnit,SalesUnit,SGST,HSNCode,PartNo,Cess,SalesAltUnit,Conv,MinStock,Status,STax,PTax,GDown,Rack,MRP,SellingPrice,ReorderPoint,OpeningStock,AddDate,DefQty,Kitchen) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d7,@d8,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d22,@d23,@d24,@d25,@d26,@d27,@d28,@d29,@d30,@d31,@d32,@d33)"
							ModCommonClasses.cmd = New SqlCommand(text7)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID_temp.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", text)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d3", 1)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d4", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(2).Value))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", 0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", Conversion.Val(Operators.DivideObject(dataGridViewRow.Cells(7).Value, 2)))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", text3)
							Dim flag6 As Boolean = dataGridViewRow.Cells(5).Value Is Nothing
							If flag6 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "PCS")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "PCS")
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", "PCS")
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value))
								ModCommonClasses.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", Conversion.Val(Operators.DivideObject(dataGridViewRow.Cells(7).Value, 2)))
							Dim flag7 As Boolean = dataGridViewRow.Cells(3).Value Is Nothing
							If flag7 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "")
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d15", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(3).Value))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d16", 0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d17", 0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d19", 1)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d20", 0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d22", "Yes")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d23", Me.strStax)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d24", Me.strPtax)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d25", "")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d26", "")
							Dim value As Object = dataGridViewRow.Cells(9).Value
							Dim flag8 As Boolean = String.IsNullOrWhiteSpace(If((value IsNot Nothing), value.ToString(), Nothing))
							If flag8 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtMrp_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d27", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
							End If
							Dim value2 As Object = dataGridViewRow.Cells(10).Value
							Dim flag9 As Boolean = String.IsNullOrWhiteSpace(If((value2 IsNot Nothing), value2.ToString(), Nothing))
							If flag9 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtMrp_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d28", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d29", 0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d30", 0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d31", DateTime.Today)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d32", 1)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d33", "")
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.con.Close()
							ModCommonClasses.con.Open()
							Dim text8 As String = "insert into Product_Join(ProductID,photo) VALUES (" + Me.txtID_temp.Text + ",@d2)"
							ModCommonClasses.cmd = New SqlCommand(text8)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							Dim memoryStream As MemoryStream = New MemoryStream()
							Dim image As Image = Me.Photo.Image
							Dim bitmap As Bitmap = New Bitmap(image)
							bitmap.Save(memoryStream, ImageFormat.Jpeg)
							Dim buffer As Byte() = memoryStream.GetBuffer()
							Dim sqlParameter As SqlParameter = New SqlParameter("@d2", SqlDbType.Image)
							sqlParameter.Value = buffer
							ModCommonClasses.cmd.Parameters.Add(sqlParameter)
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.cmd.Parameters.Clear()
							ModCommonClasses.con.Close()
							ModCommonClasses.con.Open()
							Dim text9 As String = "insert into Product_OpeningStock(ProductID,Qty,MRP,SalePrice,WSalePrice,Batch,Mfgdate,Expdate,Size,Colour,Barcode,PAddDate,RCipher,WCipher,PPrice,OPSValue,IMEI1,IMEI2) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17)"
							ModCommonClasses.cmd = New SqlCommand(text9)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID_temp.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 0.0)
							Dim value3 As Object = dataGridViewRow.Cells(9).Value
							Dim flag10 As Boolean = String.IsNullOrWhiteSpace(If((value3 IsNot Nothing), value3.ToString(), Nothing))
							If flag10 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtMrp_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
							End If
							Dim value4 As Object = dataGridViewRow.Cells(10).Value
							Dim flag11 As Boolean = String.IsNullOrWhiteSpace(If((value4 IsNot Nothing), value4.ToString(), Nothing))
							If flag11 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtMrp_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
							End If
							Dim value5 As Object = dataGridViewRow.Cells(11).Value
							Dim flag12 As Boolean = String.IsNullOrWhiteSpace(If((value5 IsNot Nothing), value5.ToString(), Nothing))
							If flag12 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtWholesale_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value))
							Dim value6 As Object = dataGridViewRow.Cells(16).Value
							Dim flag13 As Boolean = String.IsNullOrWhiteSpace(If((value6 IsNot Nothing), value6.ToString(), Nothing))
							If flag13 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", "")
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value))
							End If
							Dim value7 As Object = dataGridViewRow.Cells(17).Value
							Dim flag14 As Boolean = String.IsNullOrWhiteSpace(If((value7 IsNot Nothing), value7.ToString(), Nothing))
							If flag14 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", "")
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", text3)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", DateTime.Today)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d12", "")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d13", "")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "0.00")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d17", "")
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.cmd.Parameters.Clear()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text10 As String = "insert into Temp_Stock(ProductID, Qty, Barcode, SPrice, WPrice, StLimit, MRP, " & vbCrLf & "        Batch, MfgDate, ExpDate, Size, Colour, SalePrice, WSalePrice, SuplName, IMEI1, IMEI2, PPrice, EPPrice, QrBarcode, SalesManPur, Variant_id) VALUES (@d0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20,@d21)"
							ModCommonClasses.cmd = New SqlCommand(text10)
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.Prepare()
							ModCommonClasses.cmd.Parameters.AddWithValue("@d0", Conversion.Val(Me.txtID_temp.Text))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 0.0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d2", text3)
							Dim value8 As Object = dataGridViewRow.Cells(9).Value
							Dim flag15 As Boolean = String.IsNullOrWhiteSpace(If((value8 IsNot Nothing), value8.ToString(), Nothing))
							If flag15 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtMrp_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
							End If
							Dim value9 As Object = dataGridViewRow.Cells(11).Value
							Dim flag16 As Boolean = String.IsNullOrWhiteSpace(If((value9 IsNot Nothing), value9.ToString(), Nothing))
							If flag16 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtWholesale_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d4", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d5", 0)
							Dim value10 As Object = dataGridViewRow.Cells(9).Value
							Dim flag17 As Boolean = String.IsNullOrWhiteSpace(If((value10 IsNot Nothing), value10.ToString(), Nothing))
							If flag17 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtMrp_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d6", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(9).Value)))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d7", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(15).Value))
							Dim value11 As Object = dataGridViewRow.Cells(16).Value
							Dim flag18 As Boolean = String.IsNullOrWhiteSpace(If((value11 IsNot Nothing), value11.ToString(), Nothing))
							If flag18 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", "")
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d8", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(16).Value))
							End If
							Dim value12 As Object = dataGridViewRow.Cells(17).Value
							Dim flag19 As Boolean = String.IsNullOrWhiteSpace(If((value12 IsNot Nothing), value12.ToString(), Nothing))
							If flag19 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", "")
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d9", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(17).Value))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d10", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(13).Value))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d11", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(12).Value))
							Dim value13 As Object = dataGridViewRow.Cells(10).Value
							Dim flag20 As Boolean = String.IsNullOrWhiteSpace(If((value13 IsNot Nothing), value13.ToString(), Nothing))
							If flag20 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtMrp_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d12", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(10).Value)))
							End If
							Dim value14 As Object = dataGridViewRow.Cells(11).Value
							Dim flag21 As Boolean = String.IsNullOrWhiteSpace(If((value14 IsNot Nothing), value14.ToString(), Nothing))
							If flag21 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) * (1.0 + Conversion.Val(Me.txtWholesale_per.Text) / 100.0))
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d13", Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(11).Value)))
							End If
							ModCommonClasses.cmd.Parameters.AddWithValue("@d14", "Opening Stock")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d15", "")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d16", "")
							ModCommonClasses.cmd.Parameters.AddWithValue("@d17", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value))
							ModCommonClasses.cmd.Parameters.AddWithValue("@d18", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value))
							Me.Generate_GiftQR(text3)
							Dim memoryStream2 As MemoryStream = New MemoryStream()
							Dim bitmap2 As Bitmap = New Bitmap(Me.pbgiftqr.Image)
							bitmap2.Save(memoryStream2, ImageFormat.Jpeg)
							Dim buffer2 As Byte() = memoryStream2.GetBuffer()
							Dim sqlParameter2 As SqlParameter = New SqlParameter("@d19", SqlDbType.Image)
							sqlParameter2.Value = buffer2
							ModCommonClasses.cmd.Parameters.AddWithValue("@d20", 0.0)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d21", Conversion.Val(Me.txtID_temp.Text))
							ModCommonClasses.cmd.Parameters.Add(sqlParameter2)
							ModCommonClasses.cmd.ExecuteNonQuery()
							ModCommonClasses.cmd.Parameters.Clear()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text11 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text11)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_temp.Text))
							Dim flag22 As Boolean = dataGridViewRow.Cells(5).Value Is Nothing
							If flag22 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", "PCS")
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value))
							End If
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							ModCommonClasses.con = New SqlConnection(ModCS.cs)
							ModCommonClasses.con.Open()
							Dim text12 As String = "insert into ExtDB1(a1, a2) Values (@d1,@d2)"
							ModCommonClasses.cmd = New SqlCommand(text12)
							ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Conversion.Val(Me.txtID_temp.Text))
							Dim flag23 As Boolean = dataGridViewRow.Cells(5).Value Is Nothing
							If flag23 Then
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", "PCS")
							Else
								ModCommonClasses.cmd.Parameters.AddWithValue("@d2", RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(5).Value))
							End If
							ModCommonClasses.cmd.Connection = ModCommonClasses.con
							ModCommonClasses.cmd.ExecuteReader()
							ModCommonClasses.con.Close()
							Dim dataRow As DataRow = Me.dtBarcodes.NewRow()
							dataRow("Barcode") = text3
							dataRow("Qty") = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(4).Value))
							Me.dtBarcodes.Rows.Add(dataRow)
							Me.txtBarcode.Text = text3
						End If
					End If
					IL_17BE:
					i += 1
					Continue While
					GoTo IL_17BE
				End While
				frmPurchaseEntry.dtReceived = Me.dtBarcodes
				Me.PdfDataAddGrid()
				MyBase.Dispose()
			Catch ex As Exception
				MessageBox.Show(String.Format("Error inserting row: {0}", ex.Message))
			Finally
				ModCommonClasses.con.Close()
			End Try
		End Sub

		' Token: 0x06003591 RID: 13713 RVA: 0x0020F840 File Offset: 0x0020DA40
		Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkAll.Checked
			Try
				For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
					Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
					Dim flag As Boolean = Not dataGridViewRow.IsNewRow
					If flag Then
						dataGridViewRow.Cells(0).Value = checked
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x06003592 RID: 13714 RVA: 0x0020F8D4 File Offset: 0x0020DAD4
		Private Sub btnApply_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Me.DataGridView1.Rows.Count = 0
				If flag Then
					MessageBox.Show("No rows to process.")
				Else
					Try
						For Each obj As Object In CType(Me.DataGridView1.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj, DataGridViewRow)
							Dim flag2 As Boolean = Not dataGridViewRow.IsNewRow
							If flag2 Then
								Dim flag3 As Boolean = Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value)) AndAlso Versioned.IsNumeric(Me.txtMrp_per.Text)
								If flag3 Then
									Dim num As Double = Conversion.Val(RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells(6).Value))
									Dim num2 As Double = Conversion.Val(Me.txtMrp_per.Text)
									Dim num3 As Double = Conversion.Val(Me.txtWholesale_per.Text)
									Dim num4 As Double = num * (1.0 + num2 / 100.0)
									Dim num5 As Double = num * (1.0 + num3 / 100.0)
									dataGridViewRow.Cells(9).Value = Math.Round(num4, 2)
									dataGridViewRow.Cells(10).Value = Math.Round(num4, 2)
									dataGridViewRow.Cells(11).Value = Math.Round(num5, 2)
								Else
									dataGridViewRow.Cells(6).Value = "Invalid"
								End If
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
				End If
			Catch ex As Exception
				MessageBox.Show("Error applying MRP calculation: " + ex.Message)
			End Try
		End Sub

		' Token: 0x06003593 RID: 13715 RVA: 0x0020FAF0 File Offset: 0x0020DCF0
		Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
			Dim flag As Boolean = e.ColumnIndex = 16 AndAlso e.RowIndex >= 0
			If flag Then
				Me.strtype = 16
				Me.selectedRowIndex = e.RowIndex
				Me.pnlDate.Visible = True
				Me.pnlDate.BringToFront()
				Me.dtpDate.Focus()
			Else
				Dim flag2 As Boolean = e.ColumnIndex = 17 AndAlso e.RowIndex >= 0
				If flag2 Then
					Me.strtype = 17
					Me.selectedRowIndex = e.RowIndex
					Me.pnlDate.Visible = True
					Me.pnlDate.BringToFront()
					Me.dtpDate.Focus()
				Else
					Me.pnlDate.Visible = False
				End If
			End If
		End Sub

		' Token: 0x06003594 RID: 13716 RVA: 0x0020FBC0 File Offset: 0x0020DDC0
		Private Sub btnOk_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.selectedRowIndex >= 0 AndAlso Me.selectedRowIndex < Me.DataGridView1.Rows.Count
			If flag Then
				Dim flag2 As Boolean = Me.strtype = 16
				If flag2 Then
					Me.DataGridView1.Rows(Me.selectedRowIndex).Cells(16).Value = Me.dtpDate.Value.ToString("dd-MM-yyyy")
				Else
					Dim flag3 As Boolean = Me.strtype = 17
					If flag3 Then
						Me.DataGridView1.Rows(Me.selectedRowIndex).Cells(17).Value = Me.dtpDate.Value.ToString("dd-MM-yyyy")
					End If
				End If
				Me.pnlDate.Visible = False
			End If
		End Sub

		' Token: 0x06003595 RID: 13717 RVA: 0x0020FCA8 File Offset: 0x0020DEA8
		Private Sub dtpDate_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.[Return]
			If flag Then
				Dim flag2 As Boolean = Me.selectedRowIndex >= 0 AndAlso Me.selectedRowIndex < Me.DataGridView1.Rows.Count
				If flag2 Then
					Dim flag3 As Boolean = Me.strtype = 16
					If flag3 Then
						Me.DataGridView1.Rows(Me.selectedRowIndex).Cells(16).Value = Me.dtpDate.Value.ToString("dd-MM-yyyy")
					Else
						Dim flag4 As Boolean = Me.strtype = 17
						If flag4 Then
							Me.DataGridView1.Rows(Me.selectedRowIndex).Cells(17).Value = Me.dtpDate.Value.ToString("dd-MM-yyyy")
						End If
					End If
					Me.pnlDate.Visible = False
				End If
				e.SuppressKeyPress = True
			End If
		End Sub

		' Token: 0x06003596 RID: 13718 RVA: 0x00020BE7 File Offset: 0x0001EDE7
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			MyBase.Dispose()
			MyProject.Forms.frmProductDefault.lblform.Text = "frmProductRec2"
			MyProject.Forms.frmProductDefault.ShowDialog()
		End Sub

		' Token: 0x06003597 RID: 13719 RVA: 0x0020FDB0 File Offset: 0x0020DFB0
		Public Sub PdfDataAddGrid()
			Dim flag As Boolean = Me.dtBarcodes IsNot Nothing AndAlso Me.dtBarcodes.Rows.Count > 0
			If flag Then
				Dim num As Integer = Me.dtBarcodes.Rows.Count - 1
				For i As Integer = 0 To num
					MyProject.Forms.frmPurchaseEntry.strBarcode = Me.dtBarcodes.Rows(i)("Barcode").ToString()
					MyProject.Forms.frmPurchaseEntry.dbOpeningstock = Conversion.Val(Me.dtBarcodes.Rows(i)("Qty").ToString())
					Dim flag2 As Boolean = Not String.IsNullOrEmpty(MyProject.Forms.frmPurchaseEntry.strBarcode)
					If flag2 Then
						MyProject.Forms.frmPurchaseEntry.strStatus = "new"
						MyProject.Forms.frmPurchaseEntry.getgriditemdata()
						MyProject.Forms.frmPurchaseEntry.dgw4.Visible = True
						Dim flag3 As Boolean = MyProject.Forms.frmPurchaseEntry.dgw4.Rows.Count = 1
						If flag3 Then
							MyProject.Forms.frmPurchaseEntry.dgw4.Focus()
							MyProject.Forms.frmPurchaseEntry.RetrieveData2()
						Else
							Dim flag4 As Boolean = MyProject.Forms.frmPurchaseEntry.dgw4.Rows.Count > 1
							If flag4 Then
								MyProject.Forms.frmPurchaseEntry.dgw4.Focus()
								SendKeys.Send("{ENTER}")
							End If
						End If
						MyProject.Forms.frmPurchaseEntry.btnAdd_Click(Me, EventArgs.Empty)
					End If
				Next
			End If
		End Sub

		' Token: 0x04001703 RID: 5891
		Private dt_DSaleProduct As DataTable

		' Token: 0x04001704 RID: 5892
		Private strStax As String

		' Token: 0x04001705 RID: 5893
		Private strPtax As String

		' Token: 0x04001706 RID: 5894
		Private dtBarcodes As DataTable

		' Token: 0x04001707 RID: 5895
		Private apiKey As String

		' Token: 0x04001708 RID: 5896
		Private url As String

		' Token: 0x04001709 RID: 5897
		Private filetype As String

		' Token: 0x0400170A RID: 5898
		Private imgPath As String

		' Token: 0x0400170B RID: 5899
		Private selectedRowIndex As Integer

		' Token: 0x0400170C RID: 5900
		Private strtype As Integer

		' Token: 0x02000138 RID: 312
		Public Class Product
			' Token: 0x170014AD RID: 5293
			' (get) Token: 0x06003599 RID: 13721 RVA: 0x00020C1B File Offset: 0x0001EE1B
			' (set) Token: 0x0600359A RID: 13722 RVA: 0x00020C25 File Offset: 0x0001EE25
			Public Property sl_no As Integer?

			' Token: 0x170014AE RID: 5294
			' (get) Token: 0x0600359B RID: 13723 RVA: 0x00020C2E File Offset: 0x0001EE2E
			' (set) Token: 0x0600359C RID: 13724 RVA: 0x00020C38 File Offset: 0x0001EE38
			Public Property product_name As String

			' Token: 0x170014AF RID: 5295
			' (get) Token: 0x0600359D RID: 13725 RVA: 0x00020C41 File Offset: 0x0001EE41
			' (set) Token: 0x0600359E RID: 13726 RVA: 0x00020C4B File Offset: 0x0001EE4B
			Public Property hsn_code As String

			' Token: 0x170014B0 RID: 5296
			' (get) Token: 0x0600359F RID: 13727 RVA: 0x00020C54 File Offset: 0x0001EE54
			' (set) Token: 0x060035A0 RID: 13728 RVA: 0x00020C5E File Offset: 0x0001EE5E
			Public Property quantity As Decimal?

			' Token: 0x170014B1 RID: 5297
			' (get) Token: 0x060035A1 RID: 13729 RVA: 0x00020C67 File Offset: 0x0001EE67
			' (set) Token: 0x060035A2 RID: 13730 RVA: 0x00020C71 File Offset: 0x0001EE71
			Public Property unit As String

			' Token: 0x170014B2 RID: 5298
			' (get) Token: 0x060035A3 RID: 13731 RVA: 0x00020C7A File Offset: 0x0001EE7A
			' (set) Token: 0x060035A4 RID: 13732 RVA: 0x00020C84 File Offset: 0x0001EE84
			Public Property rate As Decimal?

			' Token: 0x170014B3 RID: 5299
			' (get) Token: 0x060035A5 RID: 13733 RVA: 0x00020C8D File Offset: 0x0001EE8D
			' (set) Token: 0x060035A6 RID: 13734 RVA: 0x00020C97 File Offset: 0x0001EE97
			Public Property total_gst_rate As String

			' Token: 0x170014B4 RID: 5300
			' (get) Token: 0x060035A7 RID: 13735 RVA: 0x00020CA0 File Offset: 0x0001EEA0
			' (set) Token: 0x060035A8 RID: 13736 RVA: 0x00020CAA File Offset: 0x0001EEAA
			Public Property discount_rate As Decimal?
		End Class
	End Class
End Namespace
