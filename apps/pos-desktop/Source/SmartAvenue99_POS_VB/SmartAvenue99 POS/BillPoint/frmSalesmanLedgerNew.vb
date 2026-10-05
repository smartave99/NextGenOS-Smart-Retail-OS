Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports BillPoint.My
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000208 RID: 520
	<DesignerGenerated()>
	Public Partial Class frmSalesmanLedgerNew
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600968E RID: 38542 RVA: 0x00049A8C File Offset: 0x00047C8C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170037F0 RID: 14320
		' (get) Token: 0x06009691 RID: 38545 RVA: 0x00049ABE File Offset: 0x00047CBE
		' (set) Token: 0x06009692 RID: 38546 RVA: 0x006C6CAC File Offset: 0x006C4EAC
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

		' Token: 0x170037F1 RID: 14321
		' (get) Token: 0x06009693 RID: 38547 RVA: 0x00049AC8 File Offset: 0x00047CC8
		' (set) Token: 0x06009694 RID: 38548 RVA: 0x00049AD2 File Offset: 0x00047CD2
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170037F2 RID: 14322
		' (get) Token: 0x06009695 RID: 38549 RVA: 0x00049ADB File Offset: 0x00047CDB
		' (set) Token: 0x06009696 RID: 38550 RVA: 0x00049AE5 File Offset: 0x00047CE5
		Friend Overridable Property Label1 As Label

		' Token: 0x170037F3 RID: 14323
		' (get) Token: 0x06009697 RID: 38551 RVA: 0x00049AEE File Offset: 0x00047CEE
		' (set) Token: 0x06009698 RID: 38552 RVA: 0x006C6CF0 File Offset: 0x006C4EF0
		Private _GelButton3 As GelButton
		Friend Overridable Property GelButton3 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton3
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton3_Click
				Dim gelButton As GelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton3 = value
				gelButton = Me._GelButton3
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170037F4 RID: 14324
		' (get) Token: 0x06009699 RID: 38553 RVA: 0x00049AF8 File Offset: 0x00047CF8
		' (set) Token: 0x0600969A RID: 38554 RVA: 0x00049B02 File Offset: 0x00047D02
		Friend Overridable Property lblBalance As Label

		' Token: 0x170037F5 RID: 14325
		' (get) Token: 0x0600969B RID: 38555 RVA: 0x00049B0B File Offset: 0x00047D0B
		' (set) Token: 0x0600969C RID: 38556 RVA: 0x006C6D34 File Offset: 0x006C4F34
		Private _btnSelection As Button
		Friend Overridable Property btnSelection As Button
			<CompilerGenerated()>
			Get
				Return Me._btnSelection
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSelection_Click
				Dim button As Button = Me._btnSelection
				If button IsNot Nothing Then
					RemoveHandler button.Click, eventHandler
				End If
				Me._btnSelection = value
				button = Me._btnSelection
				If button IsNot Nothing Then
					AddHandler button.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170037F6 RID: 14326
		' (get) Token: 0x0600969D RID: 38557 RVA: 0x00049B15 File Offset: 0x00047D15
		' (set) Token: 0x0600969E RID: 38558 RVA: 0x00049B1F File Offset: 0x00047D1F
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x170037F7 RID: 14327
		' (get) Token: 0x0600969F RID: 38559 RVA: 0x00049B28 File Offset: 0x00047D28
		' (set) Token: 0x060096A0 RID: 38560 RVA: 0x006C6D78 File Offset: 0x006C4F78
		Private _GelButton2 As GelButton
		Friend Overridable Property GelButton2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton2_Click
				Dim gelButton As GelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton2 = value
				gelButton = Me._GelButton2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170037F8 RID: 14328
		' (get) Token: 0x060096A1 RID: 38561 RVA: 0x00049B32 File Offset: 0x00047D32
		' (set) Token: 0x060096A2 RID: 38562 RVA: 0x006C6DBC File Offset: 0x006C4FBC
		Private _txtCustomerID As TextBox
		Friend Overridable Property txtCustomerID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtCustomerID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtCustomerID_TextChanged
				Dim textBox As TextBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtCustomerID = value
				textBox = Me._txtCustomerID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170037F9 RID: 14329
		' (get) Token: 0x060096A3 RID: 38563 RVA: 0x00049B3C File Offset: 0x00047D3C
		' (set) Token: 0x060096A4 RID: 38564 RVA: 0x00049B46 File Offset: 0x00047D46
		Friend Overridable Property Label5 As Label

		' Token: 0x170037FA RID: 14330
		' (get) Token: 0x060096A5 RID: 38565 RVA: 0x00049B4F File Offset: 0x00047D4F
		' (set) Token: 0x060096A6 RID: 38566 RVA: 0x00049B59 File Offset: 0x00047D59
		Friend Overridable Property Label3 As Label

		' Token: 0x170037FB RID: 14331
		' (get) Token: 0x060096A7 RID: 38567 RVA: 0x00049B62 File Offset: 0x00047D62
		' (set) Token: 0x060096A8 RID: 38568 RVA: 0x00049B6C File Offset: 0x00047D6C
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170037FC RID: 14332
		' (get) Token: 0x060096A9 RID: 38569 RVA: 0x00049B75 File Offset: 0x00047D75
		' (set) Token: 0x060096AA RID: 38570 RVA: 0x00049B7F File Offset: 0x00047D7F
		Friend Overridable Property Label2 As Label

		' Token: 0x170037FD RID: 14333
		' (get) Token: 0x060096AB RID: 38571 RVA: 0x00049B88 File Offset: 0x00047D88
		' (set) Token: 0x060096AC RID: 38572 RVA: 0x00049B92 File Offset: 0x00047D92
		Friend Overridable Property Label4 As Label

		' Token: 0x170037FE RID: 14334
		' (get) Token: 0x060096AD RID: 38573 RVA: 0x00049B9B File Offset: 0x00047D9B
		' (set) Token: 0x060096AE RID: 38574 RVA: 0x00049BA5 File Offset: 0x00047DA5
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170037FF RID: 14335
		' (get) Token: 0x060096AF RID: 38575 RVA: 0x00049BAE File Offset: 0x00047DAE
		' (set) Token: 0x060096B0 RID: 38576 RVA: 0x00049BB8 File Offset: 0x00047DB8
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17003800 RID: 14336
		' (get) Token: 0x060096B1 RID: 38577 RVA: 0x00049BC1 File Offset: 0x00047DC1
		' (set) Token: 0x060096B2 RID: 38578 RVA: 0x00049BCB File Offset: 0x00047DCB
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17003801 RID: 14337
		' (get) Token: 0x060096B3 RID: 38579 RVA: 0x00049BD4 File Offset: 0x00047DD4
		' (set) Token: 0x060096B4 RID: 38580 RVA: 0x00049BDE File Offset: 0x00047DDE
		Friend Overridable Property txtID As TextBox

		' Token: 0x060096B5 RID: 38581 RVA: 0x006C6E00 File Offset: 0x006C5000
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

		' Token: 0x060096B6 RID: 38582 RVA: 0x006C6EDC File Offset: 0x006C50DC
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.txtCustomerName.Text = ""
			Me.txtCustomerID.Text = ""
			Me.txtID.Text = ""
		End Sub

		' Token: 0x060096B7 RID: 38583 RVA: 0x00049BE7 File Offset: 0x00047DE7
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x060096B8 RID: 38584 RVA: 0x00049C03 File Offset: 0x00047E03
		Private Sub frmCustomerLedger_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x060096B9 RID: 38585 RVA: 0x006C6F38 File Offset: 0x006C5138
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

		' Token: 0x060096BA RID: 38586 RVA: 0x006C70B0 File Offset: 0x006C52B0
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

		' Token: 0x060096BB RID: 38587 RVA: 0x006C716C File Offset: 0x006C536C
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

		' Token: 0x060096BC RID: 38588 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x060096BD RID: 38589 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x060096BE RID: 38590 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x060096BF RID: 38591 RVA: 0x006C7238 File Offset: 0x006C5438
		Public Sub GetCustomerInfo()
			Try
				Me.a = ""
				Me.b = ""
				Me.c = ""
				Me.d = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(Address),RTRIM(City),RTRIM(ContactNo),RTRIM(State) FROM Customer WHERE CustomerID=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.a = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
					Me.b = Conversions.ToString(ModCommonClasses.rdr.GetValue(1))
					Me.c = Conversions.ToString(ModCommonClasses.rdr.GetValue(2))
					Me.d = Conversions.ToString(ModCommonClasses.rdr.GetValue(3))
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

		' Token: 0x060096C0 RID: 38592 RVA: 0x00049C14 File Offset: 0x00047E14
		Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs)
			Me.GetCustomerBalance()
		End Sub

		' Token: 0x060096C1 RID: 38593 RVA: 0x00049C1E File Offset: 0x00047E1E
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x060096C2 RID: 38594 RVA: 0x006C73BC File Offset: 0x006C55BC
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
				If flag Then
					MessageBox.Show("Please retrieve SalesMan Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCustomerName.Focus()
				Else
					Me.GetCustomerInfo()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select PartyID from LedgerBooksalesman1 where PartyID=@d1 and Date >=@d2 and Date < @d3"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtID.Text)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.cmd.Connection = ModCommonClasses.con
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
					Dim flag2 As Boolean = Not ModCommonClasses.rdr.Read()
					If flag2 Then
						MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
						Dim flag3 As Boolean = ModCommonClasses.rdr IsNot Nothing
						If flag3 Then
							ModCommonClasses.rdr.Close()
						End If
					Else
						Me.Cursor = Cursors.WaitCursor
						Me.Timer1.Enabled = True
						ModCommonClasses.con = New SqlConnection(ModCS.cs)
						ModCommonClasses.con.Open()
						ModCommonClasses.cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from LedgerBooksalesman1 where Date >=@d1 and Date < @d2 and PartyID=@d3 order by ID,Date,LedgerNo", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtID.Text)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.dtable = New DataTable()
						ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
						ModCommonClasses.con.Close()
						ModCommonClasses.ds = New DataSet()
						ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
						ModCommonClasses.ds.WriteXmlSchema("CustomerLedgerBook.xml")
						Dim rptSalesManLedgerNew As rptSalesManLedgerNew = New rptSalesManLedgerNew()
						rptSalesManLedgerNew.SetDataSource(ModCommonClasses.ds)
						rptSalesManLedgerNew.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
						rptSalesManLedgerNew.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
						rptSalesManLedgerNew.SetParameterValue("p3", Me.txtCustomerID.Text)
						rptSalesManLedgerNew.SetParameterValue("p4", Me.txtCustomerName.Text)
						rptSalesManLedgerNew.SetParameterValue("p5", Me.a)
						rptSalesManLedgerNew.SetParameterValue("p6", Me.b)
						rptSalesManLedgerNew.SetParameterValue("p7", Me.c)
						rptSalesManLedgerNew.SetParameterValue("p8", Me.d)
						rptSalesManLedgerNew.SetParameterValue("p9", Me.lblBalance.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSalesManLedgerNew
						MyProject.Forms.frmReport.ShowDialog()
						rptSalesManLedgerNew.Close()
						rptSalesManLedgerNew.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x060096C3 RID: 38595 RVA: 0x00049C28 File Offset: 0x00047E28
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSalesmanRecord.lblSet.Text = "Salesman LedgerNew"
			MyProject.Forms.frmSalesmanRecord.Reset()
			MyProject.Forms.frmSalesmanRecord.ShowDialog()
		End Sub

		' Token: 0x060096C4 RID: 38596 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCustomerLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x060096C5 RID: 38597 RVA: 0x006C77F8 File Offset: 0x006C59F8
		Public Sub GetCustomerBalance()
			Try
				Try
					Me.num1 = 0.0
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from LedgerBooksalesman1 where PartyID=@d1 group By PartyID"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtID.Text)
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Dim flag As Boolean = ModCommonClasses.rdr.Read()
					If flag Then
						Me.num1 = Conversions.ToDouble(ModCommonClasses.rdr.GetValue(0))
					End If
					ModCommonClasses.con.Close()
					Me.lblBalance.Text = Conversions.ToString(Me.num1)
					Me.lblBalance.ForeColor = Color.DarkGreen
					Dim flag2 As Boolean = Conversion.Val(Me.lblBalance.Text) >= 0.0
					If flag2 Then
						Me.str = "Cr"
						Me.lblBalance.ForeColor = Color.Blue
					Else
						Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblBalance.Text) < 0.0) <> 0.0
						If flag3 Then
							Me.str = "Dr"
							Me.lblBalance.ForeColor = Color.Red
						End If
					End If
					Me.lblBalance.Text = Strings.Format(Math.Abs(Conversion.Val(Me.lblBalance.Text)), "0.00")
					Me.lblBalance.Text = Me.lblBalance.Text + " " + Me.str.ToString()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
			Catch ex2 As Exception
				MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x040042AB RID: 17067
		Private a As String

		' Token: 0x040042AC RID: 17068
		Private b As String

		' Token: 0x040042AD RID: 17069
		Private c As String

		' Token: 0x040042AE RID: 17070
		Private d As String

		' Token: 0x040042AF RID: 17071
		Private num1 As Double

		' Token: 0x040042B0 RID: 17072
		Private str As String
	End Class
End Namespace
