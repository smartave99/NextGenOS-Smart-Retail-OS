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
	' Token: 0x020005B9 RID: 1465
	<DesignerGenerated()>
	Public Partial Class frmGeneralLedger
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x06011DAB RID: 73131 RVA: 0x0007A8BB File Offset: 0x00078ABB
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmSalesReport_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmGeneralLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17006EE8 RID: 28392
		' (get) Token: 0x06011DAE RID: 73134 RVA: 0x0007A8ED File Offset: 0x00078AED
		' (set) Token: 0x06011DAF RID: 73135 RVA: 0x0007A8F7 File Offset: 0x00078AF7
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17006EE9 RID: 28393
		' (get) Token: 0x06011DB0 RID: 73136 RVA: 0x0007A900 File Offset: 0x00078B00
		' (set) Token: 0x06011DB1 RID: 73137 RVA: 0x0007A90A File Offset: 0x00078B0A
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17006EEA RID: 28394
		' (get) Token: 0x06011DB2 RID: 73138 RVA: 0x0007A913 File Offset: 0x00078B13
		' (set) Token: 0x06011DB3 RID: 73139 RVA: 0x0007A91D File Offset: 0x00078B1D
		Friend Overridable Property Label1 As Label

		' Token: 0x17006EEB RID: 28395
		' (get) Token: 0x06011DB4 RID: 73140 RVA: 0x0007A926 File Offset: 0x00078B26
		' (set) Token: 0x06011DB5 RID: 73141 RVA: 0x00A4C268 File Offset: 0x00A4A468
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

		' Token: 0x17006EEC RID: 28396
		' (get) Token: 0x06011DB6 RID: 73142 RVA: 0x0007A930 File Offset: 0x00078B30
		' (set) Token: 0x06011DB7 RID: 73143 RVA: 0x0007A93A File Offset: 0x00078B3A
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17006EED RID: 28397
		' (get) Token: 0x06011DB8 RID: 73144 RVA: 0x0007A943 File Offset: 0x00078B43
		' (set) Token: 0x06011DB9 RID: 73145 RVA: 0x0007A94D File Offset: 0x00078B4D
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17006EEE RID: 28398
		' (get) Token: 0x06011DBA RID: 73146 RVA: 0x0007A956 File Offset: 0x00078B56
		' (set) Token: 0x06011DBB RID: 73147 RVA: 0x0007A960 File Offset: 0x00078B60
		Friend Overridable Property Label2 As Label

		' Token: 0x17006EEF RID: 28399
		' (get) Token: 0x06011DBC RID: 73148 RVA: 0x0007A969 File Offset: 0x00078B69
		' (set) Token: 0x06011DBD RID: 73149 RVA: 0x0007A973 File Offset: 0x00078B73
		Friend Overridable Property Label4 As Label

		' Token: 0x17006EF0 RID: 28400
		' (get) Token: 0x06011DBE RID: 73150 RVA: 0x0007A97C File Offset: 0x00078B7C
		' (set) Token: 0x06011DBF RID: 73151 RVA: 0x0007A986 File Offset: 0x00078B86
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17006EF1 RID: 28401
		' (get) Token: 0x06011DC0 RID: 73152 RVA: 0x0007A98F File Offset: 0x00078B8F
		' (set) Token: 0x06011DC1 RID: 73153 RVA: 0x00A4C2AC File Offset: 0x00A4A4AC
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

		' Token: 0x17006EF2 RID: 28402
		' (get) Token: 0x06011DC2 RID: 73154 RVA: 0x0007A999 File Offset: 0x00078B99
		' (set) Token: 0x06011DC3 RID: 73155 RVA: 0x00A4C2F0 File Offset: 0x00A4A4F0
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

		' Token: 0x06011DC4 RID: 73156 RVA: 0x00A4C334 File Offset: 0x00A4A534
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Try
				Me.Cursor = Cursors.WaitCursor
				Me.Timer1.Enabled = True
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select * from LedgerBook where Date >=@d2 and Date < @d3"
				ModCommonClasses.cmd = New SqlCommand(text)
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
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
					ModCommonClasses.cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date >=@d1 and Date < @d2 order by ID,Date,LedgerNo", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("GeneralLedger.xml")
					Dim rptGeneralLedger As rptGeneralLedger = New rptGeneralLedger()
					rptGeneralLedger.SetDataSource(ModCommonClasses.ds)
					rptGeneralLedger.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptGeneralLedger.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptGeneralLedger
					MyProject.Forms.frmReport.ShowDialog()
					rptGeneralLedger.Close()
					rptGeneralLedger.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x06011DC5 RID: 73157 RVA: 0x0007A9A3 File Offset: 0x00078BA3
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
		End Sub

		' Token: 0x06011DC6 RID: 73158 RVA: 0x00A4C658 File Offset: 0x00A4A858
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

		' Token: 0x06011DC7 RID: 73159 RVA: 0x0007A9AD File Offset: 0x00078BAD
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
		End Sub

		' Token: 0x06011DC8 RID: 73160 RVA: 0x0007A9C8 File Offset: 0x00078BC8
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x06011DC9 RID: 73161 RVA: 0x0007A9E4 File Offset: 0x00078BE4
		Private Sub frmSalesReport_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Convert_Language()
		End Sub

		' Token: 0x06011DCA RID: 73162 RVA: 0x00A4C734 File Offset: 0x00A4A934
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

		' Token: 0x06011DCB RID: 73163 RVA: 0x00A4C8AC File Offset: 0x00A4AAAC
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

		' Token: 0x06011DCC RID: 73164 RVA: 0x00A4C968 File Offset: 0x00A4AB68
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

		' Token: 0x06011DCD RID: 73165 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x06011DCE RID: 73166 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x06011DCF RID: 73167 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x06011DD0 RID: 73168 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmGeneralLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x04006B68 RID: 27496
		Private a As Decimal

		' Token: 0x04006B69 RID: 27497
		Private b As Decimal

		' Token: 0x04006B6A RID: 27498
		Private c As Decimal

		' Token: 0x04006B6B RID: 27499
		Private d As Decimal

		' Token: 0x04006B6C RID: 27500
		Private f As Decimal

		' Token: 0x04006B6D RID: 27501
		Private g As Decimal

		' Token: 0x04006B6E RID: 27502
		Private h As Decimal

		' Token: 0x04006B6F RID: 27503
		Private i As Decimal
	End Class
End Namespace
