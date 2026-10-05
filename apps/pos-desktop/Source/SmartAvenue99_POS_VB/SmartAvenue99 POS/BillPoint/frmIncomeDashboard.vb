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
Imports ClosedXML.Excel
Imports GelButtons
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace BillPoint
	' Token: 0x02000348 RID: 840
	<DesignerGenerated()>
	Public Partial Class frmIncomeDashboard
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C4E2 RID: 50402 RVA: 0x00058130 File Offset: 0x00056330
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmIncomeDashboard_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmExpDashboard_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004E28 RID: 20008
		' (get) Token: 0x0600C4E5 RID: 50405 RVA: 0x00058162 File Offset: 0x00056362
		' (set) Token: 0x0600C4E6 RID: 50406 RVA: 0x0005816C File Offset: 0x0005636C
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004E29 RID: 20009
		' (get) Token: 0x0600C4E7 RID: 50407 RVA: 0x00058175 File Offset: 0x00056375
		' (set) Token: 0x0600C4E8 RID: 50408 RVA: 0x0005817F File Offset: 0x0005637F
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17004E2A RID: 20010
		' (get) Token: 0x0600C4E9 RID: 50409 RVA: 0x00058188 File Offset: 0x00056388
		' (set) Token: 0x0600C4EA RID: 50410 RVA: 0x00058192 File Offset: 0x00056392
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004E2B RID: 20011
		' (get) Token: 0x0600C4EB RID: 50411 RVA: 0x0005819B File Offset: 0x0005639B
		' (set) Token: 0x0600C4EC RID: 50412 RVA: 0x007CEB8C File Offset: 0x007CCD8C
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

		' Token: 0x17004E2C RID: 20012
		' (get) Token: 0x0600C4ED RID: 50413 RVA: 0x000581A5 File Offset: 0x000563A5
		' (set) Token: 0x0600C4EE RID: 50414 RVA: 0x000581AF File Offset: 0x000563AF
		Friend Overridable Property Label5 As Label

		' Token: 0x17004E2D RID: 20013
		' (get) Token: 0x0600C4EF RID: 50415 RVA: 0x000581B8 File Offset: 0x000563B8
		' (set) Token: 0x0600C4F0 RID: 50416 RVA: 0x000581C2 File Offset: 0x000563C2
		Friend Overridable Property Label3 As Label

		' Token: 0x17004E2E RID: 20014
		' (get) Token: 0x0600C4F1 RID: 50417 RVA: 0x000581CB File Offset: 0x000563CB
		' (set) Token: 0x0600C4F2 RID: 50418 RVA: 0x007CEBD0 File Offset: 0x007CCDD0
		Private _TextBox1 As TextBox
		Friend Overridable Property TextBox1 As TextBox
			<CompilerGenerated()>
			Get
				Return Me._TextBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As TextBox)
				Dim eventHandler As EventHandler = AddressOf Me.TextBox1_TextChanged
				Dim textBox As TextBox = Me._TextBox1
				If textBox IsNot Nothing Then
					RemoveHandler textBox.TextChanged, eventHandler
				End If
				Me._TextBox1 = value
				textBox = Me._TextBox1
				If textBox IsNot Nothing Then
					AddHandler textBox.TextChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E2F RID: 20015
		' (get) Token: 0x0600C4F3 RID: 50419 RVA: 0x000581D5 File Offset: 0x000563D5
		' (set) Token: 0x0600C4F4 RID: 50420 RVA: 0x007CEC14 File Offset: 0x007CCE14
		Private _ComboBox1 As ComboBox
		Friend Overridable Property ComboBox1 As ComboBox
			<CompilerGenerated()>
			Get
				Return Me._ComboBox1
			End Get
			<CompilerGenerated()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Dim eventHandler As EventHandler = AddressOf Me.ComboBox1_SelectedIndexChanged
				Dim comboBox As ComboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					RemoveHandler comboBox.SelectedIndexChanged, eventHandler
				End If
				Me._ComboBox1 = value
				comboBox = Me._ComboBox1
				If comboBox IsNot Nothing Then
					AddHandler comboBox.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17004E30 RID: 20016
		' (get) Token: 0x0600C4F5 RID: 50421 RVA: 0x000581DF File Offset: 0x000563DF
		' (set) Token: 0x0600C4F6 RID: 50422 RVA: 0x000581E9 File Offset: 0x000563E9
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004E31 RID: 20017
		' (get) Token: 0x0600C4F7 RID: 50423 RVA: 0x000581F2 File Offset: 0x000563F2
		' (set) Token: 0x0600C4F8 RID: 50424 RVA: 0x000581FC File Offset: 0x000563FC
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004E32 RID: 20018
		' (get) Token: 0x0600C4F9 RID: 50425 RVA: 0x00058205 File Offset: 0x00056405
		' (set) Token: 0x0600C4FA RID: 50426 RVA: 0x0005820F File Offset: 0x0005640F
		Friend Overridable Property Label2 As Label

		' Token: 0x17004E33 RID: 20019
		' (get) Token: 0x0600C4FB RID: 50427 RVA: 0x00058218 File Offset: 0x00056418
		' (set) Token: 0x0600C4FC RID: 50428 RVA: 0x00058222 File Offset: 0x00056422
		Friend Overridable Property Label4 As Label

		' Token: 0x17004E34 RID: 20020
		' (get) Token: 0x0600C4FD RID: 50429 RVA: 0x0005822B File Offset: 0x0005642B
		' (set) Token: 0x0600C4FE RID: 50430 RVA: 0x00058235 File Offset: 0x00056435
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004E35 RID: 20021
		' (get) Token: 0x0600C4FF RID: 50431 RVA: 0x0005823E File Offset: 0x0005643E
		' (set) Token: 0x0600C500 RID: 50432 RVA: 0x00058248 File Offset: 0x00056448
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004E36 RID: 20022
		' (get) Token: 0x0600C501 RID: 50433 RVA: 0x00058251 File Offset: 0x00056451
		' (set) Token: 0x0600C502 RID: 50434 RVA: 0x007CEC58 File Offset: 0x007CCE58
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

		' Token: 0x17004E37 RID: 20023
		' (get) Token: 0x0600C503 RID: 50435 RVA: 0x0005825B File Offset: 0x0005645B
		' (set) Token: 0x0600C504 RID: 50436 RVA: 0x00058265 File Offset: 0x00056465
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004E38 RID: 20024
		' (get) Token: 0x0600C505 RID: 50437 RVA: 0x0005826E File Offset: 0x0005646E
		' (set) Token: 0x0600C506 RID: 50438 RVA: 0x00058278 File Offset: 0x00056478
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004E39 RID: 20025
		' (get) Token: 0x0600C507 RID: 50439 RVA: 0x00058281 File Offset: 0x00056481
		' (set) Token: 0x0600C508 RID: 50440 RVA: 0x0005828B File Offset: 0x0005648B
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004E3A RID: 20026
		' (get) Token: 0x0600C509 RID: 50441 RVA: 0x00058294 File Offset: 0x00056494
		' (set) Token: 0x0600C50A RID: 50442 RVA: 0x0005829E File Offset: 0x0005649E
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004E3B RID: 20027
		' (get) Token: 0x0600C50B RID: 50443 RVA: 0x000582A7 File Offset: 0x000564A7
		' (set) Token: 0x0600C50C RID: 50444 RVA: 0x000582B1 File Offset: 0x000564B1
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004E3C RID: 20028
		' (get) Token: 0x0600C50D RID: 50445 RVA: 0x000582BA File Offset: 0x000564BA
		' (set) Token: 0x0600C50E RID: 50446 RVA: 0x000582C4 File Offset: 0x000564C4
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004E3D RID: 20029
		' (get) Token: 0x0600C50F RID: 50447 RVA: 0x000582CD File Offset: 0x000564CD
		' (set) Token: 0x0600C510 RID: 50448 RVA: 0x000582D7 File Offset: 0x000564D7
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17004E3E RID: 20030
		' (get) Token: 0x0600C511 RID: 50449 RVA: 0x000582E0 File Offset: 0x000564E0
		' (set) Token: 0x0600C512 RID: 50450 RVA: 0x000582EA File Offset: 0x000564EA
		Friend Overridable Property Label1 As Label

		' Token: 0x17004E3F RID: 20031
		' (get) Token: 0x0600C513 RID: 50451 RVA: 0x000582F3 File Offset: 0x000564F3
		' (set) Token: 0x0600C514 RID: 50452 RVA: 0x000582FD File Offset: 0x000564FD
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004E40 RID: 20032
		' (get) Token: 0x0600C515 RID: 50453 RVA: 0x00058306 File Offset: 0x00056506
		' (set) Token: 0x0600C516 RID: 50454 RVA: 0x007CEC9C File Offset: 0x007CCE9C
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

		' Token: 0x17004E41 RID: 20033
		' (get) Token: 0x0600C517 RID: 50455 RVA: 0x00058310 File Offset: 0x00056510
		' (set) Token: 0x0600C518 RID: 50456 RVA: 0x007CECE0 File Offset: 0x007CCEE0
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

		' Token: 0x17004E42 RID: 20034
		' (get) Token: 0x0600C519 RID: 50457 RVA: 0x0005831A File Offset: 0x0005651A
		' (set) Token: 0x0600C51A RID: 50458 RVA: 0x007CED24 File Offset: 0x007CCF24
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

		' Token: 0x0600C51B RID: 50459 RVA: 0x007CED68 File Offset: 0x007CCF68
		Private Sub fyear()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = ModCommonClasses.con.CreateCommand()
				ModCommonClasses.cmd.CommandText = "SELECT RTRIM(FYFrom),RTRIM(FYTo) from Company"
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader()
				Dim flag As Boolean = ModCommonClasses.rdr.Read()
				If flag Then
					Me.dtpDateFrom.Value = DateAndTime.Today
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

		' Token: 0x0600C51C RID: 50460 RVA: 0x007CEE3C File Offset: 0x007CD03C
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Income.IncomeNo), Income.Date, RTRIM(Income.Name),  RTRIM(Income_OtherDetails.Particulars),  (Income_OtherDetails.Amount), RTRIM(Income_OtherDetails.Note), RTRIM(Income_OtherDetails.PModeD) FROM Income INNER JOIN Income_OtherDetails ON Income.Id = Income_OtherDetails.IncomeID where Income.Date between @d1 and @d2 order by Income.Date", ModCommonClasses.con)
				ModCommonClasses.cmd.CommandTimeout = 0
				ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
				ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
				ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
				Me.dgw.Rows.Clear()
				While ModCommonClasses.rdr.Read()
					Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
				End While
				ModCommonClasses.con.Close()
				Me.dgw.ClearSelection()
				Me.Calculate()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
			End Try
		End Sub

		' Token: 0x0600C51D RID: 50461 RVA: 0x007CF008 File Offset: 0x007CD208
		Private Sub frmIncomeDashboard_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C51E RID: 50462 RVA: 0x007CF098 File Offset: 0x007CD298
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

		' Token: 0x0600C51F RID: 50463 RVA: 0x007CF210 File Offset: 0x007CD410
		Private Sub UpdateAllControls(ctrl As Control, translations As Dictionary(Of String, String))
			Dim visible As Boolean = ctrl.Visible
			If visible Then
				Dim flag As Boolean = TypeOf ctrl Is Label OrElse TypeOf ctrl Is Button OrElse TypeOf ctrl Is GroupBox OrElse TypeOf ctrl Is CheckBox OrElse TypeOf ctrl Is RadioButton
				If flag Then
					Dim text As String = ctrl.Text
					Dim flag2 As Boolean = translations.ContainsKey(text)
					If flag2 Then
						ctrl.Text = translations(text)
					End If
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

		' Token: 0x0600C520 RID: 50464 RVA: 0x007CF2DC File Offset: 0x007CD4DC
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

		' Token: 0x0600C521 RID: 50465 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C522 RID: 50466 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C523 RID: 50467 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C524 RID: 50468 RVA: 0x00058324 File Offset: 0x00056524
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x0600C525 RID: 50469 RVA: 0x007CF3A8 File Offset: 0x007CD5A8
		Private Sub Calculate()
			' The following expression was wrapped in a checked-statement
			Try
				Dim num As Integer = Me.dgw.Rows.Count - 1
				Dim num2 As Double
				For i As Integer = 0 To num
					Dim flag As Boolean = Not Information.IsDBNull(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column10").Value))

						If flag Then
							num2 += Convert.ToDouble(RuntimeHelpers.GetObjectValue(Me.dgw.Rows(i).Cells("Column10").Value))
						End If

				Next
				Me.lblTotalAmount.Text = Conversions.ToString(num2)
			Catch ex As Exception
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Me.lblTotalAmount.Text = "Total : " + Strings.Format(Math.Round(Conversion.Val(Me.lblTotalAmount.Text), 2), "0.00")
		End Sub

		' Token: 0x0600C526 RID: 50470 RVA: 0x00087110 File Offset: 0x00085310
		Private Sub frmExpDashboard_KeyDown(sender As Object, e As KeyEventArgs)
			Dim flag As Boolean = e.KeyCode = Keys.Escape
			If flag Then
				e.Handled = True
				Dim flag2 As Boolean = MessageBox.Show("Do you want to close ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
				If flag2 Then
					MyBase.Close()
				End If
			End If
		End Sub

		' Token: 0x0600C527 RID: 50471 RVA: 0x007CF4C0 File Offset: 0x007CD6C0
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

		' Token: 0x0600C528 RID: 50472 RVA: 0x007CF5A8 File Offset: 0x007CD7A8
		Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.ComboBox1.SelectedIndex = -1
			If flag Then
				MessageBox.Show("Select the search category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				Me.ComboBox1.Focus()
			Else
				Try
					ModCommonClasses.con = New SqlConnection(ModCS.cs)
					ModCommonClasses.con.Open()
					Dim flag2 As Boolean = Me.ComboBox1.SelectedIndex = 0
					If flag2 Then
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Income.IncomeNo), Income.Date, RTRIM(Income.Name),  RTRIM(Income_OtherDetails.Particulars),  (Income_OtherDetails.Amount), RTRIM(Income_OtherDetails.Note), RTRIM(Income_OtherDetails.PModeD) FROM Income INNER JOIN Income_OtherDetails ON Income.Id = Income_OtherDetails.IncomeID where Income.Date between @d1 and @d2 and Income.IncomeNo='" + Me.TextBox1.Text + "' order by Income.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Income.IncomeNo), Income.Date, RTRIM(Income.Name),  RTRIM(Income_OtherDetails.Particulars),  (Income_OtherDetails.Amount), RTRIM(Income_OtherDetails.Note), RTRIM(Income_OtherDetails.PModeD) FROM Income INNER JOIN Income_OtherDetails ON Income.Id = Income_OtherDetails.IncomeID where Income.Date between @d1 and @d2 and Income.Name='" + Me.TextBox1.Text + "' order by Income.Date", ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Income.IncomeNo), Income.Date, RTRIM(Income.Name),  RTRIM(Income_OtherDetails.Particulars),  (Income_OtherDetails.Amount), RTRIM(Income_OtherDetails.Note), RTRIM(Income_OtherDetails.PModeD) FROM Income INNER JOIN Income_OtherDetails ON Income.Id = Income_OtherDetails.IncomeID where Income.Date between @d1 and @d2 and Income_OtherDetails.Particulars='" + Me.TextBox1.Text + "' order by Income.Date", ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Income.IncomeNo), Income.Date, RTRIM(Income.Name),  RTRIM(Income_OtherDetails.Particulars),  (Income_OtherDetails.Amount), RTRIM(Income_OtherDetails.Note), RTRIM(Income_OtherDetails.PModeD) FROM Income INNER JOIN Income_OtherDetails ON Income.Id = Income_OtherDetails.IncomeID where Income.Date between @d1 and @d2 and Income_OtherDetails.Note='" + Me.TextBox1.Text + "' order by Income.Date", ModCommonClasses.con)
									ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
									ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 4
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Income.IncomeNo), Income.Date, RTRIM(Income.Name),  RTRIM(Income_OtherDetails.Particulars),  (Income_OtherDetails.Amount), RTRIM(Income_OtherDetails.Note), RTRIM(Income_OtherDetails.PModeD) FROM Income INNER JOIN Income_OtherDetails ON Income.Id = Income_OtherDetails.IncomeID where Income.Date between @d1 and @d2 and Income_OtherDetails.PModeD='" + Me.TextBox1.Text + "' order by Income.Date", ModCommonClasses.con)
										ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
										ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
									End If
								End If
							End If
						End If
					End If
					ModCommonClasses.rdr = ModCommonClasses.cmd.ExecuteReader(CommandBehavior.CloseConnection)
					Me.dgw.Rows.Clear()
					While ModCommonClasses.rdr.Read()
						Me.dgw.Rows.Add(New Object() { ModCommonClasses.rdr(0), ModCommonClasses.rdr(1), ModCommonClasses.rdr(2), ModCommonClasses.rdr(3), ModCommonClasses.rdr(4), ModCommonClasses.rdr(5), ModCommonClasses.rdr(6) })
					End While
					ModCommonClasses.con.Close()
					Me.dgw.ClearSelection()
				Catch ex As Exception
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
				End Try
				Me.Calculate()
			End If
		End Sub

		' Token: 0x0600C529 RID: 50473 RVA: 0x00058346 File Offset: 0x00056546
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
		End Sub

		' Token: 0x0600C52A RID: 50474 RVA: 0x0005836E File Offset: 0x0005656E
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
		End Sub

		' Token: 0x0600C52B RID: 50475 RVA: 0x0005837D File Offset: 0x0005657D
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub

		' Token: 0x0600C52C RID: 50476 RVA: 0x00058387 File Offset: 0x00056587
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0600C52D RID: 50477 RVA: 0x007CFAB4 File Offset: 0x007CDCB4
		Private Sub GelButton1_Click(sender As Object, e As EventArgs)
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
	End Class
End Namespace
