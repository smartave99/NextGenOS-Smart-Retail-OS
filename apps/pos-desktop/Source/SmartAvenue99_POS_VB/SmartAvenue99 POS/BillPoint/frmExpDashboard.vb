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
	' Token: 0x02000343 RID: 835
	<DesignerGenerated()>
	Public Partial Class frmExpDashboard
		Inherits Global.System.Windows.Forms.Form
		' Token: 0x0600C343 RID: 49987 RVA: 0x000574D1 File Offset: 0x000556D1
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.frmExpDashboard_Load
			AddHandler MyBase.KeyDown, AddressOf Me.frmExpDashboard_KeyDown
			Me.InitializeComponent()
		End Sub

		' Token: 0x17004D8C RID: 19852
		' (get) Token: 0x0600C346 RID: 49990 RVA: 0x00057503 File Offset: 0x00055703
		' (set) Token: 0x0600C347 RID: 49991 RVA: 0x0005750D File Offset: 0x0005570D
		Friend Overridable Property Panel1 As Panel

		' Token: 0x17004D8D RID: 19853
		' (get) Token: 0x0600C348 RID: 49992 RVA: 0x00057516 File Offset: 0x00055716
		' (set) Token: 0x0600C349 RID: 49993 RVA: 0x00057520 File Offset: 0x00055720
		Friend Overridable Property lblTotalAmount As Label

		' Token: 0x17004D8E RID: 19854
		' (get) Token: 0x0600C34A RID: 49994 RVA: 0x00057529 File Offset: 0x00055729
		' (set) Token: 0x0600C34B RID: 49995 RVA: 0x00057533 File Offset: 0x00055733
		Friend Overridable Property Panel2 As Panel

		' Token: 0x17004D8F RID: 19855
		' (get) Token: 0x0600C34C RID: 49996 RVA: 0x0005753C File Offset: 0x0005573C
		' (set) Token: 0x0600C34D RID: 49997 RVA: 0x007C1B18 File Offset: 0x007BFD18
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

		' Token: 0x17004D90 RID: 19856
		' (get) Token: 0x0600C34E RID: 49998 RVA: 0x00057546 File Offset: 0x00055746
		' (set) Token: 0x0600C34F RID: 49999 RVA: 0x00057550 File Offset: 0x00055750
		Friend Overridable Property Label5 As Label

		' Token: 0x17004D91 RID: 19857
		' (get) Token: 0x0600C350 RID: 50000 RVA: 0x00057559 File Offset: 0x00055759
		' (set) Token: 0x0600C351 RID: 50001 RVA: 0x00057563 File Offset: 0x00055763
		Friend Overridable Property Label3 As Label

		' Token: 0x17004D92 RID: 19858
		' (get) Token: 0x0600C352 RID: 50002 RVA: 0x0005756C File Offset: 0x0005576C
		' (set) Token: 0x0600C353 RID: 50003 RVA: 0x007C1B5C File Offset: 0x007BFD5C
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

		' Token: 0x17004D93 RID: 19859
		' (get) Token: 0x0600C354 RID: 50004 RVA: 0x00057576 File Offset: 0x00055776
		' (set) Token: 0x0600C355 RID: 50005 RVA: 0x007C1BA0 File Offset: 0x007BFDA0
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

		' Token: 0x17004D94 RID: 19860
		' (get) Token: 0x0600C356 RID: 50006 RVA: 0x00057580 File Offset: 0x00055780
		' (set) Token: 0x0600C357 RID: 50007 RVA: 0x0005758A File Offset: 0x0005578A
		Friend Overridable Property GroupBox2 As GroupBox

		' Token: 0x17004D95 RID: 19861
		' (get) Token: 0x0600C358 RID: 50008 RVA: 0x00057593 File Offset: 0x00055793
		' (set) Token: 0x0600C359 RID: 50009 RVA: 0x0005759D File Offset: 0x0005579D
		Friend Overridable Property dtpDateTo As DateTimePicker

		' Token: 0x17004D96 RID: 19862
		' (get) Token: 0x0600C35A RID: 50010 RVA: 0x000575A6 File Offset: 0x000557A6
		' (set) Token: 0x0600C35B RID: 50011 RVA: 0x000575B0 File Offset: 0x000557B0
		Friend Overridable Property Label2 As Label

		' Token: 0x17004D97 RID: 19863
		' (get) Token: 0x0600C35C RID: 50012 RVA: 0x000575B9 File Offset: 0x000557B9
		' (set) Token: 0x0600C35D RID: 50013 RVA: 0x000575C3 File Offset: 0x000557C3
		Friend Overridable Property Label4 As Label

		' Token: 0x17004D98 RID: 19864
		' (get) Token: 0x0600C35E RID: 50014 RVA: 0x000575CC File Offset: 0x000557CC
		' (set) Token: 0x0600C35F RID: 50015 RVA: 0x000575D6 File Offset: 0x000557D6
		Friend Overridable Property dtpDateFrom As DateTimePicker

		' Token: 0x17004D99 RID: 19865
		' (get) Token: 0x0600C360 RID: 50016 RVA: 0x000575DF File Offset: 0x000557DF
		' (set) Token: 0x0600C361 RID: 50017 RVA: 0x000575E9 File Offset: 0x000557E9
		Friend Overridable Property Panel5 As Panel

		' Token: 0x17004D9A RID: 19866
		' (get) Token: 0x0600C362 RID: 50018 RVA: 0x000575F2 File Offset: 0x000557F2
		' (set) Token: 0x0600C363 RID: 50019 RVA: 0x007C1BE4 File Offset: 0x007BFDE4
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

		' Token: 0x17004D9B RID: 19867
		' (get) Token: 0x0600C364 RID: 50020 RVA: 0x000575FC File Offset: 0x000557FC
		' (set) Token: 0x0600C365 RID: 50021 RVA: 0x00057606 File Offset: 0x00055806
		Friend Overridable Property Label1 As Label

		' Token: 0x17004D9C RID: 19868
		' (get) Token: 0x0600C366 RID: 50022 RVA: 0x0005760F File Offset: 0x0005580F
		' (set) Token: 0x0600C367 RID: 50023 RVA: 0x00057619 File Offset: 0x00055819
		Friend Overridable Property SaveFileDialog1 As SaveFileDialog

		' Token: 0x17004D9D RID: 19869
		' (get) Token: 0x0600C368 RID: 50024 RVA: 0x00057622 File Offset: 0x00055822
		' (set) Token: 0x0600C369 RID: 50025 RVA: 0x0005762C File Offset: 0x0005582C
		Friend Overridable Property Column2 As DataGridViewTextBoxColumn

		' Token: 0x17004D9E RID: 19870
		' (get) Token: 0x0600C36A RID: 50026 RVA: 0x00057635 File Offset: 0x00055835
		' (set) Token: 0x0600C36B RID: 50027 RVA: 0x0005763F File Offset: 0x0005583F
		Friend Overridable Property Column3 As DataGridViewTextBoxColumn

		' Token: 0x17004D9F RID: 19871
		' (get) Token: 0x0600C36C RID: 50028 RVA: 0x00057648 File Offset: 0x00055848
		' (set) Token: 0x0600C36D RID: 50029 RVA: 0x00057652 File Offset: 0x00055852
		Friend Overridable Property Column14 As DataGridViewTextBoxColumn

		' Token: 0x17004DA0 RID: 19872
		' (get) Token: 0x0600C36E RID: 50030 RVA: 0x0005765B File Offset: 0x0005585B
		' (set) Token: 0x0600C36F RID: 50031 RVA: 0x00057665 File Offset: 0x00055865
		Friend Overridable Property Column9 As DataGridViewTextBoxColumn

		' Token: 0x17004DA1 RID: 19873
		' (get) Token: 0x0600C370 RID: 50032 RVA: 0x0005766E File Offset: 0x0005586E
		' (set) Token: 0x0600C371 RID: 50033 RVA: 0x00057678 File Offset: 0x00055878
		Friend Overridable Property Column10 As DataGridViewTextBoxColumn

		' Token: 0x17004DA2 RID: 19874
		' (get) Token: 0x0600C372 RID: 50034 RVA: 0x00057681 File Offset: 0x00055881
		' (set) Token: 0x0600C373 RID: 50035 RVA: 0x0005768B File Offset: 0x0005588B
		Friend Overridable Property Column6 As DataGridViewTextBoxColumn

		' Token: 0x17004DA3 RID: 19875
		' (get) Token: 0x0600C374 RID: 50036 RVA: 0x00057694 File Offset: 0x00055894
		' (set) Token: 0x0600C375 RID: 50037 RVA: 0x0005769E File Offset: 0x0005589E
		Friend Overridable Property Column16 As DataGridViewTextBoxColumn

		' Token: 0x17004DA4 RID: 19876
		' (get) Token: 0x0600C376 RID: 50038 RVA: 0x000576A7 File Offset: 0x000558A7
		' (set) Token: 0x0600C377 RID: 50039 RVA: 0x007C1C28 File Offset: 0x007BFE28
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

		' Token: 0x17004DA5 RID: 19877
		' (get) Token: 0x0600C378 RID: 50040 RVA: 0x000576B1 File Offset: 0x000558B1
		' (set) Token: 0x0600C379 RID: 50041 RVA: 0x007C1C6C File Offset: 0x007BFE6C
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

		' Token: 0x17004DA6 RID: 19878
		' (get) Token: 0x0600C37A RID: 50042 RVA: 0x000576BB File Offset: 0x000558BB
		' (set) Token: 0x0600C37B RID: 50043 RVA: 0x007C1CB0 File Offset: 0x007BFEB0
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

		' Token: 0x0600C37C RID: 50044 RVA: 0x007C1CF4 File Offset: 0x007BFEF4
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

		' Token: 0x0600C37D RID: 50045 RVA: 0x007C1DC8 File Offset: 0x007BFFC8
		Public Sub Getdata()
			Try
				ModCommonClasses.con = New SqlConnection(ModCS.cs)
				ModCommonClasses.con.Open()
				ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Voucher.VoucherNo), Voucher.Date, RTRIM(Voucher.Name),  RTRIM(Voucher_OtherDetails.Particulars),  (Voucher_OtherDetails.Amount), RTRIM(Voucher_OtherDetails.Note), RTRIM(Voucher_OtherDetails.PModeD) FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.Id = Voucher_OtherDetails.VoucherID where Voucher.Date between @d1 and @d2 order by Voucher.Date", ModCommonClasses.con)
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

		' Token: 0x0600C37E RID: 50046 RVA: 0x007C1F94 File Offset: 0x007C0194
		Private Sub frmExpDashboard_Load(sender As Object, e As EventArgs)
			Me.fyear()
			Me.Getdata()
			Me.dgw.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#ffffff")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.dgw.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#187094")
			Me.Convert_Language()
		End Sub

		' Token: 0x0600C37F RID: 50047 RVA: 0x007C2024 File Offset: 0x007C0224
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

		' Token: 0x0600C380 RID: 50048 RVA: 0x007C219C File Offset: 0x007C039C
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

		' Token: 0x0600C381 RID: 50049 RVA: 0x007C2268 File Offset: 0x007C0468
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

		' Token: 0x0600C382 RID: 50050 RVA: 0x00086F78 File Offset: 0x00085178
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

		' Token: 0x0600C383 RID: 50051 RVA: 0x00087000 File Offset: 0x00085200
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

		' Token: 0x0600C384 RID: 50052 RVA: 0x00087088 File Offset: 0x00085288
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

		' Token: 0x0600C385 RID: 50053 RVA: 0x000576C5 File Offset: 0x000558C5
		Public Sub Reset()
			Me.fyear()
			Me.dtpDateTo.Value = DateAndTime.Today
			Me.Getdata()
		End Sub

		' Token: 0x0600C386 RID: 50054 RVA: 0x007C2334 File Offset: 0x007C0534
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

		' Token: 0x0600C387 RID: 50055 RVA: 0x00087110 File Offset: 0x00085310
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

		' Token: 0x0600C388 RID: 50056 RVA: 0x007C244C File Offset: 0x007C064C
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

		' Token: 0x0600C389 RID: 50057 RVA: 0x007C2534 File Offset: 0x007C0734
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
						ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Voucher.VoucherNo), Voucher.Date, RTRIM(Voucher.Name),  RTRIM(Voucher_OtherDetails.Particulars),  (Voucher_OtherDetails.Amount), RTRIM(Voucher_OtherDetails.Note), RTRIM(Voucher_OtherDetails.PModeD) FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.Id = Voucher_OtherDetails.VoucherID where Voucher.Date between @d1 and @d2 and Voucher.VoucherNo='" + Me.TextBox1.Text + "' order by Voucher.Date", ModCommonClasses.con)
						ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
						ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
					Else
						Dim flag3 As Boolean = Me.ComboBox1.SelectedIndex = 1
						If flag3 Then
							ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Voucher.VoucherNo), Voucher.Date, RTRIM(Voucher.Name),  RTRIM(Voucher_OtherDetails.Particulars),  (Voucher_OtherDetails.Amount), RTRIM(Voucher_OtherDetails.Note), RTRIM(Voucher_OtherDetails.PModeD) FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.Id = Voucher_OtherDetails.VoucherID where Voucher.Date between @d1 and @d2 and Voucher.Name='" + Me.TextBox1.Text + "' order by Voucher.Date", ModCommonClasses.con)
							ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
							ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
						Else
							Dim flag4 As Boolean = Me.ComboBox1.SelectedIndex = 2
							If flag4 Then
								ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Voucher.VoucherNo), Voucher.Date, RTRIM(Voucher.Name),  RTRIM(Voucher_OtherDetails.Particulars),  (Voucher_OtherDetails.Amount), RTRIM(Voucher_OtherDetails.Note), RTRIM(Voucher_OtherDetails.PModeD) FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.Id = Voucher_OtherDetails.VoucherID where Voucher.Date between @d1 and @d2 and Voucher_OtherDetails.Particulars='" + Me.TextBox1.Text + "' order by Voucher.Date", ModCommonClasses.con)
								ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
								ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
							Else
								Dim flag5 As Boolean = Me.ComboBox1.SelectedIndex = 3
								If flag5 Then
									ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Voucher.VoucherNo), Voucher.Date, RTRIM(Voucher.Name),  RTRIM(Voucher_OtherDetails.Particulars),  (Voucher_OtherDetails.Amount), RTRIM(Voucher_OtherDetails.Note), RTRIM(Voucher_OtherDetails.PModeD) FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.Id = Voucher_OtherDetails.VoucherID where Voucher.Date between @d1 and @d2 and Voucher_OtherDetails.Note='" + Me.TextBox1.Text + "' order by Voucher.Date", ModCommonClasses.con)
									ModCommonClasses.cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateFrom.Value.[Date]
									ModCommonClasses.cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = Me.dtpDateTo.Value.[Date]
								Else
									Dim flag6 As Boolean = Me.ComboBox1.SelectedIndex = 4
									If flag6 Then
										ModCommonClasses.cmd = New SqlCommand("SELECT RTRIM(Voucher.VoucherNo), Voucher.Date, RTRIM(Voucher.Name),  RTRIM(Voucher_OtherDetails.Particulars),  (Voucher_OtherDetails.Amount), RTRIM(Voucher_OtherDetails.Note), RTRIM(Voucher_OtherDetails.PModeD) FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.Id = Voucher_OtherDetails.VoucherID where Voucher.Date between @d1 and @d2 and Voucher_OtherDetails.PModeD='" + Me.TextBox1.Text + "' order by Voucher.Date", ModCommonClasses.con)
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

		' Token: 0x0600C38A RID: 50058 RVA: 0x000576E7 File Offset: 0x000558E7
		Private Sub Button1_Click(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
			Me.ComboBox1.SelectedIndex = -1
			Me.ComboBox1.Focus()
		End Sub

		' Token: 0x0600C38B RID: 50059 RVA: 0x0005770F File Offset: 0x0005590F
		Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.TextBox1.Clear()
		End Sub

		' Token: 0x0600C38C RID: 50060 RVA: 0x0005771E File Offset: 0x0005591E
		Private Sub GelButton3_Click(sender As Object, e As EventArgs)
			Me.Reset()
			Me.Calculate()
		End Sub

		' Token: 0x0600C38D RID: 50061 RVA: 0x007C2A40 File Offset: 0x007C0C40
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

		' Token: 0x0600C38E RID: 50062 RVA: 0x0005772F File Offset: 0x0005592F
		Private Sub GelButton2_Click(sender As Object, e As EventArgs)
			Me.Getdata()
		End Sub
	End Class
End Namespace
