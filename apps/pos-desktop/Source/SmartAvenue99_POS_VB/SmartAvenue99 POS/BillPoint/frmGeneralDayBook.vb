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
	' Token: 0x020005B6 RID: 1462
	<DesignerGenerated()>
	Public Partial Class frmGeneralDayBook
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011D71 RID: 73073 RVA: 0x0007A7A2 File Offset: 0x000789A2
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGeneralDayBook_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006ED1 RID: 28369
		' (get) Token: 0x06011D74 RID: 73076 RVA: 0x0007A7D4 File Offset: 0x000789D4
		' (set) Token: 0x06011D75 RID: 73077 RVA: 0x0007A7DE File Offset: 0x000789DE
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006ED2 RID: 28370
		' (get) Token: 0x06011D76 RID: 73078 RVA: 0x0007A7E7 File Offset: 0x000789E7
		' (set) Token: 0x06011D77 RID: 73079 RVA: 0x0007A7F1 File Offset: 0x000789F1
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006ED3 RID: 28371
		' (get) Token: 0x06011D78 RID: 73080 RVA: 0x0007A7FA File Offset: 0x000789FA
		' (set) Token: 0x06011D79 RID: 73081 RVA: 0x0007A804 File Offset: 0x00078A04
		Friend Overridable Property Label1 As Label

		' Token: 0x17006ED4 RID: 28372
		' (get) Token: 0x06011D7A RID: 73082 RVA: 0x0007A80D File Offset: 0x00078A0D
		' (set) Token: 0x06011D7B RID: 73083 RVA: 0x0007A817 File Offset: 0x00078A17
		Friend Overridable Property GroupBox3 As GroupBox

		' Token: 0x17006ED5 RID: 28373
		' (get) Token: 0x06011D7C RID: 73084 RVA: 0x0007A820 File Offset: 0x00078A20
		' (set) Token: 0x06011D7D RID: 73085 RVA: 0x00A4B334 File Offset: 0x00A49534
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

		' Token: 0x17006ED6 RID: 28374
		' (get) Token: 0x06011D7E RID: 73086 RVA: 0x0007A82A File Offset: 0x00078A2A
		' (set) Token: 0x06011D7F RID: 73087 RVA: 0x0007A834 File Offset: 0x00078A34
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006ED7 RID: 28375
		' (get) Token: 0x06011D80 RID: 73088 RVA: 0x0007A83D File Offset: 0x00078A3D
		' (set) Token: 0x06011D81 RID: 73089 RVA: 0x0007A847 File Offset: 0x00078A47
		Friend Overridable Property Label4 As Label

		' Token: 0x17006ED8 RID: 28376
		' (get) Token: 0x06011D82 RID: 73090 RVA: 0x0007A850 File Offset: 0x00078A50
		' (set) Token: 0x06011D83 RID: 73091 RVA: 0x0007A85A File Offset: 0x00078A5A
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006ED9 RID: 28377
		' (get) Token: 0x06011D84 RID: 73092 RVA: 0x0007A863 File Offset: 0x00078A63
		' (set) Token: 0x06011D85 RID: 73093 RVA: 0x00A4B378 File Offset: 0x00A49578
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

		' Token: 0x17006EDA RID: 28378
		' (get) Token: 0x06011D86 RID: 73094 RVA: 0x0007A86D File Offset: 0x00078A6D
		' (set) Token: 0x06011D87 RID: 73095 RVA: 0x00A4B3BC File Offset: 0x00A495BC
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

		' Token: 0x06011D88 RID: 73096 RVA: 0x0007A877 File Offset: 0x00078A77
		Public Sub Reset()
			Me.dtpDateFrom.Value = DateAndTime.Today
		End Sub

		' Token: 0x06011D89 RID: 73097 RVA: 0x0007A88B File Offset: 0x00078A8B
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011D8A RID: 73098 RVA: 0x0007A8A7 File Offset: 0x00078AA7
		Private Sub frmSalesReport_Load(sender As Object, e As EventArgs)
			Me.Convert_Language()
		End Sub

		' Token: 0x06011D8B RID: 73099 RVA: 0x00A4B400 File Offset: 0x00A49600
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

		' Token: 0x06011D8C RID: 73100 RVA: 0x00A4B578 File Offset: 0x00A49778
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

		' Token: 0x06011D8D RID: 73101 RVA: 0x00A4B634 File Offset: 0x00A49834
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

		' Token: 0x06011D8E RID: 73102 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011D8F RID: 73103 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011D90 RID: 73104 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011D91 RID: 73105 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGeneralDayBook_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x06011D92 RID: 73106 RVA: 0x0007A8B1 File Offset: 0x00078AB1
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011D93 RID: 73107 RVA: 0x00A4B700 File Offset: 0x00A49900
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date between @d1 and @d2 order by ID,LedgerNo", ModCommonClasses.con)
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date].AddHours(23.0).AddMinutes(59.0).AddSeconds(59.0)
				ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
				ModCommonClasses.dtable = New DataTable()
				ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
				ModCommonClasses.con.Close()
				ModCommonClasses.ds = New DataSet()
				ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
				ModCommonClasses.ds.WriteXmlSchema("GeneralDayBook.xml")
				Dim rptGeneralDayBook As rptGeneralDayBook = New rptGeneralDayBook()
				rptGeneralDayBook.SetDataSource(ModCommonClasses.ds)
				rptGeneralDayBook.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
				MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptGeneralDayBook
				MyProject.Forms.frmReport.ShowDialog()
				rptGeneralDayBook.Close()
				rptGeneralDayBook.Dispose()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
