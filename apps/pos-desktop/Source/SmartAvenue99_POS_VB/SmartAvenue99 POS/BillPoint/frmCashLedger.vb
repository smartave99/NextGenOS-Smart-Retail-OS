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
	' Token: 0x020004AE RID: 1198
	<DesignerGenerated()>
	Public Partial Class frmCashLedger
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600F013 RID: 61459 RVA: 0x00069135 File Offset: 0x00067335
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmCashLedger_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmCashLedger_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17005C09 RID: 23561
		' (get) Token: 0x0600F016 RID: 61462 RVA: 0x00069167 File Offset: 0x00067367
		' (set) Token: 0x0600F017 RID: 61463 RVA: 0x00069171 File Offset: 0x00067371
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17005C0A RID: 23562
		' (get) Token: 0x0600F018 RID: 61464 RVA: 0x0006917A File Offset: 0x0006737A
		' (set) Token: 0x0600F019 RID: 61465 RVA: 0x00069184 File Offset: 0x00067384
		Friend Overridable Property Label1 As Label

		' Token: 0x17005C0B RID: 23563
		' (get) Token: 0x0600F01A RID: 61466 RVA: 0x0006918D File Offset: 0x0006738D
		' (set) Token: 0x0600F01B RID: 61467 RVA: 0x00905D04 File Offset: 0x00903F04
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

		' Token: 0x17005C0C RID: 23564
		' (get) Token: 0x0600F01C RID: 61468 RVA: 0x00069197 File Offset: 0x00067397
		' (set) Token: 0x0600F01D RID: 61469 RVA: 0x000691A1 File Offset: 0x000673A1
		Friend Overridable Property GroupBox1 As GroupBox

		' Token: 0x17005C0D RID: 23565
		' (get) Token: 0x0600F01E RID: 61470 RVA: 0x000691AA File Offset: 0x000673AA
		' (set) Token: 0x0600F01F RID: 61471 RVA: 0x000691B4 File Offset: 0x000673B4
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17005C0E RID: 23566
		' (get) Token: 0x0600F020 RID: 61472 RVA: 0x000691BD File Offset: 0x000673BD
		' (set) Token: 0x0600F021 RID: 61473 RVA: 0x000691C7 File Offset: 0x000673C7
		Friend Overridable Property Label4 As Label

		' Token: 0x17005C0F RID: 23567
		' (get) Token: 0x0600F022 RID: 61474 RVA: 0x000691D0 File Offset: 0x000673D0
		' (set) Token: 0x0600F023 RID: 61475 RVA: 0x000691DA File Offset: 0x000673DA
		Friend Overridable Property Label2 As Label

		' Token: 0x17005C10 RID: 23568
		' (get) Token: 0x0600F024 RID: 61476 RVA: 0x000691E3 File Offset: 0x000673E3
		' (set) Token: 0x0600F025 RID: 61477 RVA: 0x000691ED File Offset: 0x000673ED
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17005C11 RID: 23569
		' (get) Token: 0x0600F026 RID: 61478 RVA: 0x000691F6 File Offset: 0x000673F6
		' (set) Token: 0x0600F027 RID: 61479 RVA: 0x00069200 File Offset: 0x00067400
		Friend Overridable Property TextBox1 As TextBox

		' Token: 0x17005C12 RID: 23570
		' (get) Token: 0x0600F028 RID: 61480 RVA: 0x00069209 File Offset: 0x00067409
		' (set) Token: 0x0600F029 RID: 61481 RVA: 0x00069213 File Offset: 0x00067413
		Friend Overridable Property Label3 As Label

		' Token: 0x17005C13 RID: 23571
		' (get) Token: 0x0600F02A RID: 61482 RVA: 0x0006921C File Offset: 0x0006741C
		' (set) Token: 0x0600F02B RID: 61483 RVA: 0x00905D48 File Offset: 0x00903F48
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

		' Token: 0x17005C14 RID: 23572
		' (get) Token: 0x0600F02C RID: 61484 RVA: 0x00069226 File Offset: 0x00067426
		' (set) Token: 0x0600F02D RID: 61485 RVA: 0x00069230 File Offset: 0x00067430
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17005C15 RID: 23573
		' (get) Token: 0x0600F02E RID: 61486 RVA: 0x00069239 File Offset: 0x00067439
		' (set) Token: 0x0600F02F RID: 61487 RVA: 0x00069243 File Offset: 0x00067443
		Friend Overridable Property Column1 As DataGridViewTextBoxColumn

		' Token: 0x17005C16 RID: 23574
		' (get) Token: 0x0600F030 RID: 61488 RVA: 0x0006924C File Offset: 0x0006744C
		' (set) Token: 0x0600F031 RID: 61489 RVA: 0x00069256 File Offset: 0x00067456
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17005C17 RID: 23575
		' (get) Token: 0x0600F032 RID: 61490 RVA: 0x0006925F File Offset: 0x0006745F
		' (set) Token: 0x0600F033 RID: 61491 RVA: 0x00069269 File Offset: 0x00067469
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17005C18 RID: 23576
		' (get) Token: 0x0600F034 RID: 61492 RVA: 0x00069272 File Offset: 0x00067472
		' (set) Token: 0x0600F035 RID: 61493 RVA: 0x0006927C File Offset: 0x0006747C
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17005C19 RID: 23577
		' (get) Token: 0x0600F036 RID: 61494 RVA: 0x00069285 File Offset: 0x00067485
		' (set) Token: 0x0600F037 RID: 61495 RVA: 0x0006928F File Offset: 0x0006748F
		Friend Overridable Property Column4 As DataGridViewTextBoxColumn

		' Token: 0x17005C1A RID: 23578
		' (get) Token: 0x0600F038 RID: 61496 RVA: 0x00069298 File Offset: 0x00067498
		' (set) Token: 0x0600F039 RID: 61497 RVA: 0x000692A2 File Offset: 0x000674A2
		Friend Overridable Property Column5 As DataGridViewTextBoxColumn

		' Token: 0x17005C1B RID: 23579
		' (get) Token: 0x0600F03A RID: 61498 RVA: 0x000692AB File Offset: 0x000674AB
		' (set) Token: 0x0600F03B RID: 61499 RVA: 0x00905D8C File Offset: 0x00903F8C
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

		' Token: 0x17005C1C RID: 23580
		' (get) Token: 0x0600F03C RID: 61500 RVA: 0x000692B5 File Offset: 0x000674B5
		' (set) Token: 0x0600F03D RID: 61501 RVA: 0x00905DD0 File Offset: 0x00903FD0
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

		' Token: 0x17005C1D RID: 23581
		' (get) Token: 0x0600F03E RID: 61502 RVA: 0x000692BF File Offset: 0x000674BF
		' (set) Token: 0x0600F03F RID: 61503 RVA: 0x00905E14 File Offset: 0x00904014
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

		' Token: 0x17005C1E RID: 23582
		' (get) Token: 0x0600F040 RID: 61504 RVA: 0x000692C9 File Offset: 0x000674C9
		' (set) Token: 0x0600F041 RID: 61505 RVA: 0x00905E58 File Offset: 0x00904058
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

		' Token: 0x0600F042 RID: 61506 RVA: 0x00905E9C File Offset: 0x0090409C
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

		' Token: 0x0600F043 RID: 61507 RVA: 0x00905F78 File Offset: 0x00904178
		Private Sub frmCashLedger_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600F044 RID: 61508 RVA: 0x00906018 File Offset: 0x00904218
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

		' Token: 0x0600F045 RID: 61509 RVA: 0x00906190 File Offset: 0x00904390
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

		' Token: 0x0600F046 RID: 61510 RVA: 0x0090624C File Offset: 0x0090444C
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

		' Token: 0x0600F047 RID: 61511 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600F048 RID: 61512 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600F049 RID: 61513 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600F04A RID: 61514 RVA: 0x00906318 File Offset: 0x00904518
		Private Sub getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("Select Date, RTRIM(PartyName), RTRIM(LedgerNo), RTRIM(Label), RTRIM(Debit), RTRIM(Credit) from LedgerBook where Name='Cash Account' and Date between @d1 and @d2 order by Date", ModCommonClasses.con)
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

		' Token: 0x0600F04B RID: 61515 RVA: 0x009064D4 File Offset: 0x009046D4
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

		' Token: 0x0600F04C RID: 61516 RVA: 0x009065BC File Offset: 0x009047BC
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

		' Token: 0x0600F04D RID: 61517 RVA: 0x000692D3 File Offset: 0x000674D3
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.Cursor = Cursors.[Default]
			Me.Timer1.Enabled = False
		End Sub

		' Token: 0x0600F04E RID: 61518 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmCashLedger_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600F04F RID: 61519 RVA: 0x0090674C File Offset: 0x0090494C
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				Dim text As String = "select PartyID from LedgerBook where Name='Cash Account' and Date >=@d2 and Date < @d3"
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
					ModCommonClasses.cmd = New SqlCommand("Select Date, PartyName as Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date >=@d1 and Date < @d2 and Name='Cash Account' order by Date,ID", ModCommonClasses.con)
					ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
					ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date].AddDays(1.0)
					ModCommonClasses.adp = New SqlDataAdapter(ModCommonClasses.cmd)
					ModCommonClasses.dtable = New DataTable()
					ModCommonClasses.adp.Fill(ModCommonClasses.dtable)
					ModCommonClasses.con.Close()
					ModCommonClasses.ds = New DataSet()
					ModCommonClasses.ds.Tables.Add(ModCommonClasses.dtable)
					ModCommonClasses.ds.WriteXmlSchema("LedgerBookNew.xml")
					Dim rptCashBook As rptCashBook = New rptCashBook()
					rptCashBook.SetDataSource(ModCommonClasses.ds)
					rptCashBook.SetParameterValue("p1", Me.dtpDateFrom.Value.[Date])
					rptCashBook.SetParameterValue("p2", Me.dtpDateTo.Value.[Date])
					MyProject.Forms.frmReport.CrystalReportViewer1.ReportSource = rptCashBook
					MyProject.Forms.frmReport.ShowDialog()
					rptCashBook.Close()
					rptCashBook.Dispose()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600F050 RID: 61520 RVA: 0x00906A70 File Offset: 0x00904C70
		Private Sub GelButton4_Click(sender As Object, e As EventArgs)
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

		' Token: 0x0600F051 RID: 61521 RVA: 0x000692EF File Offset: 0x000674EF
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.getdata()
		End Sub

		' Token: 0x0600F052 RID: 61522 RVA: 0x00069311 File Offset: 0x00067511
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.getdata()
		End Sub
	End Class
End Namespace
