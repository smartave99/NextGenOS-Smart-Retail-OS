Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevNet.Models
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004D0 RID: 1232
	<DesignerGenerated()>
	Public Partial Class frmLoyaltySMS
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600FB53 RID: 64339 RVA: 0x0006E28F File Offset: 0x0006C48F
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmLoyaltySMS_Load
			Me.sts = ""
			Me.sts2 = ""
			Me.InitializeComponent()
		End Sub

		' Token: 0x1700602F RID: 24623
		' (get) Token: 0x0600FB56 RID: 64342 RVA: 0x0006E2C8 File Offset: 0x0006C4C8
		' (set) Token: 0x0600FB57 RID: 64343 RVA: 0x00968518 File Offset: 0x00966718
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

		' Token: 0x17006030 RID: 24624
		' (get) Token: 0x0600FB58 RID: 64344 RVA: 0x0006E2D2 File Offset: 0x0006C4D2
		' (set) Token: 0x0600FB59 RID: 64345 RVA: 0x0006E2DC File Offset: 0x0006C4DC
		Friend Overridable Property ColumnHeader1 As ColumnHeader

		' Token: 0x17006031 RID: 24625
		' (get) Token: 0x0600FB5A RID: 64346 RVA: 0x0006E2E5 File Offset: 0x0006C4E5
		' (set) Token: 0x0600FB5B RID: 64347 RVA: 0x0006E2EF File Offset: 0x0006C4EF
		Friend Overridable Property Label2 As Label

		' Token: 0x17006032 RID: 24626
		' (get) Token: 0x0600FB5C RID: 64348 RVA: 0x0006E2F8 File Offset: 0x0006C4F8
		' (set) Token: 0x0600FB5D RID: 64349 RVA: 0x0096855C File Offset: 0x0096675C
		Private _Timer2 As Timer
		Friend Overridable Property Timer2 As Timer
			<CompilerGenerated()>
			Get
				Return Me._Timer2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer2_Tick
				Dim timer As Timer = Me._Timer2
				If timer IsNot Nothing Then
					RemoveHandler timer.Tick, eventHandler
				End If
				Me._Timer2 = value
				timer = Me._Timer2
				If timer IsNot Nothing Then
					AddHandler timer.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006033 RID: 24627
		' (get) Token: 0x0600FB5E RID: 64350 RVA: 0x0006E302 File Offset: 0x0006C502
		' (set) Token: 0x0600FB5F RID: 64351 RVA: 0x0006E30C File Offset: 0x0006C50C
		Friend Overridable Property ColumnHeader9 As ColumnHeader

		' Token: 0x17006034 RID: 24628
		' (get) Token: 0x0600FB60 RID: 64352 RVA: 0x0006E315 File Offset: 0x0006C515
		' (set) Token: 0x0600FB61 RID: 64353 RVA: 0x009685A0 File Offset: 0x009667A0
		Private _chkSelectAll As CheckBox
		Friend Overridable Property chkSelectAll As CheckBox
			<CompilerGenerated()>
			Get
				Return Me._chkSelectAll
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkSelectAll_CheckedChanged
				Dim checkBox As CheckBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					RemoveHandler checkBox.CheckedChanged, eventHandler
				End If
				Me._chkSelectAll = value
				checkBox = Me._chkSelectAll
				If checkBox IsNot Nothing Then
					AddHandler checkBox.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006035 RID: 24629
		' (get) Token: 0x0600FB62 RID: 64354 RVA: 0x0006E31F File Offset: 0x0006C51F
		' (set) Token: 0x0600FB63 RID: 64355 RVA: 0x0006E329 File Offset: 0x0006C529
		Friend Overridable Property Label5 As Label

		' Token: 0x17006036 RID: 24630
		' (get) Token: 0x0600FB64 RID: 64356 RVA: 0x0006E332 File Offset: 0x0006C532
		' (set) Token: 0x0600FB65 RID: 64357 RVA: 0x0006E33C File Offset: 0x0006C53C
		Friend Overridable Property ListView1 As ListView

		' Token: 0x17006037 RID: 24631
		' (get) Token: 0x0600FB66 RID: 64358 RVA: 0x0006E345 File Offset: 0x0006C545
		' (set) Token: 0x0600FB67 RID: 64359 RVA: 0x0006E34F File Offset: 0x0006C54F
		Friend Overridable Property ColumnHeader6 As ColumnHeader

		' Token: 0x17006038 RID: 24632
		' (get) Token: 0x0600FB68 RID: 64360 RVA: 0x0006E358 File Offset: 0x0006C558
		' (set) Token: 0x0600FB69 RID: 64361 RVA: 0x0006E362 File Offset: 0x0006C562
		Friend Overridable Property ColumnHeader7 As ColumnHeader

		' Token: 0x17006039 RID: 24633
		' (get) Token: 0x0600FB6A RID: 64362 RVA: 0x0006E36B File Offset: 0x0006C56B
		' (set) Token: 0x0600FB6B RID: 64363 RVA: 0x0006E375 File Offset: 0x0006C575
		Friend Overridable Property Category As ColumnHeader

		' Token: 0x1700603A RID: 24634
		' (get) Token: 0x0600FB6C RID: 64364 RVA: 0x0006E37E File Offset: 0x0006C57E
		' (set) Token: 0x0600FB6D RID: 64365 RVA: 0x0006E388 File Offset: 0x0006C588
		Friend Overridable Property ColumnHeader8 As ColumnHeader

		' Token: 0x1700603B RID: 24635
		' (get) Token: 0x0600FB6E RID: 64366 RVA: 0x0006E391 File Offset: 0x0006C591
		' (set) Token: 0x0600FB6F RID: 64367 RVA: 0x0006E39B File Offset: 0x0006C59B
		Friend Overridable Property cmbCustomerName As ComboBox

		' Token: 0x1700603C RID: 24636
		' (get) Token: 0x0600FB70 RID: 64368 RVA: 0x0006E3A4 File Offset: 0x0006C5A4
		' (set) Token: 0x0600FB71 RID: 64369 RVA: 0x009685E4 File Offset: 0x009667E4
		Private _btnGetData As Button
		Friend Overridable Property btnGetData As Button
			<CompilerGenerated()>
			Get
				Return Me._btnGetData
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnGetData_Click
				Dim button As Button = Me._btnGetData
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnGetData = value
				button = Me._btnGetData
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700603D RID: 24637
		' (get) Token: 0x0600FB72 RID: 64370 RVA: 0x0006E3AE File Offset: 0x0006C5AE
		' (set) Token: 0x0600FB73 RID: 64371 RVA: 0x0006E3B8 File Offset: 0x0006C5B8
		Friend Overridable Property Label4 As Label

		' Token: 0x1700603E RID: 24638
		' (get) Token: 0x0600FB74 RID: 64372 RVA: 0x0006E3C1 File Offset: 0x0006C5C1
		' (set) Token: 0x0600FB75 RID: 64373 RVA: 0x0006E3CB File Offset: 0x0006C5CB
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x1700603F RID: 24639
		' (get) Token: 0x0600FB76 RID: 64374 RVA: 0x0006E3D4 File Offset: 0x0006C5D4
		' (set) Token: 0x0600FB77 RID: 64375 RVA: 0x0006E3DE File Offset: 0x0006C5DE
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006040 RID: 24640
		' (get) Token: 0x0600FB78 RID: 64376 RVA: 0x0006E3E7 File Offset: 0x0006C5E7
		' (set) Token: 0x0600FB79 RID: 64377 RVA: 0x00968628 File Offset: 0x00966828
		Private _btnReset As Button
		Friend Overridable Property btnReset As Button
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim button As Button = Me._btnReset
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnReset = value
				button = Me._btnReset
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006041 RID: 24641
		' (get) Token: 0x0600FB7A RID: 64378 RVA: 0x0006E3F1 File Offset: 0x0006C5F1
		' (set) Token: 0x0600FB7B RID: 64379 RVA: 0x0006E3FB File Offset: 0x0006C5FB
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17006042 RID: 24642
		' (get) Token: 0x0600FB7C RID: 64380 RVA: 0x0006E404 File Offset: 0x0006C604
		' (set) Token: 0x0600FB7D RID: 64381 RVA: 0x0096866C File Offset: 0x0096686C
		Private _Button3 As Button
		Friend Overridable Property Button3 As Button
			<CompilerGenerated()>
			Get
				Return Me._Button3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.Button3_Click
				Dim button As Button = Me._Button3
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006043 RID: 24643
		' (get) Token: 0x0600FB7E RID: 64382 RVA: 0x0006E40E File Offset: 0x0006C60E
		' (set) Token: 0x0600FB7F RID: 64383 RVA: 0x0006E418 File Offset: 0x0006C618
		Friend Overridable Property ListBox2 As ListBox

		' Token: 0x17006044 RID: 24644
		' (get) Token: 0x0600FB80 RID: 64384 RVA: 0x0006E421 File Offset: 0x0006C621
		' (set) Token: 0x0600FB81 RID: 64385 RVA: 0x0006E42B File Offset: 0x0006C62B
		Friend Overridable Property ListBox1 As ListBox

		' Token: 0x17006045 RID: 24645
		' (get) Token: 0x0600FB82 RID: 64386 RVA: 0x0006E434 File Offset: 0x0006C634
		' (set) Token: 0x0600FB83 RID: 64387 RVA: 0x0006E43E File Offset: 0x0006C63E
		Friend Overridable Property ColumnHeader2 As ColumnHeader

		' Token: 0x0600FB84 RID: 64388 RVA: 0x009686B0 File Offset: 0x009668B0
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
			End Try
		End Sub

		' Token: 0x0600FB85 RID: 64389 RVA: 0x0096878C File Offset: 0x0096698C
		Public Sub statusdisplay()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim sqlCommand As SqlCommand = ModCommonClasses.con.CreateCommand()
				sqlCommand.CommandText = "SELECT c1, c2 FROM WappApi"
				sqlCommand.Parameters.Clear()
				ModCommonClasses.rdr = sqlCommand.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				Dim flag2 As Boolean = flag
				If flag2 Then
					Me.sts = ModCommonClasses.rdr.GetValue(0).ToString()
					Me.sts2 = ModCommonClasses.rdr.GetValue(1).ToString()
				Else
					Me.sts = "91"
				End If
				ModCommonClasses.rdr.Close()
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FB86 RID: 64390 RVA: 0x0006E447 File Offset: 0x0006C647
		Private Sub frmLoyaltySMS_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.FillCustomer()
			Me.GetCompanyState()
			Me.chkSelectAll.Checked = True
			Me.statusdisplay()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600FB87 RID: 64391 RVA: 0x00968880 File Offset: 0x00966A80
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
						Me.UpdateAllHeaders(Me)
					End Using
				End Using
			Catch ex As Exception
				MessageBox.Show("An unexpected error occurred: " + ex.Message, "Unexpected Error")
			End Try
		End Sub

		' Token: 0x0600FB88 RID: 64392 RVA: 0x009689F8 File Offset: 0x00966BF8
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

		' Token: 0x0600FB89 RID: 64393 RVA: 0x00968AB4 File Offset: 0x00966CB4
		Private Sub UpdateAllHeaders(container As Control)
			Try
				For Each obj As Object In container.Controls
					Dim control As Control = CType(obj, Control)
					Dim flag As Boolean = TypeOf control Is DataGridView
					If flag Then
						Me.UpdateDataGridViewHeaders(CType(control, DataGridView))
					Else
						Dim flag2 As Boolean = TypeOf control Is ListView
						If flag2 Then
							Me.UpdateListViewHeaders(CType(control, ListView))
						Else
							Dim flag3 As Boolean = TypeOf control Is TabControl
							If flag3 Then
								Me.UpdateTabControlHeaders(CType(control, TabControl))
							End If
						End If
					End If
					Dim hasChildren As Boolean = control.HasChildren
					If hasChildren Then
						Me.UpdateAllHeaders(control)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600FB8A RID: 64394 RVA: 0x00086F78 File Offset: 0x00085178
		Private Sub UpdateListViewHeaders(listView As ListView)
			Try
				For Each obj As Object In listView.Columns
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
		End Sub

		' Token: 0x0600FB8B RID: 64395 RVA: 0x00087000 File Offset: 0x00085200
		Private Sub UpdateTabControlHeaders(tabControl As TabControl)
			Try
				For Each obj As Object In tabControl.TabPages
					Dim tabPage As TabPage = CType(obj, TabPage)
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(tabPage.Text)
					If flag Then
						tabPage.Text = GlobalVariables.translations(tabPage.Text)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600FB8C RID: 64396 RVA: 0x00087088 File Offset: 0x00085288
		Private Sub UpdateDataGridViewHeaders(dgv As DataGridView)
			Try
				For Each obj As Object In dgv.Columns
					Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
					Dim headerText As String = dataGridViewColumn.HeaderText
					Dim flag As Boolean = GlobalVariables.translations.ContainsKey(headerText)
					If flag Then
						dataGridViewColumn.HeaderText = GlobalVariables.translations(headerText)
					End If
				Next
			Finally
				Dim enumerator As IEnumerator
				If TypeOf enumerator Is IDisposable Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600FB8D RID: 64397 RVA: 0x00968B80 File Offset: 0x00966D80
		Private Sub btnGetData_Click(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject("SELECT Customer.Name,Customer.ContactNo, Customer.State, Customer.GSTIN, count(1) as cnt, (Sum(InvoiceInfo.AddLpoint)-Sum(InvoiceInfo.LoyaAmt)) FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceInfo.InvoiceDate between @d1 and @d2 AND InvoiceInfo.Customer_ID =", RuntimeHelpers.GetObjectValue(Interaction.IIf(Me.cmbCustomerName.SelectedIndex = -1, "InvoiceInfo.Customer_ID", RuntimeHelpers.GetObjectValue(Me.cmbCustomerName.SelectedValue))))), " ")), " GROUP BY Customer.Name, Customer.ContactNo,Customer.State, Customer.GSTIN order by Sum(InvoiceInfo.GrandTotal) desc ;")))
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "InvoiceDate").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.ListView1.Items.Clear()
				While ModCommonClasses.rdr.Read()
					Dim listViewItem As ListViewItem = New ListViewItem()
					listViewItem.Text = ModCommonClasses.rdr(0).ToString().Trim()
					listViewItem.SubItems.Add(ModCommonClasses.rdr(1).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(2).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(3).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(4).ToString().Trim())
					listViewItem.SubItems.Add(ModCommonClasses.rdr(5).ToString().Trim())
					listViewItem.SubItems.Add("")
					Me.ListView1.Items.Add(listViewItem)
				End While
				Dim num As Integer = Me.ListView1.Items.Count - 1
				For i As Integer = 0 To num
					Me.ListView1.Items(i).Checked = True
				Next
				ModCommonClasses.con.Close()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FB8E RID: 64398 RVA: 0x00968E40 File Offset: 0x00967040
		Public Sub FillCustomer()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT ID, RTRIM(Name) AS Name FROM Customer ORDER BY Name", ModCommonClasses.con)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.adp.Fill(ModCommonClasses.ds)
				ModCommonClasses.con.Close()
				Me.cmbCustomerName.DisplayMember = "Name"
				Me.cmbCustomerName.ValueMember = "ID"
				Me.cmbCustomerName.DataSource = ModCommonClasses.ds.Tables(0)
				Me.cmbCustomerName.SelectedIndex = -1
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FB8F RID: 64399 RVA: 0x00968F34 File Offset: 0x00967134
		Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkSelectAll.Checked
			Dim flag2 As Boolean = flag
			If flag2 Then
				Dim num As Integer = 0
				Dim num2 As Integer = Me.ListView1.Items.Count - 1
				Dim num3 As Integer = num
				While True
					Dim num4 As Integer = num3
					Dim num5 As Integer = num2
					Dim flag3 As Boolean = num4 > num5
					If flag3 Then
						Exit While
					End If
					Me.ListView1.Items(num3).Checked = True
					num3 += 1
				End While
			Else
				flag = Not Me.chkSelectAll.Checked
				Dim flag4 As Boolean = flag
				If flag4 Then
					Dim num6 As Integer = 0
					Dim num7 As Integer = Me.ListView1.Items.Count - 1
					Dim num8 As Integer = num6
					While True
						Dim num9 As Integer = num8
						Dim num10 As Integer = num7
						Dim flag5 As Boolean = num9 > num10
						If flag5 Then
							Exit While
						End If
						Me.ListView1.Items(num8).Checked = False
						num8 += 1
					End While
				End If
			End If
		End Sub

		' Token: 0x0600FB90 RID: 64400 RVA: 0x0006E47A File Offset: 0x0006C67A
		Private Sub Timer2_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer2.Enabled = False
		End Sub

		' Token: 0x0600FB91 RID: 64401 RVA: 0x0006E496 File Offset: 0x0006C696
		Private Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.ListView1.Items.Clear()
			Me.cmbCustomerName.SelectedIndex = -1
		End Sub

		' Token: 0x0600FB92 RID: 64402 RVA: 0x00969020 File Offset: 0x00967220
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ListView1.Items.Count = 0
			If flag Then
				MessageBox.Show("Please retrieve customers list", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				Dim flag2 As Boolean = Me.ListView1.CheckedItems.Count = 0
				If flag2 Then
					MessageBox.Show("Please select at least one customer", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					Try
						Dim flag3 As Boolean = Me.ListView1.CheckedItems.Count > 0
						If flag3 Then
							Dim num As Integer = 0
							Dim num2 As Integer = Me.ListView1.CheckedItems.Count - 1
							Dim num3 As Integer = num
							While True
								Dim num4 As Integer = num3
								Dim num5 As Integer = num2
								Dim flag4 As Boolean = num4 > num5
								If flag4 Then
									Exit While
								End If
								Dim flag5 As Boolean = Strings.Len(Me.ListView1.CheckedItems(num3).SubItems(1).Text) >= 10
								If flag5 Then
									Dim flag6 As Boolean = ModFunc.CheckForInternetConnection()
									If flag6 Then
										Me.Cursor = Cursors.WaitCursor
										Me.Timer2.Enabled = True
										ModCommonClasses.con = New SqlConnection(ModCS.cs)
										ModCommonClasses.con.Open()
										Dim text As String = "Select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
										ModCommonClasses.cmd = New SqlCommand(text)
										ModCommonClasses.cmd.Connection = ModCommonClasses.con
										ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
										Dim flag7 As Boolean = ModCommonClasses.rdr.Read()
										If flag7 Then
											Dim text2 As String = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModCommonClasses.rdr.GetValue(0)))
											Dim text3 As String = ""
											Dim flag8 As Boolean = Operators.CompareString(Me.ListView1.CheckedItems(num3).SubItems(0).Text.ToUpper(), "Cash", False) <> 0
											If flag8 Then
												text3 = String.Concat(New String() { "Dear Sir/Madam ", Me.ListView1.CheckedItems(num3).SubItems(0).Text.ToUpper(), ", You have earned the loyalty amount Rs. ", Me.ListView1.CheckedItems(num3).SubItems(5).Text, " , Please visit again, Best wishes from : ", Me.TextBox1.Text.Trim(), " " })
											End If
											ModFunc.SMSFunc(Me.ListView1.CheckedItems(num3).SubItems(1).Text, text3, text2)
											ModFunc.SMS(text3)
											num += 1
										End If
										Dim flag9 As Boolean = ModCommonClasses.rdr IsNot Nothing
										If flag9 Then
											ModCommonClasses.rdr.Close()
										End If
									End If
								End If
								num3 += 1
							End While
							Dim flag10 As Boolean = num > 0
							If flag10 Then
								MessageBox.Show("Successfully SMS Sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
							Else
								MessageBox.Show("Unsuccessfully SMS Sending", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							End If
						End If
					Catch ex As Exception
						MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
					End Try
				End If
			End If
		End Sub

		' Token: 0x0600FB93 RID: 64403 RVA: 0x0006E4CF File Offset: 0x0006C6CF
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600FB94 RID: 64404 RVA: 0x00969370 File Offset: 0x00967570
		Public Sub GetCompanyState()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(companyName) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.TextBox1.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
				End If
				Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
				If flag2 Then
					ModCommonClasses.rdr.Close()
				End If
				Dim flag3 As Boolean = ModCommonClasses.con.State = ConnectionState.Open
				If flag3 Then
					ModCommonClasses.con.Close()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600FB95 RID: 64405 RVA: 0x00969460 File Offset: 0x00967660
		Private Async Sub Button3_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Operators.CompareString(Me.sts2, "Enabled", False) <> 0
			If flag Then
				MessageBox.Show("Your WhatsApp API status is disabled", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			Else
				Dim flag2 As Boolean = Not ModFunc.CheckForInternetConnection()
				If flag2 Then
					MessageBox.Show("Internet Connection not found", "Unsuccess", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim flag3 As Boolean = Me.ListView1.Items.Count = 0
					If flag3 Then
						MessageBox.Show("Please retrieve customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Else
						Dim flag4 As Boolean = Me.ListView1.CheckedItems.Count = 0
						If flag4 Then
							MessageBox.Show("Please select customers list", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Else
							Try
								Me.Cursor = Cursors.WaitCursor
								Me.Timer2.Enabled = True
								Try
									For Each obj As Object In Me.ListView1.Items
										Dim item As ListViewItem = CType(obj, ListViewItem)
										Dim checked As Boolean = item.Checked
										If checked Then
											Dim customerName As String = item.SubItems(0).Text
											Dim textsms As String = item.SubItems(5).Text
											Dim phone As String = Me.sts + item.SubItems(1).Text
											Dim attach As String = ""
											Dim message As String = String.Format("Dear {0}, You have earned the loyalty amount Rs. {1}, {2}, _Please visit again, Best wishes from : *{3}*_", New Object() { customerName, textsms, "", Me.TextBox1.Text })
											Dim flag5 As Boolean = phone IsNot Nothing AndAlso (message IsNot Nothing OrElse attach <> Nothing)
											If flag5 Then
												Dim messageRequest As MessageRequest = New MessageRequest()
												messageRequest.Phone = phone
												messageRequest.Message = message
												messageRequest.AttachmentPath = attach
											End If
										End If
										Await Task.Delay(7000)
									Next
								Finally
									Dim enumerator As IEnumerator
									If TypeOf enumerator Is IDisposable Then
										TryCast(enumerator, IDisposable).Dispose()
									End If
								End Try
							Catch ex As Exception
								MessageBox.Show("Engine is not active")
							End Try
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x04006041 RID: 24641
		Private sts As String

		' Token: 0x04006042 RID: 24642
		Private sts2 As String

		' Token: 0x04006043 RID: 24643
		Private st1 As String

		' Token: 0x04006044 RID: 24644
		Private st2 As String

		' Token: 0x04006045 RID: 24645
		Private st3 As String
	End Class
End Namespace
