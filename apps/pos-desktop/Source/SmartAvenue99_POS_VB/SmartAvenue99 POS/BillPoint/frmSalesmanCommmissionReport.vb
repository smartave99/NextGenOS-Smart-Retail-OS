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
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020005A7 RID: 1447
	<DesignerGenerated()>
	Public Partial Class frmSalesmanCommmissionReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011AAC RID: 72364 RVA: 0x000796FE File Offset: 0x000778FE
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesmanCommmissionReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmSalesmanCommmissionReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006DC7 RID: 28103
		' (get) Token: 0x06011AAF RID: 72367 RVA: 0x00079730 File Offset: 0x00077930
		' (set) Token: 0x06011AB0 RID: 72368 RVA: 0x0007973A File Offset: 0x0007793A
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006DC8 RID: 28104
		' (get) Token: 0x06011AB1 RID: 72369 RVA: 0x00079743 File Offset: 0x00077943
		' (set) Token: 0x06011AB2 RID: 72370 RVA: 0x0007974D File Offset: 0x0007794D
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006DC9 RID: 28105
		' (get) Token: 0x06011AB3 RID: 72371 RVA: 0x00079756 File Offset: 0x00077956
		' (set) Token: 0x06011AB4 RID: 72372 RVA: 0x00079760 File Offset: 0x00077960
		Friend Overridable Property Label1 As Label

		' Token: 0x17006DCA RID: 28106
		' (get) Token: 0x06011AB5 RID: 72373 RVA: 0x00079769 File Offset: 0x00077969
		' (set) Token: 0x06011AB6 RID: 72374 RVA: 0x00A363A8 File Offset: 0x00A345A8
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

		' Token: 0x17006DCB RID: 28107
		' (get) Token: 0x06011AB7 RID: 72375 RVA: 0x00079773 File Offset: 0x00077973
		' (set) Token: 0x06011AB8 RID: 72376 RVA: 0x0007977D File Offset: 0x0007797D
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17006DCC RID: 28108
		' (get) Token: 0x06011AB9 RID: 72377 RVA: 0x00079786 File Offset: 0x00077986
		' (set) Token: 0x06011ABA RID: 72378 RVA: 0x00A363EC File Offset: 0x00A345EC
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

		' Token: 0x17006DCD RID: 28109
		' (get) Token: 0x06011ABB RID: 72379 RVA: 0x00079790 File Offset: 0x00077990
		' (set) Token: 0x06011ABC RID: 72380 RVA: 0x0007979A File Offset: 0x0007799A
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006DCE RID: 28110
		' (get) Token: 0x06011ABD RID: 72381 RVA: 0x000797A3 File Offset: 0x000779A3
		' (set) Token: 0x06011ABE RID: 72382 RVA: 0x000797AD File Offset: 0x000779AD
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006DCF RID: 28111
		' (get) Token: 0x06011ABF RID: 72383 RVA: 0x000797B6 File Offset: 0x000779B6
		' (set) Token: 0x06011AC0 RID: 72384 RVA: 0x000797C0 File Offset: 0x000779C0
		Friend Overridable Property Label2 As Label

		' Token: 0x17006DD0 RID: 28112
		' (get) Token: 0x06011AC1 RID: 72385 RVA: 0x000797C9 File Offset: 0x000779C9
		' (set) Token: 0x06011AC2 RID: 72386 RVA: 0x000797D3 File Offset: 0x000779D3
		Friend Overridable Property Label4 As Label

		' Token: 0x17006DD1 RID: 28113
		' (get) Token: 0x06011AC3 RID: 72387 RVA: 0x000797DC File Offset: 0x000779DC
		' (set) Token: 0x06011AC4 RID: 72388 RVA: 0x000797E6 File Offset: 0x000779E6
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006DD2 RID: 28114
		' (get) Token: 0x06011AC5 RID: 72389 RVA: 0x000797EF File Offset: 0x000779EF
		' (set) Token: 0x06011AC6 RID: 72390 RVA: 0x00A36430 File Offset: 0x00A34630
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

		' Token: 0x06011AC7 RID: 72391 RVA: 0x00A36474 File Offset: 0x00A34674
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

		' Token: 0x06011AC8 RID: 72392 RVA: 0x000797F9 File Offset: 0x000779F9
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
		End Sub

		' Token: 0x06011AC9 RID: 72393 RVA: 0x00079814 File Offset: 0x00077A14
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011ACA RID: 72394 RVA: 0x0007981E File Offset: 0x00077A1E
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011ACB RID: 72395 RVA: 0x00A36550 File Offset: 0x00A34750
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select * FROM InvoiceInfo INNER JOIN SalesMan ON InvoiceInfo.SalesmanID = SalesMan.SM_ID INNER JOIN Salesman_Commission ON InvoiceInfo.Inv_ID = Salesman_Commission.InvoiceID where InvoiceDate between @d2 and @d3"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.cmd.Connection = ModCommonClasses.con
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = Not ModCommonClasses.rdr.Read()
				If flag Then
					MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
					Dim flag2 As Boolean = ModCommonClasses.rdr IsNot Nothing
					If flag2 Then
						ModCommonClasses.rdr.Close()
					End If
				Else
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("Select Salesman_ID,Name,City,ContactNo,Sum(Commission) FROM InvoiceInfo INNER JOIN SalesMan ON InvoiceInfo.SalesmanID = SalesMan.SM_ID INNER JOIN Salesman_Commission ON InvoiceInfo.Inv_ID = Salesman_Commission.InvoiceID where InvoiceDate between @d2 and @d3 group by Salesman_ID,Name,City,ContactNo order by Name", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("SalesmanCommissionReport.xml")
					Dim rptSalesmanCommission As rptSalesmanCommission = New rptSalesmanCommission()
					rptSalesmanCommission.SetDataSource(ModCommonClasses.ds)
					rptSalesmanCommission.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptSalesmanCommission.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptSalesmanCommission
					MyProject.Forms.frmReport.ShowDialog()
					rptSalesmanCommission.Close()
					rptSalesmanCommission.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011ACC RID: 72396 RVA: 0x0007983A File Offset: 0x00077A3A
		Private Sub frmSalesmanCommmissionReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011ACD RID: 72397 RVA: 0x00A36854 File Offset: 0x00A34A54
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

		' Token: 0x06011ACE RID: 72398 RVA: 0x00A369CC File Offset: 0x00A34BCC
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

		' Token: 0x06011ACF RID: 72399 RVA: 0x00A36A88 File Offset: 0x00A34C88
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

		' Token: 0x06011AD0 RID: 72400 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011AD1 RID: 72401 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011AD2 RID: 72402 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011AD3 RID: 72403 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmSalesmanCommmissionReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub
	End Class
End Namespace
