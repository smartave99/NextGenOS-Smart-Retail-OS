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
	' Token: 0x020004C2 RID: 1218
	<DesignerGenerated()>
	Public Partial Class frmDebtorsReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F45F RID: 62559 RVA: 0x0006AF6C File Offset: 0x0006916C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmStockInAndOutReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmDebtorsReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005D86 RID: 23942
		' (get) Token: 0x0600F462 RID: 62562 RVA: 0x0006AF9E File Offset: 0x0006919E
		' (set) Token: 0x0600F463 RID: 62563 RVA: 0x0006AFA8 File Offset: 0x000691A8
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005D87 RID: 23943
		' (get) Token: 0x0600F464 RID: 62564 RVA: 0x0006AFB1 File Offset: 0x000691B1
		' (set) Token: 0x0600F465 RID: 62565 RVA: 0x0006AFBB File Offset: 0x000691BB
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17005D88 RID: 23944
		' (get) Token: 0x0600F466 RID: 62566 RVA: 0x0006AFC4 File Offset: 0x000691C4
		' (set) Token: 0x0600F467 RID: 62567 RVA: 0x0006AFCE File Offset: 0x000691CE
		Friend Overridable Property Label1 As Label

		' Token: 0x17005D89 RID: 23945
		' (get) Token: 0x0600F468 RID: 62568 RVA: 0x0006AFD7 File Offset: 0x000691D7
		' (set) Token: 0x0600F469 RID: 62569 RVA: 0x00928C6C File Offset: 0x00926E6C
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

		' Token: 0x17005D8A RID: 23946
		' (get) Token: 0x0600F46A RID: 62570 RVA: 0x0006AFE1 File Offset: 0x000691E1
		' (set) Token: 0x0600F46B RID: 62571 RVA: 0x0006AFEB File Offset: 0x000691EB
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17005D8B RID: 23947
		' (get) Token: 0x0600F46C RID: 62572 RVA: 0x0006AFF4 File Offset: 0x000691F4
		' (set) Token: 0x0600F46D RID: 62573 RVA: 0x0006AFFE File Offset: 0x000691FE
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005D8C RID: 23948
		' (get) Token: 0x0600F46E RID: 62574 RVA: 0x0006B007 File Offset: 0x00069207
		' (set) Token: 0x0600F46F RID: 62575 RVA: 0x0006B011 File Offset: 0x00069211
		Friend Overridable Property Label4 As Label

		' Token: 0x17005D8D RID: 23949
		' (get) Token: 0x0600F470 RID: 62576 RVA: 0x0006B01A File Offset: 0x0006921A
		' (set) Token: 0x0600F471 RID: 62577 RVA: 0x0006B024 File Offset: 0x00069224
		Friend Overridable Property Label3 As Label

		' Token: 0x17005D8E RID: 23950
		' (get) Token: 0x0600F472 RID: 62578 RVA: 0x0006B02D File Offset: 0x0006922D
		' (set) Token: 0x0600F473 RID: 62579 RVA: 0x0006B037 File Offset: 0x00069237
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005D8F RID: 23951
		' (get) Token: 0x0600F474 RID: 62580 RVA: 0x0006B040 File Offset: 0x00069240
		' (set) Token: 0x0600F475 RID: 62581 RVA: 0x0006B04A File Offset: 0x0006924A
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005D90 RID: 23952
		' (get) Token: 0x0600F476 RID: 62582 RVA: 0x0006B053 File Offset: 0x00069253
		' (set) Token: 0x0600F477 RID: 62583 RVA: 0x00928CB0 File Offset: 0x00926EB0
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

		' Token: 0x17005D91 RID: 23953
		' (get) Token: 0x0600F478 RID: 62584 RVA: 0x0006B05D File Offset: 0x0006925D
		' (set) Token: 0x0600F479 RID: 62585 RVA: 0x00928CF4 File Offset: 0x00926EF4
		Private _GelButton7 As GelButton
		Friend Overridable Property GelButton7 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton7
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton7_Click
				Dim gelButton As GelButton = Me._GelButton7
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton7 = value
				gelButton = Me._GelButton7
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D92 RID: 23954
		' (get) Token: 0x0600F47A RID: 62586 RVA: 0x0006B067 File Offset: 0x00069267
		' (set) Token: 0x0600F47B RID: 62587 RVA: 0x00928D38 File Offset: 0x00926F38
		Private _GelButton6 As GelButton
		Friend Overridable Property GelButton6 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton6
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton6_Click
				Dim gelButton As GelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton6 = value
				gelButton = Me._GelButton6
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D93 RID: 23955
		' (get) Token: 0x0600F47C RID: 62588 RVA: 0x0006B071 File Offset: 0x00069271
		' (set) Token: 0x0600F47D RID: 62589 RVA: 0x00928D7C File Offset: 0x00926F7C
		Private _GelButton5 As GelButton
		Friend Overridable Property GelButton5 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton5
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton5_Click
				Dim gelButton As GelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton5 = value
				gelButton = Me._GelButton5
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005D94 RID: 23956
		' (get) Token: 0x0600F47E RID: 62590 RVA: 0x0006B07B File Offset: 0x0006927B
		' (set) Token: 0x0600F47F RID: 62591 RVA: 0x00928DC0 File Offset: 0x00926FC0
		Private _GelButton4 As GelButton
		Friend Overridable Property GelButton4 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton4
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton4_Click
				Dim gelButton As GelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton4 = value
				gelButton = Me._GelButton4
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600F480 RID: 62592 RVA: 0x0006B085 File Offset: 0x00069285
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600F481 RID: 62593 RVA: 0x00928E04 File Offset: 0x00927004
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

		' Token: 0x0600F482 RID: 62594 RVA: 0x0006B0A1 File Offset: 0x000692A1
		Private Sub frmStockInAndOutReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F483 RID: 62595 RVA: 0x00928EE0 File Offset: 0x009270E0
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

		' Token: 0x0600F484 RID: 62596 RVA: 0x00929058 File Offset: 0x00927258
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

		' Token: 0x0600F485 RID: 62597 RVA: 0x00929114 File Offset: 0x00927314
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

		' Token: 0x0600F486 RID: 62598 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F487 RID: 62599 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F488 RID: 62600 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F489 RID: 62601 RVA: 0x0006B0B2 File Offset: 0x000692B2
		Private Sub Button3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
		End Sub

		' Token: 0x0600F48A RID: 62602 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmDebtorsReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F48B RID: 62603 RVA: 0x0000F1EA File Offset: 0x0000D3EA
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			FileSystem.Reset()
		End Sub

		' Token: 0x0600F48C RID: 62604 RVA: 0x009291E0 File Offset: 0x009273E0
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select CustNameid as [CustomerID], Sum(Credit) as [City], Sum(Debit) as [ContactNo], Sum(Credit)-Sum(Debit) as [Balance] from CustomerLedgerBook where Date between @d1 and @d2 Group By CustNameid having (sum(Credit)- sum(Debit) < 0 ) order by CustNameid", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("Debtors.xml")
				Dim rptDebtors As rptDebtors = New rptDebtors()
				rptDebtors.SetDataSource(ModCommonClasses.ds)
				rptDebtors.SetParameterValue("p1", Me.dtpDateFrom.Text)
				rptDebtors.SetParameterValue("p2", Me.dtpDateTo.Text)
				rptDebtors.SetParameterValue("p3", "Receivable From Customers")
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptDebtors
				MyProject.Forms.frmReport.ShowDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F48D RID: 62605 RVA: 0x009293D4 File Offset: 0x009275D4
		Private Sub GelButton5_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select CustNameid as [CustomerID], Sum(Credit) as [City], Sum(Debit) as [ContactNo], Sum(Credit)-Sum(Debit) as [Balance] from CustomerLedgerBook where Date between @d1 and @d2 Group By CustNameid having (sum(Credit)- sum(Debit) > 0 ) order by CustNameid", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("Debtors.xml")
				Dim rptDebtors As rptDebtors = New rptDebtors()
				rptDebtors.SetDataSource(ModCommonClasses.ds)
				rptDebtors.SetParameterValue("p1", Me.dtpDateFrom.Text)
				rptDebtors.SetParameterValue("p2", Me.dtpDateTo.Text)
				rptDebtors.SetParameterValue("p3", "Payable To Customers")
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptDebtors
				MyProject.Forms.frmReport.ShowDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F48E RID: 62606 RVA: 0x009295C8 File Offset: 0x009277C8
		Private Sub GelButton6_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select SuplNameid as [CustomerID], Sum(Credit) as [City], Sum(Debit) as [ContactNo], Sum(Debit)-Sum(Credit) as [Balance] from SupplierLedgerBook where Date between @d1 and @d2 Group By SuplNameid having (sum(Debit)- sum(Credit) < 0 ) order by SuplNameid", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("rptOutSupl.xml")
				Dim rptOutSupl As rptOutSupl = New rptOutSupl()
				rptOutSupl.SetDataSource(ModCommonClasses.ds)
				rptOutSupl.SetParameterValue("p1", Me.dtpDateFrom.Text)
				rptOutSupl.SetParameterValue("p2", Me.dtpDateTo.Text)
				rptOutSupl.SetParameterValue("p3", "Payable To Suppliers")
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptOutSupl
				MyProject.Forms.frmReport.ShowDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F48F RID: 62607 RVA: 0x009297BC File Offset: 0x009279BC
		Private Sub GelButton7_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select SuplNameid as [CustomerID], Sum(Credit) as [City], Sum(Debit) as [ContactNo], Sum(Debit)-Sum(Credit) as [Balance] from SupplierLedgerBook where Date between @d1 and @d2 Group By SuplNameid having (sum(Debit)- sum(Credit) > 0 ) order by SuplNameid", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("rptOutSupl.xml")
				Dim rptOutSupl As rptOutSupl = New rptOutSupl()
				rptOutSupl.SetDataSource(ModCommonClasses.ds)
				rptOutSupl.SetParameterValue("p1", Me.dtpDateFrom.Text)
				rptOutSupl.SetParameterValue("p2", Me.dtpDateTo.Text)
				rptOutSupl.SetParameterValue("p3", "Receivable From Suppliers")
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptOutSupl
				MyProject.Forms.frmReport.ShowDialog()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
