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
	' Token: 0x0200029C RID: 668
	<DesignerGenerated()>
	Public Partial Class frmCustomerLedger
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600A921 RID: 43297 RVA: 0x0004ECFC File Offset: 0x0004CEFC
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCustomerLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCustomerLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004181 RID: 16769
		' (get) Token: 0x0600A924 RID: 43300 RVA: 0x0004ED2E File Offset: 0x0004CF2E
		' (set) Token: 0x0600A925 RID: 43301 RVA: 0x0004ED38 File Offset: 0x0004CF38
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004182 RID: 16770
		' (get) Token: 0x0600A926 RID: 43302 RVA: 0x0004ED41 File Offset: 0x0004CF41
		' (set) Token: 0x0600A927 RID: 43303 RVA: 0x0004ED4B File Offset: 0x0004CF4B
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004183 RID: 16771
		' (get) Token: 0x0600A928 RID: 43304 RVA: 0x0004ED54 File Offset: 0x0004CF54
		' (set) Token: 0x0600A929 RID: 43305 RVA: 0x0004ED5E File Offset: 0x0004CF5E
		Friend Overridable Property Label1 As Label

		' Token: 0x17004184 RID: 16772
		' (get) Token: 0x0600A92A RID: 43306 RVA: 0x0004ED67 File Offset: 0x0004CF67
		' (set) Token: 0x0600A92B RID: 43307 RVA: 0x00713050 File Offset: 0x00711250
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

		' Token: 0x17004185 RID: 16773
		' (get) Token: 0x0600A92C RID: 43308 RVA: 0x0004ED71 File Offset: 0x0004CF71
		' (set) Token: 0x0600A92D RID: 43309 RVA: 0x0004ED7B File Offset: 0x0004CF7B
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004186 RID: 16774
		' (get) Token: 0x0600A92E RID: 43310 RVA: 0x0004ED84 File Offset: 0x0004CF84
		' (set) Token: 0x0600A92F RID: 43311 RVA: 0x0004ED8E File Offset: 0x0004CF8E
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004187 RID: 16775
		' (get) Token: 0x0600A930 RID: 43312 RVA: 0x0004ED97 File Offset: 0x0004CF97
		' (set) Token: 0x0600A931 RID: 43313 RVA: 0x0004EDA1 File Offset: 0x0004CFA1
		Friend Overridable Property Label2 As Label

		' Token: 0x17004188 RID: 16776
		' (get) Token: 0x0600A932 RID: 43314 RVA: 0x0004EDAA File Offset: 0x0004CFAA
		' (set) Token: 0x0600A933 RID: 43315 RVA: 0x0004EDB4 File Offset: 0x0004CFB4
		Friend Overridable Property Label4 As Label

		' Token: 0x17004189 RID: 16777
		' (get) Token: 0x0600A934 RID: 43316 RVA: 0x0004EDBD File Offset: 0x0004CFBD
		' (set) Token: 0x0600A935 RID: 43317 RVA: 0x0004EDC7 File Offset: 0x0004CFC7
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x1700418A RID: 16778
		' (get) Token: 0x0600A936 RID: 43318 RVA: 0x0004EDD0 File Offset: 0x0004CFD0
		' (set) Token: 0x0600A937 RID: 43319 RVA: 0x0004EDDA File Offset: 0x0004CFDA
		Friend Overridable Property Label3 As Label

		' Token: 0x1700418B RID: 16779
		' (get) Token: 0x0600A938 RID: 43320 RVA: 0x0004EDE3 File Offset: 0x0004CFE3
		' (set) Token: 0x0600A939 RID: 43321 RVA: 0x0004EDED File Offset: 0x0004CFED
		Friend Overridable Property txtCustomerName As TextBox

		' Token: 0x1700418C RID: 16780
		' (get) Token: 0x0600A93A RID: 43322 RVA: 0x0004EDF6 File Offset: 0x0004CFF6
		' (set) Token: 0x0600A93B RID: 43323 RVA: 0x00713094 File Offset: 0x00711294
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

		' Token: 0x1700418D RID: 16781
		' (get) Token: 0x0600A93C RID: 43324 RVA: 0x0004EE00 File Offset: 0x0004D000
		' (set) Token: 0x0600A93D RID: 43325 RVA: 0x0004EE0A File Offset: 0x0004D00A
		Friend Overridable Property Label5 As Label

		' Token: 0x1700418E RID: 16782
		' (get) Token: 0x0600A93E RID: 43326 RVA: 0x0004EE13 File Offset: 0x0004D013
		' (set) Token: 0x0600A93F RID: 43327 RVA: 0x007130D8 File Offset: 0x007112D8
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

		' Token: 0x1700418F RID: 16783
		' (get) Token: 0x0600A940 RID: 43328 RVA: 0x0004EE1D File Offset: 0x0004D01D
		' (set) Token: 0x0600A941 RID: 43329 RVA: 0x0004EE27 File Offset: 0x0004D027
		Friend Overridable Property lblBalance As Label

		' Token: 0x17004190 RID: 16784
		' (get) Token: 0x0600A942 RID: 43330 RVA: 0x0004EE30 File Offset: 0x0004D030
		' (set) Token: 0x0600A943 RID: 43331 RVA: 0x0071311C File Offset: 0x0071131C
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

		' Token: 0x17004191 RID: 16785
		' (get) Token: 0x0600A944 RID: 43332 RVA: 0x0004EE3A File Offset: 0x0004D03A
		' (set) Token: 0x0600A945 RID: 43333 RVA: 0x00713160 File Offset: 0x00711360
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

		' Token: 0x0600A946 RID: 43334 RVA: 0x007131A4 File Offset: 0x007113A4
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

		' Token: 0x0600A947 RID: 43335 RVA: 0x0004EE44 File Offset: 0x0004D044
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.txtCustomerName.Text = ""
			Me.txtCustomerID.Text = ""
		End Sub

		' Token: 0x0600A948 RID: 43336 RVA: 0x0004EE81 File Offset: 0x0004D081
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600A949 RID: 43337 RVA: 0x0004EE9D File Offset: 0x0004D09D
		Private Sub frmCustomerLedger_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600A94A RID: 43338 RVA: 0x00713280 File Offset: 0x00711480
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

		' Token: 0x0600A94B RID: 43339 RVA: 0x007133F8 File Offset: 0x007115F8
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

		' Token: 0x0600A94C RID: 43340 RVA: 0x007134B4 File Offset: 0x007116B4
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

		' Token: 0x0600A94D RID: 43341 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600A94E RID: 43342 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600A94F RID: 43343 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600A950 RID: 43344 RVA: 0x00713580 File Offset: 0x00711780
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

		' Token: 0x0600A951 RID: 43345 RVA: 0x0004EEAE File Offset: 0x0004D0AE
		Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs)
			Me.GetCustomerBalance()
		End Sub

		' Token: 0x0600A952 RID: 43346 RVA: 0x0004EEB8 File Offset: 0x0004D0B8
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600A953 RID: 43347 RVA: 0x00713704 File Offset: 0x00711904
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtCustomerName.Text)) = 0
				If flag Then
					MessageBox.Show("Please retrieve Customer Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtCustomerName.Focus()
				Else
					Me.GetCustomerInfo()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select PartyID from CustomerLedgerBook where PartyID=@d1 and Date >=@d2 and Date < @d3"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
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
						ModCommonClasses.cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit, Remarks from CustomerLedgerBook where Date >=@d1 and Date < @d2 and PartyID=@d3 order by ID,Date,LedgerNo", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtCustomerID.Text)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.dtable = New DataTable()
						ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
						ModCommonClasses.con.Close()
						ModCommonClasses.ds = New DataSet()
						ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
						ModCommonClasses.ds.WriteXmlSchema("CustomerLedgerBook.xml")
						Dim rptCustomerLedger As rptCustomerLedger1 = New rptCustomerLedger1()
						rptCustomerLedger.SetDataSource(ModCommonClasses.ds)
						rptCustomerLedger.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
						rptCustomerLedger.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
						rptCustomerLedger.SetParameterValue("p3", Me.txtCustomerID.Text)
						rptCustomerLedger.SetParameterValue("p4", Me.txtCustomerName.Text)
						rptCustomerLedger.SetParameterValue("p5", Me.a)
						rptCustomerLedger.SetParameterValue("p6", Me.b)
						rptCustomerLedger.SetParameterValue("p7", Me.c)
						rptCustomerLedger.SetParameterValue("p8", Me.d)
						rptCustomerLedger.SetParameterValue("p9", Me.lblBalance.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptCustomerLedger
						MyProject.Forms.frmReport.ShowDialog()
						rptCustomerLedger.Close()
						rptCustomerLedger.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600A954 RID: 43348 RVA: 0x00713B40 File Offset: 0x00711D40
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmCustomerRecord.lblSet.Text = "Customer Ledger"
			MyProject.Forms.frmCustomerRecord.btnAddCustomer.Visible = False
			MyProject.Forms.frmCustomerRecord.Reset()
			MyProject.Forms.frmCustomerRecord.ShowDialog()
		End Sub

		' Token: 0x0600A955 RID: 43349 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x0600A956 RID: 43350 RVA: 0x00713BA0 File Offset: 0x00711DA0
		Public Sub GetCustomerBalance()
			Try
				Try
					Me.num1 = 0.0
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from CustomerLedgerBook where PartyID=@d1 group By PartyID"
					ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtCustomerID.Text)
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

		' Token: 0x040046D6 RID: 18134
		Private a As String

		' Token: 0x040046D7 RID: 18135
		Private b As String

		' Token: 0x040046D8 RID: 18136
		Private c As String

		' Token: 0x040046D9 RID: 18137
		Private d As String

		' Token: 0x040046DA RID: 18138
		Private num1 As Double

		' Token: 0x040046DB RID: 18139
		Private str As String
	End Class
End Namespace
