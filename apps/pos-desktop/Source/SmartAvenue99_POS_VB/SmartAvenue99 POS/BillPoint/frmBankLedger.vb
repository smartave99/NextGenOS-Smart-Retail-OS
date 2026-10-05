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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x020004AC RID: 1196
	<DesignerGenerated()>
	Public Partial Class frmBankLedger
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600EFA1 RID: 61345 RVA: 0x00068E2C File Offset: 0x0006702C
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmBankLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmBankLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005BE4 RID: 23524
		' (get) Token: 0x0600EFA4 RID: 61348 RVA: 0x00068E5E File Offset: 0x0006705E
		' (set) Token: 0x0600EFA5 RID: 61349 RVA: 0x00068E68 File Offset: 0x00067068
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005BE5 RID: 23525
		' (get) Token: 0x0600EFA6 RID: 61350 RVA: 0x00068E71 File Offset: 0x00067071
		' (set) Token: 0x0600EFA7 RID: 61351 RVA: 0x00068E7B File Offset: 0x0006707B
		Friend Overridable Property Label3 As Label

		' Token: 0x17005BE6 RID: 23526
		' (get) Token: 0x0600EFA8 RID: 61352 RVA: 0x00068E84 File Offset: 0x00067084
		' (set) Token: 0x0600EFA9 RID: 61353 RVA: 0x00068E8E File Offset: 0x0006708E
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005BE7 RID: 23527
		' (get) Token: 0x0600EFAA RID: 61354 RVA: 0x00068E97 File Offset: 0x00067097
		' (set) Token: 0x0600EFAB RID: 61355 RVA: 0x00068EA1 File Offset: 0x000670A1
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005BE8 RID: 23528
		' (get) Token: 0x0600EFAC RID: 61356 RVA: 0x00068EAA File Offset: 0x000670AA
		' (set) Token: 0x0600EFAD RID: 61357 RVA: 0x00068EB4 File Offset: 0x000670B4
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005BE9 RID: 23529
		' (get) Token: 0x0600EFAE RID: 61358 RVA: 0x00068EBD File Offset: 0x000670BD
		' (set) Token: 0x0600EFAF RID: 61359 RVA: 0x00068EC7 File Offset: 0x000670C7
		Friend Overridable Property Label4 As Label

		' Token: 0x17005BEA RID: 23530
		' (get) Token: 0x0600EFB0 RID: 61360 RVA: 0x00068ED0 File Offset: 0x000670D0
		' (set) Token: 0x0600EFB1 RID: 61361 RVA: 0x00068EDA File Offset: 0x000670DA
		Friend Overridable Property Label2 As Label

		' Token: 0x17005BEB RID: 23531
		' (get) Token: 0x0600EFB2 RID: 61362 RVA: 0x00068EE3 File Offset: 0x000670E3
		' (set) Token: 0x0600EFB3 RID: 61363 RVA: 0x00068EED File Offset: 0x000670ED
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005BEC RID: 23532
		' (get) Token: 0x0600EFB4 RID: 61364 RVA: 0x00068EF6 File Offset: 0x000670F6
		' (set) Token: 0x0600EFB5 RID: 61365 RVA: 0x0090141C File Offset: 0x008FF61C
		Private _dgw As DataGridView
		Friend Overridable Property dgw As DataGridView
			<CompilerGenerated()>
			Get
				Return Me._dgw
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As DataGridView)
				Dim dataGridViewRowPostPaintEventHandler As DataGridViewRowPostPaintEventHandler = AddressOf Me.dgw_RowPostPaint
				Dim dataGridView As DataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					RemoveHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
				Me._dgw = value
				dataGridView = Me._dgw
				If dataGridView IsNot Nothing Then
					AddHandler dataGridView.RowPostPaint, dataGridViewRowPostPaintEventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BED RID: 23533
		' (get) Token: 0x0600EFB6 RID: 61366 RVA: 0x00068F00 File Offset: 0x00067100
		' (set) Token: 0x0600EFB7 RID: 61367 RVA: 0x00068F0A File Offset: 0x0006710A
		Friend Overridable Property Label1 As Label

		' Token: 0x17005BEE RID: 23534
		' (get) Token: 0x0600EFB8 RID: 61368 RVA: 0x00068F13 File Offset: 0x00067113
		' (set) Token: 0x0600EFB9 RID: 61369 RVA: 0x00901460 File Offset: 0x008FF660
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

		' Token: 0x17005BEF RID: 23535
		' (get) Token: 0x0600EFBA RID: 61370 RVA: 0x00068F1D File Offset: 0x0006711D
		' (set) Token: 0x0600EFBB RID: 61371 RVA: 0x00068F27 File Offset: 0x00067127
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005BF0 RID: 23536
		' (get) Token: 0x0600EFBC RID: 61372 RVA: 0x00068F30 File Offset: 0x00067130
		' (set) Token: 0x0600EFBD RID: 61373 RVA: 0x00068F3A File Offset: 0x0006713A
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005BF1 RID: 23537
		' (get) Token: 0x0600EFBE RID: 61374 RVA: 0x00068F43 File Offset: 0x00067143
		' (set) Token: 0x0600EFBF RID: 61375 RVA: 0x00068F4D File Offset: 0x0006714D
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005BF2 RID: 23538
		' (get) Token: 0x0600EFC0 RID: 61376 RVA: 0x00068F56 File Offset: 0x00067156
		' (set) Token: 0x0600EFC1 RID: 61377 RVA: 0x00068F60 File Offset: 0x00067160
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005BF3 RID: 23539
		' (get) Token: 0x0600EFC2 RID: 61378 RVA: 0x00068F69 File Offset: 0x00067169
		' (set) Token: 0x0600EFC3 RID: 61379 RVA: 0x00068F73 File Offset: 0x00067173
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005BF4 RID: 23540
		' (get) Token: 0x0600EFC4 RID: 61380 RVA: 0x00068F7C File Offset: 0x0006717C
		' (set) Token: 0x0600EFC5 RID: 61381 RVA: 0x00068F86 File Offset: 0x00067186
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005BF5 RID: 23541
		' (get) Token: 0x0600EFC6 RID: 61382 RVA: 0x00068F8F File Offset: 0x0006718F
		' (set) Token: 0x0600EFC7 RID: 61383 RVA: 0x00068F99 File Offset: 0x00067199
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005BF6 RID: 23542
		' (get) Token: 0x0600EFC8 RID: 61384 RVA: 0x00068FA2 File Offset: 0x000671A2
		' (set) Token: 0x0600EFC9 RID: 61385 RVA: 0x009014A4 File Offset: 0x008FF6A4
		Private _Button1 As GelButton
		Friend Overridable Property Button1 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim gelButton As GelButton = Me._Button1
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button1 = value
				gelButton = Me._Button1
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BF7 RID: 23543
		' (get) Token: 0x0600EFCA RID: 61386 RVA: 0x00068FAC File Offset: 0x000671AC
		' (set) Token: 0x0600EFCB RID: 61387 RVA: 0x009014E8 File Offset: 0x008FF6E8
		Private _btnReset As GelButton
		Friend Overridable Property btnReset As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnReset
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim gelButton As GelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnReset = value
				gelButton = Me._btnReset
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BF8 RID: 23544
		' (get) Token: 0x0600EFCC RID: 61388 RVA: 0x00068FB6 File Offset: 0x000671B6
		' (set) Token: 0x0600EFCD RID: 61389 RVA: 0x0090152C File Offset: 0x008FF72C
		Private _Button2 As GelButton
		Friend Overridable Property Button2 As GelButton
			<CompilerGenerated()>
			Get
				Return Me._Button2
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.GelButton1_Click
				Dim gelButton As GelButton = Me._Button2
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._Button2 = value
				gelButton = Me._Button2
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17005BF9 RID: 23545
		' (get) Token: 0x0600EFCE RID: 61390 RVA: 0x00068FC0 File Offset: 0x000671C0
		' (set) Token: 0x0600EFCF RID: 61391 RVA: 0x00901570 File Offset: 0x008FF770
		Private _btnExportExcel As GelButton
		Friend Overridable Property btnExportExcel As GelButton
			<CompilerGenerated()>
			Get
				Return Me._btnExportExcel
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As GelButton)
				Dim eventHandler As EventHandler = AddressOf Me.btnNew_Click
				Dim gelButton As GelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					RemoveHandler gelButton.Click, eventHandler
				End If
				Me._btnExportExcel = value
				gelButton = Me._btnExportExcel
				If gelButton IsNot Nothing Then
					AddHandler gelButton.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x0600EFD0 RID: 61392 RVA: 0x009015B4 File Offset: 0x008FF7B4
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

		' Token: 0x0600EFD1 RID: 61393 RVA: 0x00901690 File Offset: 0x008FF890
		Private Sub frmBankLedger_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600EFD2 RID: 61394 RVA: 0x00901730 File Offset: 0x008FF930
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

		' Token: 0x0600EFD3 RID: 61395 RVA: 0x009018A8 File Offset: 0x008FFAA8
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

		' Token: 0x0600EFD4 RID: 61396 RVA: 0x00901964 File Offset: 0x008FFB64
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

		' Token: 0x0600EFD5 RID: 61397 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600EFD6 RID: 61398 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600EFD7 RID: 61399 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600EFD8 RID: 61400 RVA: 0x00901A30 File Offset: 0x008FFC30
		Private Sub getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Date, RTRIM(PartyName), RTRIM(LedgerNo), RTRIM(Label), RTRIM(Debit), RTRIM(Credit) from LedgerBook where Name='Bank Account' and Date between @d1 and @d2 order by Date,ID", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5) })
				End While
				ModCommonClasses.con.Close()
				Me.Calculate()
				Me.dgw.ClearSelection()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600EFD9 RID: 61401 RVA: 0x00901BEC File Offset: 0x008FFDEC
		Private Sub dgw_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
			' The following expression was wrapped in a checked-expression
			Dim text As String = (e.RowIndex + 1).ToString()
			Dim sizeF As SizeF = e.Graphics.MeasureString(text, Me.Font)
			Dim flag As Boolean = Me.dgw.RowHeadersWidth < Convert.ToInt32(sizeF.Width + 20F)
			If flag Then
				Me.dgw.RowHeadersWidth = Convert.ToInt32(sizeF.Width + 20F)
			End If
			Dim buttonHighlight As Brush = SystemBrushes.ButtonHighlight
			e.Graphics.DrawString(text, Me.Font, buttonHighlight, CSng((e.RowBounds.Location.X + 15)), CSng(e.RowBounds.Location.Y) + (CSng(e.RowBounds.Height) - sizeF.Height) / 2F)
		End Sub

		' Token: 0x0600EFDA RID: 61402 RVA: 0x00901CD4 File Offset: 0x008FFED4
		Private Sub Calculate()
			Try
				Dim num2 As Double
				Dim num3 As Double
				Dim num As Integer = Me.dgw.Rows.Count - 1
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column5").Value))
						End If
						Dim flag2 As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column4").Value))
						If flag2 Then
							num3 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column4").Value))
						End If

				Next
				Me.TextBox1.Text = Conversions.ToString(num2 - num3)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.TextBox1.Text = Strings.Format(Math.Round(Conversion.Val(Me.TextBox1.Text), 2), "0.00")
		End Sub

		' Token: 0x0600EFDB RID: 61403 RVA: 0x00068FCA File Offset: 0x000671CA
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600EFDC RID: 61404 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmBankLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600EFDD RID: 61405 RVA: 0x00068FE6 File Offset: 0x000671E6
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Me.getdata()
		End Sub

		' Token: 0x0600EFDE RID: 61406 RVA: 0x00068FF0 File Offset: 0x000671F0
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.getdata()
		End Sub

		' Token: 0x0600EFDF RID: 61407 RVA: 0x00901E64 File Offset: 0x00900064
		Private Sub btnNew_Click(sender As Object, e As EventArgs)
			Try
				Dim flag As Boolean = (Me.dgw.Columns.Count = 0) Or (Me.dgw.Rows.Count = 0)
				If flag Then
					MessageBox.Show("No Record Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Else
					Dim dataTable As DataTable = New DataTable()
					Try
						For Each obj As Object In Me.dgw.Columns
							Dim dataGridViewColumn As DataGridViewColumn = CType(obj, DataGridViewColumn)
							dataTable.Columns.Add(dataGridViewColumn.HeaderText)
						Next
					Finally
						Dim enumerator As IEnumerator
						If TypeOf enumerator Is IDisposable Then
							TryCast(enumerator, IDisposable).Dispose()
						End If
					End Try
					Try
						For Each obj2 As Object In CType(Me.dgw.Rows, IEnumerable)
							Dim dataGridViewRow As DataGridViewRow = CType(obj2, DataGridViewRow)
							dataTable.Rows.Add(New Object(-1) {})
							Try
								For Each obj3 As Object In dataGridViewRow.Cells
									Dim dataGridViewCell As DataGridViewCell = CType(obj3, DataGridViewCell)
									dataTable.Rows(dataTable.Rows.Count - 1)(dataGridViewCell.ColumnIndex) = dataGridViewCell.Value.ToString()
								Next
							Finally
								Dim enumerator3 As IEnumerator
								If TypeOf enumerator3 Is IDisposable Then
									TryCast(enumerator3, IDisposable).Dispose()
								End If
							End Try
						Next
					Finally
						Dim enumerator2 As IEnumerator
						If TypeOf enumerator2 Is IDisposable Then
							TryCast(enumerator2, IDisposable).Dispose()
						End If
					End Try
					Dim text As String = ""
					Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
					Dim flag2 As Boolean = Me.SaveFileDialog1.ShowDialog() = DialogResult.OK
					If flag2 Then
						text = Me.SaveFileDialog1.FileName
					End If
					Using xlworkbook As XLWorkbook = New XLWorkbook()
						xlworkbook.Worksheets.Add(dataTable, "Export File")
						xlworkbook.SaveAs(text)
					End Using
					MessageBox.Show("Successfully Exported", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
				End If
			Catch ex As Exception
				MessageBox.Show("Export Unsuccessfully ", "Excel File", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600EFE0 RID: 61408 RVA: 0x00902110 File Offset: 0x00900310
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select PartyID from LedgerBook where Name='Bank Account' and Date >=@d2 and Date < @d3"
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
					Me.Cursor = Cursors.WaitCursor
					Me.Timer1.Enabled = True
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					ModCommonClasses.cmd = New SqlCommand("Select Date, PartyName as Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date >=@d1 and Date < @d2 and Name='Bank Account' order by ID,Date", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("BankLedgerBook.xml")
					Dim rptBanlLedger As rptBanlLedger = New rptBanlLedger()
					rptBanlLedger.SetDataSource(ModCommonClasses.ds)
					rptBanlLedger.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptBanlLedger.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptBanlLedger
					MyProject.Forms.frmReport.ShowDialog()
					rptBanlLedger.Close()
					rptBanlLedger.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub
	End Class
End Namespace
