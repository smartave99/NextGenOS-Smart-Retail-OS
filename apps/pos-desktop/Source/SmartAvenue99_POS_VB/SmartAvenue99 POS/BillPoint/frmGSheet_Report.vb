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
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.FileIO
Imports Newtonsoft.Json.Linq

Namespace BillPoint
	' Token: 0x0200011C RID: 284
	<DesignerGenerated()>
	Public Partial Class frmGSheet_Report
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06003178 RID: 12664 RVA: 0x001E9F00 File Offset: 0x001E8100
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmGSheet_Report_Load
			Me.dt = New DataTable()
			Me.spreadsheetId = ""
			Me.gid = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x17001351 RID: 4945
		' (get) Token: 0x0600317B RID: 12667 RVA: 0x0001EC7B File Offset: 0x0001CE7B
		' (set) Token: 0x0600317C RID: 12668 RVA: 0x001EAB3C File Offset: 0x001E8D3C
		Private _DataGridView1 As DataGridView
		Friend Overridable Property DataGridView1 As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._DataGridView1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim mouseEventHandler As MouseEventHandler = AddressOf Me.DataGridView1_MouseClick
				Dim dataGridView As DataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.MouseClick, mouseEventHandler
				End If
				Me._DataGridView1 = value
				dataGridView = Me._DataGridView1
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.MouseClick, mouseEventHandler
				End If
			End Set
		End Property

		' Token: 0x17001352 RID: 4946
		' (get) Token: 0x0600317D RID: 12669 RVA: 0x0001EC85 File Offset: 0x0001CE85
		' (set) Token: 0x0600317E RID: 12670 RVA: 0x001EAB80 File Offset: 0x001E8D80
		Private _btnShowAll As GelButton
		Friend Overridable Property btnShowAll As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnShowAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnShowAll_Click
				Dim gelButton As GelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnShowAll = value
				gelButton = Me._btnShowAll
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001353 RID: 4947
		' (get) Token: 0x0600317F RID: 12671 RVA: 0x0001EC8F File Offset: 0x0001CE8F
		' (set) Token: 0x06003180 RID: 12672 RVA: 0x0001EC99 File Offset: 0x0001CE99
		Friend Overridable Property Panel3 As Panel

		' Token: 0x17001354 RID: 4948
		' (get) Token: 0x06003181 RID: 12673 RVA: 0x0001ECA2 File Offset: 0x0001CEA2
		' (set) Token: 0x06003182 RID: 12674 RVA: 0x001EABC4 File Offset: 0x001E8DC4
		Private _txtCustomerName As TextBox
		Friend Overridable Property txtCustomerName As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerName
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerName_TextChanged
				Dim textBox As TextBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerName = value
				textBox = Me._txtCustomerName
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001355 RID: 4949
		' (get) Token: 0x06003183 RID: 12675 RVA: 0x0001ECAC File Offset: 0x0001CEAC
		' (set) Token: 0x06003184 RID: 12676 RVA: 0x0001ECB6 File Offset: 0x0001CEB6
		Friend Overridable Property Label3 As Label

		' Token: 0x17001356 RID: 4950
		' (get) Token: 0x06003185 RID: 12677 RVA: 0x0001ECBF File Offset: 0x0001CEBF
		' (set) Token: 0x06003186 RID: 12678 RVA: 0x0001ECC9 File Offset: 0x0001CEC9
		Friend Overridable Property Panel6 As Panel

		' Token: 0x17001357 RID: 4951
		' (get) Token: 0x06003187 RID: 12679 RVA: 0x0001ECD2 File Offset: 0x0001CED2
		' (set) Token: 0x06003188 RID: 12680 RVA: 0x001EAC08 File Offset: 0x001E8E08
		Private _txtContactNo As TextBox
		Friend Overridable Property txtContactNo As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtContactNo
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtContactNo_TextChanged
				Dim textBox As TextBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtContactNo = value
				textBox = Me._txtContactNo
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17001358 RID: 4952
		' (get) Token: 0x06003189 RID: 12681 RVA: 0x0001ECDC File Offset: 0x0001CEDC
		' (set) Token: 0x0600318A RID: 12682 RVA: 0x0001ECE6 File Offset: 0x0001CEE6
		Friend Overridable Property Label4 As Label

		' Token: 0x17001359 RID: 4953
		' (get) Token: 0x0600318B RID: 12683 RVA: 0x0001ECEF File Offset: 0x0001CEEF
		' (set) Token: 0x0600318C RID: 12684 RVA: 0x0001ECF9 File Offset: 0x0001CEF9
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x1700135A RID: 4954
		' (get) Token: 0x0600318D RID: 12685 RVA: 0x0001ED02 File Offset: 0x0001CF02
		' (set) Token: 0x0600318E RID: 12686 RVA: 0x001EAC4C File Offset: 0x001E8E4C
		Private _btnGetData As GelButton
		Friend Overridable Property btnGetData As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim gelButton As GelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnGetData = value
				gelButton = Me._btnGetData
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700135B RID: 4955
		' (get) Token: 0x0600318F RID: 12687 RVA: 0x0001ED0C File Offset: 0x0001CF0C
		' (set) Token: 0x06003190 RID: 12688 RVA: 0x0001ED16 File Offset: 0x0001CF16
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700135C RID: 4956
		' (get) Token: 0x06003191 RID: 12689 RVA: 0x0001ED1F File Offset: 0x0001CF1F
		' (set) Token: 0x06003192 RID: 12690 RVA: 0x0001ED29 File Offset: 0x0001CF29
		Friend Overridable Property Label2 As Label

		' Token: 0x1700135D RID: 4957
		' (get) Token: 0x06003193 RID: 12691 RVA: 0x0001ED32 File Offset: 0x0001CF32
		' (set) Token: 0x06003194 RID: 12692 RVA: 0x0001ED3C File Offset: 0x0001CF3C
		Friend Overridable Property Label1 As Label

		' Token: 0x1700135E RID: 4958
		' (get) Token: 0x06003195 RID: 12693 RVA: 0x0001ED45 File Offset: 0x0001CF45
		' (set) Token: 0x06003196 RID: 12694 RVA: 0x0001ED4F File Offset: 0x0001CF4F
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700135F RID: 4959
		' (get) Token: 0x06003197 RID: 12695 RVA: 0x0001ED58 File Offset: 0x0001CF58
		' (set) Token: 0x06003198 RID: 12696 RVA: 0x001EAC90 File Offset: 0x001E8E90
		Private _btnSetting As GelButton
		Friend Overridable Property btnSetting As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSetting
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSetting_Click
				Dim gelButton As GelButton = Me._btnSetting
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSetting = value
				gelButton = Me._btnSetting
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06003199 RID: 12697 RVA: 0x0001ED62 File Offset: 0x0001CF62
		Private Sub frmGSheet_Report_Load(sender As Object, e As EventArgs)
			Me.FetchSheet_Dtl()
			Me.FetchGoogleSheetData()
		End Sub

		' Token: 0x0600319A RID: 12698 RVA: 0x001EACD4 File Offset: 0x001E8ED4
		Public Sub FetchSheet_Dtl()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select RTRIM(spreadsheetId), RTRIM(gid) from GSheet_setting where IsEnabled=@d1"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", 1)
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.spreadsheetId = ModCommonClasses.rdr(0).ToString()
					Me.gid = ModCommonClasses.rdr(1).ToString()
					ModCommonClasses.rdr.Close()
					ModCommonClasses.con.Close()
				Else
					MessageBox.Show("Google Sheet not detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End If
			Catch ex As Exception
				MessageBox.Show("Error: " + ex.Message)
			End Try
		End Sub

		' Token: 0x0600319B RID: 12699 RVA: 0x001EADEC File Offset: 0x001E8FEC
		Private Sub FetchGoogleSheetJson()
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please check your internet connection.")
			Else
				Dim text As String = "https://script.google.com/macros/s/AKfycbz2HiERiIcpiGSAYG9xfRa8oQ8UVXbWhrwV12YJpNj57wx7Rmva-2h5c1zewc2c2f8RFA/exec"
				Try
					Dim webClient As WebClient = New WebClient()
					Dim text2 As String = webClient.DownloadString(text)
					Dim flag2 As Boolean = text2.TrimStart(New Char(-1) {}).StartsWith("<")
					If flag2 Then
						File.WriteAllText("bad_response.html", text2)
						MessageBox.Show("Error: Received HTML instead of JSON. Saved as 'bad_response.html'.")
					Else
						Dim jarray As JArray = JArray.Parse(text2)
						Dim dataTable As DataTable = New DataTable()
						Dim flag3 As Boolean = jarray.Count > 0
						If flag3 Then
							Try
								For Each jproperty As JProperty In CType(jarray(0), JObject).Properties()
									dataTable.Columns.Add(jproperty.Name)
								Next
							Finally
								Dim enumerator As IEnumerator(Of JProperty)
								If enumerator IsNot Nothing Then
									enumerator.Dispose()
								End If
							End Try
							Try
								For Each jtoken As JToken In jarray
									Dim jobject As JObject = CType(jtoken, JObject)
									Dim dataRow As DataRow = dataTable.NewRow()
									Try
										For Each jproperty2 As JProperty In jobject.Properties()
											dataRow(jproperty2.Name) = jproperty2.Value.ToString()
										Next
									Finally
										Dim enumerator3 As IEnumerator(Of JProperty)
										If enumerator3 IsNot Nothing Then
											enumerator3.Dispose()
										End If
									End Try
									dataTable.Rows.Add(dataRow)
								Next
							Finally
								Dim enumerator2 As IEnumerator(Of JToken)
								If enumerator2 IsNot Nothing Then
									enumerator2.Dispose()
								End If
							End Try
						End If
						Me.DataGridView1.DataSource = dataTable
					End If
				Catch ex As Exception
					MessageBox.Show("Error: " + ex.Message)
				End Try
			End If
		End Sub

		' Token: 0x0600319C RID: 12700 RVA: 0x001EB020 File Offset: 0x001E9220
		Private Sub FetchGoogleSheetData()
			Dim text As String = String.Format("https://docs.google.com/spreadsheets/d/{0}/export?format=tsv&gid={1}", Me.spreadsheetId, Me.gid)
			Dim flag As Boolean = Not ModFunc.CheckForInternetConnection()
			If flag Then
				MessageBox.Show("Please Check your Internet Ccnnection!")
			Else
				Try
					Dim webClient As WebClient = New WebClient()
					Dim text2 As String = webClient.DownloadString(text)
					Dim tempFileName As String = Path.GetTempFileName()
					File.WriteAllText(tempFileName, text2)
					Using textFieldParser As TextFieldParser = New TextFieldParser(tempFileName)
						textFieldParser.TextFieldType = FieldType.Delimited
						textFieldParser.SetDelimiters(New String() { vbTab })
						textFieldParser.HasFieldsEnclosedInQuotes = True
						Dim flag2 As Boolean = Not textFieldParser.EndOfData
						If flag2 Then
							Dim array As String() = textFieldParser.ReadFields()
							For Each text3 As String In array
								Me.dt.Columns.Add(text3.Trim())
							Next
						End If
						While Not textFieldParser.EndOfData
														Dim array3 As String() = textFieldParser.ReadFields()
							If Not array3.All(Function(f) String.IsNullOrWhiteSpace(f)) Then
								Me.dt.Rows.Add(array3)
							End If
						End While
					End Using
					Dim array4 As String() = New String() { "Token Number", "Billing Address", "Billing Name", "Billing Shop Name", "Billing Full Address", "Billing District", "Billing Post Office", "Billing State", "Billing PIN", "Billing Phone", "Billing GST", "Shipping Address", "Shipping Name", "Shipping Shop Name", "Shipping Full Address", "Shipping District", "Shipping Post Office", "Shipping State", "Shipping PIN", "Shipping Phone", "Shipping GST", "Date", "Status", "Remark" }
					Dim num As Integer = Me.dt.Columns.Count - 1
					For j As Integer = 0 To num
						Me.dt.Columns(j).ColumnName = array4(j)
					Next
					Dim dataTable As DataTable = Me.dt.Clone()
					Try
						For Each obj As Object In Me.dt.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Dim text4 As String = dataRow("Date").ToString().Trim()
							Dim flag4 As Boolean = Not String.IsNullOrWhiteSpace(text4)
							If flag4 Then
								Dim dateTime As DateTime
								Dim flag5 As Boolean = DateTime.TryParseExact(text4, "M/d/yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, dateTime)
								If flag5 Then
									Dim flag6 As Boolean = DateTime.Compare(dateTime.[Date], DateTime.Today) = 0
									If flag6 Then
										dataTable.ImportRow(dataRow)
									End If
								End If
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Me.DataGridView1.DataSource = dataTable
				Catch ex As WebException
					Dim flag7 As Boolean = ex.Response IsNot Nothing
					If flag7 Then
						Dim httpWebResponse As HttpWebResponse = CType(ex.Response, HttpWebResponse)
						Dim flag8 As Boolean = httpWebResponse.StatusCode = HttpStatusCode.BadRequest
						If flag8 Then
						End If
					End If
				End Try
			End If
		End Sub

		' Token: 0x0600319D RID: 12701 RVA: 0x001EB408 File Offset: 0x001E9608
		Private Sub btnShowAll_Click(sender As Object, e As EventArgs)
			Dim text As String = String.Format("https://docs.google.com/spreadsheets/d/{0}/export?format=tsv&gid={1}", Me.spreadsheetId, Me.gid)
			Try
				Dim webClient As WebClient = New WebClient()
				Dim text2 As String = webClient.DownloadString(text)
				Dim tempFileName As String = Path.GetTempFileName()
				File.WriteAllText(tempFileName, text2)
				Using textFieldParser As TextFieldParser = New TextFieldParser(tempFileName)
					textFieldParser.TextFieldType = FieldType.Delimited
					textFieldParser.SetDelimiters(New String() { vbTab })
					textFieldParser.HasFieldsEnclosedInQuotes = True
					Dim flag As Boolean = Not textFieldParser.EndOfData
					If flag Then
						Dim array As String() = textFieldParser.ReadFields()
						For Each text3 As String In array
							Me.dt.Columns.Add(text3.Trim())
						Next
					End If
					While Not textFieldParser.EndOfData
													Dim array3 As String() = textFieldParser.ReadFields()
							If Not array3.All(Function(f) String.IsNullOrWhiteSpace(f)) Then
								Me.dt.Rows.Add(array3)
							End If
					End While
				End Using
				Dim array4 As String() = New String() { "Token Number", "Billing Address", "Billing Name", "Billing Shop Name", "Billing Full Address", "Billing District", "Billing Post Office", "Billing State", "Billing PIN", "Billing Phone", "Billing GST", "Shipping Address", "Shipping Name", "Shipping Shop Name", "Shipping Full Address", "Shipping District", "Shipping Post Office", "Shipping State", "Shipping PIN", "Shipping Phone", "Shipping GST", "Date", "Status", "Remark" }
				Dim num As Integer = Me.dt.Columns.Count - 1
				For j As Integer = 0 To num
					Me.dt.Columns(j).ColumnName = array4(j)
				Next
				Me.DataGridView1.DataSource = Me.dt
			Catch ex As WebException
				Dim flag3 As Boolean = ex.Response IsNot Nothing
				If flag3 Then
					Dim httpWebResponse As HttpWebResponse = CType(ex.Response, HttpWebResponse)
					Dim flag4 As Boolean = httpWebResponse.StatusCode = HttpStatusCode.BadRequest
					If flag4 Then
					End If
				End If
			End Try
		End Sub

		' Token: 0x0600319E RID: 12702 RVA: 0x0001ED73 File Offset: 0x0001CF73
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs)
			Microsoft.VisualBasic.FileSystem.Reset()
			Me.RetrieveData()
		End Sub

		' Token: 0x0600319F RID: 12703 RVA: 0x001EB6F4 File Offset: 0x001E98F4
		Public Sub RetrieveData()
			Try
				Dim flag As Boolean = Me.DataGridView1.SelectedRows.Count = 0
				If flag Then
					MessageBox.Show("Please select a row.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Dim flag2 As Boolean = Me.DataGridView1.Rows.Count > 0
					If flag2 Then
						Dim dataGridViewRow As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
						MyProject.Forms.frmCustomer.Show()
						MyBase.Hide()
						MyProject.Forms.frmCustomer.cmbCustomerName.Text = dataGridViewRow.Cells(2).Value.ToString() + " - " + dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCustomer.txtCustName.Text = dataGridViewRow.Cells(2).Value.ToString() + " - " + dataGridViewRow.Cells(3).Value.ToString()
						MyProject.Forms.frmCustomer.txtAddress.Text = dataGridViewRow.Cells(4).Value.ToString()
						MyProject.Forms.frmCustomer.txtCity.Text = dataGridViewRow.Cells(5).Value.ToString()
						MyProject.Forms.frmCustomer.cmbState.Text = dataGridViewRow.Cells(7).Value.ToString()
						MyProject.Forms.frmCustomer.txtZipCode.Text = dataGridViewRow.Cells(8).Value.ToString()
						MyProject.Forms.frmCustomer.txtContactNo.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmCustomer.txtPhNo.Text = dataGridViewRow.Cells(9).Value.ToString()
						MyProject.Forms.frmCustomer.txtGSTIN.Text = dataGridViewRow.Cells(10).Value.ToString()
						MyProject.Forms.frmCustomer.txtRemarks.Text = dataGridViewRow.Cells(23).Value.ToString()
						MyProject.Forms.frmCustomer.txtpermentAddress.Text = dataGridViewRow.Cells(11).Value.ToString() + ", Mob:" + dataGridViewRow.Cells(19).Value.ToString()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060031A0 RID: 12704 RVA: 0x001EB9FC File Offset: 0x001E9BFC
		Private Sub txtCustomerName_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dt Is Nothing
			If Not flag Then
				Dim dataView As DataView = New DataView(Me.dt)
				Dim text As String = Me.txtCustomerName.Text.Trim().Replace("'", "''")
				dataView.RowFilter = String.Format("[Billing Name] LIKE '%{0}%'", text)
				Dim dataTable As DataTable = dataView.ToTable()
				Dim dataTable2 As DataTable = dataTable.Clone()
				Dim num As Integer = Math.Min(9, dataTable.Rows.Count - 1)
				For i As Integer = 0 To num
					dataTable2.ImportRow(dataTable.Rows(i))
				Next
				Me.DataGridView1.DataSource = dataTable2
			End If
		End Sub

		' Token: 0x060031A1 RID: 12705 RVA: 0x001EBAB4 File Offset: 0x001E9CB4
		Private Sub txtContactNo_TextChanged(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				Dim flag As Boolean = Me.dt Is Nothing
				If Not flag Then
					Dim dataView As DataView = New DataView(Me.dt)
					Dim text As String = Me.txtContactNo.Text.Trim().Replace("'", "''")
					dataView.RowFilter = String.Format("[Billing Phone] LIKE '%{0}%'", text)
					Dim dataTable As DataTable = dataView.ToTable()
					Dim dataTable2 As DataTable = dataTable.Clone()
					Dim num As Integer = Math.Min(9, dataTable.Rows.Count - 1)
					For i As Integer = 0 To num
						dataTable2.ImportRow(dataTable.Rows(i))
					Next
					Me.DataGridView1.DataSource = dataTable2
				End If
			Catch ex As WebException
				Dim flag2 As Boolean = ex.Response IsNot Nothing
				If flag2 Then
					Dim httpWebResponse As HttpWebResponse = CType(ex.Response, HttpWebResponse)
					Dim flag3 As Boolean = httpWebResponse.StatusCode = HttpStatusCode.BadRequest
					If flag3 Then
					End If
				End If
			End Try
		End Sub

		' Token: 0x060031A2 RID: 12706 RVA: 0x001EBBCC File Offset: 0x001E9DCC
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.dt Is Nothing
			If Not flag Then
				Try
					Dim [date] As DateTime = Me.dtpDateFrom.Value.[Date]
					Dim dateTime As DateTime = Me.dtpDateTo.Value.[Date].AddDays(1.0).AddSeconds(-1.0)
					Dim dataTable As DataTable = Me.dt.Clone()
					Try
						For Each obj As Object In Me.dt.Rows
							Dim dataRow As DataRow = CType(obj, DataRow)
							Dim text As String = dataRow("Date").ToString().Trim()
							Dim flag2 As Boolean = Not String.IsNullOrWhiteSpace(text)
							If flag2 Then
								Dim dateTime2 As DateTime
								Dim flag3 As Boolean = DateTime.TryParseExact(text, "M/d/yyyy H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, dateTime2)
								If flag3 Then
									Dim flag4 As Boolean = DateTime.Compare(dateTime2, [date]) >= 0 AndAlso DateTime.Compare(dateTime2, dateTime) <= 0
									If flag4 Then
										dataTable.ImportRow(dataRow)
									End If
								End If
							End If
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Me.DataGridView1.DataSource = dataTable
				Catch ex As WebException
					Dim flag5 As Boolean = ex.Response IsNot Nothing
					If flag5 Then
						Dim httpWebResponse As HttpWebResponse = CType(ex.Response, HttpWebResponse)
						Dim flag6 As Boolean = httpWebResponse.StatusCode = HttpStatusCode.BadRequest
						If flag6 Then
						End If
					End If
				End Try
			End If
		End Sub

		' Token: 0x060031A3 RID: 12707 RVA: 0x0001ED83 File Offset: 0x0001CF83
		Private Sub btnSetting_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmGSheet_Setting.ShowDialog()
		End Sub

		' Token: 0x04001548 RID: 5448
		Private dt As DataTable

		' Token: 0x04001549 RID: 5449
		Private spreadsheetId As String

		' Token: 0x0400154A RID: 5450
		Private gid As String
	End Class
End Namespace
