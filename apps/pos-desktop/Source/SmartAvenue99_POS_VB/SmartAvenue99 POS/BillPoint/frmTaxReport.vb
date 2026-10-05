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
	' Token: 0x020005A6 RID: 1446
	<DesignerGenerated()>
	Public Partial Class frmTaxReport
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011A79 RID: 72313 RVA: 0x0007954A File Offset: 0x0007774A
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmTaxReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmTaxReport_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006DB6 RID: 28086
		' (get) Token: 0x06011A7C RID: 72316 RVA: 0x0007957C File Offset: 0x0007777C
		' (set) Token: 0x06011A7D RID: 72317 RVA: 0x00079586 File Offset: 0x00077786
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006DB7 RID: 28087
		' (get) Token: 0x06011A7E RID: 72318 RVA: 0x0007958F File Offset: 0x0007778F
		' (set) Token: 0x06011A7F RID: 72319 RVA: 0x00079599 File Offset: 0x00077799
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006DB8 RID: 28088
		' (get) Token: 0x06011A80 RID: 72320 RVA: 0x000795A2 File Offset: 0x000777A2
		' (set) Token: 0x06011A81 RID: 72321 RVA: 0x000795AC File Offset: 0x000777AC
		Friend Overridable Property Label1 As Label

		' Token: 0x17006DB9 RID: 28089
		' (get) Token: 0x06011A82 RID: 72322 RVA: 0x000795B5 File Offset: 0x000777B5
		' (set) Token: 0x06011A83 RID: 72323 RVA: 0x00A34F98 File Offset: 0x00A33198
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

		' Token: 0x17006DBA RID: 28090
		' (get) Token: 0x06011A84 RID: 72324 RVA: 0x000795BF File Offset: 0x000777BF
		' (set) Token: 0x06011A85 RID: 72325 RVA: 0x000795C9 File Offset: 0x000777C9
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006DBB RID: 28091
		' (get) Token: 0x06011A86 RID: 72326 RVA: 0x000795D2 File Offset: 0x000777D2
		' (set) Token: 0x06011A87 RID: 72327 RVA: 0x000795DC File Offset: 0x000777DC
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006DBC RID: 28092
		' (get) Token: 0x06011A88 RID: 72328 RVA: 0x000795E5 File Offset: 0x000777E5
		' (set) Token: 0x06011A89 RID: 72329 RVA: 0x000795EF File Offset: 0x000777EF
		Friend Overridable Property Label2 As Label

		' Token: 0x17006DBD RID: 28093
		' (get) Token: 0x06011A8A RID: 72330 RVA: 0x000795F8 File Offset: 0x000777F8
		' (set) Token: 0x06011A8B RID: 72331 RVA: 0x00079602 File Offset: 0x00077802
		Friend Overridable Property Label4 As Label

		' Token: 0x17006DBE RID: 28094
		' (get) Token: 0x06011A8C RID: 72332 RVA: 0x0007960B File Offset: 0x0007780B
		' (set) Token: 0x06011A8D RID: 72333 RVA: 0x00079615 File Offset: 0x00077815
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006DBF RID: 28095
		' (get) Token: 0x06011A8E RID: 72334 RVA: 0x0007961E File Offset: 0x0007781E
		' (set) Token: 0x06011A8F RID: 72335 RVA: 0x00079628 File Offset: 0x00077828
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17006DC0 RID: 28096
		' (get) Token: 0x06011A90 RID: 72336 RVA: 0x00079631 File Offset: 0x00077831
		' (set) Token: 0x06011A91 RID: 72337 RVA: 0x0007963B File Offset: 0x0007783B
		Friend Overridable Property DateTimePicker1 As DateTimePicker

		' Token: 0x17006DC1 RID: 28097
		' (get) Token: 0x06011A92 RID: 72338 RVA: 0x00079644 File Offset: 0x00077844
		' (set) Token: 0x06011A93 RID: 72339 RVA: 0x0007964E File Offset: 0x0007784E
		Friend Overridable Property Label3 As Label

		' Token: 0x17006DC2 RID: 28098
		' (get) Token: 0x06011A94 RID: 72340 RVA: 0x00079657 File Offset: 0x00077857
		' (set) Token: 0x06011A95 RID: 72341 RVA: 0x00079661 File Offset: 0x00077861
		Friend Overridable Property Label5 As Label

		' Token: 0x17006DC3 RID: 28099
		' (get) Token: 0x06011A96 RID: 72342 RVA: 0x0007966A File Offset: 0x0007786A
		' (set) Token: 0x06011A97 RID: 72343 RVA: 0x00079674 File Offset: 0x00077874
		Friend Overridable Property DateTimePicker2 As DateTimePicker

		' Token: 0x17006DC4 RID: 28100
		' (get) Token: 0x06011A98 RID: 72344 RVA: 0x0007967D File Offset: 0x0007787D
		' (set) Token: 0x06011A99 RID: 72345 RVA: 0x00A34FDC File Offset: 0x00A331DC
		Private _btnDelete As GelButton
		Friend Overridable Property btnDelete As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnDelete
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnDelete_Click
				Dim gelButton As GelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnDelete = value
				gelButton = Me._btnDelete
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DC5 RID: 28101
		' (get) Token: 0x06011A9A RID: 72346 RVA: 0x00079687 File Offset: 0x00077887
		' (set) Token: 0x06011A9B RID: 72347 RVA: 0x00A35020 File Offset: 0x00A33220
		Private _GelButton1 As GelButton
		Friend Overridable Property GelButton1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._GelButton1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._GelButton1 = value
				gelButton = Me._GelButton1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17006DC6 RID: 28102
		' (get) Token: 0x06011A9C RID: 72348 RVA: 0x00079691 File Offset: 0x00077891
		' (set) Token: 0x06011A9D RID: 72349 RVA: 0x00A35064 File Offset: 0x00A33264
		Private _btnSave As GelButton
		Friend Overridable Property btnSave As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnSave
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnSave = value
				gelButton = Me._btnSave
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06011A9E RID: 72350 RVA: 0x00A350A8 File Offset: 0x00A332A8
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
					Me.DateTimePicker2.Text = Conversions.ToString(ModCommonClasses.rdr.GetValue(0))
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

		' Token: 0x06011A9F RID: 72351 RVA: 0x0007969B File Offset: 0x0007789B
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.DateTimePicker1.Value = DateAndTime.Today
		End Sub

		' Token: 0x06011AA0 RID: 72352 RVA: 0x000796C7 File Offset: 0x000778C7
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011AA1 RID: 72353 RVA: 0x000796E3 File Offset: 0x000778E3
		Private Sub frmTaxReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011AA2 RID: 72354 RVA: 0x00A351A0 File Offset: 0x00A333A0
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

		' Token: 0x06011AA3 RID: 72355 RVA: 0x00A35318 File Offset: 0x00A33518
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

		' Token: 0x06011AA4 RID: 72356 RVA: 0x00A353D4 File Offset: 0x00A335D4
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

		' Token: 0x06011AA5 RID: 72357 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011AA6 RID: 72358 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011AA7 RID: 72359 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011AA8 RID: 72360 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmTaxReport_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011AA9 RID: 72361 RVA: 0x000796F4 File Offset: 0x000778F4
		Private Sub btnDelete_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011AAA RID: 72362 RVA: 0x00A354A0 File Offset: 0x00A336A0
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select * FROM InvoiceInfo where (CGST+SGST+IGST+CESS) > 0"
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
					ModCommonClasses.cmd = New SqlCommand("Select distinct InvoiceNo,InvoiceDate,Customer.CustomerID,Name,CGST,SGST,IGST,CESS FROM InvoiceInfo INNER JOIN Customer ON InvoiceInfo.Customer_ID = Customer.ID where InvoiceDate between @d2 and @d3 and (CGST+SGST+IGST+CESS) > 0 order by InvoiceDate", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("GST.xml")
					Dim rptGSTReport As rptGSTReport = New rptGSTReport()
					rptGSTReport.SetDataSource(ModCommonClasses.ds)
					rptGSTReport.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptGSTReport.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptGSTReport
					MyProject.Forms.frmReport.ShowDialog()
					rptGSTReport.Close()
					rptGSTReport.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011AAB RID: 72363 RVA: 0x00A357A4 File Offset: 0x00A339A4
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "Select InvoiceNo,InvoiceDate,Customer.CustomerID,Name,(ServiceTax) FROM InvoiceInfo1 INNER JOIN Service ON InvoiceInfo1.ServiceID = Service.S_ID INNER JOIN Customer ON Service.CustomerID = Customer.ID where InvoiceDate between @d2 and @d3 and ServiceTax > 0 order by Name"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
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
					ModCommonClasses.cmd = New SqlCommand("Select InvoiceNo,InvoiceDate,Customer.CustomerID,Name,(ServiceTax) FROM InvoiceInfo1 INNER JOIN Service ON InvoiceInfo1.ServiceID = Service.S_ID INNER JOIN Customer ON Service.CustomerID = Customer.ID where InvoiceDate between @d2 and @d3 and ServiceTax > 0 order by Name", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker2.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.DateTimePicker1.Value.[Date]
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("ServiceTaxReport1.xml")
					Dim rptServiceTaxReport As rptServiceTaxReport = New rptServiceTaxReport()
					rptServiceTaxReport.SetDataSource(ModCommonClasses.ds)
					rptServiceTaxReport.SetParameterValue("p1", Me.DateTimePicker2.Value.[Date])
					rptServiceTaxReport.SetParameterValue("p2", Me.DateTimePicker1.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptServiceTaxReport
					MyProject.Forms.frmReport.ShowDialog()
					rptServiceTaxReport.Close()
					rptServiceTaxReport.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
