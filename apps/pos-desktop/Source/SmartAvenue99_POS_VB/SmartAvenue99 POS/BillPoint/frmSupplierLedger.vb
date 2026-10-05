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
	' Token: 0x020002AE RID: 686
	<DesignerGenerated()>
	Public Partial Class frmSupplierLedger
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600B1FC RID: 45564 RVA: 0x00052AA0 File Offset: 0x00050CA0
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSupplierLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSupplierLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x170044C0 RID: 17600
		' (get) Token: 0x0600B1FF RID: 45567 RVA: 0x00052AD2 File Offset: 0x00050CD2
		' (set) Token: 0x0600B200 RID: 45568 RVA: 0x00052ADC File Offset: 0x00050CDC
		Friend Overridable Property Panel1 As Panel

		' Token: 0x170044C1 RID: 17601
		' (get) Token: 0x0600B201 RID: 45569 RVA: 0x00052AE5 File Offset: 0x00050CE5
		' (set) Token: 0x0600B202 RID: 45570 RVA: 0x00052AEF File Offset: 0x00050CEF
		Friend Overridable Property Panel2 As Panel

		' Token: 0x170044C2 RID: 17602
		' (get) Token: 0x0600B203 RID: 45571 RVA: 0x00052AF8 File Offset: 0x00050CF8
		' (set) Token: 0x0600B204 RID: 45572 RVA: 0x00052B02 File Offset: 0x00050D02
		Friend Overridable Property Label1 As Label

		' Token: 0x170044C3 RID: 17603
		' (get) Token: 0x0600B205 RID: 45573 RVA: 0x00052B0B File Offset: 0x00050D0B
		' (set) Token: 0x0600B206 RID: 45574 RVA: 0x00052B15 File Offset: 0x00050D15
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x170044C4 RID: 17604
		' (get) Token: 0x0600B207 RID: 45575 RVA: 0x00052B1E File Offset: 0x00050D1E
		' (set) Token: 0x0600B208 RID: 45576 RVA: 0x0076FDCC File Offset: 0x0076DFCC
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

		' Token: 0x170044C5 RID: 17605
		' (get) Token: 0x0600B209 RID: 45577 RVA: 0x00052B28 File Offset: 0x00050D28
		' (set) Token: 0x0600B20A RID: 45578 RVA: 0x00052B32 File Offset: 0x00050D32
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x170044C6 RID: 17606
		' (get) Token: 0x0600B20B RID: 45579 RVA: 0x00052B3B File Offset: 0x00050D3B
		' (set) Token: 0x0600B20C RID: 45580 RVA: 0x00052B45 File Offset: 0x00050D45
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x170044C7 RID: 17607
		' (get) Token: 0x0600B20D RID: 45581 RVA: 0x00052B4E File Offset: 0x00050D4E
		' (set) Token: 0x0600B20E RID: 45582 RVA: 0x00052B58 File Offset: 0x00050D58
		Friend Overridable Property Label2 As Label

		' Token: 0x170044C8 RID: 17608
		' (get) Token: 0x0600B20F RID: 45583 RVA: 0x00052B61 File Offset: 0x00050D61
		' (set) Token: 0x0600B210 RID: 45584 RVA: 0x00052B6B File Offset: 0x00050D6B
		Friend Overridable Property Label4 As Label

		' Token: 0x170044C9 RID: 17609
		' (get) Token: 0x0600B211 RID: 45585 RVA: 0x00052B74 File Offset: 0x00050D74
		' (set) Token: 0x0600B212 RID: 45586 RVA: 0x00052B7E File Offset: 0x00050D7E
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x170044CA RID: 17610
		' (get) Token: 0x0600B213 RID: 45587 RVA: 0x00052B87 File Offset: 0x00050D87
		' (set) Token: 0x0600B214 RID: 45588 RVA: 0x00052B91 File Offset: 0x00050D91
		Friend Overridable Property Label3 As Label

		' Token: 0x170044CB RID: 17611
		' (get) Token: 0x0600B215 RID: 45589 RVA: 0x00052B9A File Offset: 0x00050D9A
		' (set) Token: 0x0600B216 RID: 45590 RVA: 0x00052BA4 File Offset: 0x00050DA4
		Friend Overridable Property txtSupplierName As TextBox

		' Token: 0x170044CC RID: 17612
		' (get) Token: 0x0600B217 RID: 45591 RVA: 0x00052BAD File Offset: 0x00050DAD
		' (set) Token: 0x0600B218 RID: 45592 RVA: 0x0076FE10 File Offset: 0x0076E010
		Private _txtSupplierID As TextBox
		Friend Overridable Property txtSupplierID As TextBox
			<CompilerGenerated()>
			Get
				Return Me._txtSupplierID
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.txtSupplierID_TextChanged
				Dim textBox As TextBox = Me._txtSupplierID
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._txtSupplierID = value
				textBox = Me._txtSupplierID
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170044CD RID: 17613
		' (get) Token: 0x0600B219 RID: 45593 RVA: 0x00052BB7 File Offset: 0x00050DB7
		' (set) Token: 0x0600B21A RID: 45594 RVA: 0x00052BC1 File Offset: 0x00050DC1
		Friend Overridable Property Label5 As Label

		' Token: 0x170044CE RID: 17614
		' (get) Token: 0x0600B21B RID: 45595 RVA: 0x00052BCA File Offset: 0x00050DCA
		' (set) Token: 0x0600B21C RID: 45596 RVA: 0x0076FE54 File Offset: 0x0076E054
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

		' Token: 0x170044CF RID: 17615
		' (get) Token: 0x0600B21D RID: 45597 RVA: 0x00052BD4 File Offset: 0x00050DD4
		' (set) Token: 0x0600B21E RID: 45598 RVA: 0x00052BDE File Offset: 0x00050DDE
		Friend Overridable Property lblBalance As Label

		' Token: 0x170044D0 RID: 17616
		' (get) Token: 0x0600B21F RID: 45599 RVA: 0x00052BE7 File Offset: 0x00050DE7
		' (set) Token: 0x0600B220 RID: 45600 RVA: 0x0076FE98 File Offset: 0x0076E098
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

		' Token: 0x170044D1 RID: 17617
		' (get) Token: 0x0600B221 RID: 45601 RVA: 0x00052BF1 File Offset: 0x00050DF1
		' (set) Token: 0x0600B222 RID: 45602 RVA: 0x0076FEDC File Offset: 0x0076E0DC
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

		' Token: 0x0600B223 RID: 45603 RVA: 0x0076FF20 File Offset: 0x0076E120
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

		' Token: 0x0600B224 RID: 45604 RVA: 0x00052BFB File Offset: 0x00050DFB
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.txtSupplierName.Text = ""
			Me.txtSupplierID.Text = ""
		End Sub

		' Token: 0x0600B225 RID: 45605 RVA: 0x00052C38 File Offset: 0x00050E38
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600B226 RID: 45606 RVA: 0x00052C54 File Offset: 0x00050E54
		Private Sub frmSupplierLedger_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600B227 RID: 45607 RVA: 0x0076FFFC File Offset: 0x0076E1FC
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

		' Token: 0x0600B228 RID: 45608 RVA: 0x00770174 File Offset: 0x0076E374
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

		' Token: 0x0600B229 RID: 45609 RVA: 0x00770230 File Offset: 0x0076E430
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

		' Token: 0x0600B22A RID: 45610 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600B22B RID: 45611 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600B22C RID: 45612 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600B22D RID: 45613 RVA: 0x007702FC File Offset: 0x0076E4FC
		Public Sub GetSupplierInfo()
			Try
				Me.a = ""
				Me.b = ""
				Me.c = ""
				Me.d = ""
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(Address),RTRIM(City),RTRIM(ContactNo),RTRIM(State) FROM Supplier WHERE SupplierID=@d1"
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
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

		' Token: 0x0600B22E RID: 45614 RVA: 0x00052C65 File Offset: 0x00050E65
		Private Sub txtSupplierID_TextChanged(sender As Object, e As EventArgs)
			Me.GetSupplierBalance()
		End Sub

		' Token: 0x0600B22F RID: 45615 RVA: 0x00052C6F File Offset: 0x00050E6F
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x0600B230 RID: 45616 RVA: 0x00770480 File Offset: 0x0076E680
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = Strings.Len(Strings.Trim(Me.txtSupplierName.Text)) = 0
				If flag Then
					MessageBox.Show("Please retrieve Supplier Name", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Me.txtSupplierName.Focus()
				Else
					Me.GetSupplierInfo()
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim text As String = "select PartyID from SupplierLedgerBook where PartyID=@d1 and Date >=@d2 and Date < @d3"
					ModCommonClasses.cmd = New SqlCommand(text)
					ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
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
						ModCommonClasses.cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit, Remarks from SupplierLedgerBook where Date >=@d1 and Date < @d2 and PartyID=@d3 order by ID,Date,LedgerNo", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
						ModCommonClasses.cmd.Parameters.AddWithValue("@d3", Me.txtSupplierID.Text)
						ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
						ModCommonClasses.dtable = New DataTable()
						ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
						ModCommonClasses.con.Close()
						ModCommonClasses.ds = New DataSet()
						ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
						ModCommonClasses.ds.WriteXmlSchema("SupplierLedger.xml")
						Dim rptSupplierLedger As rptSupplierLedger1 = New rptSupplierLedger1()
						rptSupplierLedger.SetDataSource(ModCommonClasses.ds)
						rptSupplierLedger.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
						rptSupplierLedger.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
						rptSupplierLedger.SetParameterValue("p3", Me.txtSupplierID.Text)
						rptSupplierLedger.SetParameterValue("p4", Me.txtSupplierName.Text)
						rptSupplierLedger.SetParameterValue("p5", Me.a)
						rptSupplierLedger.SetParameterValue("p6", Me.b)
						rptSupplierLedger.SetParameterValue("p7", Me.c)
						rptSupplierLedger.SetParameterValue("p8", Me.d)
						rptSupplierLedger.SetParameterValue("p9", Me.lblBalance.Text)
						MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSupplierLedger
						MyProject.Forms.frmReport.ShowDialog()
						rptSupplierLedger.Close()
						rptSupplierLedger.Dispose()
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600B231 RID: 45617 RVA: 0x00052C79 File Offset: 0x00050E79
		Private Sub btnSelection_Click(sender As Object, e As EventArgs)
			MyProject.Forms.frmSupplierRecord.lblSet.Text = "Supplier Ledger"
			MyProject.Forms.frmSupplierRecord.Reset()
			MyProject.Forms.frmSupplierRecord.ShowDialog()
		End Sub

		' Token: 0x0600B232 RID: 45618 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSupplierLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600B233 RID: 45619 RVA: 0x007708BC File Offset: 0x0076EABC
		Public Sub GetSupplierBalance()
			Try
				Me.num1 = 0.0
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from SupplierLedgerBook where PartyID=@d1 group By PartyID"
				ModCommonClasses.cmd = New SqlCommand(text, ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.AddWithValue("@d1", Me.txtSupplierID.Text)
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
					Me.lblBalance.ForeColor = Color.Red
				Else
					Dim flag3 As Boolean = Conversion.Val(Conversions.ToDouble(Me.lblBalance.Text) < 0.0) <> 0.0
					If flag3 Then
						Me.str = "Dr"
						Me.lblBalance.ForeColor = Color.Blue
					End If
				End If
				Me.lblBalance.Text = Strings.Format(Math.Abs(Conversion.Val(Me.lblBalance.Text)), "0.00")
				Me.lblBalance.Text = (Me.lblBalance.Text + " " + Me.str).ToString()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x04004A83 RID: 19075
		Private a As String

		' Token: 0x04004A84 RID: 19076
		Private b As String

		' Token: 0x04004A85 RID: 19077
		Private c As String

		' Token: 0x04004A86 RID: 19078
		Private d As String

		' Token: 0x04004A87 RID: 19079
		Private num1 As Double

		' Token: 0x04004A88 RID: 19080
		Private str As String
	End Class
End Namespace
